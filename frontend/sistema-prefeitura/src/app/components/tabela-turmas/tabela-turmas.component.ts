import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Turma } from 'src/app/shared/models/Turma.model';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router, ActivatedRoute } from '@angular/router';
import { relative } from 'path';

@Component({
  selector: 'app-tabela-turmas',
  templateUrl: './tabela-turmas.component.html',
  styleUrls: ['./tabela-turmas.component.scss']
})
export class TabelaTurmasComponent implements OnInit {

  public turmas: Turma[];
  public escola: Escola = new Escola();
  @Input() escolaId: string;
  @Input() limit: number;
  dataSource: MatTableDataSource<Turma> = new MatTableDataSource<Turma>();

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = ['nome', 'ano','tooltip'];

  constructor(private escolaService: EscolaService, 
    private router: Router, 
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getEscola();
  }
  public getEscola(){
    this.escolaService.getEscola(this.escolaId).then((data) => {
      this.escola = data;
      this.getTurmas();
    });
  }

  public getTurmas(){
    this.escolaService.getTurmas(this.escolaId).then((data) => {
      this.turmas = data;
      if(this.limit > 0)
          this.turmas = this.turmas.slice(0,this.limit);
      this.dataSource = new MatTableDataSource(this.turmas);
      this.dataSource.sort = this.sort;
    });
  }

  public deleteTurma(turma: Turma){
    this.escolaService.deleteDisciplina(this.escolaId,turma.id).then(() => {
      this.getTurmas();

    })
  }
  
  public detalhesTurma(turma: Turma){
    this.router.navigate(['turmas', turma.id], {relativeTo: this.route.parent});
  }

}
