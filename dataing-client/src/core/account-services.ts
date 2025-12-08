import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { UserCreds } from '../types/UserCreds';
import { RegisterCreds } from '../types/RegisterCreds';
import { LoginCreds } from '../types/LoginCreds';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient);
  private baseUrl = "https://localhost:7133/api/account/";
  currentUser = signal<any>(null);

  Register(creds: RegisterCreds)
  {
    return this.http.post<UserCreds>(this.baseUrl + 'register', creds).pipe(
      tap((user) => {
        if (user) {
          this.GetcurrentUser(user);
        }
      })
    );
  }

  login(creds:LoginCreds) {
    return this.http.post<UserCreds>(this.baseUrl + 'login', creds).pipe(
      tap((user) => {
        if (user) {
          this.GetcurrentUser(user);
        }
      })
    );
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
  GetcurrentUser(user: UserCreds)
  {
      localStorage.setItem('user', JSON.stringify(user));
      this.currentUser.set(user)
  }
}
