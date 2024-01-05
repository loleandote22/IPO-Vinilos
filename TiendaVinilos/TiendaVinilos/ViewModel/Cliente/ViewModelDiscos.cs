using System;
using System.Collections.Generic;
using System.Linq;
using TiendaVinilos.EntidadesAuxiliares;
using TiendaVinilos.Presentación.Páginas;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using TiendaVinilos.Presentación.Controles;
using System.Configuration;
using TiendaVinilos.ViewModelCliente;
using TiendaVinilos.Presentación.Páginas.Discos;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Win32;
using System.Net;
using System.Media;
using static System.Net.WebRequestMethods;
using System.Runtime.CompilerServices;



namespace TiendaVinilos.ViewModel.Cliente
{
    public class ViewModelDiscos: ViewModelBase
    {
        private Entidades contexto;
        private DiscosClientePage pagina;
        public Usuario cliente;
        private List<int> generosSeleccionados = new List<int>();
        private List<int> artistasSeleccionados = new List<int>();
        private List<GeneroSeleccion> todosGeneros;
        private List<ArtistaSeleccion> todosArtistas;
        private List<Disco> discos;
        private List<string> rangoPrecios = new List<string> { "- 50 €", "50 - 100 €", "+ 100 €" };
        private Grid panel;
        private int menor = 0;
        private int mayor = int.MaxValue;
        private int paginaActual;
        private int totalPaginas;
        private bool deseoActivo;
        private Visibility verBotonIzq;
        private Visibility verBotonDech;
        private ICommand verPaginaIzqCommand;
        private ICommand verPaginaDechCommand;
        public ViewModelMain ViewModelMain;
        public ViewModelDiscos(DiscosClientePage pagina,ViewModelMain viewModelMain, Entidades contexto, Usuario cliente)
        {
            this.pagina = pagina;
            this.contexto = contexto;
            this.cliente = cliente;
            ViewModelMain= viewModelMain;
            todosGeneros = (from g in contexto.Genero select new GeneroSeleccion() { Genero = g }).ToList();
            todosArtistas = (from a in contexto.Artista select new ArtistaSeleccion() { Artista = a}).ToList();
            panel = this.pagina.Tabla;
           
            foreach (GeneroSeleccion generoSeleccion in todosGeneros)
            {
                var check = new CheckBox();
                check.Content = generoSeleccion.Genero.nombre;
                check.IsChecked = generoSeleccion.Seleccionado;
                check.Checked += generocheckeado;
                check.Unchecked += generouncheckeado;
                this.pagina.Generos.Items.Add(check);

            }

            foreach (string precio in rangoPrecios) { 
                var radButton = new RadioButton();
                radButton.Content = precio;
                radButton.Checked += RadButton_Checked;
                radButton.GroupName = "precios";
                this.pagina.Precios.Items.Add(radButton);
            }
            foreach(ArtistaSeleccion artistaSeleccion in todosArtistas)
            {
                var check = new CheckBox();
                check.Content = artistaSeleccion.Artista.nombre;
                check.IsChecked = artistaSeleccion.Seleccionado;
                check.Checked += artistacheckeado;
                check.Unchecked += artistauncheckeado;
                this.pagina.Artistas.Items.Add(check);

            }

            discos = (from d in contexto.Disco select d).ToList();
            verBotonIzq = Visibility.Collapsed;
            if (discos.Count < 21)
                verBotonDech = Visibility.Collapsed;
            VerPaginaIzqCommand = new RelayCommand(new Action<object>((o) => VerPaginaIzq()));
            VerPaginaDechCommand = new RelayCommand(new Action<object>((o) => VerPaginaDech()));
            PaginaActual = 1;
            double elementos = discos.Count / 20.0;
            totalPaginas = Convert.ToInt32(Math.Ceiling(elementos));
            DeseoActivo = true;
            mostrarDiscos();
        }
        public Visibility VerBotonIzq { get => verBotonIzq; set { verBotonIzq = value; OnPropertyChanged("VerBotonIzq"); } }
        public Visibility VerBotonDech { get => verBotonDech; set { verBotonDech = value; OnPropertyChanged("VerBotonDech"); } }

        public ICommand VerPaginaIzqCommand { get => verPaginaIzqCommand; set { verPaginaIzqCommand = value;OnPropertyChanged("VerPaginaIzqCommand"); }  }
        public ICommand VerPaginaDechCommand { get => verPaginaDechCommand; set { verPaginaDechCommand = value; OnPropertyChanged("VerPaginaDechCommand"); } }
        public int PaginaActual { get => paginaActual; set { paginaActual = value; OnPropertyChanged("PaginaActual"); } }

        public int TotalPaginas { get => totalPaginas; set { totalPaginas = value; OnPropertyChanged("TotalPaginas"); } }



        public bool DeseoActivo { get => deseoActivo; set { deseoActivo = value; OnPropertyChanged("DeseoActivo"); } }

        private void RadButton_Checked(object sender, RoutedEventArgs e)
        {
            int posicion = rangoPrecios.IndexOf(((RadioButton)sender).Content.ToString());
            var texto = rangoPrecios[posicion];
            switch (posicion)
            {
                case 0:
                    int inicio = texto.IndexOf("-") + 2;
                    int fin = texto.IndexOf("€") - 1;
                    texto = texto.Substring(inicio , fin-inicio);
                    mayor = int.Parse(texto);
                    menor = 0;
                    break;
                case 1:
                    var textoMenor = texto.Substring(0,texto.IndexOf(" "));
                    menor = int.Parse(textoMenor);
                    inicio = texto.IndexOf("-") + 2;
                    fin = texto.IndexOf("€") - 1;
                    texto = texto.Substring(inicio, fin-inicio);
                    mayor = int.Parse(texto);
                    break;
                case 2:
                    inicio = texto.IndexOf(" ") + 1;
                    fin = texto.IndexOf("€")-1;
                    texto = texto.Substring(inicio, fin-inicio);
                    menor = int.Parse(texto);
                    mayor = int.MaxValue;
                    break;
            }
            PaginaActual = 1;
            mostrarDiscos();
        }

        private void mostrarDiscos() {
            panel.RowDefinitions.Clear();
            panel.Children.Clear();
            List<Disco> discos;
            if (generosSeleccionados.Count > 0)
                discos = (from d in contexto.Disco from g in generosSeleccionados where d.idGenero == g && d.precio >= menor && d.precio <= mayor select d).ToList();
            else
                discos = (from d in contexto.Disco where d.precio >= menor && d.precio <= mayor select d).ToList();
            if (artistasSeleccionados.Count > 0)
                discos = (from d in discos from a in artistasSeleccionados where d.idArtista == a select d).ToList();
            if(discos.Count > 0)
            for(int k = 0; k < 39; k++)
            {
                discos.Add(discos[k]);
            }
            double elementos = discos.Count / 20.0;
            TotalPaginas = Convert.ToInt32(Math.Ceiling(elementos));
            if (totalPaginas == 0)
                TotalPaginas++;
            discos = discos.Skip((paginaActual-1) * 20).Take(20).ToList();
                for (int posicion =0;posicion<discos.Count;posicion++)
                {
                    DiscoControl discoControl = new DiscoControl();
                    discoControl.MouseEnter += DiscoControl_MouseEnter;
                    discoControl.MouseLeave += DiscoControl_MouseLeave;
                    discoControl.DataContext = new ViewModelDiscoControl(discos[posicion], this);
                    Grid.SetColumn(discoControl, posicion%5);
                    Grid.SetRow(discoControl, posicion / 5);
                    if (posicion % 5 == 0)
                        panel.RowDefinitions.Add(new RowDefinition() { Height=new GridLength(400)});
                    panel.Children.Add(discoControl);
                }
        }

        private void DiscoControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ((DiscoControl)sender).Cursor = Cursors.Arrow;
        }

        private void DiscoControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ((DiscoControl)sender).Cursor = Cursors.Hand;
        }

        private void generocheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = true;
            generosSeleccionados.Add(seleccionado.Genero.idGenero);
            paginaActual = 1;          
            mostrarDiscos();
        }

       


        private void generouncheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = false;
            generosSeleccionados.Remove(seleccionado.Genero.idGenero);
            paginaActual = 1;
            mostrarDiscos();
        }
        private void artistacheckeado(object sender, EventArgs e) {
            string artista = ((CheckBox)sender).Content.ToString();
            ArtistaSeleccion seleccionado = (from s in todosArtistas where s.Artista.nombre == artista select s).First();
            seleccionado.Seleccionado = true;
            artistasSeleccionados.Add(seleccionado.Artista.idArtista);
            paginaActual = 1;
            mostrarDiscos();

        }
        private void artistauncheckeado(object sender, EventArgs e) {
            string artista = ((CheckBox)sender).Content.ToString();
            ArtistaSeleccion seleccionado = (from s in todosArtistas where s.Artista.nombre == artista select s).First();
            seleccionado.Seleccionado = false;
            artistasSeleccionados.Remove(seleccionado.Artista.idArtista);
            paginaActual = 1;
            mostrarDiscos();
        }
        
        private void VerPaginaIzq()
        {
            PaginaActual--;
            if (PaginaActual == 1)
                VerBotonIzq = Visibility.Collapsed;
            mostrarDiscos();
        }
        private void VerPaginaDech() {
            PaginaActual++;
            if (PaginaActual>= TotalPaginas)
                VerBotonDech = Visibility.Collapsed;
            mostrarDiscos();
        }
    }
   
    public class ViewModelDiscoControl : ViewModelBase
    {
        private ICommand verDisco;
        private ICommand comprarDiscoCommand;
        private ICommand anadirDeseoCommand;
        private Disco disco;
        private string imagenDisco;
        private double precio;
        private double precioAntes;
        private ViewModelDiscos viewModel;
        private Visibility verPromocion;

        public ViewModelDiscoControl(Disco Disco, ViewModelDiscos viewModel)
        {
            this.viewModel = viewModel;
            disco = Disco;
            var imagen = disco.portada;
            if (imagen != null)
                imagenDisco = imagen;
            if (imagenDisco == null)
                imagenDisco = "/Presentación/Imágenes/Imagen_no_disponible.png";
            var descuento = (from p in disco.Promocion where p.fechaInicio<= DateTime.Now && p.fechaFin>=DateTime.Now select p).FirstOrDefault();
            double cantidad = 0;
            if (descuento != null)
            {
                cantidad = descuento.descuento;
                VerPromocion= Visibility.Visible;
                PrecioAntes = disco.precio.Value;
            }else
                VerPromocion= Visibility.Collapsed;
            precio = disco.precio.Value * (100-cantidad)/100;
            VerDisco = new RelayCommand(new Action<object>((o) => mostrarDisco()));
            ComprarDiscoCommand = new RelayCommand(new Action<object>((o)=> comprarDisco()));
            AnadirDeseoCommand = new RelayCommand(new Action<object>((o)=> annadirDeseo()));

        }
        public Disco Disco { get { return disco; } }
        public ICommand VerDisco { get => verDisco; set => verDisco = value; }
        public ICommand ComprarDiscoCommand { get => comprarDiscoCommand; set => comprarDiscoCommand = value; }
        public ICommand AnadirDeseoCommand { get => anadirDeseoCommand; set => anadirDeseoCommand = value; }
        public string ImagenDisco { get => imagenDisco; set => imagenDisco = value; }
        public double Precio { get => precio; set => precio = value; }
        public Visibility VerPromocion { get => verPromocion; set { verPromocion = value; OnPropertyChanged("VerPromocion"); } }
        public double PrecioAntes { get => precioAntes; set { precioAntes = value; OnPropertyChanged("PrecioAntes"); } }

        private void mostrarDisco()
        {
            DiscoClientePage pagina= new DiscoClientePage();
            pagina.DataContext = new ViewModelDisco(pagina, viewModel.ViewModelMain, disco, viewModel.cliente);
            viewModel.ViewModelMain.cambiarPantalla(pagina, disco.titulo);
        }
        private void comprarDisco()
        {
            Console.WriteLine("Hola mi amor");
        }
        private void annadirDeseo()
        {
            if (viewModel.ViewModelMain.EstadoBarra==0)
            {
                Entidades contexto = viewModel.ViewModelMain.contexto;
                bool deseado = (from d in contexto.Deseo where d.idUsuario == viewModel.cliente.idUsuario && d.idDisco == disco.idDisco select d).Count() > 0;
                if (!deseado)
                {
                    contexto.Deseo.Add(new Deseo() { idDisco = disco.idDisco, idUsuario = viewModel.cliente.idUsuario });
                    contexto.SaveChanges();
                    viewModel.ViewModelMain.noDeseado();
                }
                else
                    viewModel.ViewModelMain.yaDeseado();
                viewModel.ViewModelMain.VerPopUp = Visibility.Visible;
                viewModel.ViewModelMain.barraPopup();
            }
        }
    }
    public class ViewModelDisco : ViewModelBase
    {
        private DiscoClientePage pagina;
        private ViewModelMain viewModel;
        private Disco disco;
        private Usuario usuario;
        private string imagen;
        private string contenido;
        private string cancion;
        private string imagenUsuario;
        private string comentario;
        private int likes;
        private int dislikes;
        private int unidades;
        private int opiniones;
        private double precio;
        private bool reproduciendo = false;
        private bool activarComentario;
        private ICommand likeCommand;
        private ICommand dislikeCommand;
        private ICommand cancionCara1Command;
        private ICommand cancionCara2Command;
        private ICommand cancelarComentarioCommand;
        private ICommand comentarComentarioCommand;
        private ICommand anadirDeseoCommand;
        private Visibility verCara2;
        public ViewModelDisco(DiscoClientePage pagina, ViewModelMain viewModel, Disco disco, Usuario cliente)
        {
            this.pagina = pagina;
            this.viewModel = viewModel;
            Disco = disco;
            imagen = disco.portada;
            usuario = cliente;
            imagenUsuario = cliente.imagen;
            Image image = new Image();
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(disco.portada);
            myBitmapImage.EndInit();
            image.Source = myBitmapImage;
            image.Height = 100;
            image.Margin = new Thickness(10, 0, 10, 0);
            pagina.imagenes.Children.Add(image);
            Unidades = disco.unidades.GetValueOrDefault();
            double cantidad = 0;
            if (disco.Promocion.Count > 0)
            {
                var descuento = (from p in disco.Promocion where p.fechaInicio >= DateTime.Now && p.fechaFin <= DateTime.Now select p).FirstOrDefault();
                cantidad = disco.Promocion.First().descuento;
            }
            Precio = disco.precio.Value * (100 - cantidad) / 100;
            foreach (ImagenDisco imagen in disco.ImagenDisco.ToList())
            {
                image = new Image();
                myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                myBitmapImage.UriSource = new Uri(imagen.enlace);
                myBitmapImage.EndInit();
                image.Source = myBitmapImage;
                image.Height = 100;
                image.Margin = new Thickness(10, 0, 10, 0);
                pagina.imagenes.Children.Add(image);
            }
            Likes = disco.favoritos.GetValueOrDefault();
            Dislikes = disco.criticos.GetValueOrDefault();
            bool hayCara2 = (from c in disco.Cancion where c.cara == 2 select c).Count() > 0;
            if (hayCara2)
                VerCara2 = Visibility.Visible;
            else
                VerCara2 = Visibility.Collapsed;

            opiniones = disco.ComentarioDisco.Count();
            StackPanel panelComentarios = pagina.comentarios;
            foreach (ComentarioDisco comentario in disco.ComentarioDisco.Reverse())
                panelComentarios.Children.Add(new ComentarioControl() { DataContext = new ViewModelComentarios(comentario.Usuario.imagen, comentario.contenido) });
            CancionCara1Command = new RelayCommand(new Action<object>((o) => reproducirCara1()));
            CancionCara2Command = new RelayCommand(new Action<object>((o) => reproducirCara2()));
            CancelarComentarioCommand = new RelayCommand(new Action<object>((o) => { cancelarComentario(); }));
            ComentarComentarioCommand = new RelayCommand(new Action<object>((o) => { comentarComentario(); }));
            AnadirDeseoCommand = new RelayCommand(new Action<object>((o) => annadirDeseo()));
            ActivarComentario = false;
        }

        private void MediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            reproduciendo = false;
        }

        public Disco Disco { get => disco; set => disco = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Contenido { get => contenido; set { contenido = value; OnPropertyChanged("Contenido"); } }
        public string Cancion { get => cancion; set => cancion = value; }
        public string ImagenUsuario { get => imagenUsuario; set => imagenUsuario = value; }
        public int Likes { get => likes; set { likes = value; OnPropertyChanged("Likes"); } }
        public int Dislikes { get => dislikes; set { dislikes = value; OnPropertyChanged("Dislikes"); } }
        public int Unidades { get => unidades; set { unidades = value; OnPropertyChanged("Unidades"); } }
        public int Opiniones { get => opiniones; set { opiniones = value; OnPropertyChanged("Opiniones"); } }
        public double Precio { get => precio; set { precio = value; OnPropertyChanged("Precio"); } }
        public ICommand LikeCommand { get => likeCommand; set => likeCommand = value; }
        public ICommand DislikeCommand { get => dislikeCommand; set => dislikeCommand = value; }
        public ICommand CancionCara1Command { get => cancionCara1Command; set => cancionCara1Command = value; }
        public ICommand CancionCara2Command { get => cancionCara2Command; set => cancionCara2Command = value; }
        public ICommand CancelarComentarioCommand { get => cancelarComentarioCommand; set => cancelarComentarioCommand = value; }
        public ICommand ComentarComentarioCommand { get => comentarComentarioCommand; set => comentarComentarioCommand = value; }
        public ICommand AnadirDeseoCommand { get => anadirDeseoCommand; set => anadirDeseoCommand = value; }
        public Visibility VerCara2 { get => verCara2; set { verCara2 = value; OnPropertyChanged("VerCara2"); } }

        public string Comentario { get => comentario; set { comentario = value; ActivarComentario = comentario.Length > 0; OnPropertyChanged("Comentario"); } }

        public bool ActivarComentario { get => activarComentario; set { activarComentario = value; OnPropertyChanged("ActivarComentario"); } }

        private void reproducirCara1()
        {
            if (!reproduciendo)
            {
                Random r = new Random();
                int posCancion = r.Next(0, disco.Cancion.Count());
                viewModel.soundPlayer.SoundLocation = (from c in disco.Cancion where c.cara == 1 select c).ToList()[posCancion].enlace;
                viewModel.soundPlayer.Play();
                reproduciendo = true;
            }
            else { reproduciendo = false; viewModel.soundPlayer.Stop(); }

        }

        private void reproducirCara2()
        {
            if (!reproduciendo)
            {
                Random r = new Random();
                int posCancion = r.Next(0, disco.Cancion.Count());
                viewModel.soundPlayer.SoundLocation = (from c in disco.Cancion where c.cara == 2 select c).ToList()[posCancion].enlace;
                viewModel.soundPlayer.Play();
                reproduciendo = true;
            }
            else { reproduciendo = false; viewModel.soundPlayer.Stop(); }
        }

        private void cancelarComentario()
        {
            Comentario = "";
        }
        private void comentarComentario()
        {
            viewModel.contexto.ComentarioDisco.Add(new ComentarioDisco() { idUsuario = usuario.idUsuario, idDisco = disco.idDisco, contenido = Comentario, publicacion = DateTime.Now });
            viewModel.contexto.SaveChanges();
            cancelarComentario();
            opiniones = disco.ComentarioDisco.Count();
            StackPanel panelComentarios = pagina.comentarios;
            panelComentarios.Children.Clear();
            foreach (ComentarioDisco comentario in disco.ComentarioDisco.Reverse())
                panelComentarios.Children.Add(new ComentarioControl() { DataContext = new ViewModelComentarios(comentario.Usuario.imagen, comentario.contenido) });
        }
        private void annadirDeseo()
        {
            if (viewModel.EstadoBarra==0)
            {
                Entidades contexto = viewModel.contexto;
                bool deseado = (from d in contexto.Deseo where d.idUsuario == usuario.idUsuario && d.idDisco == disco.idDisco select d).Count() > 0;
                if (!deseado)
                {
                    contexto.Deseo.Add(new Deseo() { idDisco = disco.idDisco, idUsuario = usuario.idUsuario });
                    contexto.SaveChanges();
                    viewModel.noDeseado();
                }
                else
                    viewModel.yaDeseado();
                viewModel.VerPopUp = Visibility.Visible;
                viewModel.barraPopup();
                BackgroundWorker worker = new BackgroundWorker();
            }
        }
    }
}
