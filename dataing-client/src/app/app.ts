// src/app/app.ts  (or app.component.ts)
import { Component, OnInit, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom, single } from 'rxjs';
import { Nav } from '../layout/nav/nav';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  imports: [Nav],
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  protected title = 'dataing-client';
  private http = inject(HttpClient);
  protected members = signal<any>([]);

 async ngOnInit() {
    this.members.set(await this.getAllMembers());
  }
  async getAllMembers() {
    try {
      return lastValueFrom(this.http.get('https://localhost:7133/api/member/GetAllMembers'));
    }
    catch (error) {
      console.error('Error fetching members:', error);
      throw error;
    }
  }
}
