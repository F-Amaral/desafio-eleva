import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Professor } from 'src/app/shared/models/Professor.model';
import { EscolaService } from 'src/app/services/escola/escola.service';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';

@Component({
  selector: 'app-form-disciplina',
  templateUrl: './form-disciplina.component.html',
  styleUrls: ['./form-disciplina.component.scss']
})
export class FormDisciplinaComponent implements OnInit {

  
  public disciplina: Disciplina = new Disciplina();
  public professores: Professor[];
  @Input() escolaId: string;
  @Input() value: Disciplina;

  @Output() disciplinaChanged = new EventEmitter<Disciplina>();

  constructor(private escolaService:EscolaService) {
    if(this.value)
    this.disciplina = this.value;
  }

  ngOnInit(): void {
    this.getProfessores();
  }


  getProfessores(){
    this.escolaService.getProfessores(this.escolaId).then((data) => {
      this.professores = data;
    })
  }

  handleNome(nome: string){
    this.disciplina.nome = nome;
    this.disciplinaChanged.emit(this.disciplina);
  }

  handleProfessor(professor: Professor){
    this.disciplina.professorId = professor.id;
    this.disciplinaChanged.emit(this.disciplina);
  }

}
