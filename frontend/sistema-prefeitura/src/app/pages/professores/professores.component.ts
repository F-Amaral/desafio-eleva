import { Component, OnInit, ViewChild } from '@angular/core';
import { Professor } from 'src/app/shared/models/Professor.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { ProfessorModalComponent } from 'src/app/components/professor-modal/professor-modal.component';
import { TabelaProfessoresComponent } from 'src/app/components/tabela-professores/tabela-professores.component';
import { Escola } from 'src/app/shared/models/Escola.model';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.scss']
})
export class ProfessoresComponent implements OnInit {

  public dialogRef: MatDialogRef<ProfessorModalComponent>;
  escolaId: string;
  escola: Escola = new Escola();
  @ViewChild(TabelaProfessoresComponent) tabelaProfessores: TabelaProfessoresComponent; 

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
    this.dialogRef = this.dialog.open(ProfessorModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: "Adicionar professor",
        escolaId: this.escolaId
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaProfessores.getProfessores();
    })
  }

  public onEdit(professor: Professor){
    this.dialogRef = this.dialog.open(ProfessorModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '50%',
      minWidth: '50%',
      data: {
        professor: professor,
        title: "Atualizar professor",
        escolaId: this.escolaId
      }
    })
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaProfessores.getProfessores();
    })
  }
}
