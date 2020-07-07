import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tabela-disciplinas',
  templateUrl: './tabela-disciplinas.component.html',
  styleUrls: ['./tabela-disciplinas.component.scss']
})
export class TabelaDisciplinasComponent implements OnInit {

  public disciplinas: Disciplina[];
  public escola: Escola = new Escola();
  @Input() public escolaId: string;
  @Input() public turmaId: string;
  @Input() public limit: number;
  @Output() deleteDisciplinaClicked = new EventEmitter<Disciplina>();
  dataSource: MatTableDataSource<Disciplina> = new MatTableDataSource<Disciplina>();

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  displayedColumns: string[] = ['nome', 'professor', 'tooltip'];

  constructor(private escolaService: EscolaService,
    private router: Router,
    private route: ActivatedRoute) {
      this.limit = this.limit > 0 ? this.limit : 0;
     }

  ngOnInit(): void {
    this.getEscola();
  }
  public getEscola() {
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
      this.getDisciplinas();
    });
  }

  public getDisciplinas() {
    if (this.turmaId) {
      this.escolaService.getDisciplinasByTurma(this.escolaId, this.turmaId).then((data) => {
        this.disciplinas = data;
        if(this.limit > 0)
          this.disciplinas = this.disciplinas.slice(0,this.limit);
        this.dataSource = new MatTableDataSource(this.disciplinas);
        this.dataSource.sort = this.sort;
      });
    } else {
      this.escolaService.getDisciplinas(this.escolaId).then((data) => {
        this.disciplinas = data;
        if(this.limit > 0)
          this.disciplinas = this.disciplinas.slice(0,this.limit);
        this.dataSource = new MatTableDataSource(this.disciplinas);
        this.dataSource.sort = this.sort;
      });
    }
  }

  public deleteDisciplina(disciplina: Disciplina) {
    if(!this.turmaId){
      this.escolaService.deleteDisciplina(this.escolaId, disciplina.id).then(() => {
        this.getDisciplinas();
      })
    }else{
      this.deleteDisciplinaClicked.emit(disciplina);
    }
  }

  public detalhesDisciplina(disciplina: Disciplina) {
    this.router.navigate(['./disciplinas', disciplina.id])
  }
}
