using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace QPXdemoApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string RequestString(string dep, string arr, DateTime date, bool roundtrip)
        {
            QpxRequest rqst = new QpxRequest();
            rqst.request = new Request();

            string dateStr = date.ToString("yyyy-MM-dd");

            if (roundtrip)
                rqst.request.slice = new Slice[] { new Slice() { origin = dep, destination = arr, date = dateStr }, new Slice() { origin = arr, destination = dep, date = dateStr } };
            else
                rqst.request.slice = new Slice[] { new Slice() { origin = dep, destination = arr, date = dateStr } };

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(rqst);

            return s;
        }

        private void getFlights()
        {
            if (MessageBox.Show("confirm?", "Confirm then wait! app will be frozen ;)", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

            jsonTextBox.Text = "";
            responseTextBox.Text = "";

            Application.DoEvents();

            try
            {
                //// Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create(urlTextBox.Text + "?key=" + apiKeyTextBox.Text);

                // Set the Method property of the request to POST.
                request.Method = "POST";
                // Create POST data and convert it to a byte array.
                string postData = RequestString(depTextBox.Text, arrTextBox.Text, dateTimePicker.Value, roundTripCheckBox.Checked);//                   
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                using (Stream dataStream = request.GetRequestStream())
                {
                    // Write the data to the request stream.
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    // Close the Stream object.
                    dataStream.Close();
                    // Get the response.
                    using (WebResponse response = request.GetResponse())
                    {
                        // Display the status.
                        //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                        // Get the stream containing content returned by the server.
                        using (Stream dataStream1 = response.GetResponseStream())
                        {
                            // Open the stream using a StreamReader for easy access.
                            using (StreamReader reader = new StreamReader(dataStream1))
                            {
                                // Read the content.
                                string responseFromServer = reader.ReadToEnd();

                                jsonTextBox.Text = JsonHelper.FormatJson(responseFromServer);

                                QpxResponse responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<QpxResponse>(responseFromServer);

                                responseTextBox.Text = responseData.AsString();

                                reader.Close();
                            }
                            dataStream1.Close();
                        }
                        response.Close();
                    }
                    dataStream.Close();
                }
            }
            catch (Exception exception)
            {
                jsonTextBox.Text = exception.ToString();
                //System.Windows.Forms.MessageBox.Show(exception.Message, "Error getting tickets", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            getFlights();
        }
    }

}
