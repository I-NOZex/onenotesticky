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
        AsyncObservableCollection<PageViewModel> pages = new AsyncObservableCollection<PageViewModel>();
        public AsyncObservableCollection<PageViewModel> Pages {
            get {
                return this.pages;
            }
            set {
                this.pages = value;
                RaisePropertyChanged("Pages");
            }
        }

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
        #endregion

        #region Constructor
        public SectionViewModel() {
        }
        #endregion
    }
}
