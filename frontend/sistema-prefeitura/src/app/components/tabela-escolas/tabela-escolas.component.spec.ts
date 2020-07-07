import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TabelaEscolasComponent } from './tabela-escolas.component';

describe('TabelaEscolasComponent', () => {
  let component: TabelaEscolasComponent;
  let fixture: ComponentFixture<TabelaEscolasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabelaEscolasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabelaEscolasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
