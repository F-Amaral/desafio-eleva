import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TurmaAlunoModalComponent } from './turma-aluno-modal.component';

describe('TurmaAlunoModalComponent', () => {
  let component: TurmaAlunoModalComponent;
  let fixture: ComponentFixture<TurmaAlunoModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TurmaAlunoModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TurmaAlunoModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
