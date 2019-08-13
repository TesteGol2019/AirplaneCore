import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AirplaneComponent } from './airplane.component';
import { AirplaneDetailComponent } from './airplane-detail/airplane-detail.component';
import { AirplaneService } from './airplane.service';
import { MaterialModule } from './../modules/material.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  declarations: [
    AirplaneComponent,
    AirplaneDetailComponent,
  ],
  providers: [AirplaneService],
  exports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class AirplaneModule { }
