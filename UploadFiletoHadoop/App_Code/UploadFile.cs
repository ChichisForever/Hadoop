using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.IO;
using Renci.SshNet;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hola a todos";
    }
    [WebMethod]
    public String UploadFileToFtp(string url, string filePath)
    {
        try
        {
            var fileName = Path.GetFileName(filePath);
            Console.WriteLine(url);

            var request = (FtpWebRequest)WebRequest.Create(url + fileName);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("cloudera", "cloudera");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead(filePath))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            response.Close();

            Console.WriteLine("Subiendo archivo a hadoop");
            using (var client = new SshClient("192.168.1.6", "cloudera", "cloudera"))

            {
                client.Connect();
                client.RunCommand("hadoop fs -copyFromLocal JSON/" + fileName + " /user/JSON/"+fileName);
                client.RunCommand("rm JSON/" + fileName);
                client.Disconnect();
            }


            return "Archivo Subido con éxito";
        }
        catch (Exception ex)
        {
            return "Parece que tenemos un problema." + ex.Message;
        }

     }
}
