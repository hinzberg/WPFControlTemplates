using System.Windows;

namespace DemoTemplates
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowRepository repository = new MainWindowRepository();

            this.DataContext = repository;
        }
    }
}
