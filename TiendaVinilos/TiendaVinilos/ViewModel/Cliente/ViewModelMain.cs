using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Input;
using TiendaVinilos.Presentacion.Páginas;
using TiendaVinilos.Presentación.Páginas;
using TiendaVinilos.ViewModel.Cliente;

namespace TiendaVinilos.ViewModelCliente
{
    internal class ViewModelMain: ViewModelBase
    {
        private String texto;
        private String idiomaSeleccionado;
        private ICommand commandArtistas;
        private ICommand commandDiscos;
        private ICommand commandPromociones;
        private ICommand commandContacto;
        private ICommand commandCompra;
        private ICommand usuarioCommand;
        private ICommand inicioCommand;
        private List<String> listaIdiomas = new List<string> { "Español", "Inglés" };
        private int elementosCarrito;
        private Object pantalla;
        private String titulo;
        public Entidades contexto = new Entidades();
        private Usuario cliente;
        // private 
        public ViewModelMain(Usuario cliente, Entidades entidades)
        {
            this.cliente = cliente;
            contexto = entidades;
            commandArtistas= new RelayCommand(new Action<object>((o) => verArtistas()));
            commandDiscos= new RelayCommand(new Action<object>((o) => verDiscos()));
            commandPromociones = new RelayCommand(new Action<object>((o) => verPromociones()));
            commandContacto =new RelayCommand(new Action<object>((o) => verContacto()));
            commandCompra = new RelayCommand(new Action<object>((o) => verCompra()));
            usuarioCommand= new RelayCommand(new Action<object>((o) => verPerfil()));
            inicioCommand = new RelayCommand(new Action<object>((o) => verInicio()));
            elementosCarrito = 0;
            IdiomaSeleccionado = listaIdiomas[0];
            Titulo = "Bienvenido";
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
        public ICommand CommandCompra { get => commandCompra; set => commandCompra = value; }
        public ICommand UsuarioCommand { get => usuarioCommand; set => usuarioCommand = value; }
        public ICommand InicioCommand { get => inicioCommand; set => inicioCommand = value; }
        public int ElementosCarrito { get => elementosCarrito; set { elementosCarrito = value;OnPropertyChanged("ElementosCarrito"); } }
        public String Titulo { get => titulo;set { titulo = value; ;OnPropertyChanged("Titulo"); } }
        public Object Pantalla { get => pantalla; set {
                pantalla = value;
                OnPropertyChanged("Pantalla");
            } }


        private void verArtistas() { 
            ArtistasPage artistas = new ArtistasPage();
            artistas.DataContext = new ViewModelArtistas( artistas, contexto);
            Pantalla = artistas;
            Titulo = "Atistas";
        }
        private void verDiscos() { DiscosClientePage discos = new DiscosClientePage();
            discos.DataContext = new ViewModelDiscos(discos, contexto, cliente);
            Pantalla = discos;
            Titulo = "Discos";
        }
        private void verPromociones() { MessageBox.Show("Promociones"); }
        private void verContacto() { MessageBox.Show("Contacto"); }
        private void verCompra() { MessageBox.Show("Compra"); }
        private void verPerfil() { MessageBox.Show("Perfil");  }
        private void verInicio() { MessageBox.Show("Inicio"); }
    }
}
