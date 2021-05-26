using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProductsReviewsAngular.Models.Configurations;

namespace ProductsReviewsAngular.Models
{
    public class AppContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<AtributesGroup> AtributesGroups { get; set; }
        public DbSet<Atribute> Atributes { get; set; }
        public DbSet<AtributeValue> AtributeValues { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Alcohol> Alcohols { get; set; }
        //public DbSet<AlcoholCharacteristics> AlcoholCharacteristics { get; set; }
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<Product>().HasKey(k => k.idProduct);            
            modelBuilder.Entity<Product>()
            .HasMany(ag => ag.AtributeValues)
            .WithOne(atr => atr.Product).OnDelete(DeleteBehavior.NoAction);   
            modelBuilder.Entity<Product>()
            .HasMany(art => art.Articles)
            .WithOne(atr => atr.Product).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupType>().HasKey(k => k.idGroupType);
            modelBuilder.Entity<GroupType>()
            .HasMany(ag => ag.atributesGroups)
            .WithOne(gt => gt.GroupType).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<GroupType>().HasMany(ag => ag.atributesGroups).WithOne(gt => gt.GroupType).HasForeignKey(k => k.idGroupType);
            //modelBuilder.Entity<GroupType>().HasMany(p => p.Products).WithOne(gt => gt.GroupType).HasForeignKey(k => k.idGroupType);
            modelBuilder.Entity<AtributesGroup>().HasKey(k => k.idAtrbutesGroup);
            modelBuilder.Entity<AtributesGroup>()
            .HasMany(ag => ag.atributes)
            .WithOne(atr => atr.AtributesGroup).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<AtributesGroup>().HasMany(a => a.atributes).WithOne(ag => ag.AtributesGroup).HasForeignKey(k => k.idAtrbutesGroup);
            modelBuilder.Entity<Atribute>().HasKey(k => k.idAtribute);
            modelBuilder.Entity<Atribute>()
            .HasMany(ag => ag.AtributeValues)
            .WithOne(atr => atr.Atribute).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Atribute>().HasMany(av => av.AtributeValues).WithOne(a => a.Atribute).HasForeignKey(k => k.idAtribute);
            //modelBuilder.Entity<AtributeValue>().HasKey(k => k.idAtributeValue);
            modelBuilder.Entity<AtributeValue>().HasKey(k => new{k.idAtribute, k.value});
            modelBuilder.Entity<AtributeValue>()
            .HasMany(ag => ag.Childrens)
            .WithOne(atr => atr.Parent).OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Country>().HasKey(k => k.idCountry);
            modelBuilder.Entity<Country>()
            .HasMany(pr => pr.Producers)
            .WithOne(co => co.Country).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producer>().HasKey(k => k.idProducer);            
            modelBuilder.Entity<Producer>()
            .HasMany(pr => pr.Products)
            .WithOne(prod => prod.Producer).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>().HasKey(k => k.idArticle);    
            modelBuilder.Entity<Article>()
            .HasMany(com => com.Comments)
            .WithOne(art => art.Article).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>().HasKey(k => new { k.idComment, k.idArticle, k.idUser });

            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<User>()
            .HasMany(com => com.Comments)
            .WithOne(u => u.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
            .HasMany(art => art.Articles)
            .WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);

            //modelBuilder
            //    .Entity<Product>()
            //    .HasMany(c => c.Atributes)
            //    .WithMany(s => s.Products)
            //    .UsingEntity<AtributeValue>(
            //        pa =>
            //        pa.HasOne(p => p.Atribute)
            //        .WithMany(av => av.AtributeValues)
            //        .HasForeignKey(p => p.idAtribute),
            //        pa =>
            //        pa.HasOne(av => av.Product)
            //        .WithMany(p => p.AtributeValues)
            //        .HasForeignKey(av => av.idProduct),
            //        pa =>
            //        {
            //            pa.Property(v => v.value).HasDefaultValue("value");
            //            pa.HasKey(k => new { k.idAtribute, k.idProduct });
            //            pa.ToTable("AtributeValue");
            //        }
            //    );

            //modelBuilder.Entity<Alcohol>()
            //    .HasKey(k => k._alcID);
            //modelBuilder.Entity<AlcoholCharacteristics>()
            //    .HasKey(k => k.id);

            //modelBuilder
            //    .Entity<Alcohol>()
            //    .HasMany(c => c._alcoholCharacteristics)
            //    .WithMany(s => s._alcohols)
            //    .UsingEntity<AlcoholCharacteristicValue>(
            //        acv =>
            //        acv.HasOne(pt => pt._AlcoholCharacteristics)
            //        .WithMany(t => t._alcoholCharacteristicValues)
            //        .HasForeignKey(pt => pt._alcCharacteristicID),
            //        acv =>
            //        acv.HasOne(pt => pt._Alcohol)
            //       .WithMany(p => p._alcoholCharacteristicValues)
            //      .HasForeignKey(pt => pt._alcID),
            //        j =>
            //        {
            //            j.Property(pt => pt._value);
            //            j.HasKey(t => new { t._alcID, t._alcCharacteristicID });
            //            j.ToTable("AlcoholCharacteristicValue");
            //        });
        }
    }
}
