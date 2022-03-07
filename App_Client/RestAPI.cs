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


        
        /// <summary>
        /// Metodo que sirve para realizar una consulta POST a un RestApi
        /// </summary>
        /// <param name="url">La url del RestAPI a consumir</param>
        /// <param name="data">La data que se envíara al RestAPI, puede ir vacio</param>
        /// <param name="credenciales">Las credenciales de autorizacion="Basic " para utilizar el metodo</param>
        /// <param name="autorization">El tipo de autorizacion="Basic " que se utilizara para consumir el RestAPI</param>
        /// <returns>Retorna la respuesta del servidor, tal y como este la devuelve</returns>


        public string PostAPI(string url, string data, string credenciales, string autorization)
        {
            string respuesta = "No se pudo realizar el metodo post";
            //var url = $"http://localhost:8080/items";
            var request = (HttpWebRequest)WebRequest.Create(url);
            //string json = $"{{\"data\":\"{data}\"}}";


            request.Headers.Add("Authorization", autorization + credenciales);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 900000;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
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
                // Handle error
                respuesta = "Se produjo una excepcion la cual es: " + ex;
                Console.WriteLine(respuesta);
                return respuesta;
            }
        }


        /// <summary>
        /// Metodo que sirve para realizar una consulta PUT a un RestApi
        /// </summary>
        /// <param name="url">La url del RestAPI a consumir</param>
        /// <param name="data">La data que se envíara al RestAPI, puede ir vacio</param>
        /// <param name="credenciales">Las credenciales de autorizacion="Basic " para utilizar el metodo</param>
        /// <param name="autorization">El tipo de autorizacion="Basic " que se utilizara para consumir el RestAPI</param>
        /// <returns>Retorna la respuesta del servidor, tal y como este la devuelve</returns>


        public string PutAPI(string url, string data, string credenciales, string autorization)
        {
            string respuesta = "No se pudo realizar el metodo Put";
            //var url = $"http://localhost:8080/items";
            var request = (HttpWebRequest)WebRequest.Create(url);
            //string json = $"{{\"id\":\"{id}\",\"data\":\"{data}\"}}";
            //byte[] byteArray = Encoding.UTF8.GetBytes(data);
            request.Headers.Add("Authorization", autorization + credenciales);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 900000;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
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
                // Handle error
                respuesta = "Se produjo una excepcion la cual es: " + ex;
                Console.WriteLine(respuesta);
                return respuesta;
            }
        }


        /// <summary>
        /// Metodo que sirve para realizar una consulta Delte a un RestApi
        /// </summary>
        /// <param name="url">La url del RestAPI a consumir</param>
        /// <param name="data">La data que se envíara al RestAPI, puede ir vacio</param>
        /// <param name="credenciales">Las credenciales de autorizacion="Basic " para utilizar el metodo</param>
        /// <param name="autorization">El tipo de autorizacion="Basic " que se utilizara para consumir el RestAPI</param>
        /// <returns>Retorna la respuesta del servidor, tal y como este la devuelve</returns>


        public string DeleteAPI(string url, string data, string credenciales, string autorization)
        {
            string respuesta = "No se pudo realizar el metodo Delete";
            //var url = $"http://localhost:8080/items/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", autorization + credenciales);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Timeout = 900000;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
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
                            return respuesta;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                respuesta = "Se produjo una excepcion la cual es: " + ex;
                Console.WriteLine(respuesta);
                //respuesta = respuesta.Replace("[{", "{");
                //respuesta = respuesta.Replace("}]", "}");
                return respuesta;
            }
        }

        /// <summary>
        /// Convierte el usuario y la contraseña en Base 64
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="contraseña">Contraseña</param>
        /// <returns></returns>

        public string credenciales64(string usuario, string contraseña)
        {
            string credenciales = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(usuario + ":" + contraseña));
            return credenciales;
        }


    }
}
