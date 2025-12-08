import { Home } from '../features/home/home';
import { Component, OnInit, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom, single } from 'rxjs';
import { Nav } from '../layout/nav/nav';
import { AccountService } from '../core/account-services';
import { UserCreds } from '../types/UserCreds';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  imports: [Nav,Home],
  styleUrls: ['./app.css']
})
export class App implements OnInit {
  protected title = 'dataing-client';
  private http = inject(HttpClient);
  private accountService = inject(AccountService);
  protected members = signal<UserCreds[]>([]);

 async ngOnInit() {
   this.members.set(await this.getAllMembers());
    this.setCurrentUser();
  }
  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if(!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user); 
  }

  async getAllMembers(){
    try {
      return lastValueFrom(this.http.get<UserCreds[]>('https://localhost:7133/api/member/GetAllMembers'));
    }
    catch (error) {
      console.error('Error fetching members:', error);
      throw error;
    }
  }
}
