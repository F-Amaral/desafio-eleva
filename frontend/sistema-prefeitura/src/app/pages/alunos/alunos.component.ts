import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { ActivatedRoute } from '@angular/router';
import { AlunoModalComponent } from 'src/app/components/aluno-modal/aluno-modal.component';
import { TabelaAlunosComponent } from 'src/app/components/tabela-alunos/tabela-alunos.component';
import { Escola } from 'src/app/shared/models/Escola.model';
import { EscolaService } from 'src/app/services/escola/escola.service';


@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss']
})
export class AlunosComponent implements OnInit {

  escolaId: string;
  escola: Escola = new Escola();
  public dialogRef: MatDialogRef<AlunoModalComponent>;
  @ViewChild(TabelaAlunosComponent) tabelaAlunos: TabelaAlunosComponent;

  constructor(public dialog: MatDialog,
    private route: ActivatedRoute,
    private escolaService: EscolaService) {
  }


  ngOnInit(): void {
    this.getEscola();
  }

  public getEscola(){
    this.escolaId = this.route.parent.snapshot.params['escolaId'];
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
    })
  }

  public onAdd(){
    this.dialogRef = this.dialog.open(AlunoModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: "Adicionar aluno",
        escolaId: this.escolaId
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaAlunos.getAlunos();
    })
  }

  public onEdit(aluno: Aluno){
    this.dialogRef = this.dialog.open(AlunoModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '50%',
      minWidth: '50%',
      data: {
        aluno: aluno,
        title: "Atualizar aluno",
        escolaId: this.escolaId
      }
    })
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaAlunos.getAlunos();
    })
  }
}
