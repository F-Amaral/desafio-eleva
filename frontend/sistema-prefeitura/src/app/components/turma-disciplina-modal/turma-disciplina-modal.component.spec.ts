import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TurmaDisciplinaModalComponent } from './turma-disciplina-modal.component';

describe('TurmaDisciplinaModalComponent', () => {
  let component: TurmaDisciplinaModalComponent;
  let fixture: ComponentFixture<TurmaDisciplinaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TurmaDisciplinaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TurmaDisciplinaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
