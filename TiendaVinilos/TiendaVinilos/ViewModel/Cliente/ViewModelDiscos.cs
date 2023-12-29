using System;
using System.Collections.Generic;
using System.Linq;
using TiendaVinilos.EntidadesAuxiliares;
using TiendaVinilos.Presentación.Páginas;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using TiendaVinilos.Presentación.Controles;



namespace TiendaVinilos.ViewModel.Cliente
{
    internal class ViewModelDiscos
    {
        private Entidades contexto;
        private DiscosClientePage pagina;
        private Usuario cliente;
        private List<GeneroSeleccion> todosGeneros;

        internal List<GeneroSeleccion> TodosGeneros { get => todosGeneros; set => todosGeneros = value; }

        private List<int> generosSeleccionados = new List<int>();
        private List<int> artistasSeleccionados = new List<int> { };
        private ListView panel;
        private List<Disco> discos;
        private List<string> rangoPrecios = new List<string> { "- 50 €", "50 - 100 €", "+ 100 €" };
        private int menor = 0;
        private int mayor = int.MaxValue;
        public List<ArtistaSeleccion> todosArtistas;
        public ViewModelDiscos(DiscosClientePage pagina, Entidades contexto, Usuario cliente)
        {
            this.pagina = pagina;
            this.contexto = contexto;
            this.cliente = cliente;
            todosGeneros = (from g in contexto.Genero select new GeneroSeleccion() { Genero = g }).ToList();
            todosArtistas = (from a in contexto.Artista select new ArtistaSeleccion() { Artista = a}).ToList();
            panel = this.pagina.Tabla;
            foreach (GeneroSeleccion generoSeleccion in TodosGeneros)
            {
                var check = new CheckBox();
                check.Content = generoSeleccion.Genero.nombre;
                check.IsChecked = generoSeleccion.Seleccionado;
                check.Checked += generocheckeado;
                check.Unchecked += generouncheckeado;
                this.pagina.Generos.Items.Add(check);

            }

            foreach (string precio in rangoPrecios) { 
                var radButton = new RadioButton();
                radButton.Content = precio;
                radButton.Checked += RadButton_Checked;
                radButton.GroupName = "precios";
                this.pagina.Precios.Items.Add(radButton);
            }
            foreach(ArtistaSeleccion artistaSeleccion in todosArtistas)
            {
                var check = new CheckBox();
                check.Content = artistaSeleccion.Artista.nombre;
                check.IsChecked = artistaSeleccion.Seleccionado;
                check.Checked += artistacheckeado;
                check.Unchecked += artistauncheckeado;
                this.pagina.Artistas.Items.Add(check);

            }

            discos = (from d in contexto.Disco select d).ToList();
            //var presio = discos.First().Promocion.First().descuento;
            mostrarDiscos();
        }

        private void RadButton_Checked(object sender, RoutedEventArgs e)
        {
            int posicion = rangoPrecios.IndexOf(((RadioButton)sender).Content.ToString());
            
            var texto = rangoPrecios[posicion];
            switch (posicion)
            {
                case 0:
                    int inicio = texto.IndexOf("-") + 2;
                    int fin = texto.IndexOf("€") - 1;
                    texto = texto.Substring(inicio , fin-inicio);
                    mayor = int.Parse(texto);
                    menor = 0;
                    break;
                case 1:
                    var textoMenor = texto.Substring(0,texto.IndexOf(" "));
                    menor = int.Parse(textoMenor);
                    inicio = texto.IndexOf("-") + 2;
                    fin = texto.IndexOf("€") - 1;
                    texto = texto.Substring(inicio, fin-inicio);
                    mayor = int.Parse(texto);
                    break;
                case 2:
                    inicio = texto.IndexOf(" ") + 1;
                    fin = texto.IndexOf("€")-1;
                    texto = texto.Substring(inicio, fin-inicio);
                    menor = int.Parse(texto);
                    mayor = int.MaxValue;
                    break;
            }
            mostrarDiscos();
            //discos = (from d in contexto.Disco where d.precio>=menor && d.precio<=mayor select d).ToList();
        }

        private void mostrarDiscos() {
            panel.Items.Clear();
            List<Disco> discos;
            if (generosSeleccionados.Count > 0)
                discos = (from d in contexto.Disco from g in generosSeleccionados where d.idGenero == g && d.precio >= menor && d.precio <= mayor select d).ToList();
            else
                discos = (from d in contexto.Disco where d.precio >= menor && d.precio <= mayor select d).ToList();
            if (artistasSeleccionados.Count > 0)
                discos = (from d in discos from a in artistasSeleccionados where d.idArtista == a select d).ToList();
            foreach (var disc in discos)
                {
                    DiscoControl discoControl = new DiscoControl();
                    discoControl.MouseEnter += DiscoControl_MouseEnter;
                    discoControl.MouseLeave += DiscoControl_MouseLeave;
                    discoControl.DataContext = new ViewModelDiscoControl(disc);
                    panel.Items.Add(discoControl);
                }
        }

        private void DiscoControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ((DiscoControl)sender).Cursor = Cursors.Arrow;
        }

        private void DiscoControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ((DiscoControl)sender).Cursor = Cursors.Hand;
        }

        private void generocheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = true;
            generosSeleccionados.Add(seleccionado.Genero.idGenero);
            //panel.Items.Clear();
            mostrarDiscos();
        }
        private void generouncheckeado(object sender, EventArgs e)
        {
            string genero = ((CheckBox)sender).Content.ToString();
            GeneroSeleccion seleccionado = (from s in todosGeneros where s.Genero.nombre == genero select s).First();
            seleccionado.Seleccionado = false;
            generosSeleccionados.Remove(seleccionado.Genero.idGenero);
            mostrarDiscos();
        }
        private void artistacheckeado(object sender, EventArgs e) {
            string artista = ((CheckBox)sender).Content.ToString();
            ArtistaSeleccion seleccionado = (from s in todosArtistas where s.Artista.nombre == artista select s).First();
            seleccionado.Seleccionado = true;
            artistasSeleccionados.Add(seleccionado.Artista.idArtista);
            mostrarDiscos();

        }
        private void artistauncheckeado(object sender, EventArgs e) {
            string artista = ((CheckBox)sender).Content.ToString();
            ArtistaSeleccion seleccionado = (from s in todosArtistas where s.Artista.nombre == artista select s).First();
            seleccionado.Seleccionado = false;
            artistasSeleccionados.Remove(seleccionado.Artista.idArtista);
            mostrarDiscos();
        }
    }
   
    public class ViewModelDiscoControl : ViewModelBase
    {
        private ICommand verDisco;
        private ICommand comprarDiscoCommand;
        private ICommand anadirDeseoCommand;
        private Disco disco;
        private string imagenDisco;
        private double precio;
        public ViewModelDiscoControl(Disco Disco)
        {
            disco = Disco;
            var imagen = disco.ImagenDisco.FirstOrDefault();
            if (imagen != null)
                imagenDisco = imagen.enlace;
            if (imagenDisco == null)
                imagenDisco = "/Presentación/Imágenes/Imagen_no_disponible.png";
            else Console.WriteLine(imagenDisco);
            var descuento = (from p in disco.Promocion select p).FirstOrDefault();
            double cantidad = 100;
            if (descuento != null)
                cantidad = descuento.descuento;
            precio = disco.precio.Value * cantidad/100;
            VerDisco = new RelayCommand(new Action<object>((o) => mostrarDisco()));
            ComprarDiscoCommand = new RelayCommand(new Action<object>((o)=> comprarDisco()));
            AnadirDeseoCommand = new RelayCommand(new Action<object>((o)=> annadirDeseo()));

        }
        public Disco Disco { get { return disco; } }
        public ICommand VerDisco { get => verDisco; set => verDisco = value; }
        public ICommand ComprarDiscoCommand { get => comprarDiscoCommand; set => comprarDiscoCommand = value; }
        public ICommand AnadirDeseoCommand { get => anadirDeseoCommand; set => anadirDeseoCommand = value; }
        public string ImagenDisco { get => imagenDisco; set => imagenDisco = value; }
        public double Precio { get => precio; set => precio = value; }

        private void mostrarDisco()
        {
            // Mostrar página del disco seleccionado
            MessageBox.Show(disco.titulo);
        }
        private void comprarDisco()
        {
            //Mandar al formulario de compra con los discos de la cesta
        }
        private void annadirDeseo()
        {
            //Mostrar mensaje afirmando que se ha añadido
        }
    }
}
