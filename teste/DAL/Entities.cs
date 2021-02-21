namespace teste.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Web;
    using teste.Models;

    public partial class TesteConnectionString : DbContext
    {

        public TesteConnectionString() : base("TesteConnectionString") { }

        public virtual DbSet<Carro> Carro { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Peca> Peca { get; set; }
        public virtual DbSet<Mensageria> Mensageria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}