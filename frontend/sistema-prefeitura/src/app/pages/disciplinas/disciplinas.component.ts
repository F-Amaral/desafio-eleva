import { Component, OnInit, ViewChild } from '@angular/core';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { DisciplinaModalComponent } from 'src/app/components/disciplina-modal/disciplina-modal.component';
import { TabelaDisciplinasComponent } from 'src/app/components/tabela-disciplinas/tabela-disciplinas.component';
import { Escola } from 'src/app/shared/models/Escola.model';

@Component({
  selector: 'app-disciplinas',
  templateUrl: './disciplinas.component.html',
  styleUrls: ['./disciplinas.component.scss']
})
export class DisciplinasComponent implements OnInit {

  public dialogRef: MatDialogRef<DisciplinaModalComponent>;
  escolaId: string;
  escola: Escola = new Escola();
  @ViewChild(TabelaDisciplinasComponent) tabelaDisciplinas: TabelaDisciplinasComponent; 

  constructor(public dialog: MatDialog, private route: ActivatedRoute, private escolaService: EscolaService) { }

  ngOnInit(): void {
    this.getEscola();
  }

  public getEscola() {
    this.escolaId = this.route.parent.snapshot.params["escolaId"];
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
    })
  }

  public onAdd(){
    this.dialogRef = this.dialog.open(DisciplinaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: "Adicionar disciplina",
        escolaId: this.escolaId
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaDisciplinas.getDisciplinas();
    })
  }

  public onEdit(disciplina: Disciplina){
    this.dialogRef = this.dialog.open(DisciplinaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '50%',
      minWidth: '50%',
      data: {
        disciplina: disciplina,
        title: "Atualizar disciplina",
        escolaId: this.escolaId
      }
    })
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaDisciplinas.getDisciplinas();
    })
  }
}
