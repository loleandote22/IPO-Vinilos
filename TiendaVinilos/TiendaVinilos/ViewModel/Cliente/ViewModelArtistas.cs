using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TiendaVinilos.EntidadesAuxiliares;
using TiendaVinilos.Presentacion;
using TiendaVinilos.Presentacion.Páginas;

namespace TiendaVinilos.ViewModelCliente
{
    internal class ViewModelArtistas :ViewModelBase
    {
        private ArtistasPage artistasPage;

        private int tamano;
        private ICommand verMasCommand;
        private ICommand verMenosCommand;
        // Se necesita cuando se acceda a un artista en concreto
        private Entidades contexto;
        public List<GeneroSeleccion> todosGeneros;
        private List<Artista> todosArtistas;
        private List<GeneroSeleccion> generosSeleccionados= new List<GeneroSeleccion>();
        private ListView panel;
        public ViewModelArtistas(ArtistasPage artistasPage, Entidades contexto) {
           Mouse.OverrideCursor= Cursors.Wait;
            this.contexto = contexto;
            this.artistasPage = artistasPage;
           panel = this.artistasPage.Tabla;
            Tamano = 100;
            todosGeneros = (from g in contexto.Genero select new GeneroSeleccion() { Genero=g}).ToList();
          
            foreach (GeneroSeleccion generoSeleccion in todosGeneros)
            {
                var check = new CheckBox();
                check.Content = generoSeleccion.Genero.nombre;
                check.IsChecked = generoSeleccion.Seleccionado;
                check.Checked += controlcheckeado;
                check.Unchecked += controluncheckeado;
                artistasPage.Generos.Items.Add(check);
            }
            todosArtistas = (from a in contexto.Artista select a).ToList();
            mostrarArtistas();
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        public ICommand MostarMasMenosGenero { get; set; }
        public int Tamano { get => tamano; set { tamano = value; OnPropertyChanged("Tamano"); } }

        public ICommand VerMenosCommand { get => verMenosCommand; set => verMenosCommand = value; }
        public ICommand VerMasCommand { get => verMasCommand; set => verMasCommand = value; }
        public bool Auxiliar { get => auxiliar; set => auxiliar = value; }

        private Boolean auxiliar;
        private void controlcheckeado(object sender, EventArgs e)
        {
            string genero= ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado= (from s in todosGeneros where s.Genero.nombre== genero select s).First();
            seleccionado.Seleccionado = true;
            generosSeleccionados.Add(seleccionado);
            panel.Items.Clear();
            var artistas = (from a in todosArtistas join g in generosSeleccionados on a.Genero.idGenero equals g.Genero.idGenero select a).ToList();
            foreach (var artist in artistas)
            {
                ArtistaControl artistaControl = new ArtistaControl();
                artistaControl.DataContext = new ViewModelArtistaControl(artist);
                panel.Items.Add(artistaControl);
            }
        }
        private void controluncheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = false;
            generosSeleccionados.Remove(seleccionado);
            panel.Items.Clear();
            if(generosSeleccionados.Count > 0)
            {
                var artistas = (from a in todosArtistas join g in generosSeleccionados on a.Genero.idGenero equals g.Genero.idGenero select a).ToList();
                foreach(var artist in artistas)
                {
                    ArtistaControl artistaControl = new ArtistaControl();
                    artistaControl.DataContext = new ViewModelArtistaControl(artist);
                    panel.Items.Add(artistaControl);
                }
            }
            else
                mostrarArtistas();
        }
        private void mostrarArtistas()
        {
            foreach (Artista artista in todosArtistas)
            {
                ArtistaControl artistaControl = new ArtistaControl();
                artistaControl.MouseEnter += ArtistaControl_MouseEnter;
                artistaControl.MouseLeave += ArtistaControl_MouseLeave;
                artistaControl.DataContext = new ViewModelArtistaControl(artista);
                panel.Items.Add(artistaControl);
            }
        }

        private void ArtistaControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Console.WriteLine(((ArtistaControl)sender).Cursor = Cursors.Arrow);
        }

        private void ArtistaControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Console.WriteLine(((ArtistaControl)sender).Cursor = Cursors.Hand);
        }
    }
    public class ViewModelArtistaControl : ViewModelBase
    {
        private ICommand verArtista;
        private Artista artista;
        private string imagenArtista;
        public ViewModelArtistaControl(Artista Artista) {
            artista= Artista;
            var imagen = artista.ImagenArtista.FirstOrDefault();
            if (imagen != null) 
            imagenArtista = imagen.enlace;
            if (imagenArtista == null)
            {
                imagenArtista = "/Presentación/Imágenes/Imagen_no_disponible.png";
            }
            VerArtista = new RelayCommand(new Action<object>((o) => mostrarArtista()));
        }
        public Artista Artista { get { return artista; } }
        public ICommand VerArtista { get => verArtista; set => verArtista = value; }
        public string ImagenArtista { get => imagenArtista; set => imagenArtista = value; }

        private void mostrarArtista()
        {
            MessageBox.Show(artista.nombre);
        }
    }
}
