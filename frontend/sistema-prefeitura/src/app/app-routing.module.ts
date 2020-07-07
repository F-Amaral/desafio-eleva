import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EscolasComponent } from './pages/escolas/escolas.component';
import { AuthGuard } from './guards/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './services/interceptor.service';
import { EscolasDetalhesComponent } from './pages/escolas-detalhes/escolas-detalhes.component';
import { AlunosComponent } from './pages/alunos/alunos.component';
import { ProfessoresComponent } from './pages/professores/professores.component';
import { DisciplinasComponent } from './pages/disciplinas/disciplinas.component';
import { TurmasComponent } from './pages/turmas/turmas.component';
import { DetalhesTurmasComponent } from './pages/detalhes-turmas/detalhes-turmas.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch:'full'},
  {
    path: 'escolas',
    component: EscolasComponent,
    canActivate: [AuthGuard],
    data: {
      breadcrumb: 'Escolas'
    },
    children: [
      {
        path: ':escolaId',
        component: EscolasDetalhesComponent,
        data: {
          breadcrumb: 'Escola'
        },
        children: [
          {
            path: 'alunos',
            component: AlunosComponent,
            data: {
              breadcrumb: 'Alunos'
            }
          },
          {
            path: 'professores',
            component: ProfessoresComponent,
            data: {
              breadcrumb: 'Professores'
            }
          },
          {
            path: 'disciplinas',
            component: DisciplinasComponent,
            data: {
              breadcrumb: 'Disciplinas'
            }
          },
          {
            path: 'turmas',
            component: TurmasComponent,
            data: {
              breadcrumb: 'Turmas'
            },
            children: [
              {
                path: ':turmaId',
                component: DetalhesTurmasComponent,
                data: {
                  breadcrumb: 'Turma'
                }
              }
            ]
          },
        ]
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ]
})
export class AppRoutingModule { }
