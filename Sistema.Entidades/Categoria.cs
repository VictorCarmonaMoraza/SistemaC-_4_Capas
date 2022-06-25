using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    //Representa la tabla categoria de la BBDD
    public class Categoria
    {
        //Representa el idCategoria de la tabla categoria
        public string IdCategoria { get; set; }
        ///Representa el nombre de la tabla categoria
        public string Nombre { get; set; }
        //Representa el descripcion de la tabla categoria
        public string Descripcion { get; set; }
        //Representa el estado de la tabla categoria
        public bool Estado { get; set; }
    }
}
