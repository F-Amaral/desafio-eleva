import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Escola } from 'src/app/shared/models/Escola.model';
import { EscolaService } from 'src/app/services/escola/escola.service';

@Component({
  selector: 'app-escola-modal',
  templateUrl: './escola-modal.component.html',
  styleUrls: ['./escola-modal.component.scss']
})
export class EscolaModalComponent implements OnInit {

  public escola: Escola;
  public isAdd: boolean;

  constructor(
    public dialogRef: MatDialogRef<EscolaModalComponent>, 
    private escolaService: EscolaService,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.escola = data.escola ?? new Escola();
      this.isAdd = data.escola === undefined;
    }

    ngOnInit(): void {
    }

    onNoClick(): void {
      this.dialogRef.close();
    }

    onSubmit(){ 
      if(this.isAdd){
        this.escolaService.addEscola(this.escola).then((data) => {
          this.escola = data;
          console.log(this.escola);
          this.dialogRef.close();
        });
      }
    }

    handleNome(nome: string){
      this.escola.nome = nome;
    }

    handleDescricao(descricao: string){
      this.escola.descricao = descricao;
    }
}
