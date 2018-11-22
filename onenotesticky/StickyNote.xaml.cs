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
using System.Diagnostics;


namespace onenotesticky {
    /// <summary>
    /// Interaction logic for StickyNote.xaml
    /// </summary>
    public partial class StickyNote : Window {
        public StickyNote() {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            StickyNote form2 = new StickyNote();
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

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.LeftCtrl || e.Key == Key.RightCtrl) {
                txt_noteContent.IsDocumentEnabled = true;
                txt_noteContent.IsReadOnly = true;
                txt_noteContent.AddHandler(Hyperlink.RequestNavigateEvent, new RequestNavigateEventHandler(RequestNavigateHandler));
            }
        }

        private void RequestNavigateHandler(object sender, RequestNavigateEventArgs e) {
            disableHyperlinks();
            Process.Start(e.Uri.ToString());      
            e.Handled = true;
        }

        private void disableHyperlinks() {
            txt_noteContent.IsDocumentEnabled = false;
            txt_noteContent.IsReadOnly = false;   
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            disableHyperlinks();
        }

    }
}
