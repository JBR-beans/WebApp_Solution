import { Component } from '@angular/core';

interface PageLink {
  id: number;
  component: Component | undefined;
  slug: string;

}


@Component({
  selector: 'app-nav',
  standalone: false,
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  staticPages: PageLink[] = [
    {
    id: 1,
    component: undefined,
    slug: 'post-slug1'
    },
    {
    id: 2,
    component: undefined,
    slug: 'post-slug2'
    },
    {
    id: 3,
    component: undefined,
    slug: 'post-slug3'
    }
  ];
}
