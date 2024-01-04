using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using TiendaVinilos.Presentación.Controles;
using TiendaVinilos.Presentación.Ventanas;
using TiendaVinilos.ViewModelCliente;

namespace TiendaVinilos
{
    public class ViewModelLogin:ViewModelBase
    {

        private Entidades contexto = new Entidades();
        private string nombre;
        private ICommand accederCommand;
        private LoginWindow loginWindow;
        public ViewModelLogin(LoginWindow ventana)
        {
            AccederCommand = new RelayCommand(new Action<object>((o) => acceder()));
            loginWindow = ventana;
        }
        public ICommand AccederCommand { get => accederCommand; set => accederCommand = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        private void acceder()
        {
            var clave = loginWindow.contaseña.Password;
            Usuario usuario = null;
            LoadingControl loginControl = new LoadingControl();
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = loginControl.Background;
            Grid.SetColumn(rectangle, 1);
            Grid.SetColumn(loginControl, 1);
            loginWindow.panel.Children.Add(loginControl);
            try
            {
                usuario = (from u in contexto.Usuario where u.nombre == nombre && u.contraseña == clave select u).FirstOrDefault();
                rectangle.Visibility = Visibility.Collapsed;
                loginControl.Visibility = Visibility.Collapsed;
                if (usuario != null)
                {
                    TarjetaBienvenidaWindow tarjeta = new TarjetaBienvenidaWindow();
                    tarjeta.DataContext = new ViewModelBienvenida(tarjeta, this, usuario);
                    tarjeta.Show();
                  
                }
                else
                    MessageBox.Show("No hay ningún usuario con ese nombre o contraseña", "Credenciales incorrectas", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Data.Entity.Core.EntityException e ) { Console.WriteLine(e.Message); MessageBox.Show("No tienes conexión a Internet"); }
            
           }
        public void accederApp(Usuario usuario)
        {
            usuario.conexion = DateTime.Now;
            contexto.SaveChanges();
            if (usuario.tipo == "Administrador")
                new MainWindowAdministrador().Show();
            else
            {
                MainWindowCliente ventana = new MainWindowCliente();
                ventana.DataContext = new ViewModelMain(usuario, contexto);
                ventana.Show();
                ventana.Topmost=true;
            }
            loginWindow.Close();
        }
    }
    public  class ViewModelBienvenida : ViewModelBase
    {
        private TarjetaBienvenidaWindow ventana;
        private ViewModelLogin viewModel;
        private string bienvenidaUsuario;
        private string modoAcceso;
        private string fecha;
        private string imagen;
        private ICommand continuarCommand;
        private Usuario usuario;
        public ViewModelBienvenida(TarjetaBienvenidaWindow tarjeta, ViewModelLogin viewModel, Usuario usuario)
        {
            ventana = tarjeta;
            this.viewModel = viewModel;
            this.usuario= usuario;
            BienvenidaUsuario = "Hola " + usuario.nombre;
            ModoAcceso ="Has accedido como "+ usuario.tipo;
            Imagen = usuario.imagen;
            DateTime? ultimoAcceso = usuario.conexion;
            Console.WriteLine(usuario.conexion);
            if (usuario.conexion.HasValue)
                Fecha = ultimoAcceso.Value.ToString("dd/MM/yy HH:mm");
            else
                Fecha = "Es tu primer acceso, bienvenido";
            ContinuarCommand = new RelayCommand(new Action<object>((o) => continuar()));
        }

        public string BienvenidaUsuario { get => bienvenidaUsuario; set { bienvenidaUsuario = value; OnPropertyChanged("BienvenidaUsuario"); } }
        public string ModoAcceso { get => modoAcceso; set { modoAcceso = value; OnPropertyChanged("ModoAcceso"); } }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        public ICommand ContinuarCommand { get => continuarCommand; set => continuarCommand = value; }
        private void continuar()
        {
            ventana.Close();
            viewModel.accederApp(usuario);
        }
    }
}

