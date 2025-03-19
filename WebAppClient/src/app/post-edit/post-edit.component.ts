import { Component, OnInit } from '@angular/core';
import { DataService, Page } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { FormBuilder, FormGroup } from '@angular/forms';
import { of } from 'rxjs';


@Component({
  selector: 'app-post-edit',
  standalone: false,
  templateUrl: './post-edit.component.html',
  styleUrl: './post-edit.component.css'
})
export class PostEditComponent {
  id: number = 0;
  page: Page = {
    contentId: 0,
    slug: '',
    Author: '',
    AuthorId: '',
    Title: '',
    Body: '',
    CreatedAt: new Date(),
    UpdatedAt: new Date,
    Visibility: 0,
    CategoryId: 0,
    Category: {
      CategoryId: 0,
      CategoryName: '',
      PostedContent: []
    }
  }
  isLoaded: boolean = false;
  isEditing: boolean = false;
  pageForm: FormGroup = new FormGroup({});
  constructor(private data: DataService,
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
  ) {
    this.data.selectedPage$.subscribe(selectedPage$ => {
      if (selectedPage$ == undefined) {
        console.log("post-edit");
        this.initEmptyForm();
      } else {
        this.initForm(selectedPage$);
      }
    });
  }
  initForm(pageData: Page) {
    this.page = pageData;
    this.pageForm = this.fb.group({
      contentId: [pageData.contentId],
      Title: [pageData.Title],
      Body: [pageData.Body],
      CreatedAt: [pageData.CreatedAt],
      UpdatedAt: [new Date()],
      Visibility: [pageData.Visibility],
      CategoryId: [pageData.CategoryId],
      Category: this.fb.group({
        CategoryId: [pageData.Category.CategoryId],
        CategoryName: [pageData.Category.CategoryName],
        PostedContent: this.fb.array(pageData.Category.PostedContent)
      })
    });

    this.isEditing = true;
    this.isLoaded = true;
  }
  initEmptyForm() {
    this.pageForm = this.fb.group({
      contentId: [0],
      Title: ['title'],
      Body: ['body'],
      CreatedAt: [new Date()],
      UpdatedAt: [new Date()],
      Visibility: [0],
      CategoryId: [0],
      Category: this.fb.group({
        CategoryId: [0],
        CategoryName: [''],
        PostedContent: this.fb.array([])
      })
    });

    this.isEditing = false;
    this.isLoaded = true;
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = Number(params.get("id"));
      if (this.id > 0) {
        this.data.getPageById(this.id);
      }
    });
  }

  loadForm() {
    this.pageForm.patchValue({
      contentId: this.page.contentId,
      Title: this.page.Title,
      Body: this.page.Body,
      CreatedAt: this.page.CreatedAt,
      UpdatedAt: this.page.UpdatedAt,
      Visibility: this.page.Visibility,
      CategoryId: this.page.CategoryId,
      Category: this.page.Category
    });
  }
  onSave() {
    // take the formgroup, read the values, and then submit them to the data service
    console.log(this.pageForm.value);

    let savedPage: Page = {
      contentId: this.pageForm.value.contentId,
      slug: this.pageForm.value.slug,
      Author: this.pageForm.value.Author,
      AuthorId: this.pageForm.value.AuthorId,
      Title: this.pageForm.value.Title,
      Body: this.pageForm.value.Body,
      CreatedAt: this.pageForm.value.CreatedAt,
      UpdatedAt: this.pageForm.value.UpdatedAt,
      Visibility: Number(this.pageForm.value.Visibility),
      CategoryId: this.pageForm.value.CategoryId,
      Category: this.pageForm.value.Category
    }

    if (this.isEditing) {
      this.data.updatePage(this.page.contentId, savedPage);
      this.router.navigate(['post', this.id]);
    } else {
      this.data.createPage(savedPage)
      //this.router.navigate(['post', contentId]);
      this.router.navigate(['post']);
    }
  }

  onClear() {
    // reset the formgroup
  }
}
