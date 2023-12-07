using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TiendaVinilos
{
    internal class DataContextMain: ViewModelBase
    {
        public DataContextMain()
        {
            Command= new RelayCommand(new Action<object>((o) => hacerAlgo()));
        }
        private ICommand command;
        private String texto;

        public ICommand Command { get => command; set => command = value; }
        public string Texto { get => texto;
            set
            {
                texto = value;
                OnPropertyChanged("Texto");
            }

        }

        private void hacerAlgo()
        {
        //    if (usuario.tipo == "Administrador")
        //    {
        //        MainWindowAdministrador ventana = new MainWindowAdministrador();
        //        ventana.Show();
        //    }
        //    else
        //    {
        //        MainWindowCliente ventana = new MainWindowCliente();
        //        ventana.show();
        //    }
        //}
    }
}
