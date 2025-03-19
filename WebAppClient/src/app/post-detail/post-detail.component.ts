import { Component, OnInit } from '@angular/core';
import { DataService, Page } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { mergeMap, tap } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-post-detail',
  standalone: false,
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent implements OnInit {
  id: number = 0;
  post: BehaviorSubject<Page | undefined> = new BehaviorSubject<Page | undefined>(undefined);

  isLoaded: boolean = false;

  constructor(private data: DataService,
    private route: ActivatedRoute,
    private router: Router) {

    this.id = 0;
    this.post = this.data.selectedPage$;

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get("id"));
      this.isLoaded = true;
      this.data.getPageById(this.id);
    });
  }

}
