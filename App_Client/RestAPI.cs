using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App_Client
{
    public class RestAPI
    {

        //Comentario de Prueba

        private string autorization = "Basic ";

        public string Autorization { get => autorization; set => autorization = value; }

        /// <summary>
        /// Metodo que sirve para realizar una consulta GET a un RestApi
        /// </summary>
        /// <param name="url">La url del RestAPI a consumir</param>
        /// <param name="credenciales">Las credenciales de autorizacion="Basic " para utilizar el metodo</param>
        /// <param name="autorization">El tipo de autorizacion="Basic " que se utilizara para consumir el RestAPI</param>
        /// <returns>Retorna la respuesta del servidor, tal y como este la devuelve</returns>

        public string GetAPI(string url, string credenciales, string autorization)
        {
            string respuesta = "No se obtuvo la respuesta esperada";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", autorization + credenciales);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 900000;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return respuesta;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                            respuesta = responseBody;
                            //respuesta = respuesta.Replace("[{", "{");
                            //respuesta = respuesta.Replace("}]", "}");
                            return respuesta;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                respuesta = "Se produjo una excepcion la cual es: " + ex;
                Console.WriteLine(respuesta);
                return respuesta;

            }
        }

    }
}
