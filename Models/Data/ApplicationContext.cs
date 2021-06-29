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
    public class ApplicationContext : IdentityDbContext<User>
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

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.Entity<Product>().HasKey(k => k.idProduct);
            modelBuilder.Entity<Product>()
            .HasMany(ag => ag.AtributeValues)
            .WithOne(atr => atr.product).OnDelete(DeleteBehavior.Cascade);   
            modelBuilder.Entity<Product>()
            .HasMany(art => art.Articles)
            .WithOne(atr => atr.product).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupType>().HasKey(k => k.idGroupType);
            modelBuilder.Entity<GroupType>()
            .HasMany(ag => ag.atributesGroups)
            .WithOne(gt => gt.GroupType).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AtributesGroup>().HasKey(k => k.idAtrbutesGroup);
            modelBuilder.Entity<AtributesGroup>()
            .HasMany(ag => ag.atributes)
            .WithOne(atr => atr.AtributesGroup).OnDelete(DeleteBehavior.Cascade);

             modelBuilder.Entity<Atribute>().HasKey(k => k.idAtribute);
            modelBuilder.Entity<Atribute>()
            .HasMany(ag => ag.AtributeValues)
            .WithOne(atr => atr.atribute).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AtributeValue>().HasKey(k => new{k.idAtribute, k.normalizedValue});
            modelBuilder.Entity<AtributeValue>()
            .HasMany(ag => ag.childrens)
            .WithOne(atr => atr.parent).OnDelete(DeleteBehavior.NoAction);
            
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
            .HasMany(com => com.comments)
            .WithOne(art => art.Article).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>().HasKey(k => new { k.idComment, k.idArticle, k.idUser });

            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<User>()
            .HasMany(com => com.Comments)
            .WithOne(u => u.User).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
            .HasMany(art => art.Articles)
            .WithOne(u => u.user).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
