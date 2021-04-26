import { environment } from './../../environments/environment';
import { Funcionario } from './../models/Funcionario';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {

  Url = `${environment.UrlPrincipal}/Funcionario`;

  Getter(): Observable <Funcionario[]>{
    return this.http.get<Funcionario[]>(`${this.Url}`)
  }
  
  GetId(id: number): Observable<Funcionario>{
    return this.http.get<Funcionario>(`${this.Url}/${id}`)
  }

  Post(funcionario: Funcionario){
    return this.http.post<Funcionario>(`${this.Url}`, funcionario)

  }

  Put(id: number, funcionario: Funcionario){
    return this.http.put<Funcionario>(`${this.Url}/${id}`, funcionario)

  }

  Delete(id: number){
    return this.http.delete<Funcionario>(`${this.Url}/${id}`)

  }
  
  constructor(private http: HttpClient) { }

  

}