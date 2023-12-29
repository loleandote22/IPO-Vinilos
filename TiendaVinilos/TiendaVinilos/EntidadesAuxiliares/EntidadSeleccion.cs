namespace TiendaVinilos.EntidadesAuxiliares
{
    internal class GeneroSeleccion
    {
        private Genero genero;
        private bool seleccionado=false;
        public GeneroSeleccion() { }
        public GeneroSeleccion(Genero genero) { Genero = genero; }

        public bool Seleccionado { get => seleccionado; set => seleccionado = value; }
        public Genero Genero { get => genero; set => genero = value; }
    }
    public class ArtistaSeleccion
    {
        private Artista artista;
        private bool seleccionado= false;
        public ArtistaSeleccion() { }
        public ArtistaSeleccion(Artista artista) {  Artista = artista; }
        public bool Seleccionado { get => seleccionado;set => seleccionado = value;}
        public Artista Artista { get => artista; set => artista = value; }
    }
}
