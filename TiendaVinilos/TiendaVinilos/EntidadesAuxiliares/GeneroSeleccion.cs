using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos.EntidadesAuxiliares
{
    internal class GeneroSeleccion
    {
        private Genero genero;
        private Boolean seleccionado=false;
        public GeneroSeleccion() { }
        public GeneroSeleccion(Genero genero) { this.Genero = genero; }

        public bool Seleccionado { get => seleccionado; set => seleccionado = value; }
        public Genero Genero { get => genero; set => genero = value; }
    }
}
