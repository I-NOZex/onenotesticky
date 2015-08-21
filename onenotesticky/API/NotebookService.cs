using onenotesticky.nsNotebook;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onenotesticky;
using onenotesticky.nsSection;

namespace onenotesticky {
    public static class NotebookService {
        /// <summary>
        /// Get Notebooks
        /// </summary>
        /// <param name="onFinish">Action to be performed after data received</param>
        public static void getNotebooks(Action<NotebookModel> onFinish) {
            OnenoteAuth.whenLoggedIn(() =>{ 
                var client = new RestClient("https://www.onenote.com/api/v1.0");
                RestRequest request = new RestRequest("notebooks", Method.GET);
                request.AddParameter("Authorization", "Bearer " + OnenoteAuth.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method
                //async with deserialization
                var asyncHandle = client.ExecuteAsync<NotebookModel>(request, response => {
                    onFinish(response.Data);
                });
            });
        }

        public static void getNotebookSections(string notebookID, Action<SectionModel> callback) {
            OnenoteAuth.whenLoggedIn(() => {
                var client = new RestClient("https://www.onenote.com/api/v1.0");
                RestRequest request = new RestRequest(string.Format("notebooks/{0}/sections", notebookID), Method.GET);
                request.AddParameter("Authorization", "Bearer " + OnenoteAuth.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method
                //async with deserialization
                var asyncHandle = client.ExecuteAsync<SectionModel>(request, response => callback(response.Data));
            });
        }
    }
}
