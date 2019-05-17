using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace FTPsubir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bsubir_Click(object sender, EventArgs e)
        {
           

            FtpWebRequest solicitud = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName( "C:\\Users\\ALBERTO\\Desktop\\a20146129.txt"));
            solicitud.Method = WebRequestMethods.Ftp.UploadFile;
            solicitud.Credentials = new NetworkCredential("test1pweb", "computadora321");
            solicitud.UsePassive = true;
            solicitud.UseBinary = true;
            solicitud.KeepAlive = false;


            FileStream abrir= File.OpenRead("C:\\Users\\ALBERTO\\Desktop\\a20146129.txt");
            byte[] buffer = new byte[abrir.Length];
            abrir.Read(buffer, 0, buffer.Length);
            abrir.Close();


            Stream streamQuery = solicitud.GetRequestStream();
            streamQuery.Write(buffer, 0, buffer.Length);
            streamQuery.Close();
            
        }
    }
}
