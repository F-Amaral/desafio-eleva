import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesTurmasComponent } from './detalhes-turmas.component';

describe('DetalhesTurmasComponent', () => {
  let component: DetalhesTurmasComponent;
  let fixture: ComponentFixture<DetalhesTurmasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhesTurmasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesTurmasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
