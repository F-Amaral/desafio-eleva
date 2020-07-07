import { Component, OnInit, Inject } from '@angular/core';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-aluno-modal',
  templateUrl: './aluno-modal.component.html',
  styleUrls: ['./aluno-modal.component.scss']
})
export class AlunoModalComponent implements OnInit {
  
  public aluno: Aluno;
  escolaId: string;
  public isAdd: boolean;
  public buttonText: string;

  constructor(
    public dialogRef: MatDialogRef<AlunoModalComponent>, 
    private escolaService: EscolaService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.aluno = data.aluno ? data.aluno : new Aluno();
      this.isAdd = data.aluno === undefined;
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
        this.escolaService.addAluno(this.escolaId, this.aluno).then((data) => {
          this.aluno = data;
          this.dialogRef.close();
        });
      }else{
        this.escolaService.updateAluno(this.escolaId, this.aluno).then((data) => {
          this.aluno = data;
          this.dialogRef.close();
        })
      }
    }

   handleAluno(aluno: Aluno){
     this.aluno = aluno;
   }

}
