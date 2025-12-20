import { Component, input, output, inject } from '@angular/core';  // Add inject here
import { AccountService } from '../../../core/services/account-services';
import { RegisterCreds } from '../../../types/RegisterCreds';
import { FormsModule } from '@angular/forms';
import { UserCreds } from '../../../types/UserCreds';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  accountService = inject(AccountService);
  creds = {} as RegisterCreds;

  RegisterMode = output<boolean>();

  register() {
    this.accountService.Register(this.creds).subscribe({
      next: response => { 
        console.log('Registration successful:', response);
        this.cancel();
      },
      error: error => {
        console.error('Registration failed:', error);
      },
    });
  }
  
  cancel() {
    this.RegisterMode.emit(false);
  }
}