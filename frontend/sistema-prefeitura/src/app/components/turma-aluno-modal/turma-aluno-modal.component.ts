import { Component, OnInit, Inject } from '@angular/core';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { Turma } from 'src/app/shared/models/Turma.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Event } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-turma-aluno-modal',
  templateUrl: './turma-aluno-modal.component.html',
  styleUrls: ['./turma-aluno-modal.component.scss']
})
export class TurmaAlunoModalComponent implements OnInit {

  public turma: Turma;
  public alunos: Aluno[];
  public alunosToInclude: string[] = [];
  public novoAluno: Aluno = new Aluno();
  escolaId: string;

  constructor(
    public dialogRef: MatDialogRef<TurmaAlunoModalComponent>,
    private escolaService: EscolaService,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.turma = data.turma ? data.turma : new Turma();
    this.escolaId = data.escolaId;
  }

  ngOnInit(): void {
    this.getAlunos()
  }

  public getAlunos() {
    this.escolaService.getAlunos(this.escolaId).then((data) => {
      this.alunos = data.filter((item) => item.turmaId != this.turma.id && item.turmaId == null);
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public onSubmit() {
    if(this.alunosToInclude.length > 0)
      this.escolaService.addAlunosToTurma(this.escolaId, this.turma.id, this.alunosToInclude).then((data) => {
        this.dialogRef.close();
      });
    else if(this.novoAluno && this.novoAluno.nome != "" && this.novoAluno.sobrenome != "")
      this.handleNovoAlunoSubmit();
    else
      this.openSnackbar("Escolha ou insira um aluno!");
  }

  handleAlunos(event: any) {
    if (event.isUserInput) {
      if (event.source.selected)
        this.alunosToInclude.push((event.source.value as Aluno).id);
      else
        this.alunosToInclude.splice(this.alunosToInclude.indexOf((event.source.value as Aluno).id));
    }
    console.log(this.alunosToInclude)
  }

  handleNovoAlunoChanged(aluno: Aluno) {
    aluno.turmaId = this.turma.id;
    this.novoAluno = aluno;
  }

  handleNovoAlunoSubmit() {
    if(this.novoAluno && this.novoAluno.nome != "" && this.novoAluno.sobrenome != ""){
      this.escolaService.addAluno(this.escolaId, this.novoAluno).then((data) => {
        this.novoAluno.nome = "",
          this.novoAluno.sobrenome = "",
          this.novoAluno.turmaId = ""
      });
    }else
      this.openSnackbar("Preencha os campos antes de continuar!");

  }

  openSnackbar(mensagem: string){
    this._snackBar.open(mensagem, "Ok", {
      duration: 4000
    })
  }
}
