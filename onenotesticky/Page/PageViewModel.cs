using onenotesticky.nsPage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace onenotesticky {
    /// <summary>
    /// Page class is the note itself
    /// </summary>
    class PageViewModel : ObservableObject {
        #region Members
        private int pageID;
        private Page page;
        private ICommand getPageCommand;
        private ICommand savePageCommand;
        #endregion

        #region Construction
        /// <summary>
        /// Constructs the default instance of a SongViewModel
        /// </summary>
        public PageViewModel()
        {
            this.page = new Page { Title = "Unknown"};
        }
        #endregion

        #region Public Properties/Commands
        public Page Page {
            get { return this.page; }
            set {
                if (value != this.page) {
                    this.page = value;
                    RaisePropertyChanged("Page");
                }
            }
        }

        public int PageID {
            get { return this.pageID; }
            set {
                if (value != this.pageID) {
                    this.pageID = value;
                    RaisePropertyChanged("PageID");
                }
            }
        }
        public String Title {
            get { return Page.Title; }
            set {
                if (value != Page.Title) {
                    Page.Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }


        public ICommand SavePageCommand {
            get {
                if (this.savePageCommand == null) {
                    this.savePageCommand = new RelayCommand(
                        param => SavePage(),
                        param => (Page != null)
                    );
                }
                return this.savePageCommand;
            }
        }

        public ICommand GetPageCommand {
            get {
                if (this.getPageCommand == null) {
                    this.getPageCommand = new RelayCommand(
                        param => GetPage(param)
                    );
                }
                return this.getPageCommand;
            }
        }

        private string pageContent = "\n\r\n\r               LOADING...                  ";
        public string PageContent {
            get { return this.pageContent; }
            set {
                if (value != this.pageContent) {
                    this.pageContent = value;
                    RaisePropertyChanged("PageContent");
                }
            }
        }

        #endregion

        #region Private Helpers

        private void GetPage(object pageID) {
            // You should get the product from the database
            // but for now we'll just return a new object
            ////PageModel s = new PageModel();
            ////s.PageID = PageID;
            ////s.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vitae ante in nulla interdum tristique. Duis commodo feugiat purus, id bibendum arcu egestas eu. Donec orci leo, vestibulum at magna hendrerit, lobortis iaculis augue. Proin dapibus ultricies ornare. Sed imperdiet justo sit amet ligula eleifend ornare. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae pellentesque tortor. Etiam egestas vel augue non iaculis. Suspendisse dignissim arcu faucibus diam tincidunt, id lobortis mi vulputate. Nullam sagittis lorem eu leo consequat rhoncus. ";
            ////Page = s;
            //PageService.getPageContent()
            System.Diagnostics.Debug.WriteLine("dl click");
            PageService.getPageContent(pageID.ToString(), (pgContent) => {
                this.PageContent = pgContent ;
                Application.Current.Dispatcher.Invoke((Action)(() => {
                    showNote();
                }));
                
                
                System.Diagnostics.Debug.WriteLine("content received");
            });
        }

        private void showNote(){
            StickyNote note = new StickyNote() { DataContext = this };
            //System.Windows.Documents.FlowDocument doc = new System.Windows.Documents.FlowDocument();
            //doc.Blocks.Add((System.Windows.Documents.Block)MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(this.pageContent, true));
            note.notecontent.Document = XamlReader.Parse(MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(this.pageContent, true)) as FlowDocument;
            note.ShowInTaskbar = false;
            System.Diagnostics.Debug.WriteLine(MarkupConverter.HtmlToXamlConverter.ConvertHtmlToXaml(this.pageContent, true));
            note.Show();
        }



        private void SavePage() {
            // You would implement your Product save here
        }

        #endregion
    }
}
