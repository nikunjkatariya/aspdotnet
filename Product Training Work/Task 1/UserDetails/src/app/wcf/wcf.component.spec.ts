import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WCFComponent } from './wcf.component';

describe('WCFComponent', () => {
  let component: WCFComponent;
  let fixture: ComponentFixture<WCFComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WCFComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WCFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
