import { Component, numberAttribute, OnInit } from '@angular/core';
import { DataService, Page } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-post-detail',
  standalone: false,
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent implements OnInit{
  id: number = 0;
  post: Page | undefined;

  constructor(private data: DataService,
    private route: ActivatedRoute,
    private router: Router) {

      this.id = 1;
      this.post = {
        contentId: 0,
        slug: "",
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

    
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get("id"));
      this.post = this.data.pages.find(p => p.contentId == this.id);
    });
  }

  
}
