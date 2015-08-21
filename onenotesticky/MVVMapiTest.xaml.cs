using LiveConnectLib;
using onenotesticky.nsNotebook;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace onenotesticky {
    /// <summary>
    /// Interaction logic for MVVMapiTest.xaml
    /// </summary>
    public partial class MVVMapiTest : Window {
        public MVVMapiTest() {
            InitializeComponent();

            this.DataContext = new MainViewModel();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            App.Current.Shutdown();
        }
    }
}
