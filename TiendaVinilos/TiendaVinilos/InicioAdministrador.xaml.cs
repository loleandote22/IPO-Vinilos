using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class InicioAdministrador : Window
    {
    

        public InicioAdministrador()
        {
            InitializeComponent();
        }

        //botones de mas y menos
        private void BtnMas_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar más artistas al presionar el botón "Más"
            stackPanelArtistas.Children.Add(new TextBlock { Text = "Queen", Margin = new Thickness(2) });
            stackPanelArtistas.Children.Add(new TextBlock { Text = "Nirvana", Margin = new Thickness(2) });
            stackPanelArtistas.Children.Add(new TextBlock { Text = "Oasis", Margin = new Thickness(2) });

            btnMas.Visibility = Visibility.Collapsed;
            btnMenos.Visibility = Visibility.Visible;
            stackPanelArtistas.Visibility = Visibility.Visible;
        }

        private void BtnMenos_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar artistas adicionales al presionar el botón "Menos"
            while (stackPanelArtistas.Children.Count > 3)
            {
                stackPanelArtistas.Children.RemoveAt(stackPanelArtistas.Children.Count - 1);
            }

            btnMas.Visibility = Visibility.Visible;
            btnMenos.Visibility = Visibility.Collapsed;
        }


        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}