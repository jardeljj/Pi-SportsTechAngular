using System;

namespace WebAPI.Models{
public class Funcionario{

    public int id { get; set; }

    public string nome { get; set; }

    public string foto { get; set; }

    public string RG { get; set; }    
    
    public int DepartamentoId { get; set; }
    
    public Departamento Departamento { get; set; }

    public Funcionario(){

    }

	public Funcionario(int id, string nome, string foto, string RG, int DepartamentoId)
    {
        this.id = id;
        this.nome = nome;
        this.foto = foto;
        this.RG = RG;
        this.DepartamentoId = DepartamentoId;

        }
}
}