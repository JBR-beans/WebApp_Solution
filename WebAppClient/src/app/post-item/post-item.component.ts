import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DataService, Page } from '../data.service';
@Component({
  selector: 'app-post-item',
  standalone: false,
  templateUrl: './post-item.component.html',
  styleUrl: './post-item.component.css'
})
export class PostItemComponent {

  @Input() page!: Page;
  @Output() deletePage = new EventEmitter<number>();

  constructor(private data: DataService) { }
  onDelete() {
    this.data.deletePageById(this.page.contentId);
  } 
}
