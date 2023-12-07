using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TiendaVinilos
{
    internal class LoginViewModel:ViewModelBase
    {
        public LoginViewModel()
        {
            AccederCommand = new RelayCommand(new Action<object>((o) => acceder()));
        }
        private ICommand accederCommand;
        public ICommand AccederCommand { get => accederCommand; set => accederCommand = value; }
        private void acceder()
        {
            MainWindowAdministrador ventana = new MainWindowAdministrador();
                    ventana.Show();
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
}
