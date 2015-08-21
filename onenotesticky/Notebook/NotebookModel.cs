using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onenotesticky.nsNotebook {

    /// <summary>
    /// Notebook class is the collection of sections
    /// </summary>

    public class NotebookModel : ObservableObject {
        private string odatacontext;
        [DeserializeAs(Name = "@odata.context")]
        public string Odatacontext {
            get { return this.odatacontext; }
            set {
                if (value != this.odatacontext) {
                    this.odatacontext = value;
                }
            }
        }

        private List<Notebook> notebooks;
        [DeserializeAs(Name = "value")]
        public List<Notebook> Notebooks {
            get { return notebooks; }
            set {
                if (value != this.notebooks) {
                    this.notebooks = value;
                    RaisePropertyChanged("Notebooks");
                }
            }
        }
    }

    public class Notebook : ObservableObject {
        private bool isDefault;
        public bool IsDefault {
            get { return isDefault; }
            set {
                if (value != this.isDefault) {
                    this.isDefault = value;
                }
            }
        }
        private string userRole;
        public string UserRole {
            get { return userRole; }
            set {
                if (value != this.userRole) {
                    this.userRole = value;
                }
            }
        }
        private bool isShared;
        public bool IsShared {
            get { return isShared; }
            set {
                if (value != this.isShared) {
                    this.isShared = value;
                }
            }
        }
        private string sectionsUrl;
        public string SectionsUrl {
            get { return sectionsUrl; }
            set {
                if (value != this.sectionsUrl) {
                    this.sectionsUrl = value;
                }
            }
        }
        private string sectionGroupsUrl;
        public string SectionGroupsUrl {
            get { return sectionGroupsUrl; }
            set {
                if (value != this.sectionGroupsUrl) {
                    this.sectionGroupsUrl = value;
                }
            }
        }
        private Links links;
        public Links Links {
            get { return links; }
            set {
                if (value != this.links) {
                    this.links = value;
                }
            }
        }
        private string name;
        public string Name {
            get { return name; }
            set {
                if (value != this.name) {
                    this.name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        private string createdBy;
        public string CreatedBy {
            get { return createdBy; }
            set {
                if (value != this.createdBy) {
                    this.createdBy = value;
                }
            }
        }
        private string lastModifiedBy;
        public string LastModifiedBy {
            get { return lastModifiedBy; }
            set {
                if (value != this.lastModifiedBy) {
                    this.lastModifiedBy = value;
                }
            }
        }
        private DateTime lastModifiedTime;
        public DateTime LastModifiedTime {
            get { return lastModifiedTime; }
            set {
                if (value != this.lastModifiedTime) {
                    this.lastModifiedTime = value;
                }
            }
        }
        private string id;
        public string Id {
            get { return id; }
            set {
                if (value != this.id) {
                    this.id = value;
                }
            }
        }
        private string self;
        public string Self{
            get { return self; }
            set {
                if (value != this.self) {
                    this.self = value;
                }
            }
        }
        private DateTime createdTime;
        public DateTime CreatedTime {
            get { return createdTime; }
            set {
                if (value != this.createdTime) {
                    this.createdTime = value;
                }
            }
        }
    }

    public class Links : ObservableObject {
        private Onenoteclienturl oneNoteClientUrl;
        public Onenoteclienturl OneNoteClientUrl {
            get { return oneNoteClientUrl; }
            set {
                if (value != this.oneNoteClientUrl) {
                    this.oneNoteClientUrl = value;
                }
            }
        }
        private Onenoteweburl oneNoteWebUrl;
        public Onenoteweburl OneNoteWebUrl {
            get { return oneNoteWebUrl; }
            set {
                if (value != this.oneNoteWebUrl) {
                    this.oneNoteWebUrl = value;
                }
            }
        }
    }

    public class Onenoteclienturl : ObservableObject {
        private string href;
        public string Href {
            get { return href; }
            set {
                if (value != this.href) {
                    this.href = value;
                }
            }
        }
    }

    public class Onenoteweburl : ObservableObject {
        private string href;
        public string Href {
            get { return href; }
            set {
                if (value != this.href) {
                    this.href = value;
                }
            }
        }
    }
}
