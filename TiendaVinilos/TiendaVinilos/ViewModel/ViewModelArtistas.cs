using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TiendaVinilos.Presentacion;
using TiendaVinilos.Presentacion.Páginas;

namespace TiendaVinilos.ViewModel
{
    internal class ViewModelArtistas :ViewModelBase
    {
        private ArtistasPage artistasPage;
        public ViewModelArtistas(ArtistasPage artistasPage) {
            this.artistasPage = artistasPage;
            //Grid panel = artistasPage.tabla;
            ListView panel = artistasPage.Tabla;
            //ListView panel = (ListView)artistasPage.GetChildObjects().First();
            int i = 0;
            //while (i < 23)
            //{

            //    ArtistaControl artistaControl = new ArtistaControl();
            //    artistaControl.DataContext = new ViewModelArtistaControl(i.ToString());
            //    Grid.SetColumn(artistaControl, i % 4);
            //    Grid.SetRow(artistaControl, i / 4);
            //    panel.Children.Add(artistaControl);
            //    i++;
            //    if (i % 4 == 0)
            //    {
            //        RowDefinition fila = new RowDefinition();
            //        fila.Height = new GridLength(270);
            //        panel.RowDefinitions.Add(fila);
            //    }
            //}
            while (i < 23)
            {

                ArtistaControl artistaControl = new ArtistaControl();
                artistaControl.DataContext = new ViewModelArtistaControl(i.ToString());
                panel.Items.Add(artistaControl);
                i++;
            }
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
