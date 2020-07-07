import { Component, OnInit, Inject } from '@angular/core';
import { Turma } from 'src/app/shared/models/Turma.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EscolaService } from 'src/app/services/escola/escola.service';

@Component({
  selector: 'app-turma-modal',
  templateUrl: './turma-modal.component.html',
  styleUrls: ['./turma-modal.component.scss']
})
export class TurmaModalComponent implements OnInit {

  public turma: Turma;
  escolaId: string;
  public isAdd: boolean;
  public buttonText: string;

  constructor(
    public dialogRef: MatDialogRef<TurmaModalComponent>, 
    private escolaService: EscolaService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.turma = data.turma ? data.turma : new Turma();
      this.isAdd = data.turma === undefined;
      this.escolaId = data.escolaId;
      this.buttonText = this.isAdd ? "Adicionar" : "Atualizar";
    }

    ngOnInit(): void {
    }

    onNoClick(): void {
      this.dialogRef.close();
    }
    
    onSubmit(){ 
      if(this.isAdd){
        this.escolaService.addTurma(this.escolaId, this.turma).then((data) => {
          this.turma = data;
          this.dialogRef.close();
        });
      }else{
        this.escolaService.updateTurma(this.escolaId, this.turma).then((data) => { 
          this.turma = data;
          this.dialogRef.close();
        })
      }
    }

    handleNome(nome: string){
      this.turma.nome = nome;
    }

    handleAno(ano: string){
      this.turma.ano = ano;
    }

}
