import { Component } from '@angular/core';

interface Page {
  slug: string;
  component: Component | undefined;
  path: string;

}


@Component({
  selector: 'app-nav',
  standalone: false,
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  staticPages: Page[] = [
    {
    slug: 'slug1',
    component: undefined,
    path: 'post/slug1'
    },
    {
      slug: 'slug2',
      component: undefined,
      path: 'post/slug2'
      },
      {
        slug: 'slug3',
        component: undefined,
        path: 'post/slug3'
        },
  ];
}
