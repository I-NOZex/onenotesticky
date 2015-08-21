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
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e) {
            App.Current.Shutdown();
        }

        private void sectionsList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        //    SectionViewModel section = (SectionViewModel)sectionsList.SelectedItem;

        //    System.Diagnostics.Debug.WriteLine("dl click");
        //    foreach (var pg in section.Pages) {
        //        PageService.getPageContent(pg.Page.Id, (pgContent) => {
        //            pg.PageContent = pgContent;
        //            Application.Current.Dispatcher.Invoke((Action)(() => {
        //                showNote(pg.PageContent);
        //            }));
                
                
        //            System.Diagnostics.Debug.WriteLine("content received");
        //        });		 
        //    }

        //}

        //private void showNote(string pc) {
        //    StickyNote note = new StickyNote() { DataContext = this };
        //    //System.Windows.Documents.FlowDocument doc = new System.Windows.Documents.FlowDocument();
        //    //doc.Blocks.Add((System.Windows.Documents.Block)MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(this.pageContent, true));
        //    note.notecontent.Document = XamlReader.Parse(MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(pc, true)) as FlowDocument;

        //    System.Diagnostics.Debug.WriteLine(MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(pc, true));
        //    note.Show();
        }
    }
}
