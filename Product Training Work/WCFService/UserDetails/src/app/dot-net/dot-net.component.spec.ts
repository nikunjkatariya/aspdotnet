import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DotNETComponent } from './dot-net.component';

describe('DotNETComponent', () => {
  let component: DotNETComponent;
  let fixture: ComponentFixture<DotNETComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DotNETComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DotNETComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
