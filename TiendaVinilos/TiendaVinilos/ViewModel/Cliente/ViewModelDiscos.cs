using System;
using System.Collections.Generic;
using System.Linq;
using TiendaVinilos.EntidadesAuxiliares;
using TiendaVinilos.Presentación.Páginas;
using System.Windows.Controls;
using TiendaVinilos.Presentacion;
using TiendaVinilos.ViewModelCliente;
using System.Windows.Input;
using System.Windows;



namespace TiendaVinilos.ViewModel.Cliente
{
    internal class ViewModelDiscos
    {
        private Entidades contexto;
        private DiscosClientePage pagina;
        private Usuario cliente;
        private List<GeneroSeleccion> todosGeneros;

        internal List<GeneroSeleccion> TodosGeneros { get => todosGeneros; set => todosGeneros = value; }

        private List<GeneroSeleccion> generosSeleccionados = new List<GeneroSeleccion>();
        private ListView panel;

        //public List<ArtistaSeleccion> todosArtistas;
        public ViewModelDiscos(DiscosClientePage pagina, Entidades contexto, Usuario cliente)
        {
            this.pagina = pagina;
            this.contexto = contexto;
            this.cliente = cliente;
            todosGeneros = (from g in contexto.Genero select new GeneroSeleccion() { Genero = g }).ToList();
            panel = this.pagina.Tabla;
            foreach (GeneroSeleccion generoSeleccion in TodosGeneros)
            {
                var check = new CheckBox();
                check.Content = generoSeleccion.Genero.nombre;
                check.IsChecked = generoSeleccion.Seleccionado;
                check.Checked += controlcheckeado;
                check.Unchecked += controluncheckeado;
                this.pagina.Generos.Items.Add(check);
            }
        }
        private void mostrarDiscos() { }
        private void controlcheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = true;
            generosSeleccionados.Add(seleccionado);
            panel.Items.Clear();
            //var discos = (from d in todosDiscos join g in generosSeleccionados on d.Genero.idGenero equals g.Genero.idGenero select a).ToList();
            //foreach (var disc in discos)
            //{
            //    DiscoControl discoControl = new DiscoControl();
            //    discoControl.DataContext = new ViewModelDiscoControl(disc);
            //    panel.Items.Add(discoControl);
            //}
        }
        private void controluncheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = false;
            generosSeleccionados.Remove(seleccionado);
            panel.Items.Clear();
            if (generosSeleccionados.Count > 0)
            {
                //var discos = (from d in todosDiscos join g in generosSeleccionados on d.Genero.idGenero equals g.Genero.idGenero select a).ToList();
                //foreach (var disc in discos)
                //{
                //    DiscoControl discoControl = new DiscoControl();
                //    discoControl.DataContext = new ViewModelDiscoControl(disc);
                //    panel.Items.Add(discoControl);
                //}
            }
            else
                mostrarDiscos();
        }
    }
    public class ViewModelDiscoControl : ViewModelBase
    {
        private ICommand verDisco;
        private Disco disco;
        private string imagenDisco;
        public ViewModelDiscoControl(Disco Disco)
        {
            disco = Disco;
            var imagen = disco.ImagenDisco.FirstOrDefault();
            if (imagen != null)
                imagenDisco = imagen.enlace;
            if (imagenDisco == null)
                imagenDisco = "/Presentación/Imágenes/Imagen_no_disponible.png";
            VerDisco = new RelayCommand(new Action<object>((o) => mostrarDisco()));
        }
        public Disco Disco { get { return disco; } }
        public ICommand VerDisco { get => verDisco; set => verDisco = value; }
        public string ImagenArtista { get => imagenDisco; set => imagenDisco = value; }

        private void mostrarDisco()
        {
            MessageBox.Show(disco.titulo);
        }
    }
}
