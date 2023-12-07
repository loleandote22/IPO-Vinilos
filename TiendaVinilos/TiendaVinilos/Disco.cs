//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaVinilos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disco
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disco()
        {
            this.Cancion = new HashSet<Cancion>();
            this.ComentarioDisco = new HashSet<ComentarioDisco>();
            this.Deseo = new HashSet<Deseo>();
            this.ElementoPedido = new HashSet<ElementoPedido>();
            this.ElementoCesta = new HashSet<ElementoCesta>();
            this.ImagenDisco = new HashSet<ImagenDisco>();
        }
    
        public int idDisco { get; set; }
        public string titulo { get; set; }
        public string portada { get; set; }
        public string discografica { get; set; }
        public string formato { get; set; }
        public string pais { get; set; }
        public System.DateTime publicacion { get; set; }
        public Nullable<int> idGenero { get; set; }
        public Nullable<int> favoritos { get; set; }
        public Nullable<int> criticos { get; set; }
        public Nullable<int> unidades { get; set; }
        public Nullable<int> idArtista { get; set; }
    
        public virtual Artista Artista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancion> Cancion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComentarioDisco> ComentarioDisco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deseo> Deseo { get; set; }
        public virtual Genero Genero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementoPedido> ElementoPedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ElementoCesta> ElementoCesta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagenDisco> ImagenDisco { get; set; }
    }
}
