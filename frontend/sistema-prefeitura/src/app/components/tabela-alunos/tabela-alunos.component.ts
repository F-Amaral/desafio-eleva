import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-tabela-alunos',
  templateUrl: './tabela-alunos.component.html',
  styleUrls: ['./tabela-alunos.component.scss']
})
export class TabelaAlunosComponent implements OnInit {

  public alunos: Aluno[];
  public escola: Escola = new Escola();
  
  @Input() escolaId: string;
  @Input() turmaId: string;
  @Input() limit: number;

  @Output() deleteAlunoClicked = new EventEmitter<Aluno>();
  @Output() editarAlunoClicked = new EventEmitter<Aluno>();

  dataSource: MatTableDataSource<Aluno> = new MatTableDataSource<Aluno>();

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = ['nome', 'sobrenome','tooltip'];

  constructor(private escolaService: EscolaService, 
    private router: Router, 
    private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.getEscola();
  }


  public getEscola(){    
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
      this.getAlunos();
    });
  }

  public getAlunos(){
    if(this.turmaId){
      this.escolaService.getAlunosByTurma(this.escolaId, this.turmaId).then((data) => {
        this.alunos = data;
        if(this.limit > 0)
          this.alunos = this.alunos.slice(0, this.limit);
        this.dataSource = new MatTableDataSource(this.alunos);
        this.dataSource.sort = this.sort;
      });
    }else{
      this.escolaService.getAlunos(this.escolaId).then((data) => {
        this.alunos = data;
        if(this.limit > 0)
          this.alunos = this.alunos.slice(0, this.limit);
        this.dataSource = new MatTableDataSource(this.alunos);
        this.dataSource.sort = this.sort;
      });
    }
  }

  public deleteAluno(aluno: Aluno){
    if(!this.turmaId){
      this.escolaService.deleteAluno(this.escolaId,aluno.id).then(() => {
        this.getAlunos();
      });
    }else{
      this.deleteAlunoClicked.emit(aluno);
    };
  }
  
  public detalhesAluno(aluno: Aluno){
    this.router.navigate(['./alunos', aluno.id ])
  }

  public editarAluno(aluno: Aluno){
    this.editarAlunoClicked.emit(aluno);
  }


}
