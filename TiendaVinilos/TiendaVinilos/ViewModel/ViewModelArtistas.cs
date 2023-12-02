using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TiendaVinilos.Presentacion;
using TiendaVinilos.Presentacion.Páginas;

namespace TiendaVinilos.ViewModel
{
    internal class ViewModelArtistas :ViewModelBase
    {
        private ArtistasPage artistasPage;
        public ViewModelArtistas(ArtistasPage artistasPage) {
            this.artistasPage = artistasPage;
            //Grid panel = (Grid)artistasPage.GetChildObjects().First();
            ListView panel = (ListView)artistasPage.GetChildObjects().First();
            int i = 0;
            while (i < 23)
            {
                panel.Items.Add(new ArtistaControl());
                //panel.Children.Add(new ArtistaControl());
                i++;
                //ArtistaControl artistaControl = new ArtistaControl();
                //Grid.SetColumn(artistaControl,(i%4));
                //panel.Children.Add(artistaControl);
                //i++;
                //if (i % 4 == 0)
                //{
                //    RowDefinition fila = new RowDefinition();
                //    fila.Height = new GridLength(250);
                //    panel.RowDefinitions.Add(fila);
                //}
            }
        }

    }
}
