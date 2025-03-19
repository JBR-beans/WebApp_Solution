import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, delay, map, Observable, tap } from 'rxjs';


export interface Category {
  CategoryId: number;
  CategoryName: string;
  PostedContent: Page[];
}

export interface Page {
  contentId: number;
  slug: string,
  Title: string;
  Body: string;
  AuthorId: string;
  Author: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  Visibility: number;
  CategoryId: number;
  Category: Category;
}

@Injectable({
  providedIn: 'root'
})

export class DataService {


  pages$: BehaviorSubject<Page[]> = new BehaviorSubject<Page[]>([]);

  selectedPage$: BehaviorSubject<Page | undefined> = new BehaviorSubject<Page | undefined>(undefined);

  pages: Page[] = [];
  constructor(private _http: HttpClient) {
 /*   this.pages = [
      {
        contentId: 1,
        slug: "slug1",
        Title: 'new page 1',
        Body: 'this is a new page',
        AuthorId: 'author1',
        Author: 'author1',
        CreatedAt: new Date(),
        UpdatedAt: new Date(),
        Visibility: 1,
        CategoryId: 1,
        Category: {
          CategoryId: 1,
          CategoryName: 'new category1',
          PostedContent: []
        }
      },
      {
        contentId: 2,
        slug: "slug2",
        Title: 'new page 2',
        Body: 'this is a new page',
        AuthorId: 'author2',
        Author: 'author2',
        CreatedAt: new Date(),
        UpdatedAt: new Date(),
        Visibility: 1,
        CategoryId: 2,
        Category: {
          CategoryId: 2,
          CategoryName: 'new category2',
          PostedContent: []
        }
      },
      {
        contentId: 3,
        slug: "slug3",
        Title: 'new page3',
        Body: 'this is a new page',
        AuthorId: 'author3',
        Author: 'author3',
        CreatedAt: new Date(),
        UpdatedAt: new Date(),
        Visibility: 1,
        CategoryId: 3,
        Category: {
          CategoryId: 3,
          CategoryName: 'new category3',
          PostedContent: []
        }
      },
    ];
*/
  }

  getAllPages(): void {
    this._http.get<Page[]>('/api/contents').pipe(
      tap(x => {
        console.log('getallpages');
      }),
      delay(1000)
    ).subscribe(data => {
      this.pages$.next(data);
    })
  }
  
  getPageById(id: number): void {
    this._http.get<Page>('/api/contents/' + id).pipe(
      tap(x => {
        console.log('getPageById : ', x);
      }),
      delay(1000)
    ).subscribe((data: Page) => { // next
      console.log("getPostById success", data)
      this.selectedPage$.next(data);
    }, (err) => { // err
      this.selectedPage$.next(undefined);
    }, () => {
      console.log("end")
    });
  }

  createPage(page: Page): void {
    this._http.post<Page>('/api/contents/', page).subscribe(data => {
      this.getAllPages();
    });
  }

  updatePage(id: number, page: Page): void {
    this._http.put<Page>('/api/contents/' + id, page).subscribe(data => {
      this.getAllPages();
    });
  }


  deletePageById(id: number): void {
    this._http.delete<any>('/api/contents/' + id).pipe(tap(x => {
      console.log("tap, delete by id");
    })).subscribe(result => {
      this.getAllPages();
    });
  }
    deletePage(page: Page): void {
      this.deletePageById(page.contentId);
    }

  }

