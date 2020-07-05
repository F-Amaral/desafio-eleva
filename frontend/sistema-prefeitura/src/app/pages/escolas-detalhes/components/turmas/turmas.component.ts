import { Component, OnInit, ViewChild } from '@angular/core';
import { Turma } from 'src/app/shared/models/Turma.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-turmas',
  templateUrl: './turmas.component.html',
  styleUrls: ['./turmas.component.scss']
})
export class TurmasComponent implements OnInit {

  escolaId: string;
  turmas: Turma[];
  dataSource: MatTableDataSource<Turma>;
  displayedColumns: string[] = ['nome','ano'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private escolaService: EscolaService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getTurmas();
  }

  public getTurmas() {
    this.escolaId = this.route.snapshot.params['id'];
    this.escolaService.getTurmas(this.escolaId).then((data) => {
      this.turmas = data.slice(0,4);
      this.dataSource = new MatTableDataSource(this.turmas);
      this.dataSource.sort = this.sort;
    })
  }

  public detalhesDisciplinas() {
    this.router.navigate(['turmas']);
  }

}
