import { Component, OnInit, Inject } from '@angular/core';
import { Professor } from 'src/app/shared/models/Professor.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-professor-modal',
  templateUrl: './professor-modal.component.html',
  styleUrls: ['./professor-modal.component.scss']
})
export class ProfessorModalComponent implements OnInit {

  public professor: Professor;
  escolaId: string;
  public isAdd: boolean;
  public buttonText: string;

  constructor(
    public dialogRef: MatDialogRef<ProfessorModalComponent>, 
    private escolaService: EscolaService,
    private route: ActivatedRoute,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.professor = data.professor ?? new Professor();
      this.isAdd = data.professor === undefined;
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
        this.escolaService.addProfessor(this.escolaId, this.professor).then((data) => {
          this.professor = data;
          this.dialogRef.close();
        });
      }else{
        this.escolaService.updateProfessor(this.escolaId, this.professor).then((data) => {
          this.professor = data;
          this.dialogRef.close();
        })
      }
    }

    handleNome(nome: string){
      this.professor.nome = nome;
    }

    handleSobrenome(sobrenome: string){
      this.professor.sobrenome = sobrenome;
    }


}
