using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVinilos.ViewModel.Cliente
{
    internal class ViewModelComentarios : ViewModelBase
    {
        private string imagen;
        private string comentario;
        public ViewModelComentarios(string imagen, string comentario) {
           Imagen = imagen;
           Comentario = comentario;
        }

        public string Imagen { get => imagen; set { imagen = value; OnPropertyChanged("Imagen"); } }
        public string Comentario { get => comentario; set { comentario = value; OnPropertyChanged("Comentario"); } }
    }
}
