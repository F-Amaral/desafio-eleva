import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TurmaModalComponent } from './turma-modal.component';

describe('TurmaModalComponent', () => {
  let component: TurmaModalComponent;
  let fixture: ComponentFixture<TurmaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TurmaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TurmaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
