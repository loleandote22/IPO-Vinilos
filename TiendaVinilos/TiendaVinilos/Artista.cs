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
    
    public partial class Artista
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artista()
        {
            this.Disco = new HashSet<Disco>();
            this.ImagenArtista = new HashSet<ImagenArtista>();
            this.Integrante = new HashSet<Integrante>();
        }
    
        public int idArtista { get; set; }
        public string nombre { get; set; }
        public System.DateTime inicio { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> idGenero { get; set; }
        public Nullable<int> favoritos { get; set; }
    
        public virtual Genero Genero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disco> Disco { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagenArtista> ImagenArtista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Integrante> Integrante { get; set; }
    }
}
