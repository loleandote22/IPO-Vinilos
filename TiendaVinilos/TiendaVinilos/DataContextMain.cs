using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TiendaVinilos
{
    internal class DataContextMain: ViewModelBase
    {
        private ICommand command;
        private String texto;
        private String idiomaSeleccionado;
        public ICommand Command { get => command; set => command = value; }
        private ICommand commandArtistas;
        private ICommand commandDiscos;
        private ICommand commandPromociones;
        private ICommand commandContacto;
        private List<String> listaIdiomas = new List<string> { "Español", "Inglés" };
        private int elementosCarrito;
        private String titulo;
       // private 
        public DataContextMain()
        {
            Command= new RelayCommand(new Action<object>((o) => hacerAlgo()));
            commandArtistas= new RelayCommand(new Action<object>((o) => verArtistas()));
            commandDiscos= new RelayCommand(new Action<object>((o) => verDiscos()));
            commandPromociones = new RelayCommand(new Action<object>((o) => verPromociones()));
            commandContacto =new RelayCommand(new Action<object>((o) => verContacto()));
            elementosCarrito = 0;
            IdiomaSeleccionado = listaIdiomas[0];
            DateTime fecha = System.DateTime.Now;
        }

        public string Texto { get => texto;
            set
            {
                texto = value;
                OnPropertyChanged("Texto");
            }

        }

        public string IdiomaSeleccionado { get => idiomaSeleccionado; set => idiomaSeleccionado = value; }
        public List<string> ListaIdiomas { get => listaIdiomas; set => listaIdiomas = value; }
        public ICommand CommandArtistas { get => commandArtistas; set => commandArtistas = value; }
        public ICommand CommandDiscos { get => commandDiscos; set => commandDiscos = value; }
        public ICommand CommandPromociones { get => commandPromociones; set => commandPromociones = value; }
        public ICommand CommandContacto { get => commandContacto; set => commandContacto = value; }
        public int ElementosCarrito { get => elementosCarrito; set=> elementosCarrito = value; }
        public String Titulo { get => titulo;set=>titulo = value; }
       // public DateTime Fecha { get=> }

        private void hacerAlgo()
        {
            MessageBox.Show("Hola");
        }
        private void verArtistas() { MessageBox.Show("Artistas"); }
        private void verDiscos() { MessageBox.Show("Discos"); }
        private void verPromociones() { MessageBox.Show("Promociones"); }
        private void verContacto() { MessageBox.Show("Contacto"); }
    }
}
