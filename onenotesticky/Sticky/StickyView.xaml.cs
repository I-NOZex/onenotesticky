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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net.Http;
using System.Net.Http.Headers;


namespace onenotesticky {
    /// <summary>
    /// Interaction logic for StickyView.xaml
    /// </summary>
    public partial class StickyView : Window {
        public StickyView() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            StickyView form2 = new StickyView();
            form2.Title = Microsoft.VisualBasic.Interaction.InputBox("Titulo da Nota");
            form2.ShowInTaskbar = false;
            form2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btn_menu_Click(object sender, RoutedEventArgs e) {
            ContextMenu cm = this.FindResource("ctxmenu_options") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            cm.IsOpen = true;
        }
    }
}
