import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Escola } from 'src/app/shared/models/Escola.model';
import { Aluno } from 'src/app/shared/models/Aluno.model';

@Component({
  selector: 'app-escolas-detalhes',
  templateUrl: './escolas-detalhes.component.html',
  styleUrls: ['./escolas-detalhes.component.scss']
})
export class EscolasDetalhesComponent implements OnInit {

  escola: Escola;
  alunos: Aluno[];
  private sub: any;


  constructor(private route: ActivatedRoute, private escolaService: EscolaService) { }

  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.getEscola(params['id']);
      this.getAlunos(params['id'])
    });
  }

  getEscola(id:string){
    this.escolaService.getEscola(id).subscribe(escola => this.escola = escola);
  }

  getAlunos(escola: string){
    this.escolaService.getAlunos(escola).subscribe(alunos => this.alunos = alunos);
  }
}
