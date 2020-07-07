import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { Professor } from 'src/app/shared/models/Professor.model';

@Component({
  selector: 'app-disciplina-modal',
  templateUrl: './disciplina-modal.component.html',
  styleUrls: ['./disciplina-modal.component.scss']
})
export class DisciplinaModalComponent implements OnInit {

  public disciplina: Disciplina;
  public escolaId: string;
  public isAdd: boolean;
  public buttonText: string;

  constructor(
    public dialogRef: MatDialogRef<DisciplinaModalComponent>, 
    private escolaService: EscolaService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.disciplina = data.disciplina ? data.disciplina : new Disciplina();
      this.isAdd = data.disciplina === undefined;
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
        this.escolaService.addDisciplina(this.escolaId, this.disciplina).then((data) => {
          this.disciplina = data;
          this.dialogRef.close();
        });
      }else{
        this.escolaService.updateDisciplina(this.escolaId, this.disciplina).then((data) => {
          this.disciplina = data;
          this.dialogRef.close();
        });
      }
    }

    handleDisciplinaChanged(disciplina: Disciplina){
      this.disciplina = disciplina;
    }

}
