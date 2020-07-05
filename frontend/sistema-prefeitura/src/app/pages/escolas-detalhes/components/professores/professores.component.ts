import { Component, OnInit, ViewChild } from '@angular/core';
import { Professor } from 'src/app/shared/models/Professor.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.scss']
})
export class ProfessoresComponent implements OnInit {

  escolaId: string;
  professores: Professor[];
  dataSource: MatTableDataSource<Professor>;
  displayedColumns: string[] = ['nome','sobrenome'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private escolaService: EscolaService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getProfessores();
  }

  public getProfessores() {
    this.escolaId = this.route.snapshot.params['id'];
    this.escolaService.getProfessores(this.escolaId).then((data) => {
      this.professores = data.slice(0,4);
      this.dataSource = new MatTableDataSource(this.professores);
      this.dataSource.sort = this.sort;
    })
  }

  public detalhesProfessores() {
    this.router.navigate(['professores']);
  }
}
