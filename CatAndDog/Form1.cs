using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatAndDog
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dogimage = GetDogImageURL();

            pictureBox1.ImageLocation = dogimage;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string catimage = getcatimageurl();
            pictureBox2.ImageLocation = catimage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public static string GetDogImageURL()
        {
            string url = "https://dog.ceo/api/breeds/image/random";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            string imageUrl;

            using (var Responsereader = new StreamReader(webStream))
            {
                var response = Responsereader.ReadToEnd();
                dog dog = JsonConvert.DeserializeObject<dog>(response);
                imageUrl = dog.message;
            }
            return imageUrl;

        }
        public static string getcatimageurl()
        {
            string url = "https://api.thecatapi.com/v1/images/search";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            string catimage;
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            using (var Responsereader = new StreamReader(webStream))
            {
                var response = Responsereader.ReadToEnd();
                JavaScriptSerializer ser = new JavaScriptSerializer();

                List<Cat> catliist = ser.Deserialize<List<Cat>>(response);
                catimage = catliist[0].url;
            }
            return catimage;
        }
    }
}
