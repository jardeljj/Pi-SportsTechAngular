using System;
using System.Collections.Generic;


namespace WebAPI.Models{
public class Departamento{

	public int id { get; set; }

    public string nome { get; set; }

    public string marca { get; set; }

	public string tamanho { get; set; }

	public string cor { get; set; }

	public double preco { get; set; }

    public int qtd { get; set; }


    public string status { get; set; }



	

	public Departamento(){ }

        public Departamento(int id, string nome, string marca, string tamanho, string cor, double preco, int qtd, string status)
        {
            this.id = id;
            this.nome = nome;
            this.marca = marca;
            this.tamanho = tamanho;
            this.cor = cor;
            this.preco = preco;
            this.qtd = qtd;
            this.status = status;
     
        }
    }
}