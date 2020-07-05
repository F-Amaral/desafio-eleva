import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-botao-flutuante',
  templateUrl: './botao-flutuante.component.html',
  styleUrls: ['./botao-flutuante.component.scss']
})
export class BotaoFlutuanteComponent implements OnInit {

  constructor() { }

  @Output() requestedAdd = new EventEmitter();

  ngOnInit(): void {
  }

  requestAdd(){
    this.requestedAdd.emit(null);
  }
}
