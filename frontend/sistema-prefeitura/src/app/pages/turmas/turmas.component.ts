import { Component, OnInit, ViewChild } from '@angular/core';
import { Turma } from 'src/app/shared/models/Turma.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router, Event, RouterEvent } from '@angular/router';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { TurmaModalComponent } from 'src/app/components/turma-modal/turma-modal.component';
import { TabelaTurmasComponent } from 'src/app/components/tabela-turmas/tabela-turmas.component';
import { Escola } from 'src/app/shared/models/Escola.model';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-turmas',
  templateUrl: './turmas.component.html',
  styleUrls: ['./turmas.component.scss']
})
export class TurmasComponent implements OnInit {

  public dialogRef: MatDialogRef<TurmaModalComponent>;
  escolaId: string;
  shouldLoadChildren: boolean = false;
  escola: Escola = new Escola();

  @ViewChild(TabelaTurmasComponent) tabelaTurmas: TabelaTurmasComponent;

  constructor(public dialog: MatDialog,
    private route: ActivatedRoute,
    private escolaService: EscolaService,
    private router: Router) {
    this.shouldLoadChildren = !router.url.endsWith('/turmas');
  }

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  ngOnInit(): void {
    this.getEscola();
    this.router.events.pipe(
      filter((e: Event): e is RouterEvent => e instanceof RouterEvent)
    ).subscribe((e: RouterEvent) => {
      this.shouldLoadChildren = !e.url.endsWith("/turmas");
    })
  }

  getEscola() {
    this.escolaId = this.route.parent.snapshot.params["escolaId"];
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
    });
  }

  public onAdd() {
    this.dialogRef = this.dialog.open(TurmaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '60%',
      minWidth: '40%',
      data: {
        title: "Adicionar Turma",
        escolaId: this.escolaId
      }
    });
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaTurmas.getTurmas();
    })
  }

  public onEdit(turma: Turma) {
    this.dialogRef = this.dialog.open(TurmaModalComponent, {
      width: 'auto',
      height: 'auto',
      minHeight: '50%',
      minWidth: '50%',
      data: {
        turma: turma,
        title: "Atualizar turma",
        escolaId: this.escolaId
      }
    })
    this.dialogRef.afterClosed().subscribe(result => {
      this.tabelaTurmas.getTurmas();
    })
  }

}
