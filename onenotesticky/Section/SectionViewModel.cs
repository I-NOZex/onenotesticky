using onenotesticky.nsPage;
using onenotesticky.nsSection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onenotesticky {
    /// <summary>
    /// Section class is the collection of pages (aka notes)
    /// </summary>
    class SectionViewModel : ObservableObject {
        #region Members
        private int sectionID;
        private PageModel currentSection;
        AsyncObservableCollection<PageViewModel> pages = new AsyncObservableCollection<PageViewModel>();
        private ICommand getPagesCommand;
        private ICommand savePagesCommand;
        #endregion

        private Section section;
        public Section Section {
            get { return this.section; }
            set {
                if (value != this.section) {
                    this.section = value;
                    RaisePropertyChanged("Section");
                }
            }
        }

        #region Public Properties
        public AsyncObservableCollection<PageViewModel> Pages {
            get {
                return this.pages;
            }
            set {
                this.pages = value;
            }
        }

        public PageModel CurrentSection {
            get { return this.currentSection; }
            set {
                if (value != this.currentSection) {
                    this.currentSection = value;
                    //RaisePropertyChanged("CurrentSection");
                }
            }
        }

        public int SectionID {
            get { return this.sectionID; }
            set {
                if (value != this.sectionID) {
                    this.sectionID = value;
                    //OnPropertyChanged("SectionID");
                }
            }
        }

        private int name;
        public int Name {
            get { return this.name; }
            set {
                if (value != this.name) {
                    this.name = value;
                    //OnPropertyChanged("SectionID");
                }
            }
        }
        #endregion

        #region Constructor
        public SectionViewModel() {

            for (int i = 0; i < 5; i++) {
                //this.pages.Add(new PageViewModel { Page = new Page { Title = "p" + (pages.Count) } });
            }
        }
        #endregion

        #region Public Commands
        public ICommand SavePagesCommand {
            get {
                if (this.savePagesCommand == null) {
                    this.savePagesCommand = new RelayCommand(
                        param => SavePages(),
                        param => (currentSection != null)
                    );
                }
                return this.savePagesCommand;
            }
        }

        public ICommand GetPagesCommand {
            get {
                if (this.getPagesCommand == null) {
                    this.getPagesCommand = new RelayCommand(
                        param => GetPages(),
                        param => sectionID > 0
                    );
                }
                return this.getPagesCommand;
            }
        }
        #endregion


bool CanUpdateSongTitlesExecute() {
    return true;
}

public ICommand UpdateTitles { get { return new RelayCommand(UpdateSongTitlesExecute, CanUpdateSongTitlesExecute); } }

private bool CanUpdateSongTitlesExecute(object obj) {
    return true;
}

private void UpdateSongTitlesExecute(object obj) {
    if (this.pages == null)
        return;

    //++_count;
    foreach (var page in this.pages) {
        page.Title += "looool";
    }
}


        #region Private Helpers
        private void GetPages() {
            // You should get the product from the database
            // but for now we'll just return a new object
            ////PageModel s = new PageModel();
            ////s.PageID = PageID;
            ////s.Title = "Test Product";
            ////s.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vitae ante in nulla interdum tristique. Duis commodo feugiat purus, id bibendum arcu egestas eu. Donec orci leo, vestibulum at magna hendrerit, lobortis iaculis augue. Proin dapibus ultricies ornare. Sed imperdiet justo sit amet ligula eleifend ornare. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae pellentesque tortor. Etiam egestas vel augue non iaculis. Suspendisse dignissim arcu faucibus diam tincidunt, id lobortis mi vulputate. Nullam sagittis lorem eu leo consequat rhoncus. ";
            ////CurrentPage = s;
        }

        private void SavePages() {
            // You would implement your Product save here
        }
        #endregion

    }
}
