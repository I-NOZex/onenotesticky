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

        private static void postPage(string sectionID, Action<string> onFinish) {
            string resourceUri = (string.IsNullOrEmpty(sectionID)) ? "notes/pages" : string.Format("notes/sections/{0}/pages", sectionID);

            OnenoteAuth.whenLoggedIn(() => {
                var client = new RestClient("https://www.onenote.com/api/v1.0");
                RestRequest request = new RestRequest(resourceUri , Method.POST);
                request.AddParameter("Authorization", "Bearer " + OnenoteAuth.AccessToken, ParameterType.HttpHeader); // adds to POST or URL querystring based on Method
                request.AddHeader("Content-Type", "multipart/form-data; boundary=NewPart");
                request.AddBody("--NewPart\r\nContent-Disposition: form-data; name=\"Presentation\"\r\nContent-Type: application/xhtml+xml \r\n<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"en-us\">\r\n  <head>\r\n    <title>Page from OneNote API console</title>\r\n\t<meta name=\"created\" content=\"2014-03-17T09:00:00-08:00\" /> \r\n  </head>\r\n  <body>\r\n    <h1>HTML sample block</h1>\r\n\r\n    <h2>The basics</h2>\r\n    <p>For the most part, try to keep the HTML simple, and be \r\n      sure to properly close all tags.</p>\r\n    <p>Character encoding must be in UTF-8; the service doesn't \r\n      accept other encodings</p>\r\n\r\n    <h2>Overall structure</h2>\r\n    <p>The normal &lt;html&gt;, &lt;head&gt; and &lt;body&gt; tags are \r\n      expected, but the service is usually okay if they aren't included.</p>\r\n    <p>Inside the &lt;head&gt; tag, we recognize only the &lt;title&gt; and\r\n      One form of the &lt;meta&gt; tags.</p> \r\n    <p>All includes, CSS, script, etc. inside the &lt;head&gt; and &lt;body&gt;\r\n      blocks are ignored.</p>\r\n    <p>As you can tell from the &lt;body&gt; tag's style attribute, in this\r\n      HTML, the service ignores CSS styles</p>\r\n\r\n    <h2>Block formatting</h2>\r\n    <p>Paragraph (&lt;p&gt;) and line-break (&lt;br/&gt;) tags are handled \r\n      properly. They get the &quot;Normal&quot; OneNote styling</p>\r\n    <p>The &lt;div&gt; and &lt;span&gt; tags are recognized but generally \r\n      don't have any significant effect, since CSS styling is ignored. A\r\n      &lt;div&gt; tag acts like a &lt;p&gt; tag.</p>\r\n    <p>The header tags &lt;h1&gt; through &lt;h6&gt; are recognized, and\r\n      map to the OneNote Heading 1 through Heading 6 styles.</p>\r\n\r\n    <h2>Simple character formatting</h2>\r\n    <p>This paragraph shows how the API handles <b>HTML4+ bold \r\n      &lt;b&gt;</b> tags</p>\r\n    <p>...and <strong>HTML4+ strong &lt;strong&gt;</strong> tags</p>\r\n    <p>...and <i>HTML4+ italics &lt;i&gt;</i> tags</p>\r\n    <p>...and <em>HTML4+ emphasis &lt;em&gt;</em> tags</p>\r\n    <p>...and <a href=\".\">HTML anchor &lt;a&gt;</a> tags.</p>\r\n\r\n    <h2>Images</h2>\r\n    <p>The &lt;img&gt; tag is supported. For example, here&apos;s a referenced image: </p>\r\n    <img src=\"http://officeimg.vo.msecnd.net/en-us/files/018/949/ZA103278226.png\"/>\r\n    <p>The OneNote API supports JPEG, GIF, TIFF and PNG images</p>\r\n    <p>This next tag inserts a screenshot thumbnail image of the OneNote.com web\r\n      page into the captured page, displayed as 500 pixels wide.</p>\r\n    <img data-render-src=\"http://www.onenote.com\" width=\"500\"/>\r\n    <h2>Tables</h2>\r\n    <p>Tables are understood, but not table headers. Table headers are treated\r\n      like normal rows. You can nest tables, but their content-layout ability\r\n      is limited. </p>\r\n    <p>Tables have to be &quot;regular&quot;, in that the service assumes all \r\n      rows have same number of columns. Similarly, all columns have the same \r\n      number of rows. More specifically, the service ignores colspan and rowspan \r\n      attributes.</p>\r\n    <p>You can set the table border to either \"0\" (no border) or \"1\" (with border).</p>\r\n    <table border=\"1\"\t>\r\n      <tr>\r\n        <td>First row First column</td>\r\n        <td>First row Second column</td>\r\n      </tr>\r\n      <tr>\r\n        <td>Second row First column</td>\r\n        <td>Second row Second column</td>\r\n      </tr>\r\n    </table>\r\n    <p>Lists of both types (&lt;ol&gt; and &lt;ul&gt;) are supported, and can\r\n      be nested. But, the &quot;type=&quot; attribute is ignored.</p>\r\n    <ul>\r\n      <li>First unordered list item</li>\r\n      <li>Second unordered list item<br>which contains another list\r\n        <ol>\r\n          <li>First (nested) ordered list item</li>\r\n          <li>Second (nested) ordered list item</li>\r\n        </ol>\r\n      </li>\r\n    </ul>\r\n    <h2>Not (yet) supported</h2>\r\n    <p>Nested tables are supported, but table header rows (&lt;th&gt;) \r\n      are treated like normal table rows (&lt;tr&gt;)</p>\r\n    <p>CSS styles are ignored at this time.</p>\r\n    <p>Scripts are ignored.</p>\r\n    <p>Other tags (e.g, &lt;article&gt;, &lt;header&gt;,\r\n      &lt;footer&gt;, &lt;section&gt; and &lt;aside&gt;) are largely\r\n      ignored, but their otherwise-valid contents are included.</p>\r\n</body>\r\n</html>\r\n--NewPart--\r\n.");
                //async 
                client.ExecuteAsync(request, response => onFinish(response.Content));
            });
        }
    }
}
