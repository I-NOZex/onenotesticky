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
using MarkupConverter;

namespace onenotesticky {
    /// <summary>
    /// Page class is the note itself
    /// </summary>
    class PageViewModel : ObservableObject {
        #region Members
        private ICommand getPageCommand;
        private ICommand savePageCommand;

        private Page page = new Page();
        public Page Page {
            get { return this.page; }
            set {
                if (value != this.page) {
                    this.page = value;
                    RaisePropertyChanged("Page");
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

        private string pageContent = "\n\r\n\r               LOADING...";
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

        #region Construction
        public PageViewModel() {
        }
        #endregion

        #region Commands
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
        #endregion

        #region Private Helpers

        private void GetPage(object pageID) {
            System.Diagnostics.Debug.WriteLine("cb item click");
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
            note.txt_noteContent.Document = 
                XamlReader.Parse(
                    HtmlToXamlConverter.ConvertHtmlToXaml(this.pageContent, true)
                ) as FlowDocument;

            note.ShowInTaskbar = false;
            note.Show();
        }



        private void SavePage() {
        }
        #endregion
    }
}
