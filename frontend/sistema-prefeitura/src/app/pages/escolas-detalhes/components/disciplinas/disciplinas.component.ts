import { Component, OnInit, ViewChild } from '@angular/core';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-disciplinas',
  templateUrl: './disciplinas.component.html',
  styleUrls: ['./disciplinas.component.scss']
})
export class DisciplinasComponent implements OnInit {

  escolaId: string;
  disciplinas: Disciplina[];
  dataSource: MatTableDataSource<Disciplina>;
  displayedColumns: string[] = ['nome','professor'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private escolaService: EscolaService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getDisciplinas();
  }

  public getDisciplinas() {
    this.escolaId = this.route.snapshot.params['id'];
    this.escolaService.getDisciplinas(this.escolaId).then((data) => {
      this.disciplinas = data.slice(0,4);
      this.dataSource = new MatTableDataSource(this.disciplinas);
      this.dataSource.sort = this.sort;
    })
  }

  public detalhesDisciplinas() {
    this.router.navigate(['disciplinas']);
  }
}
