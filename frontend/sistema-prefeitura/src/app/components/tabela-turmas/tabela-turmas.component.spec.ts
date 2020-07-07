import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TabelaTurmasComponent } from './tabela-turmas.component';

describe('TabelaTurmasComponent', () => {
  let component: TabelaTurmasComponent;
  let fixture: ComponentFixture<TabelaTurmasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabelaTurmasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabelaTurmasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
