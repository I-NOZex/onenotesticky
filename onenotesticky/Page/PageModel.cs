using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onenotesticky.nsPage {
    /// <summary>
    /// Page class is the note itself
    /// </summary>
    /// 

    public class PageModel : ObservableObject {
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

        private List<Page> pages;
        [DeserializeAs(Name = "value")]
        public List<Page> Pages {
            get { return pages; }
            set {
                if (value != this.pages) {
                    this.pages = value;
                }
            }
        }
        public string odatanextLink;
    }

    public class Page : ObservableObject {

        private string title;
        public string Title {
            get { return title; }
            set { title = value; }
        }

        private string createdByAppId;
        public string CreatedByAppId {
            get { return createdByAppId; }
            set { createdByAppId = value; }
        }

        private Links links;
        public Links Links {
            get { return links; }
            set { links = value; }
        }

        private string contentUrl;
        public string ContentUrl {
            get { return contentUrl; }
            set { contentUrl = value; }
        }

        private object thumbnailUrl;
        public object ThumbnailUrl {
            get { return thumbnailUrl; }
            set { thumbnailUrl = value; }
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
    }

    public class Links : ObservableObject {
        private Onenoteclienturl oneNoteClientUrl;
        public Onenoteclienturl OneNoteClientUrl {
            get { return oneNoteClientUrl; }
            set { oneNoteClientUrl = value; }
        }

        private Onenoteweburl oneNoteWebUrl;
        public Onenoteweburl OneNoteWebUrl {
            get { return oneNoteWebUrl; }
            set { oneNoteWebUrl = value; }
        }
    }

    public class Onenoteclienturl : ObservableObject {
        private string href;
        public string Href {
            get { return href; }
            set { href = value; }
        }
    }

    public class Onenoteweburl : ObservableObject {
        private string href;
        public string Href {
            get { return href; }
            set { href = value; }
        }
    }
}
