import { Component } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-post-list',
  standalone: false,
  templateUrl: './post-list.component.html',
  styleUrl: './post-list.component.css'
})
export class PostListComponent {
constructor(private data: DataService){
  
}
}
