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
    public static class SectionService {

        public static void getSectionPages(string sectionID, Action<PageModel> onFinish) {
            OnenoteAuth.whenLoggedIn(() =>{ 
                var client = new RestClient("https://www.onenote.com/api/v1.0");
                RestRequest request = new RestRequest(string.Format("sections/{0}/pages", sectionID), Method.GET);
                request.AddParameter("Authorization", "Bearer " + OnenoteAuth.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method
                //async with deserialization
                var asyncHandle = client.ExecuteAsync<PageModel>(request, response => onFinish(response.Data));
            });
        }
    }
}
