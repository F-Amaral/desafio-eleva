import { Component, OnInit, ViewChild } from '@angular/core';
import { Escola } from 'src/app/shared/models/Escola.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tabela-escolas',
  templateUrl: './tabela-escolas.component.html',
  styleUrls: ['./tabela-escolas.component.scss']
})
export class TabelaEscolasComponent implements OnInit {

  public escolas: Escola[];
  dataSource: MatTableDataSource<Escola> = new MatTableDataSource<Escola>();

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  displayedColumns: string[] = ['nome', 'descricao','tooltip'];

  constructor(private escolaService: EscolaService,
    private router: Router) { }

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
    this.escolaService.deleteEscola(escola.id).then(() => {
      this.getEscolas();

    })
  }
  
  public detalhesEscola(escola: Escola){
    this.router.navigate(['/escolas/', escola.id ])
  }



}
