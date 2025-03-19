import { Component } from '@angular/core';

interface PageLink {
  slug: string;
  component: Component | undefined;
  displayName: string;

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
    slug: 'slug1',
    component: undefined,
    displayName: 'slug1'
    },
    {
    slug: 'slug2',
    component: undefined,
    displayName: 'slug2'
    },
    {
    slug: 'slug3',
    component: undefined,
    displayName: 'slug3'
    }
  ];
}
