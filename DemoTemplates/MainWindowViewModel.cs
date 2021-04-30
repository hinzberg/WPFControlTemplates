using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTemplates
{
    public class MainWindowViewModel
    {

        public MainWindowViewModel()
        {
            this.IsCheckedProperty = true;
        }

        public bool IsCheckedProperty { get; private set; }

    }
}

