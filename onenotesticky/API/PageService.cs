using onenotesticky.nsNotebook;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onenotesticky;
using onenotesticky.nsPage;

namespace onenotesticky {
    public static class PageService {

        public static void getPageContent(string pageID, Action<string> onFinish) {
            OnenoteAuth.whenLoggedIn(() =>{ 
                var client = new RestClient("https://www.onenote.com/api/v1.0");
                RestRequest request = new RestRequest(string.Format("pages/{0}/content", pageID), Method.GET);
                request.AddParameter("Authorization", "Bearer " + OnenoteAuth.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method
                //async 
                client.ExecuteAsync(request, response => onFinish(response.Content));
            });
        }
    }
}
