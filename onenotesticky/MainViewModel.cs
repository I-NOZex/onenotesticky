using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Web.Script.Serialization;
using onenotesticky.nsNotebook;
using System.IO;
using onenotesticky.nsPage;
using RestSharp;
using LiveConnectLib;
using System.Windows.Threading;
using System.Threading;
using onenotesticky.nsSection;

namespace onenotesticky {
    class MainViewModel : ObservableObject {

        private string loadingOverlay;
        public string LoadingOverlay { 
            get {
                return this.loadingOverlay;
            }
            set {
                if (value != this.loadingOverlay) {
                    this.loadingOverlay = value;
                    RaisePropertyChanged("LoadingOverlay");
                }
            }
        }

        private AsyncObservableCollection<NotebookViewModel> notebooks = new AsyncObservableCollection<NotebookViewModel>();

        public AsyncObservableCollection<NotebookViewModel> Notebooks {
            get {
                return this.notebooks;
            }
            set {
                if (value != this.notebooks) {
                    this.notebooks = value;
                    RaisePropertyChanged("Notebooks");
                }
            }
        }


        public MainViewModel() {

            NotebookService.getNotebooks((notebookModel) => {
                LoadingOverlay = "Visible";
                foreach (Notebook nb in notebookModel.Notebooks) {
                    NotebookViewModel notebookVM = new NotebookViewModel();
                    notebookVM.Notebook = nb;
                    /////////////////////////////
                        NotebookService.getNotebookSections(nb.Id, (sectionModel) => {
                            foreach (Section s in sectionModel.Sections) {
                                SectionViewModel sectionVM = new SectionViewModel();
                                sectionVM.Section = s;
                                /////////////////////////////
                                    SectionService.getSectionPages(s.Id, (pageModel) => {
                                        foreach (Page pg in pageModel.Pages) {
                                            PageViewModel pageVM = new PageViewModel();
                                            pageVM.Page = pg;
                                            sectionVM.Pages.Add(pageVM);
                                        }
                                        
                                    });   
                                /////////////////////////////
                                notebookVM.Sections.Add(sectionVM);
                            }
                        });                    
                    /////////////////////////////
                    this.Notebooks.Add(notebookVM);    
                }
                LoadingOverlay = "Hidden";
                System.Diagnostics.Debug.WriteLine("All data received");
            });
        }

        //public void fillNotebook(NotebookModel nb) {

        //    //var nbvm = new NotebookViewModel();
        //    //nbvm.Notebooks = nb;
        //    //this.Notebooks.Add(nbvm);
        //    foreach (Notebook n in nb.Notebooks) {
        //        NotebookViewModel nbvm = new NotebookViewModel();
        //        nbvm.Notebook = n;
        //        fillSections(n.Id, nbvm);
        //        this.Notebooks.Add(nbvm);
        //    }

        //    //foreach (var nbx in this.Notebooks) {
        //    //    nbx.Notebook.Name += "looool";
        //    //}

        //}

        //public void fillSections(string nbId,NotebookViewModel nb) {
        //    System.Diagnostics.Debug.WriteLine("get sections--------------");
        //    var client = new RestClient("https://www.onenote.com/api/v1.0");
        //    RestRequest request = new RestRequest(string.Format("notebooks/{0}/sections",nbId), Method.GET);
        //    request.AddParameter("Authorization", "Bearer " + liveConnect.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method

        //    IRestResponse<SectionModel> response = client.Execute<SectionModel>(request);
        //    System.Diagnostics.Debug.WriteLine(response.ErrorMessage);
        //    foreach (Section s in response.Data.Sections) {
        //        SectionViewModel svm = new SectionViewModel();
        //        svm.Section = s;
        //        nb.Sections.Add(svm);
        //        fillPages(s.Id, svm);
        //    }
        //}

        //public void fillPages(string sId, SectionViewModel s) {
        //    System.Diagnostics.Debug.WriteLine("get sections--------------");
        //    var client = new RestClient("https://www.onenote.com/api/v1.0");
        //    RestRequest request = new RestRequest(string.Format("sections/{0}/pages", sId), Method.GET);
        //    request.AddParameter("Authorization", "Bearer " + liveConnect.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method

        //    IRestResponse<PageModel> response = client.Execute<PageModel>(request);
        //    System.Diagnostics.Debug.WriteLine(response.ErrorMessage);
        //    foreach (Page p in response.Data.Pages) {
        //        PageViewModel pvm = new PageViewModel();
        //        pvm.Page = p;
        //        s.Pages.Add(pvm);
        //    }
        //}

    }
}
