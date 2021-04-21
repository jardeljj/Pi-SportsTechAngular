using System;
using System.Collections.Generic;


namespace WebAPI.Models{
public class Departamento{

	public int id { get; set; }

    public string nome { get; set; }

    public string sigla { get; set; }

	public IEnumerable<Funcionario> Funcionarios { get; set; }

	public Departamento(){ }

	public Departamento(int id, string nome, string sigla){
		this.id = id;
		this.nome = nome;
		this.sigla = sigla;
		}
}
}