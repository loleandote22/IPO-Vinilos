﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiendaVinilosEntities : DbContext
    {
        public TiendaVinilosEntities()
            : base("name=TiendaVinilosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Cancion> Cancion { get; set; }
        public virtual DbSet<ComentarioDisco> ComentarioDisco { get; set; }
        public virtual DbSet<Deseo> Deseo { get; set; }
        public virtual DbSet<Disco> Disco { get; set; }
        public virtual DbSet<Duda> Duda { get; set; }
        public virtual DbSet<ElementoPedido> ElementoPedido { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<ImagenArtista> ImagenArtista { get; set; }
        public virtual DbSet<ImagenDisco> ImagenDisco { get; set; }
        public virtual DbSet<Integrante> Integrante { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Tienda> Tienda { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ElementoCesta> ElementoCesta { get; set; }
    }
}
