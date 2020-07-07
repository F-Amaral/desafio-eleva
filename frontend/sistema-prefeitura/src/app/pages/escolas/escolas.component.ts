import { Component, OnInit, ViewChild } from '@angular/core';
import { Escola } from 'src/app/shared/models/Escola.model';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router, ActivatedRoute, Event, RouterEvent } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EscolaModalComponent } from 'src/app/components/escola-modal/escola-modal.component';
import { TabelaEscolasComponent } from 'src/app/components/tabela-escolas/tabela-escolas.component';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.scss']
})
export class EscolasComponent implements OnInit {
  
  public adicionarEscolaModal: boolean = false;
  public dialogRef: MatDialogRef<EscolaModalComponent>;
  public shouldLoadChildren: boolean = false;
  public escolaId: string;

  @ViewChild(TabelaEscolasComponent) tabelaEscolas: TabelaEscolasComponent;

  constructor(public dialog: MatDialog, private router: Router) {
    this.shouldLoadChildren = !router.url.endsWith('/escolas');
  }

  @ViewChild(MatSort, {static: true}) sort: MatSort;

  ngOnInit(): void {
    this.router.events.pipe(
      filter((e: Event): e is RouterEvent => e instanceof RouterEvent)
    ).subscribe((e:RouterEvent) => {
      this.shouldLoadChildren = !e.url.endsWith("/escolas");
    })
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
      this.tabelaEscolas.getEscolas();
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
      this.tabelaEscolas.getEscolas();
    })
  }
}
