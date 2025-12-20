import { inject, Injectable } from '@angular/core';
import { AccountService } from './services/account-services';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InitServices {
  private account = inject(AccountService);
  init()
  {
    const userString = localStorage.getItem('user');
    if(!userString) return of(null);
    const user = JSON.parse(userString);
    this.account.currentUser.set(user); 
    return of(null)
  }
}
