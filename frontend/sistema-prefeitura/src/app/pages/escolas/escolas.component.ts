import { Component, OnInit, ViewChild } from '@angular/core';
import { Escola } from 'src/app/shared/models/Escola.model';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { EscolaModalComponent } from './components/escola-modal/escola-modal.component';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.scss']
})
export class EscolasComponent implements OnInit {
  
  public escolas: Escola[];
  public adicionarEscolaModal: boolean = false;
  public dialogRef: MatDialogRef<EscolaModalComponent>;
  dataSource: MatTableDataSource<Escola>;

  displayedColumns: string[] = ['nome', 'descricao','tooltip'];

  constructor(private escolaService: EscolaService, private router: Router, public dialog: MatDialog) {
  }

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  ngOnInit(): void {
    this.getEscolas();
  }

  public getEscolas(){
    this.escolaService.getEscolas().then((data) => {
      this.escolas = data;
      this.dataSource = new MatTableDataSource(this.escolas);
      this.dataSource.sort = this.sort;
    });
  }

  public deleteEscola(escola: Escola){
    console.log(escola)
    this.escolaService.deleteEscola(escola.id).then(() => {
      this.getEscolas();

    })
  }
  
  public detalhesEscola(escola: Escola){
    this.router.navigate(['/escolas/', escola.id ])
  }

  public onAdd(){
    this.dialogRef = this.dialog.open(EscolaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data:{
        title: "Adicionar Escola"
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      this.getEscolas();
    })
  }

  public onEdit(escola: Escola){
    this.dialogRef = this.dialog.open(EscolaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '50%',
      minWidth: '50%',
      data: {
        escola: escola,
        title: "Atualizar escola"
      }
    })
    this.dialogRef.afterClosed().subscribe(result => {
      this.getEscolas();
    })
  }
}
