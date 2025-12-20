import { Component, OnInit, inject, signal } from '@angular/core';
import { Nav } from '../layout/nav/nav';
import { Router, RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  imports: [Nav, RouterOutlet],
  styleUrls: ['./app.css']
})
export class App  {
  protected router = inject(Router)
}
