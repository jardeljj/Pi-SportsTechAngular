import { Departamento } from './../models/Departamento';
import { DepartamentoService } from './Departamento.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.css']
})
export class DepartamentosComponent implements OnInit {

  public departamentoForm: FormGroup;
  public departamentoSelecionado: Departamento;
  public departamentos:  Departamento[];

  constructor(private fb: FormBuilder, 
              private departamentoService: DepartamentoService) {
    this.criarform();

   }

  ngOnInit(): void {
     this.carregarDados();
  }

  //Lista

  carregarDados(){
    this.departamentoService.Getter().subscribe(
      (departamentos: Departamento[]) => {
        this.departamentos = departamentos;
      },
      (erro:any) => {
        console.error(erro);
      }
    )
  }
  
  //Formulario

  criarform(){
    this.departamentoForm = this.fb.group({
      id:[''],
      nome:[''],
      sigla:['']
    });
  }

  departamentoSelect(departamento: Departamento){
    this.departamentoSelecionado = departamento;
    this.departamentoForm.patchValue(departamento);

  }


  //Alterar

  salvarDepartamento(departamento: Departamento){
    if(departamento.id == 0){
      this.departamentoService.Post(departamento).subscribe(
        (departamento: Departamento) => {
          console.log(departamento);
          this.voltar();
          this.carregarDados();
        },
        (erro: any) => {
          console.log(erro);
        }     
        
      );
    }else{
    this.departamentoService.Put(departamento.id, departamento).subscribe(
      (departamento: Departamento) => {
        console.log(departamento);
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
    this.salvarDepartamento(this.departamentoForm.value);
  }


  //Adcionar

  addDepartamento(){
    this.departamentoSelecionado = new Departamento();
    this.departamentoForm.patchValue(this.departamentoSelecionado);
  }

  
  //Voltar

  voltar(){
    this.departamentoSelecionado = null;
  }

  //Deletar
  deletar(id: number){
    this.departamentoService.Delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarDados();
      },
      (erro: any) => {
        console.error(erro);
      }      
    );
  }
  
}
