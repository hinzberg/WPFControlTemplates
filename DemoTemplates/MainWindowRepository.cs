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
            ComboBoxItems.Add("London");
            ComboBoxItems.Add("Paris");
            ComboBoxItems.Add("New York");
            ComboBoxItems.Add("Berlin");
            ComboBoxItems.Add("Tokyo");
            ComboBoxItems.Add("Rom");
            ComboBoxItems.Add("Amsterdam");

            Thread ProgressBarFillingThread = new Thread(this.FillProgressBar);
            ProgressBarFillingThread.IsBackground = true;//Info beim schließen des fenster stoppt die property den thread!
            ProgressBarFillingThread.Start();

            this.ControlsEnabled = true;

        }
        public List<string> ComboBoxItems { get; set; }

        public ObservableCollection<MainWindowViewModel> ViewModelCollection { get; set; }

        public bool ControlsEnabled
        {
            get => base.GetProperty<bool>(nameof(ControlsEnabled));
            set
            {
                base.SetProperty(nameof(ControlsEnabled), value);
            }
        }


        public double ProgressBarValue
        {
            get => base.GetProperty<double>(nameof(ProgressBarValue));
            set
            {
                base.SetProperty(nameof(ProgressBarValue), value);
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
