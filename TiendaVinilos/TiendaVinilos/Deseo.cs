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
    
    public partial class Deseo
    {
        public int idDeseo { get; set; }
        public int idDisco { get; set; }
        public int idUsuario { get; set; }
    
        public virtual Disco Disco { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
