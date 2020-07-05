import { Component, OnInit } from '@angular/core';
import { Escola } from 'src/app/shared/models/Escola.model';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-escolas',
  templateUrl: './escolas.component.html',
  styleUrls: ['./escolas.component.scss']
})
export class EscolasComponent implements OnInit {
  
  public escolas: Escola[];

  displayedColumns: string[] = ['nome', 'descricao','tooltip'];

  constructor(private escolaService: EscolaService, private router: Router) {
  }

  ngOnInit(): void {
    this.getEscolas();
  }

  public getEscolas(){
    this.escolaService.getEscolas().subscribe(escolas => this.escolas = escolas);
  }

  public deleteEscola(escola: Escola){
    this.escolaService.deleteEscola(escola.id);
  }
  
  public detalhesEscola(escola: Escola){
    this.router.navigate(['/escolas/', escola.id ])
  }

}
