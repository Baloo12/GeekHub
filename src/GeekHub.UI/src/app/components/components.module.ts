import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { LayoutModule } from './core/layout/layout.module';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  imports: [
    LayoutModule,
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ]
})
export class ComponentsModule {}