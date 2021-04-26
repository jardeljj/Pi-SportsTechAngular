import { environment } from './../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Departamento } from '../models/departamento';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {
  
  Url = `${environment.UrlPrincipal}/Departamento`;

  Getter(): Observable <Departamento[]>{
    return this.http.get<Departamento[]>(`${this.Url}`)
  }
  
  GetId(id: number): Observable<Departamento>{
    return this.http.get<Departamento>(`${this.Url}/${id}`)
  }

  Post(departamento: Departamento){
    return this.http.post<Departamento>(`${this.Url}`, departamento)

  }

  Put(id: number,departamento: Departamento){
    return this.http.put<Departamento>(`${this.Url}/${id}`,departamento)

  }

  Delete(id: number){
    return this.http.delete<Departamento>(`${this.Url}/${id}`)

  }
  
  constructor(private http: HttpClient) { }
}