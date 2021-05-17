namespace DemoTemplates
{
    public class MainWindowViewModel
    {

        public MainWindowViewModel()
        {
            this.IsCheckedProperty = true;
            this.TextProperty = "Hello World";
        }

        public bool IsCheckedProperty { get; private set; }
        public string TextProperty { get; set; }

    }
}

