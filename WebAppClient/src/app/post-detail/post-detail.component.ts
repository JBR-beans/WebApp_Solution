import { Component } from '@angular/core';
import { DataService, Page } from '../data.service';

@Component({
  selector: 'app-post-detail',
  standalone: false,
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent {
  id: number = 1;
  post: Page | undefined;

  constructor(private data: DataService) {

    this.post = this.data.pages.find(p => p.ContentId == this.id);

  }
}
