import { Component } from '@angular/core';
import { DataService, Page } from '../data.service';

@Component({
  selector: 'app-nav',
  standalone: false,
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  pages: Page[] = [];
  
  constructor(private data: DataService) {
/*    this.data.getAllPages().subscribe(data => {
      this.pages = data;
    });*/
  }
}
