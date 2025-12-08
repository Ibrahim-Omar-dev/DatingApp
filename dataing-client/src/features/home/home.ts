import { Component, Input, signal } from '@angular/core';
import { Register } from "../accout/register/register";      // Make sure this is a component
import { UserCreds } from '../../types/UserCreds';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [Register],        // Must be a standalone component
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home {
  
  registerMode = signal(false);

  showRegister(vaule: boolean) {
    this.registerMode.set(vaule);
  }
}
