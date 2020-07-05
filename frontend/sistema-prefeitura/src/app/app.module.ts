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

@NgModule({
  declarations: [
    AppComponent,
    EscolasComponent,
    NavBarComponent,
    ProfileComponent,
    ExternalApiComponent,
    EscolasDetalhesComponent,
    AlunosComponent
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
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
