import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessorModalComponent } from './professor-modal.component';

describe('ProfessorModalComponent', () => {
  let component: ProfessorModalComponent;
  let fixture: ComponentFixture<ProfessorModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessorModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessorModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
