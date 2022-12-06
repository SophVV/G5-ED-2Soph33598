using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodoArbolBusqueda
{
    public class NodoArbol
    {
        public NodoArbol RamaIzquierda { get; set; }
        public int Dato { get; set; }
        public string Nombre { get; set; }
        public NodoArbol RamaDerecha { get; set; }

        public NodoArbol(int dato, string nombre)
        {
            RamaIzquierda = null;
            this.Dato = dato;
            this.Nombre = nombre;
            RamaDerecha = null;
        }


    }
}
