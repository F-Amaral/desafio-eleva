import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplinaModalComponent } from './disciplina-modal.component';

describe('DisciplinaModalComponent', () => {
  let component: DisciplinaModalComponent;
  let fixture: ComponentFixture<DisciplinaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DisciplinaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DisciplinaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
