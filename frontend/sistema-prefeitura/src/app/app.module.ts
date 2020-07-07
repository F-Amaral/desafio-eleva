import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EscolasComponent } from './pages/escolas/escolas.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HttpClientModule } from '@angular/common/http';
import { ExternalApiComponent } from './components/external-api/external-api.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon'; 
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table'; 
import {MatCardModule} from '@angular/material/card'; 
import {MatTooltipModule} from '@angular/material/tooltip';
import { EscolasDetalhesComponent } from './pages/escolas-detalhes/escolas-detalhes.component'; 
import {MatGridListModule} from '@angular/material/grid-list';
import { BotaoFlutuanteComponent } from './components/botao-flutuante/botao-flutuante.component';
import {MatDialogModule} from '@angular/material/dialog'; 
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input'; 
import {MatDividerModule} from '@angular/material/divider'; 
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatMenuModule} from '@angular/material/menu'; 
import {MatSortModule} from '@angular/material/sort';
import { AlunosComponent } from './pages/alunos/alunos.component';
import { ProfessoresComponent } from './pages/professores/professores.component';
import { TabelaAlunosComponent } from './components/tabela-alunos/tabela-alunos.component';
import { CardComponent } from './components/card/card.component';
import { TabelaProfessoresComponent } from './components/tabela-professores/tabela-professores.component';
import { AlunoModalComponent } from './components/aluno-modal/aluno-modal.component';
import { ProfessorModalComponent } from './components/professor-modal/professor-modal.component';
import { DisciplinasComponent } from './pages/disciplinas/disciplinas.component';
import { TurmasComponent } from './pages/turmas/turmas.component';
import { TabelaDisciplinasComponent } from './components/tabela-disciplinas/tabela-disciplinas.component';
import { TabelaTurmasComponent } from './components/tabela-turmas/tabela-turmas.component';
import { EscolaModalComponent } from './components/escola-modal/escola-modal.component';
import { TabelaEscolasComponent } from './components/tabela-escolas/tabela-escolas.component';
import { DisciplinaModalComponent } from './components/disciplina-modal/disciplina-modal.component';
import {MatSelectModule} from '@angular/material/select'; 
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { TurmaModalComponent } from './components/turma-modal/turma-modal.component'; 
import {BreadcrumbModule} from 'angular-crumbs';
import { DetalhesTurmasComponent } from './pages/detalhes-turmas/detalhes-turmas.component';
import { LoadingComponent } from './components/loading/loading.component';
import { TurmaAlunoModalComponent } from './components/turma-aluno-modal/turma-aluno-modal.component';
import { TurmaDisciplinaModalComponent } from './components/turma-disciplina-modal/turma-disciplina-modal.component';
import { FormAlunoComponent } from './components/forms/form-aluno/form-aluno.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { FormDisciplinaComponent } from './components/forms/form-disciplina/form-disciplina.component';
import { HomeComponent } from './pages/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    EscolasComponent,
    NavBarComponent,
    ProfileComponent,
    ExternalApiComponent,
    EscolasDetalhesComponent,
    AlunosComponent,
    BotaoFlutuanteComponent,
    EscolaModalComponent,
    ProfessoresComponent,
    DisciplinasComponent,
    TurmasComponent,
    AlunoModalComponent,
    TabelaAlunosComponent,
    CardComponent,
    TabelaProfessoresComponent,
    ProfessorModalComponent,
    TabelaDisciplinasComponent,
    TabelaTurmasComponent,
    TabelaEscolasComponent,
    DisciplinaModalComponent,
    TurmaModalComponent,
    DetalhesTurmasComponent,
    LoadingComponent,
    TurmaAlunoModalComponent,
    TurmaDisciplinaModalComponent,
    FormAlunoComponent,
    FormDisciplinaComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    MatTooltipModule,
    MatGridListModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatProgressSpinnerModule,
    MatMenuModule,
    MatSortModule,
    MatSelectModule,
    MatAutocompleteModule,
    BreadcrumbModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
