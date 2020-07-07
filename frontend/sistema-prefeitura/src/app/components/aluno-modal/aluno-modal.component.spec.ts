import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlunoModalComponent } from './aluno-modal.component';

describe('AlunoModalComponent', () => {
  let component: AlunoModalComponent;
  let fixture: ComponentFixture<AlunoModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlunoModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlunoModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
