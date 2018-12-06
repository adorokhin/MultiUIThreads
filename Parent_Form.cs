using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Drawing;
using System.Diagnostics;

namespace MultiUIThread
{
    public partial class Parent_Form : Form
    {
        const int CYCLES = 10;

        [ThreadStatic] static int batch = 0;
        CancellationTokenSource cancelSource;
        List<Task> tasks = new List<Task>();

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

                int i;
                for (i = 1; i <= 5; i++)
                {
                    int jj = i;
                    
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Debug.WriteLine($"<Window Task> {Task.CurrentId} started.");

                        //if(Debugger.IsAttached)
                        //    Debugger.Break();

                        int localBatchNo = batch;
                        Child_Form w = new Child_Form();
                        w.Show();
                        w.Location = new Point(jj * w.Width + 20, localBatchNo * w.Height + 20);

                        w.BackColor = (new Func<Color>(() => {
                            Random randomGen = new Random(jj);
                            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                            KnownColor randomColorName = names[randomGen.Next(names.Length)];
                            return Color.FromKnownColor(randomColorName);
                        })).Invoke();

                        w.Shown += (s1, e1) =>
                        {
                            var t = Task.Factory.StartNew(() =>
                            {
                                Debug.WriteLine($"<Batch Task> {Task.CurrentId} started.");
                                for (int ii = 0; ii < CYCLES; ii++)
                                {
                                    if (token.IsCancellationRequested)
                                        break;
                                    w.labelBatch.SetProperty2(() => w.labelBatch.Text, $"{localBatchNo}");
                                    w.labelTask.SetProperty2(() => w.labelBatch.Text, $"{jj}");
                                    w.labelCycle.SetProperty2(() => w.labelBatch.Text, $"{(ii+1)}/{CYCLES}");
                                    Thread.Sleep(1000);
                                }
                                w.Invoke((MethodInvoker)(()=>{ try { w.Close(); } catch (Exception) { }}));
                            }).ContinueWith((tt) => { Debug.WriteLine($"<Batch Task> {tt.Id} being continued with absolutely nothing."); });
                        };

                        w.Closed += (sender2, e2) => Dispatcher.CurrentDispatcher.InvokeShutdown();
                        //Dispatcher.Run();
                    }
                    , token   //, CancellationToken.None
                    , TaskCreationOptions.None
                    , TaskScheduler.FromCurrentSynchronizationContext()
                    )
                    .ContinueWith((t) => {
                        Debug.WriteLine($"<Window Task> {t.Id} being continued with absolutely nothing.");
                        tasks.Remove(t);
                    }));
                }
                
                //Task.WaitAll(tasks.ToArray());

                //while(tasks.Count > 0)
                //    tasks.Remove(tasks[Task.WaitAny(tasks.ToArray())]);
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
            batch=0;
            cancelSource.Cancel(); // Safely cancel worker.
            buttonKillThemAll.Enabled = false;
        }
    }
}
