import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LayoutComponent } from 'src/app/components/core/layout/layout.component';
import { AppHeaderComponent } from '../header/header.component';
import { AppRoutingModule } from 'src/app/app-routing.module';

@NgModule({
  declarations: [AppHeaderComponent, LayoutComponent],
  imports: [CommonModule, BrowserModule, AppRoutingModule]
})
export class LayoutModule {}