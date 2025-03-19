import { Component } from "@angular/core";
import { DataService, Page } from "../data.service";
import { BehaviorSubject } from "rxjs";

@Component({
  selector: 'app-post-list',
  standalone: false,
  templateUrl: './post-list.component.html',
  styleUrl: './post-list.component.css'
})
export class PostListComponent {
  pages: BehaviorSubject<Page[]> = new BehaviorSubject<Page[]>([]);

  constructor(private data: DataService) {
    this.data.getAllPages();
    this.pages = this.data.pages$;
  }
}
