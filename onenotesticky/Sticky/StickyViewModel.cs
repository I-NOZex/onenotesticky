using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace onenotesticky {
    class StickyViewModel : ObservableObject {
        #region Fields

        private int stickyID;
        private StickyModel currentSticky;
        private ICommand getStickyCommand;
        private ICommand saveStickyCommand;

        #endregion

        #region Public Properties/Commands

        public StickyModel CurrentSticky {
            get { return currentSticky; }
            set {
                if (value != currentSticky) {
                    currentSticky = value;
                    OnPropertyChanged("CurrentSticky");
                }
            }
        }

        public ICommand SaveStickyCommand {
            get {
                if (saveStickyCommand == null) {
                    saveStickyCommand = new RelayCommand(
                        param => SaveSticky(),
                        param => (CurrentSticky != null)
                    );
                }
                return SaveStickyCommand;
            }
        }

        public ICommand GetStickyCommand {
            get {
                if (getStickyCommand == null) {
                    getStickyCommand = new RelayCommand(
                        param => GetSticky(),
                        param => StickyID > 0
                    );
                }
                return getStickyCommand;
            }
        }

        public int StickyID {
            get { return stickyID; }
            set {
                if (value != stickyID) {
                    stickyID = value;
                    OnPropertyChanged("StickyID");
                }
            }
        }

        #endregion

        #region Private Helpers

        private void GetSticky() {
            // You should get the product from the database
            // but for now we'll just return a new object
            StickyModel p = new StickyModel();
            p.StickyID = 1;
            p.Title = "Test Product";
            p.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vitae ante in nulla interdum tristique. Duis commodo feugiat purus, id bibendum arcu egestas eu. Donec orci leo, vestibulum at magna hendrerit, lobortis iaculis augue. Proin dapibus ultricies ornare. Sed imperdiet justo sit amet ligula eleifend ornare. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae pellentesque tortor. Etiam egestas vel augue non iaculis. Suspendisse dignissim arcu faucibus diam tincidunt, id lobortis mi vulputate. Nullam sagittis lorem eu leo consequat rhoncus. ";
        }

        private void SaveSticky() {
            // You would implement your Product save here
        }

        #endregion
    }
}
