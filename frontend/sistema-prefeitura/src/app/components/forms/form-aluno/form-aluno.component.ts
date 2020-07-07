import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Aluno } from 'src/app/shared/models/Aluno.model';

@Component({
  selector: 'app-form-aluno',
  templateUrl: './form-aluno.component.html',
  styleUrls: ['./form-aluno.component.scss']
})
export class FormAlunoComponent implements OnInit {

  aluno: Aluno = new Aluno();

  @Input() value: Aluno;
  @Output() alunoChanged = new EventEmitter<Aluno>();

  constructor() { 
    if(this.value)
      this.aluno = this.value;
  }

  ngOnInit(): void {
  }

  public handleNome(nome: string){
    this.aluno.nome = nome;
    this.alunoChanged.emit(this.aluno);
  }

  public handleSobrenome(sobrenome: string){
    this.aluno.sobrenome = sobrenome;
    this.alunoChanged.emit(this.aluno);
  }

}
