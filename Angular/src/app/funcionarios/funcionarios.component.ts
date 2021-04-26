import { Departamento } from './../models/Departamento';
import { HttpClient } from '@angular/common/http';
import { FuncionarioService } from './funcionario.service';
import { Funcionario } from './../models/Funcionario';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-funcionarios',
  templateUrl: './funcionarios.component.html',
  styleUrls: ['./funcionarios.component.css']
})
export class FuncionariosComponent implements OnInit {

  public funcionarioForm: FormGroup;
  public imgUrl: string ="/assets/img/download.png";
  public funcionarioSelecionado: Funcionario;
  public funcionarios:  Funcionario[];
  public departamento: Departamento[];
  public AquivoUpload: File = null;

  constructor(private fb: FormBuilder, 
              private funcionarioService: FuncionarioService,
              private http:HttpClient) {
    this.criarform();

   }

  ngOnInit(): void {
     this.carregarDados();
  }

  //Lista

  carregarDados(){
    this.funcionarioService.Getter().subscribe(
      (funcionarios: Funcionario[]) => {
        this.funcionarios = funcionarios;
      },
      (erro:any) => {
        console.error(erro);
      }
    )
  }
  
  //Formulario

  criarform(){
    this.funcionarioForm = this.fb.group({
      id:[''],
      nome:[''],
      rg:[''],
      foto:[''],
      departamentoId:['']
    });
  }

  funcionarioSelect(funcionario: Funcionario){
    this.funcionarioSelecionado = funcionario;
    this.funcionarioForm.patchValue(funcionario); 

  }


  /*Post Cria
    Put Altera  
  */
  salvarFuncionario(funcionario: Funcionario){
    if(funcionario.id == 0){
      this.funcionarioService.Post(funcionario).subscribe(
        (funcionario: Funcionario) => {
          console.log(funcionario);
          this.voltar();
          this.carregarDados();
        },
        (erro: any) => {
          console.log(erro);
        }     
        
      );
    }else{
    this.funcionarioService.Put(funcionario.id, funcionario).subscribe(
      (funcionario: Funcionario) => {
        console.log(funcionario);
        this.voltar();
        this.carregarDados();
      },
      (erro: any) => {
        console.log(erro);
      }     
    
    );
  }

  }

  enviar(){
    this.salvarFuncionario(this.funcionarioForm.value);
  }


  //Adcionar

  addFuncionario(){ 
    this.funcionarioSelecionado = new Funcionario;
    this.funcionarioForm.patchValue(this.funcionarioSelecionado);
  }

  
  //Voltar

  voltar(){
    this.funcionarioSelecionado = null;
  }

  deletar(id: number){
    this.funcionarioService.Delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarDados();
      },
      (erro: any) => {
        console.error(erro);
      }      
    );
  }

  PreviewImagem(file: FileList){
    this.AquivoUpload = file.item(0);

    var reader = new FileReader();
    reader.onload = (event:any) =>{
      this.imgUrl = event.target.result;
    }
    reader.readAsDataURL(this.AquivoUpload);

  }

}