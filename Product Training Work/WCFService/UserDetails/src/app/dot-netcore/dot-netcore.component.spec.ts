import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DotNETCoreComponent } from './dot-netcore.component';

describe('DotNETCoreComponent', () => {
  let component: DotNETCoreComponent;
  let fixture: ComponentFixture<DotNETCoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DotNETCoreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DotNETCoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
