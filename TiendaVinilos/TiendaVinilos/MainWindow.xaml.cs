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

namespace TiendaVinilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        internal class DataContextMain : ViewModelBase
        {
            public DataContextMain()
            {
                Command = new RelayCommand(new Action<object>((o) => hacerAlgo()));
            }
            private ICommand command;
            private String texto;

            public ICommand Command { get => command; set => command = value; }
            public string Texto
            {
                get => texto;
                set
                {
                    texto = value;
                    OnPropertyChanged("Texto");
                }

            }

            private void hacerAlgo()
            {
                MessageBox.Show("Bienvenido Alejandro");
            }
        }
    }
}
