using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TiendaVinilos
{
    internal class LoginViewModel:ViewModelBase
    {

        private TiendaVinilosEntities contexto = new TiendaVinilosEntities();
        private string nombre;
        private ICommand accederCommand;
        private LoginWindow loginWindow;
        public LoginViewModel(LoginWindow ventana)
        {
            AccederCommand = new RelayCommand(new Action<object>((o) => acceder()));
            loginWindow = ventana;
        }
        public ICommand AccederCommand { get => accederCommand; set => accederCommand = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        private void acceder()
        {
            var clave = loginWindow.contaseña.Password;
            Usuario usuario= (from u in contexto.Usuario where u.nombre== nombre && u.contraseña== clave select u).FirstOrDefault();
            if (usuario != null)
            {
                if (usuario.tipo == "Administrador")
                    new MainWindowAdministrador().Show();
                else
                    new MainWindowCliente().Show();
                loginWindow.Close();
            }
            else
                MessageBox.Show("No hay ningún usuario con ese nombre o contraseña","Credenciales incorrectas", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}

