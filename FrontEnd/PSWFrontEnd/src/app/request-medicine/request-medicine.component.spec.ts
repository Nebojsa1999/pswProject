import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestMedicineComponent } from './request-medicine.component';

describe('RequestMedicineComponent', () => {
  let component: RequestMedicineComponent;
  let fixture: ComponentFixture<RequestMedicineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RequestMedicineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestMedicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
