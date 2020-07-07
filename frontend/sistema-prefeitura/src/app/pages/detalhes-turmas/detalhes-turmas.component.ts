import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Turma } from 'src/app/shared/models/Turma.model';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { TurmaAlunoModalComponent } from 'src/app/components/turma-aluno-modal/turma-aluno-modal.component';
import { TabelaAlunosComponent } from 'src/app/components/tabela-alunos/tabela-alunos.component';
import { BreadcrumbService } from 'angular-crumbs';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { TurmaDisciplinaModalComponent } from 'src/app/components/turma-disciplina-modal/turma-disciplina-modal.component';
import { TabelaDisciplinasComponent } from 'src/app/components/tabela-disciplinas/tabela-disciplinas.component';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';

@Component({
  selector: 'app-detalhes-turmas',
  templateUrl: './detalhes-turmas.component.html',
  styleUrls: ['./detalhes-turmas.component.scss']
})
export class DetalhesTurmasComponent implements OnInit {

  turma: Turma = new Turma();
  turmaId: string;
  escolaId: string;

  @ViewChild(TabelaAlunosComponent) tabelaAlunos : TabelaAlunosComponent;
  @ViewChild(TabelaDisciplinasComponent) tabelaDisciplinas : TabelaDisciplinasComponent;

  turmaAlunoDialogRef: MatDialogRef<TurmaAlunoModalComponent>;
  turmaDisciplinaDialogRef: MatDialogRef<TurmaDisciplinaModalComponent>;

  constructor(private route: ActivatedRoute, 
    private escolaService: EscolaService,
    private dialog: MatDialog,
    private breadcrumbService: BreadcrumbService) {
      this.turma.escola = new Escola();
     }

  ngOnInit(): void {
    this.getTurma();
  }

  getTurma(){
    this.escolaId = this.route.parent.parent.snapshot.params['escolaId'];
    this.turmaId = this.route.snapshot.params['turmaId'];
    this.escolaService.getTurma(this.escolaId, this.turmaId).then((data) => {
      this.turma = data;
      this.breadcrumbService.changeBreadcrumb(this.route.snapshot, this.turma.nome);
    })
  }

  public adicionarAluno(){
    this.turmaAlunoDialogRef = this.dialog.open(TurmaAlunoModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: `Adicionar aluno à turma ${this.turma.nome}`,
        turma: this.turma,
        escolaId: this.escolaId
      }
    });
    this.turmaAlunoDialogRef.afterClosed().subscribe(result => {
      this.tabelaAlunos.getAlunos();
    })
  }

  public adicionarDisciplina(){
    this.turmaDisciplinaDialogRef = this.dialog.open(TurmaDisciplinaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: `Adicionar discicplina à turma ${this.turma.nome}`,
        turma: this.turma,
        escolaId: this.escolaId
      }
    });
    this.turmaDisciplinaDialogRef.afterClosed().subscribe(result => {
      this.tabelaDisciplinas.getDisciplinas();
    })
  }

  public handleDeleteAluno(aluno: Aluno){
    this.escolaService.removeAlunoFromTurma(this.escolaId, this.turmaId, aluno.id).then(() =>
      this.tabelaAlunos.getAlunos()
    );
  }

  public handleDeleteDisciplina(disciplina: Disciplina){
    this.escolaService.removeDisciplinaFromTurma(this.escolaId, this.turmaId, disciplina.id).then(() =>
      this.tabelaDisciplinas.getDisciplinas()
    );
  }

}
