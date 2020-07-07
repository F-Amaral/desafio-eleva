import { Component, OnInit, Inject } from '@angular/core';
import { Turma } from 'src/app/shared/models/Turma.model';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-turma-disciplina-modal',
  templateUrl: './turma-disciplina-modal.component.html',
  styleUrls: ['./turma-disciplina-modal.component.scss']
})
export class TurmaDisciplinaModalComponent implements OnInit {

  public turma: Turma;
  public disciplinas: Disciplina[];
  public disciplinasToInclude: string[] = [];
  public novaDisciplina: Disciplina;
  escolaId: string;

  constructor(
    public dialogRef: MatDialogRef<TurmaDisciplinaModalComponent>,
    private escolaService: EscolaService,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.turma = data.turma ? data.turma : new Turma();
    this.escolaId = data.escolaId;
  }

  ngOnInit(): void {
    this.getDisciplinas()
  }

  public getDisciplinas() {
    this.escolaService.getDisciplinas(this.escolaId).then((data) => {
      this.disciplinas = data;
    })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public onSubmit() {
    if(this.disciplinasToInclude.length > 0)
      this.escolaService.addDisciplinasToTurma(this.escolaId, this.turma.id, this.disciplinasToInclude).then((data) => {
        this.dialogRef.close();
      });
    else if(this.novaDisciplina && this.novaDisciplina.nome != "" && this.novaDisciplina.professorId != "")
      this.handleNovaDisciplinaSubmit();
    else
      this.openSnackbar("Escolha ou insira uma disciplina!");
  }

  handleDisciplinas(event: any) {
    if (event.isUserInput) {
      if (event.source.selected)
        this.disciplinasToInclude.push((event.source.value as Disciplina).id);
      else
        this.disciplinasToInclude.splice(this.disciplinasToInclude.indexOf((event.source.value as Disciplina).id));
    }
    console.log(this.disciplinasToInclude)
  }

  handleNovaDisciplinaChanged(disciplina: Disciplina) {
    this.novaDisciplina = disciplina;
  }

  handleNovaDisciplinaSubmit() {
    if(this.novaDisciplina && this.novaDisciplina.nome != "" && this.novaDisciplina.professorId != ""){
      this.escolaService.addDisciplina(this.escolaId, this.novaDisciplina).then((data) => {
        this.novaDisciplina.nome = "",
        this.novaDisciplina.professorId = ""
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
