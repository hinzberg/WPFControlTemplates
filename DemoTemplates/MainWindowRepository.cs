using KleinesRpgSpiel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoTemplates
{
    public class MainWindowRepository : ViewModelBase
    {
        public const double PROGRESS_BAR_MAX = 100;
        public const double PROGRESS_BAR_MIN = 0;
        public MainWindowRepository()
        {
            this.ViewModelCollection = new ObservableCollection<MainWindowViewModel>();

            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());
            this.ViewModelCollection.Add(new MainWindowViewModel());

            this.ComboBoxItems = new List<string>();
            ComboBoxItems.Add("c");
            ComboBoxItems.Add("b");
            ComboBoxItems.Add("a5 ist ein guter VALUE");
            ComboBoxItems.Add("a4");
            ComboBoxItems.Add("a3");
            ComboBoxItems.Add("a2");
            ComboBoxItems.Add("a1");

            Thread ProgressBarFillingThread = new Thread(this.FillProgressBar);
            ProgressBarFillingThread.IsBackground = true;//Info beim schließen des fenster stoppt die property den thread!
            ProgressBarFillingThread.Start();

        }
        public List<string> ComboBoxItems { get; set; }

        public ObservableCollection<MainWindowViewModel> ViewModelCollection { get; set; }

        private double _ProgressBarValue;

        public double ProgressBarValue
        {
            private set
            {
                this._ProgressBarValue = value;
                base.OnPropertyChanged(nameof(this.ProgressBarValue));
            }

            get
            {
                return
                  this._ProgressBarValue;
            }
        }

        /// <summary>
        /// Füllt die ProgressBar immer bis zum Max und setzt sie dann auf 0 bzw die entsprechende konstante
        /// </summary>
        private void FillProgressBar()
        {
            do
            {
                this.ProgressBarValue += 1;
                Thread.Sleep(100);

                if (this.ProgressBarValue >= PROGRESS_BAR_MAX)
                {
                    Thread.Sleep(1000);
                    this.ProgressBarValue = PROGRESS_BAR_MIN;
                }
            }
            while (true);

        }

    }
}
