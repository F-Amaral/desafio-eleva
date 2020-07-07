import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router, Event, RouterEvent } from '@angular/router';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Escola } from 'src/app/shared/models/Escola.model';
import { BreadcrumbService } from 'angular-crumbs';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-escolas-detalhes',
  templateUrl: './escolas-detalhes.component.html',
  styleUrls: ['./escolas-detalhes.component.scss']
})
export class EscolasDetalhesComponent implements OnInit {

  escola: Escola = new Escola();
  escolaId: string;
  public shouldLoadChildren: boolean = false;

  constructor(private route: ActivatedRoute, 
    private escolaService: EscolaService,
    private router:Router,
    private breadcrumbService: BreadcrumbService) {}

  ngOnInit(): void {
    this.getEscola();
  }
  
  getEscola() {
    this.escolaId = this.route.snapshot.params['escolaId'];
    this.shouldLoadChildren = !this.router.url.endsWith(`/${this.escolaId}`);
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
      this.breadcrumbService.changeBreadcrumb(this.route.snapshot, this.escola.nome);
      this.router.events.pipe(
        filter((e: Event): e is RouterEvent => e instanceof RouterEvent)
      ).subscribe((e:RouterEvent) => {
        this.shouldLoadChildren = !e.url.endsWith(`/${this.escolaId}`);
      })
    })
  }

  public detalhesAlunos() {
    this.router.navigate([`/escolas/${this.escolaId}/alunos`]);
  }

  public detalhesProfessores() {
    this.router.navigate([`/escolas/${this.escolaId}/professores`]);
  }

  
  public detalhesDisciplinas() {
    this.router.navigate([`/escolas/${this.escolaId}/disciplinas`]);
  }

  public detalhesTurmas() {
    this.router.navigate([`/escolas/${this.escolaId}/turmas`]);
  }
}
