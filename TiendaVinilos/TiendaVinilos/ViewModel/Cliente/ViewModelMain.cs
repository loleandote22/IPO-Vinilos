using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TiendaVinilos.Presentacion.Páginas;
using TiendaVinilos.Presentación.Páginas;
using TiendaVinilos.ViewModel.Cliente;

namespace TiendaVinilos.ViewModelCliente
{
    public class ViewModelMain: ViewModelBase
    {
        private string texto;
        private string idiomaSeleccionado;
        private string mensaje;
        private ICommand commandArtistas;
        private ICommand commandDiscos;
        private ICommand commandPromociones;
        private ICommand commandContacto;
        private ICommand commandCompra;
        private ICommand usuarioCommand;
        private ICommand inicioCommand;
        private List<string> listaIdiomas = new List<string> { "Español", "Inglés" };
        private int elementosCarrito;
        private int estadoBarra;
        private Page pantalla;
        private string titulo;
        public Entidades contexto = new Entidades();
        private Usuario cliente;

        private Visibility verPopUp;
        private Visibility verCorrecto;
        private Visibility verInfo;
        public SoundPlayer soundPlayer = new SoundPlayer();
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
            verPopUp = Visibility.Collapsed;
        }

        public string Texto { get => texto;
            set
            {
                texto = value;
                OnPropertyChanged("Texto");
            }

        }

        public string IdiomaSeleccionado { get => idiomaSeleccionado; set => idiomaSeleccionado = value; }
        public string Mensaje { get => mensaje; set { mensaje = value; OnPropertyChanged("Mensaje"); } }
        public List<string> ListaIdiomas { get => listaIdiomas; set => listaIdiomas = value; }
        public ICommand CommandArtistas { get => commandArtistas; set => commandArtistas = value; }
        public ICommand CommandDiscos { get => commandDiscos; set => commandDiscos = value; }
        public ICommand CommandPromociones { get => commandPromociones; set => commandPromociones = value; }
        public ICommand CommandContacto { get => commandContacto; set => commandContacto = value; }
        public ICommand CommandCompra { get => commandCompra; set => commandCompra = value; }
        public ICommand UsuarioCommand { get => usuarioCommand; set => usuarioCommand = value; }
        public ICommand InicioCommand { get => inicioCommand; set => inicioCommand = value; }
        public int ElementosCarrito { get => elementosCarrito; set { elementosCarrito = value;OnPropertyChanged("ElementosCarrito"); } }
        public int EstadoBarra { get => estadoBarra; set { estadoBarra = value; OnPropertyChanged("EstadoBarra"); } }
        public string Titulo { get => titulo;set { titulo = value; ;OnPropertyChanged("Titulo"); } }

        public Visibility VerPopUp { get => verPopUp; set { verPopUp = value; OnPropertyChanged("VerPopUp"); } }
        public Visibility VerCorrecto { get => verCorrecto; set { verCorrecto = value; OnPropertyChanged("VerCorrecto"); } }
        public Visibility VerInfo
        {
            get => verInfo; set { verInfo = value; OnPropertyChanged("VerInfo"); }
        }
        public Page Pantalla { get => pantalla; set {
                pantalla = value;
                OnPropertyChanged("Pantalla");
            } }


        private void verArtistas() { 
            ArtistasPage artistas = new ArtistasPage();
            artistas.DataContext = new ViewModelArtistas( artistas, contexto);
            cambiarPantalla(artistas, "Artistas");
        }
        private void verDiscos() { DiscosClientePage discos = new DiscosClientePage();
            discos.DataContext = new ViewModelDiscos(discos,this, contexto, cliente);
            cambiarPantalla(discos, "Discos");
        }
        private void verPromociones() { MessageBox.Show("Promociones"); }
        private void verContacto() { MessageBox.Show("Contacto"); }
        private void verCompra() { MessageBox.Show("Compra"); }
        private void verPerfil() { MessageBox.Show("Perfil");  }
        private void verInicio() { MessageBox.Show("Inicio"); }
        public void cambiarPantalla(Page pantalla, string titulo="")
        {
            Pantalla= pantalla;
            if (titulo.Length > 0) 
            Titulo = titulo;
            soundPlayer.Stop();
        }


        public void noDeseado()
        {

            VerCorrecto = Visibility.Visible;
            VerInfo = Visibility.Collapsed;
            Mensaje = "Disco añadido a la lista de deseos";
        }
        public void yaDeseado()
        {
            VerInfo = Visibility.Visible;
            VerCorrecto = Visibility.Collapsed;
            Mensaje = "El disco ya estaba en tu lista de deseos";
        }
        public void barraPopup()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += actualizarBarra;
            worker.ProgressChanged += actualizacion;
            worker.RunWorkerAsync();
        }

        private void actualizarBarra(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(10);
            }

            (sender as BackgroundWorker).ReportProgress(-1);
        }

        private void actualizacion(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0)
                EstadoBarra = e.ProgressPercentage;
            else { EstadoBarra = 0; VerPopUp = Visibility.Collapsed; }

        }
    }
}
