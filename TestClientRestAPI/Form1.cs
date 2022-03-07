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


            usuarios usuario = new usuarios();
            usuario = usuarios[0];
            usuario.idusuarios = 7;
            usuario.nombre = "Azucena";
            usuario.apellido = "Grijalva";


            //Guardar el nuevo usuario
            respuesta = "";
            string data = JsonConvert.SerializeObject(usuario);
            respuesta = consumir.PostAPI(url, data, "", "");


            //Impirmir el valor de respuesta
            //Si retorna una lista vacia, es porque no existen usuarios
            if (respuesta.Equals("{}"))
            {
                //Imprimir que no encontro ningun usuario
            }
            //Sí son varios objetos json
            if ((respuesta.StartsWith("{") && respuesta.EndsWith("}")))
            {
                usuario = JsonConvert.DeserializeObject<usuarios>(respuesta);
            }


            //Guardar ubicaciones para el usuario creado

            //Guardar primera ubicacion
            ubicacion ubicaciones = new ubicacion();
            ubicaciones.latitud = "-92.551968";
            ubicaciones.longitud = "15.166495";
            ubicaciones.idusuario = usuario.idusuarios;
            ubicaciones.descripcion = "chiapas";

            url = "http://127.0.0.1:8000/ubicaciones";
            data = "";
            respuesta = "";
            data = JsonConvert.SerializeObject(ubicaciones);
            respuesta = consumir.PostAPI(url, data, "", "");

            //Guardar una segunda ubicacion
            ubicaciones.descripcion = "Santa Lucia Cotz";
            ubicaciones.latitud = "2.1244";
            ubicaciones.longitud = "15.166495";
            url = "http://127.0.0.1:8000/ubicaciones";
            data = "";
            respuesta = "";
            data = JsonConvert.SerializeObject(ubicaciones);
            respuesta = consumir.PostAPI(url, data, "", "");

        }

    }


    public class usuarios
    {
        string Nombre;
        string Apellido;
        int Idusuario;

        public string nombre { get => Nombre; set => Nombre = value; }
        public string apellido { get => Apellido; set => Apellido = value; }
        public int idusuarios { get => Idusuario; set => Idusuario = value; }
    }

    public class ubicacion
    {
        string Longitud;
        string Latitud;
        int Idusuario;
        string Descripcion;

        public string longitud { get => Longitud; set => Longitud = value; }
        public string latitud { get => Latitud; set => Latitud = value; }
        public int idusuario { get => Idusuario; set => Idusuario = value; }
        public string descripcion { get => Descripcion; set => Descripcion = value; }
    }

}