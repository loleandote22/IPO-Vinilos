using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TiendaVinilos.Presentacion;
using TiendaVinilos.Presentacion.Páginas;

namespace TiendaVinilos.ViewModel
{
    internal class ViewModelArtistas :ViewModelBase
    {
        private ArtistasPage artistasPage;

        private List<string> generos;
        private int tamano;
        private Visibility verMenos;
        private Visibility verMas;
        private ICommand verMasCommand;
        private ICommand verMenosCommand;

        public ViewModelArtistas(ArtistasPage artistasPage) {
            this.artistasPage = artistasPage;
            ListView panel = this.artistasPage.Tabla;
            VerMenos = Visibility.Collapsed;
            VerMas = Visibility.Visible;
            Tamano = 100;
            VerMasCommand = new RelayCommand(new Action<object>((o) => mostrarMas()));
            VerMenosCommand = new RelayCommand(new Action<object>((o)=> mostrarMenos()));
            int i = 0;
            generos = new List<string>() { "Hip-Hop","Framenco","Pop"};
            var colores = new List<Brush> { new SolidColorBrush(Color.FromRgb(255, 0, 0)), new SolidColorBrush(Color.FromRgb(0, 255, 0)), new SolidColorBrush(Color.FromRgb(0, 0, 255)) }; 
            while (i < 20)
            {
                var generado = this.artistasPage.Generos;
                Label etiqueta = new Label();
                etiqueta.Content = i.ToString();
                //etiqueta.Background = colores.ToArray()[i%colores.Count];
                etiqueta.Height = 25;
                generado.Children.Add(etiqueta);
                i++;
            }
            i = 0;
            while (i < 23)
            {

                ArtistaControl artistaControl = new ArtistaControl();
                artistaControl.DataContext = new ViewModelArtistaControl(i.ToString());
                panel.Items.Add(artistaControl);
                i++;
            }
        }

        public List<string> Generos { get => generos; set => generos = value; }
        public ICommand MostarMasMenosGenero { get; set; }
        public int Tamano { get => tamano; set { tamano = value; OnPropertyChanged("Tamano"); } }
        public Visibility VerMas { get => verMas; set => verMas = value; }
        public Visibility VerMenos { get => verMenos; set  { verMenos = value; OnPropertyChanged("VerMenos"); } }

        public ICommand VerMenosCommand { get => verMenosCommand; set => verMenosCommand = value; }
        public ICommand VerMasCommand { get => verMasCommand; set => verMasCommand = value; }


        private void mostrarMas()
        {
            Tamano = generos.Count * 25;
            VerMas = Visibility.Collapsed;
            VerMenos = Visibility.Visible;
            MessageBox.Show(generos.Count().ToString());
        }
        private void mostrarMenos()
        {
            Tamano = 75;
            VerMenos= Visibility.Collapsed;
            VerMas= Visibility.Visible;
        }
    }
    public class ViewModelArtistaControl : ViewModelBase
    {
        private ICommand verArtista;
        private string artista;
        public ViewModelArtistaControl(String Artista) {
            artista= Artista;
            VerArtista = new RelayCommand(new Action<object>((o) => mostrarArtista()));
        }

        public ICommand VerArtista { get => verArtista; set => verArtista = value; }
        private void mostrarArtista()
        {
            MessageBox.Show(artista);
        }
    }
}
