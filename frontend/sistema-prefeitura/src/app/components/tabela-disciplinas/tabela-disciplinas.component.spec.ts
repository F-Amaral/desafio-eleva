import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TabelaDisciplinasComponent } from './tabela-disciplinas.component';

describe('TabelaDisciplinasComponent', () => {
  let component: TabelaDisciplinasComponent;
  let fixture: ComponentFixture<TabelaDisciplinasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabelaDisciplinasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabelaDisciplinasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
