using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;



namespace WebAPI.Data{
public class DataContext : DbContext
	{

	 public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-6JIGCVA\kinha;Initial Catalog=Departamento;Data Source=DESKTOP-6JIGCVA");
    }

    protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Administrativo","SP"),
                    new Departamento(2, "Financeiro","SP"),
                    new Departamento(3, "Recursos Humanos","SP"),
                    new Departamento(4, "Departamento Comercial","SP"),
                });
            
            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>{
                    new Funcionario(1, "Marcos","Enviar","11554454x",3),
                    new Funcionario(2, "João","Enviar","81584454x",2),
                    new Funcionario(3, "Clara","Enviar","31759454x",1),
                    new Funcionario(4, "Matheus","Enviar","51534454x",4),
                    new Funcionario(5, "Maria","Enviar","11254464x",3)
                });
		}
	}

}