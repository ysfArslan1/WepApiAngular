import { Component, ViewEncapsulation } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CommonModule} from '@angular/common';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    CommonModule, 
    NavbarComponent,// navbarı bu sayfaya eklemek için include içine yazdık
    FormsModule,
    HttpClientModule
  ], 
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  template: `<div *ngIf="visible">Hi</div>`,
  encapsulation: ViewEncapsulation.None
})
export class AppComponent {
  title = 'AngularFullStack.UI';
}
