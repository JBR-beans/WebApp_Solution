import { Component } from '@angular/core';
import { DataService, Page } from '../data.service';

@Component({
  selector: 'app-post-list',
  standalone: false,
  templateUrl: './post-list.component.html',
  styleUrl: './post-list.component.css'
})
export class PostListComponent {
pages: Page[] = [];

  constructor(private data: DataService) {
    this.data.getAllPages().subscribe(data => {
      this.pages = data;
    });
  }
}
