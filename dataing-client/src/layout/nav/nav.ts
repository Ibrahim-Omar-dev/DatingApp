import { AccountService } from '../../core/services/account-services';
import { Component, inject, Injectable, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { ToastServices } from '../../core/services/toast-services';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrls: ['./nav.css'],
})
export class Nav {
  protected accountServices = inject(AccountService);
  private router = inject(Router)
  private toast = inject(ToastServices);
  protected creds: any = {};



  login() {
    this.accountServices.login(this.creds).subscribe({
      next: (response) => {
        this.toast.showSuccess("Successfuly login")
        this.router.navigateByUrl('/members')
      },
      error: (error) => {
        this.toast.showError("The email or password was wrong");
      },
    });
  }
  logout() {
    this.accountServices.logout();
    this.router.navigateByUrl('/')

  }
}
