using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using onenotesticky.nsNotebook;

namespace onenotesticky {
    /// <summary>
    /// Page class is the note itself
    /// </summary>
    class NotebookViewModel : ObservableObject {
        #region Members
        private Notebook notebook;
        public Notebook Notebook {
            get { return this.notebook; }
            set {
                if (value != this.notebook) {
                    this.notebook = value;
                    RaisePropertyChanged("Notebook");
                }
            }
        }

        private NotebookModel notebooks;
        public NotebookModel Notebooks {
            get { return this.notebooks; }
            set {
                if (value != this.notebooks) {
                    this.notebooks = value;
                    RaisePropertyChanged("Notebooks");
                }
            }
        }

        AsyncObservableCollection<SectionViewModel> sections = new AsyncObservableCollection<SectionViewModel>();
        public AsyncObservableCollection<SectionViewModel> Sections {
            get {
                return this.sections;
            }
            set {
                this.sections = value;
                RaisePropertyChanged("Sections");
            }
        }
        #endregion

        #region Constructor
        public NotebookViewModel(){

        }
        #endregion
    }
}
