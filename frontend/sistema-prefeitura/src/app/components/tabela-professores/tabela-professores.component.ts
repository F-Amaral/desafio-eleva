import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Professor } from 'src/app/shared/models/Professor.model';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tabela-professores',
  templateUrl: './tabela-professores.component.html',
  styleUrls: ['./tabela-professores.component.scss']
})
export class TabelaProfessoresComponent implements OnInit {

  public professores: Professor[];
  public escola: Escola = new Escola();
  @Input() escolaId: string;
  @Input() limit: number;
  dataSource: MatTableDataSource<Professor> = new MatTableDataSource<Professor>();

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = ['nome', 'sobrenome','tooltip'];

  constructor(private escolaService: EscolaService, 
    private router: Router, 
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getEscola();
  }

  public getEscola(){
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
      this.getProfessores();
    });
  }

  public getProfessores(){
    this.escolaService.getProfessores(this.escolaId).then((data) => {
      this.professores = data;
      if(this.limit > 0)
          this.professores = this.professores.slice(0,this.limit);
      this.dataSource = new MatTableDataSource(this.professores);
      this.dataSource.sort = this.sort;
    });
  }

  public deleteAluno(professor: Professor){
    this.escolaService.deleteProfessor(this.escolaId,professor.id).then(() => {
      this.getProfessores();

    })
  }
  
  public detalhesAluno(professor: Professor){
    this.router.navigate(['./professores', professor.id ])
  }
}
