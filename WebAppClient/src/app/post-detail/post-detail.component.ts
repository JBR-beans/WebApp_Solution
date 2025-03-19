import { Component, numberAttribute } from '@angular/core';
import { DataService, Page } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-post-detail',
  standalone: false,
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent {
  id: number = 0;
  post: Page | undefined;

  constructor(private data: DataService,
    private route: ActivatedRoute,
    private router: Router) {

      this.id = 1;
      this.post = {
        ContentId: 0,
        AuthorId: "",
        Author: "",
        Title: "",
        Body: "",
        CreatedAt: new Date(),
        UpdatedAt: new Date(),
        CategoryId: 0,
        Category: {
          CategoryId: 0,
          CategoryName: "",
          PostedContent: []
        },
        Visibility: 0
      };
    
    this.initComponent();

  }

  initComponent() {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get("id"));
      this.post = this.data.pages.find(p => p.ContentId == this.id);
    });
    //this.id = Number(this.route.snapshot.paramMap.get('id'));
    //let page = this.data.pages.find(p => p.ContentId == this.id);
  }


}
