using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TiendaVinilos.Presentacion;
using TiendaVinilos.ViewModel;

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindowCliente: Window
    {
        public MainWindowCliente()
        {
            InitializeComponent();
            VentanaAuxiliar();
        }
        public void VentanaAuxiliar()
        {
            // Create the application's main window
            var mainWindow = new System.Windows.Window();
            mainWindow.Title = "WrapPanel Sample";


            // Instantiate a new WrapPanel and set properties
            var myWrapPanel = new WrapPanel();
            //myWrapPanel.Background = System.Windows.Media.Brushes.Azure;
            myWrapPanel.Orientation = Orientation.Horizontal;
            myWrapPanel.HorizontalAlignment = HorizontalAlignment.Left;
            myWrapPanel.VerticalAlignment = VerticalAlignment.Top;
            int i = 1;
            var artistac= new ArtistaControl();
            artistac.Margin = new Thickness(10);
            // Add the buttons to the parent WrapPanel using the Children.Add method.
            myWrapPanel.Children.Add(artistac);
            artistac.DataContext = new ViewModelArtistaControl(i.ToString());
            artistac = new ArtistaControl();
            artistac.Margin = new Thickness(10);
            myWrapPanel.Children.Add(artistac);
            artistac = new ArtistaControl();
            artistac.Margin = new Thickness(10);
            myWrapPanel.Children.Add(artistac);
            artistac = new ArtistaControl();
            artistac.Margin = new Thickness(10);
            myWrapPanel.Children.Add(artistac);

            // Add the WrapPanel to the MainWindow as Content
            mainWindow.Content = myWrapPanel;
            mainWindow.Show();
        }
    }
}
