import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EscolasComponent } from './pages/escolas/escolas.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from './guards/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './services/interceptor.service';
import { EscolasDetalhesComponent } from './pages/escolas-detalhes/escolas-detalhes.component';

const routes: Routes = [
  {path: 'escolas', component: EscolasComponent, canActivate: [AuthGuard]},
  {path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
  {path: 'escolas/:id', component:EscolasDetalhesComponent, canActivate:[AuthGuard]}
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
