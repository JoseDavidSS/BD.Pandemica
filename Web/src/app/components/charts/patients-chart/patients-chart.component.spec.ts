import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientsChartComponent } from './patients-chart.component';

describe('PatientsChartComponent', () => {
  let component: PatientsChartComponent;
  let fixture: ComponentFixture<PatientsChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientsChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientsChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
