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
import { AlunosComponent } from './pages/escolas-detalhes/components/alunos/alunos.component';
import { BotaoFlutuanteComponent } from './components/botao-flutuante/botao-flutuante.component';
import {MatDialogModule} from '@angular/material/dialog'; 
import {MatFormFieldModule} from '@angular/material/form-field';
import { EscolaModalComponent } from './pages/escolas/components/escola-modal/escola-modal.component'; 
import {MatInputModule} from '@angular/material/input'; 
import {MatDividerModule} from '@angular/material/divider'; 
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatMenuModule} from '@angular/material/menu'; 
import {MatSortModule} from '@angular/material/sort';
import { ProfessoresComponent } from './pages/escolas-detalhes/components/professores/professores.component';
import { DisciplinasComponent } from './pages/escolas-detalhes/components/disciplinas/disciplinas.component';
import { TurmasComponent } from './pages/escolas-detalhes/components/turmas/turmas.component';

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
    MatSortModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
