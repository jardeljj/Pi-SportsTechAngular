using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;



namespace WebAPI.Data{
public class DataContext : DbContext
	{

	 public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
             public DbSet<Departamento> Departamento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-6JIGCVA\kinha;Initial Catalog=Pi-4;Data Source=DESKTOP-6JIGCVA");
    }

    protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Chuteira","Nike","35","azul",199.99,35,"ativo"),

                });

		}
	}

}