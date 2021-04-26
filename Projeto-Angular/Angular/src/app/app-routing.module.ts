import { FuncionariosComponent } from './funcionarios/funcionarios.component';
import { DepartamentosComponent } from './departamentos/departamentos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [

  { path: 'departamentos', component: DepartamentosComponent },
  { path: 'funcionarios', component: FuncionariosComponent }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
