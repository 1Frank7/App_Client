using App_Client;
using Newtonsoft.Json;

namespace TestClientRestAPI


{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://127.0.0.1:8000/usuarios";
            //string usuario= "RestAPI";
            string contraseña = "Prueba123!";
            string autorizacion = "Basic ";


            //Obtener usuarios
            RestAPI consumir = new RestAPI();
            //Creamos una lista del tipo usuarios donde tendremos los usuarios obtenidos del restapi
            List<usuarios> usuarios = new List<usuarios>();
            //URL del Endpoint
            url = "http://127.0.0.1:8000/usuarios";
            //Consumimos el Endpoint
            string respuesta = consumir.GetAPI(url, "", "");

            //Si retorna una lista vacia, es porque no existen usuarios 
            if (respuesta.Equals("[]"))
            {
                //Imprimir que no encontro ningun usuario
            }
            //Sí son varios objetos json
            if ((respuesta.StartsWith("[") && respuesta.EndsWith("]")))
            {
                usuarios = JsonConvert.DeserializeObject<List<usuarios>>(respuesta);
            }

}