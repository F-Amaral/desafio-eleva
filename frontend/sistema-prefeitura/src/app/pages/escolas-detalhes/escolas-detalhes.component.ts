import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Escola } from 'src/app/shared/models/Escola.model';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-escolas-detalhes',
  templateUrl: './escolas-detalhes.component.html',
  styleUrls: ['./escolas-detalhes.component.scss']
})
export class EscolasDetalhesComponent implements OnInit {

  escola: Escola = new Escola();
  escolaId: string;

  constructor(private route: ActivatedRoute, private escolaService: EscolaService) {}

  ngOnInit(): void {
    this.getEscola();
  }

  getEscola() {
    this.escolaId = this.route.snapshot.params['id'];
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
    })
  }
}
