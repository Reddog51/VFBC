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

        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
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

        
        protected void btnWorkOnPost_Click(object sender, EventArgs e)
        {
            string url = "https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/13";

            HttpContent stringContent = new StringContent("Hello");
            HttpContent stringContent2 = new StringContent("Worldl");

            HttpContent bytesContent = new ByteArrayContent(theBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                stringContent.Headers.Add("Content-Disposition", "form-data; name=\"title\"");
                formData.Add(stringContent, "title");
                stringContent2.Headers.Add("Content-Disposition", "form-data; name=\"caption\"");
                formData.Add(stringContent2, "caption");
                formData.Add(bytesContent, "video", "video");

                string line = string.Empty;
                try
                {
                    var response = client.PostAsync(url, formData).Result;
                    StreamReader sr = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    line = sr.ReadToEnd();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
