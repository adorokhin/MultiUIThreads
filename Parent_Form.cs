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
        public Parent_Form()
        {
            InitializeComponent();
        }

        private void buttonSpawn_Click(object sender, EventArgs e)
        {
            try
            {
                var tasks = new List<Task>();
                for (int i = 1; i < 10; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() =>
                    {
                        Child_Form w = new Child_Form();
                        w.Show();
                        System.Func<Color> fc = (() =>
                        {
                            Random randomGen = new Random();
                            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                            KnownColor randomColorName = names[randomGen.Next(names.Length)];
                            return Color.FromKnownColor(randomColorName);
                        });
                        w.BackColor = (fc.Invoke());
                        w.Closed += (sender2, e2) => Dispatcher.CurrentDispatcher.InvokeShutdown();
                        Dispatcher.Run();
                    }
                        , CancellationToken.None
                        , TaskCreationOptions.None
                        , TaskScheduler.FromCurrentSynchronizationContext()
                    ));
                }
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    throw ex.InnerException;
                }
            }
        }
    }
}
