using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace VFBC
{
    public partial class _default1 : System.Web.UI.Page
    {
        /// <summary>
        /// variables to hold values needed by upload
        /// </summary>
        private static string UpLoadedFileName = string.Empty;
        private static byte[] UpLoadedFileBytes = null;
        private static byte[] byteArray = null;
        /// <summary>
        /// variables from form
        /// </summary>
        private static string UploadFileExtension = string.Empty;
        private string VideoTitle = string.Empty;
        private string VideoCaption = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload2Portal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("btnUpload2Portal_Click");
            //check to insure that there is a file to be uploaded
            if (FileUpload1.HasFile)
            {
                UpLoadedFileName = FileUpload1.FileName;
                UpLoadedFileBytes = FileUpload1.FileBytes;
                UploadFileExtension = GetFileExtension(UpLoadedFileName);
                VideoTitle = tbTitle.Text;
                VideoCaption = tbCaption.Text;

                //check to make sure title is not empty
                // this verification should be own function since it gets called twice
                if (string.IsNullOrEmpty(VideoTitle))
                {
                    tbTitle.Focus();
                    uploadErrorTitle.Visible = true;
                    uploadErrorTitle.BorderColor = System.Drawing.Color.Red;
                    uploadErrorTitle.Text = "Please add title";
                }
                else
                {
                    uploadErrorTitle.Visible = false;
                    uploadErrorTitle.Text = string.Empty;
                }

                //check to make sure caption is not empty
                if (string.IsNullOrEmpty(VideoCaption))
                {
                    tbCaption.Focus();
                    uploadErrorCaption.Visible = true;
                    uploadErrorCaption.Text = "Please add caption";
                }
                else
                {
                    uploadErrorCaption.Text = string.Empty;
                    uploadErrorCaption.Visible = false;
                }
                Upload2Brightcove();
            }
            else
            {
                //message to user if no file has been selected before Upload to Visit Florida Brightcove is clicked
                FileUpload1.Focus();
                RetVal.Text = "Please select a file to upload";
                RetVal.Visible = true;
                return;
            }
        }

        protected void btnUpDate2Portal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("btnUpDate2Portal_Click");
            VideoTitle = tbTitleUpdate.Text;
            VideoCaption = tbCaptionUpdate.Text;
            if (string.IsNullOrEmpty(VideoTitle))
            {
                tbTitleUpdate.Focus();
                titleUpdateError.Visible = true;
                titleUpdateError.BorderColor = System.Drawing.Color.Red;
                titleUpdateError.Text = "Please add title";
            }
            else
            {
                titleUpdateError.Visible = false;
                titleUpdateError.Text = string.Empty;
            }

            //check to make sure caption is not empty
            if (string.IsNullOrEmpty(VideoCaption))
            {
                tbCaptionUpdate.Focus();
                titleUpdateCaptionError.Visible = true;
                titleUpdateCaptionError.Text = "Please add caption";
            }
            else
            {
                titleUpdateCaptionError.Visible = false;
                titleUpdateCaptionError.Text = string.Empty;
            }
            UpdateBrightcove();
        }


        protected void btnDelete2Portal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("btnDelete2Portal_Click");
            DeleteBrightcove();
        }



        private void DeleteBrightcove()
        {
            string str = MediaKeyDelete.Text;
            string url = "https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/" + str;
            string line = string.Empty;
            string userName = ConfigurationManager.AppSettings["BrightCoveClientId"];
            string passWord = ConfigurationManager.AppSettings["BrightCoveSecretClientId"];
            string unpw = userName + ":" + passWord;
            byteArray = Encoding.ASCII.GetBytes(unpw);
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var response = client.DeleteAsync(url).Result;
                    StreamReader sr = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    line = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                if (!RetValDelete.Visible)
                {
                    RetValDelete.Visible = true;
                }
                RetValDelete.Text = ex.Message;
            }

            if (!RetValDelete.Visible)
            {
                RetValDelete.Visible = true;
            }
            RetValDelete.Text = line;
        }

        private void UpdateBrightcove()
        {
            string str = MediaKeyUpdate.Text;
            string url = "https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/" + str;
            VideoTitle = tbTitleUpdate.Text;
            VideoCaption = tbCaptionUpdate.Text;

            string userName = ConfigurationManager.AppSettings["BrightCoveClientId"];
            string passWord = ConfigurationManager.AppSettings["BrightCoveSecretClientId"];
            string unpw = userName + ":" + passWord;
            byteArray = Encoding.ASCII.GetBytes(unpw);

            HttpContent stringContent = new StringContent("Hello");
            HttpContent stringContent2 = new StringContent("World");

            string line = string.Empty;

            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("title", VideoTitle);
            postData.Add("caption", VideoCaption);

            using (var client = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                        var response = client.PutAsync(url, content).Result;
                        StreamReader sr = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                        line = sr.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.Message);
                        RetValUpdate.Text = ex.Message;
                        if (!RetValUpdate.Visible)
                        {
                            RetValUpdate.Visible = true;
                        }
                    }
                }
            }
            if (!RetValUpdate.Visible)
            {
                RetValUpdate.Visible = true;
            }
            RetValUpdate.Text = line;
        }

        private void Upload2Brightcove()
        {
            //url of end point 

            string userName = ConfigurationManager.AppSettings["BrightCoveClientId"];
            string passWord = ConfigurationManager.AppSettings["BrightCoveSecretClientId"];
            string unpw = userName + ":" + passWord;
            Byte[] byteArray = Encoding.ASCII.GetBytes(unpw);
            string str = DateTime.Now.ToString("MMddyyyyHHmmssfff");
            str = "MODOPTEST" + str;
            string url = "https://visit-florida-brightcove-stage.herokuapp.com/api/v2/video/" + str;

            HttpContent stringContent = new StringContent("Hello");
            HttpContent stringContent2 = new StringContent("World");
            HttpContent bytesContent = new ByteArrayContent(UpLoadedFileBytes);

            string line = string.Empty;

            using (var client = new HttpClient())

            using (var formData = new MultipartFormDataContent())
            {
                stringContent.Headers.Add("Content-Disposition", "form-data; name=\"title\"");
                if (!string.IsNullOrEmpty(tbTitle.Text))
                {
                    formData.Add(stringContent, tbTitle.Text);
                }
                stringContent2.Headers.Add("Content-Disposition", "form-data; name=\"caption\"");
                if (!string.IsNullOrEmpty(tbCaption.Text))
                {
                    formData.Add(stringContent2, tbCaption.Text);
                }

                formData.Add(bytesContent, "video", UploadFileExtension);
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var response = client.PostAsync(url, formData).Result;
                    StreamReader sr = new StreamReader(response.Content.ReadAsStreamAsync().Result);
                    line = sr.ReadToEnd();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    RetVal.Text = ex.Message;
                    if (!RetVal.Visible) {
                        RetVal.Visible = true;
                    }
                }
            }
            RetVal.Text = UpLoadedFileName + " : " + line;
            RetVal.Visible = true;
        }

        /// <summary>
        /// Gets random number for name.  replaced i8n production by correct values
        /// </summary>
        /// <returns> int </returns>
        private int GetUploadNumber()
        {
            int ret = 0;
            Random r = new Random(DateTime.Now.Millisecond);
            Random x = new Random();
            ret = r.Next(10, 9999);
            return ret;
        }

        /// <summary>
        /// gets file extension to be included in file name.
        /// </summary>
        /// <param name="FileName">File name being uploaded</param>
        /// <returns>file extension</returns>
        private string GetFileExtension(string FileName)
        {
            string ret = string.Empty;
            ret = FileName.Substring(FileName.Length - 4);
            return ret;
        }


    }
}