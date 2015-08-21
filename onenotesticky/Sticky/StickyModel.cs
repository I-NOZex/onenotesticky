using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onenotesticky {
    class StickyModel : ObservableObject {
        #region Fields
        private int stickyID;
        private String title;
        private String content;

        public int StickyID {
            get { return this.stickyID; }
            set {
                if (value != this.stickyID) {
                    this.stickyID = value;
                    OnPropertyChanged("StickyID");
                }
            }
        }
        public String Title {
            get { return this.title; }
            set {
                if (value != this.title) {
                    this.title = value;
                    OnPropertyChanged("Title");
                }
            }        
        }
        public String Content {
            get { return this.content; }
            set {
                if (value != this.content) {
                    this.content = value;
                    OnPropertyChanged("Content");
                }
            }          
        }
        #endregion // Fields

        #region Properties
        #endregion // Properties
    }
}
