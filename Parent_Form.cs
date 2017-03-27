using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Drawing;

namespace MultiUIThread
{
    public partial class Parent_Form : Form
    {

        [ThreadStatic] static int batch = 0;
        CancellationTokenSource cancelSource;

        public Parent_Form()
        {
            cancelSource = new CancellationTokenSource();
            InitializeComponent();
        }

        private void buttonSpawn_Click(object sender, EventArgs e)
        {
            try
            {
                if(cancelSource.IsCancellationRequested)
                    cancelSource = new CancellationTokenSource();

                var token = cancelSource.Token;
                
                buttonKillThemAll.Enabled = true;
                batch++;

                var tasks = new List<Task>();
                int i;
                for (i = 1; i < 5; i++)
                {
                    int jj = i;
                    
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        int localBatchNo = batch;
                        Child_Form w = new Child_Form();
                        w.Show();

                        Func<Color> fc = (() =>
                        {
                            Random randomGen = new Random(jj);
                            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                            KnownColor randomColorName = names[randomGen.Next(names.Length)];
                            return Color.FromKnownColor(randomColorName);
                        });
                        w.BackColor = (fc.Invoke());

                        const int CYCLES = 100;
                        w.Shown += (s1, e1) =>
                        {
                            var t = Task.Factory.StartNew(() =>
                            {
                                for (int ii = 0; ii < CYCLES; ii++)
                                {
                                    if (token.IsCancellationRequested)
                                        break;
                                    w.labelBatch.SetProperty2(() => w.labelBatch.Text, $"{localBatchNo}");
                                    w.labelTask.SetProperty2(() => w.labelBatch.Text, $"{jj}");
                                    w.labelCycle.SetProperty2(() => w.labelBatch.Text, $"{(ii+1)}/{CYCLES}");
                                    Thread.Sleep(1000);
                                }
                                w.Invoke((MethodInvoker)(()=>{w.Close();}));
                            });
                        };

                        w.Closed += (sender2, e2) => Dispatcher.CurrentDispatcher.InvokeShutdown();
                        //Dispatcher.Run();
                    }
                    , token   //, CancellationToken.None
                    , TaskCreationOptions.None
                    , TaskScheduler.FromCurrentSynchronizationContext()
                    ));
                }
                //Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    throw ex.InnerException;
                }
            }
        }

        private void buttonKillThemAll_Click(object sender, EventArgs e)
        {
            cancelSource.Cancel(); // Safely cancel worker.
            buttonKillThemAll.Enabled = false;
        }
    }
}
