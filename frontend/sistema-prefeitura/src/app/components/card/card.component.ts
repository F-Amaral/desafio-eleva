import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  @Input() title: string;
  @Input() detalhesText: string;

  @Output() detailsClicked = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void {
  }

  public details(){
    this.detailsClicked.emit();
  }

}
