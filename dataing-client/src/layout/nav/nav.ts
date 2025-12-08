import { AccountService } from './../../core/account-services';
import { Component, inject, Injectable, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './nav.html',
  styleUrls: ['./nav.css'],
})
export class Nav {
  protected accountServices = inject(AccountService);
  protected creds: any = {};


  login() {
    this.accountServices.login(this.creds).subscribe({
      next: (response) => {
        console.log('Login successful', response);
      },
      error: (error) => {
        console.error('Login failed', error);
      },
    });
  }
  logout() {
    this.accountServices.logout();
  }
}
