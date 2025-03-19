import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Category {
  CategoryId: number;
  CategoryName: string;
  PostedContent: Page[];
}

export interface Page {
  ContentId: number;
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
  
  pages: Page[];
  constructor(private _http: HttpClient) {
    this.pages = [
      {
        ContentId: 1,
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
        ContentId: 2,
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
        ContentId: 3,
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

  }

  getAllPages(): Observable<Page[]> {
    return this._http.get<Page[]>('/api/contents/');
  }
  getPageById(id: number): Observable<Page> {
    return this._http.get<Page>('/api/contents/'+id);
  }
}

