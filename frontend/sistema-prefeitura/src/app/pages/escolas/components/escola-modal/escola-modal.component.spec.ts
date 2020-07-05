import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EscolaModalComponent } from './escola-modal.component';

describe('EscolaModalComponent', () => {
  let component: EscolaModalComponent;
  let fixture: ComponentFixture<EscolaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EscolaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EscolaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
