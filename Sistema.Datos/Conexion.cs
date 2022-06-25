using System;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    public  class Conexion
    {
        //Almacena la base de datos a la que nos conectaremos
        private string Base;
        //Almacena el nombre del servidor al que nos conectaremos
        private string Servidor;
        //Almacenara el Usuario de la BBDD
        private string Usuario;
        //Almacenara la clave de la BBDD
        private string Clave;
        //Almacenara si estamos entrando con autenticacion de Windows o autenticacion de SQL Server
        private bool Seguridad;

        //Para la instanciacion de la conexion
        private static Conexion Con = null;

        //Constructor
        private Conexion()
        {
            this.Base = "dbsistema";
            this.Servidor = "MSI\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "1234";
            this.Seguridad = true;  //Autenticacion de Windows cuando esta a true
        }

        //Creamos la conexion
        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();

            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database= " + this.Base + ";";

                //Validacion para ver que tipo de conexion es
                if (this.Seguridad)  //Autenticacion de windows
                {
                    //Autenticacion de windows
                    Cadena.ConnectionString = Cadena.ConnectionString + " Integrated Security = SSPI";
                }
                else
                {
                    //Autenticacion de SQL Server
                    Cadena.ConnectionString = Cadena.ConnectionString + "User Id= " + this.Usuario + "; Password=" + this.Clave;
                }
            }
            //Si tenemos un error
            catch (Exception ex)
            {
                Cadena = null;
                //Lanzo el error
                throw ex;
            }
            return Cadena;
        }

        //Metodo para crear instancias de Conexion
        public static Conexion getInstancia()
        {
            //Verificamos si tenemos instancia
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
