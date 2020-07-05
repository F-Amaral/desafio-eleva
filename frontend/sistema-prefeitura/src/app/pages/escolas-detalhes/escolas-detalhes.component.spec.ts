import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EscolasDetalhesComponent } from './escolas-detalhes.component';

describe('EscolasDetalhesComponent', () => {
  let component: EscolasDetalhesComponent;
  let fixture: ComponentFixture<EscolasDetalhesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EscolasDetalhesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EscolasDetalhesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
