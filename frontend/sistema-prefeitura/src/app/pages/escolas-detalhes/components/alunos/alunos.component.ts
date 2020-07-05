import { Component, OnInit, ViewChild } from '@angular/core';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { MatTableDataSource } from '@angular/material/table';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { MatSort } from '@angular/material/sort';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.scss']
})
export class AlunosComponent implements OnInit {

  escolaId: string;
  alunos: Aluno[];
  dataSource: MatTableDataSource<Aluno>;
  displayedColumns: string[] = ['nome','sobrenome'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private escolaService: EscolaService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.getAlunos();
  }

  public getAlunos() {
    this.escolaId = this.route.snapshot.params['id'];
    this.escolaService.getAlunos(this.escolaId).then((data) => {
      this.alunos = data.slice(0,4);
      this.dataSource = new MatTableDataSource(this.alunos);
      this.dataSource.sort = this.sort;
    })
  }

  public detalhesAlunos() {
    this.router.navigate(['alunos']);
  }
}
