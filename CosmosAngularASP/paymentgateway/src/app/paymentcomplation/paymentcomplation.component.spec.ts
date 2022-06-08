import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentcomplationComponent } from './paymentcomplation.component';

describe('PaymentcomplationComponent', () => {
  let component: PaymentcomplationComponent;
  let fixture: ComponentFixture<PaymentcomplationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentcomplationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentcomplationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
