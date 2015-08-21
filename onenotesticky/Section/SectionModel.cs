using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onenotesticky.nsSection {

    public class SectionModel : ObservableObject {
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

        private List<Section> sections;
        [DeserializeAs(Name = "value")]
        public List<Section> Sections {
            get { return sections; }
            set {
                if (value != this.sections) {
                    this.sections = value;
                }
            }
        }
    }

    public class Section : ObservableObject {
        private bool isDefault;
        public bool IsDefault {
            get { return isDefault; }
            set { isDefault = value; }
        }

        private string pagesUrl;
        public string PagesUrl {
            get { return pagesUrl; }
            set { pagesUrl = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string createdBy;
        public string CreatedBy {
            get { return createdBy; }
            set { createdBy = value; }
        }

        private string lastModifiedBy;
        public string LastModifiedBy {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        private DateTime lastModifiedTime;
        public DateTime LastModifiedTime {
            get { return lastModifiedTime; }
            set { lastModifiedTime = value; }
        }

        private string id;
        public string Id {
            get { return id; }
            set { id = value; }
        }

        private string self;
        public string Self {
            get { return self; }
            set { self = value; }
        }

        private DateTime createdTime;
        public DateTime CreatedTime {
            get { return createdTime; }
            set { createdTime = value; }
        }

        private string parentSectionGroupodatacontext;
        public string ParentSectionGroupodatacontext {
            get { return parentSectionGroupodatacontext; }
            set { parentSectionGroupodatacontext = value; }
        }

        private object parentSectionGroup;
        public object ParentSectionGroup {
            get { return parentSectionGroup; }
            set { parentSectionGroup = value; }
        }

        private string parentNotebookodatacontext;
        public string ParentNotebookodatacontext {
            get { return parentNotebookodatacontext; }
            set { parentNotebookodatacontext = value; }
        }

        private Parentnotebook parentNotebook;
        public Parentnotebook ParentNotebook {
            get { return parentNotebook; }
            set { parentNotebook = value; }
        }
    }

    public class Parentnotebook : ObservableObject {
        private string id;
        public string Id {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }


        private string self;
        public string Self {
            get { return self; }
            set { self = value; }
        }
    }

}
