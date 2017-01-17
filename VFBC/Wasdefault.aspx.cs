using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net.Http;

namespace VFBC
{
    public partial class _default : System.Web.UI.Page
    {
        private string ClientIdValue = string.Empty;
        private string ClientSecretIdValue = string.Empty;
        private string IngestProfileValue = string.Empty;
        private string IngestNameValue = string.Empty;
        private string BCLogInIdValue = string.Empty;
        private string BCLogPWValue = string.Empty;
        private static byte[] theBytes;
        private static HttpPostedFile theFile;
        private static string theFileName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblClientIdVal.Text = ClientIdValue;
            lblClientSecIdVal.Text = ClientSecretIdValue;
            lblIngestPVal.Text = IngestProfileValue;
            lblIngestPName.Text = IngestNameValue;
            lblBCLogId.Text = BCLogInIdValue;
            lblBCPW.Text = BCLogPWValue;
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            ClientIdValue = ConfigurationManager.AppSettings["BrightCoveClientId"];
            ClientSecretIdValue = ConfigurationManager.AppSettings["BrightCoveSecretClientId"];
            IngestProfileValue = ConfigurationManager.AppSettings["IngestProfile"];
            IngestNameValue = ConfigurationManager.AppSettings["IngestProfileName"];
            BCLogInIdValue = ConfigurationManager.AppSettings["BrightcoveLoginId"];
            BCLogPWValue = ConfigurationManager.AppSettings["BrightcoveLoginPw"];
            tb1.Text = "new attempt";

        }

        protected void btnUpload2Portal_Click(object sender, EventArgs e)
        {
            if (fu.HasFile)
            {
                theFileName = fu.FileName;
                theBytes = fu.FileBytes;
                theFile = fu.PostedFile;
            }
            RetVal.Visible = true;
            RetVal.Text = fu.FileName + " successfully uploaded.";
        }

        public static ManualResetEvent allDone = new ManualResetEvent(false);
        protected void btnWorkOnPost_Click(object sender, EventArgs e)
        {

            /*
reading:  https://www.w3.org/TR/html401/interact/forms.html#control-name
reading:  https://www.w3.org/TR/html401/interact/forms.html#h-17.13.4.2
reading:  https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.fileupload(v=vs.110).aspx
             */
            string url = "https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/13";
            //--------------------------------------------------------------------------------------------------//
            /*
             * var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"user\":\"test\"," +
                                  "\"password\":\"bla\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
             */
            /*
             * POST /api/v2/video/1 HTTP/1.1
                Host: visit-florida-brightcove-stage.herokuapp.com
                Content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW
                Cache-Control: no-cache
                Postman-Token: 2e57c0da-3adb-1e3c-ca10-1bf5f4645f46

                ------WebKitFormBoundary7MA4YWxkTrZu0gW
                Content-Disposition: form-data; name="title"

                test title
                ------WebKitFormBoundary7MA4YWxkTrZu0gW
                Content-Disposition: form-data; name="caption"

                test caption
                ------WebKitFormBoundary7MA4YWxkTrZu0gW
                Content-Disposition: form-data; name="video"; filename=""
                Content-Type: 


                ------WebKitFormBoundary7MA4YWxkTrZu0gW--
             */
            /*
             * // Perform the equivalent of posting a form with a filename and two files, in HTML:
                // <form action="{url}" method="post" enctype="multipart/form-data">
                //     <input type="text" name="filename" />
                //     <input type="file" name="file1" />
                //     <input type="file" name="file2" />
                // </form>
                private System.IO.Stream Upload(string url, string filename, Stream fileStream, byte [] fileBytes)
                {
                   // Convert each of the three inputs into HttpContent objects

                   HttpContent stringContent = new StringContent(filename);
                   // examples of converting both Stream and byte [] to HttpContent objects
                   // representing input type file
                   HttpContent fileStreamContent = new StreamContent(fileStream);
                   HttpContent bytesContent = new ByteArrayContent(fileBytes);

                   // Submit the form using HttpClient and 
                   // create form data as Multipart (enctype="multipart/form-data")

                   using (var client = new HttpClient())
                   using (var formData = new MultipartFormDataContent()) 
                   {
                       // Add the HttpContent objects to the form data

                       // <input type="text" name="filename" />
                       formData.Add(stringContent, "filename", "filename");
                       // <input type="file" name="file1" />
                       formData.Add(fileStreamContent, "file1", "file1");
                       // <input type="file" name="file2" />
                       formData.Add(bytesContent, "file2", "file2");

                       // Actually invoke the request to the server

                       // equivalent to (action="{url}" method="post")
                       var response = client.PostAsync(url, formData).Result;

                       // equivalent of pressing the submit button on the form
                       if (!response.IsSuccessStatusCode)
                       {
                           return null;
                       }
                       return response.Content.ReadAsStreamAsync().Result;
                   }
                }

             */
            HttpContent stringContent = new StringContent("Hello");
            HttpContent stringContent2 = new StringContent("Worldl");
            // examples of converting both Stream and byte [] to HttpContent objects
            // representing input type file

            //FileStream fileStream = new FileStream(, FileMode.Create, System.IO.FileAccess.Write);

            //HttpContent fileStreamContent = new StreamContent(theFile.InputStream);
            HttpContent bytesContent = new ByteArrayContent(theBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                // Add the HttpContent objects to the form data

                // <input type="text" name="filename" />
                //formData.Add(stringContent, "title", "title");
                //formData.Add(stringContent2, "caption", "caption");
                stringContent.Headers.Add("Content-Disposition", "form-data; name=\"title\"");
                formData.Add(stringContent, "title");
                stringContent2.Headers.Add("Content-Disposition", "form-data; name=\"caption\"");
                formData.Add(stringContent2, "caption");
                // <input type="file" name="file1" />
                //formData.Add(fileStreamContent, "video", "video");
                // <input type="file" name="file2" />
                formData.Add(bytesContent, "video", "video");

                // Actually invoke the request to the server

                // equivalent to (action="{url}" method="post")
                string line = string.Empty;
                try
                {
                    
                    var response = client.PostAsync(url, formData).Result;
                    Stream strm = response.Content.ReadAsStreamAsync().Result;
                    StreamReader sr = new StreamReader(strm);
                    line = sr.ReadToEnd();
                    
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                // equivalent of pressing the submit button on the form
                //Stream strm = response.Content.ReadAsStreamAsync().Result;
                //if (!response.IsSuccessStatusCode)
                //{
                //    return null;
                //}
                //return response.Content.ReadAsStreamAsync().Result;
            }


            /////////////////////////not quite
            //string URL = "http://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/1";
            //var httpWebRequest = WebRequest.Create(URL);
            //httpWebRequest.ContentType = "multipart/form-data";
            //httpWebRequest.Method = "Post";
            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //        string json = GetJSON();
            //        streamWriter.Write(json);
            //        streamWriter.Flush();
            //        streamWriter.Close();
            //        tb2.Text = json;
                    
            //}
            //TextBox1.Text = httpWebRequest.Method;
            //TextBox2.Text = httpWebRequest.RequestUri.ToString();
            //try
            //{
            //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
            //    var streamReader = new StreamReader(httpResponse.GetResponseStream());
            //    string line = streamReader.ReadToEnd();
            //    tb1.Text = line;
            //}
            //catch (WebException wex) {
            //    Console.WriteLine(wex.Message); }
            ////////////////////////////////////////////////////////////
            //--------------------------------------------------------------------------------------------------//
            // Create an instance of the RequestState and assign 
            // 'myWebRequest' to it's request field.    
            //RequestState myRequestState = new RequestState();
            //myRequestState.request = wr;
            //wr.ContentType = "application/x-www-form-urlencoded";
            //myRequestState.request.Method = "POST";
            //IAsyncResult r = (IAsyncResult)wr.BeginGetRequestStream(
            //    new AsyncCallback(ReadCallback), myRequestState);

            //allDone.WaitOne();
            //WebResponse myWebResponse = wr.GetResponse();
            //Stream streamResponse = myWebResponse.GetResponseStream();
            //StreamReader streamRead = new StreamReader(streamResponse);
            //char[] readBuff = new char[256];
            //int count = streamRead.Read(readBuff, 0, 256);
            //string outData = string.Empty;
            //while (count > 0) {
            //    outData += new string(readBuff, 0, count);
            //    count = streamRead.Read(readBuff, 0, 256);
            //}
            //streamResponse.Close();
            //streamRead.Close();
            //myWebResponse.Close();


        }

        private static string GetJSON()
        {
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new
            {
                title = "Foo",
                caption = "Bar",
                video = theFileName
                ////////////////////just don't do anything, but will serialize
                //video = theFileName
                //video = fu.PostedFile

                ////////////////these result in error
                //video = fu.FileContent // Exception has been thrown by the target of an invocation.
                //video = theFile // Exception has been thrown by the target of an invocation.
                //video = theFile.InputStream; // Exception has been thrown by the target of an invocation.
                //video = theBytes //"Error during serialization or deserialization using the JSON JavaScriptSerializer. The length of the string exceeds the value set on the maxJsonLength property."
            });
            return json;
        }

        private static void ReadCallback(IAsyncResult asynchronousResult)
        {
            RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
            WebRequest myWebRequest = myRequestState.request;

            // End the Asynchronus request.
            Stream streamResponse = myWebRequest.EndGetRequestStream(asynchronousResult);
            

            // Create a string that is to be posted to the uri.
            Console.WriteLine("Please enter a string to be posted:");
            string postData = "yada";
            // Convert the string into a byte array.
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Write the data to the stream.
            streamResponse.Write(byteArray, 0, postData.Length);
            streamResponse.Close();
            allDone.Set();
        }
    }

    public class RequestState
    {
        // This class stores the request state of the request.
        public WebRequest request;
        public RequestState()
        {
            request = null;
        }
    }
}