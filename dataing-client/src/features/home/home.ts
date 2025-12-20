import { Component, Input, signal } from '@angular/core';
import { Register } from "../accout/register/register";    

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [Register],      
  templateUrl: './home.html',
  styleUrls: ['./home.css']
})
export class Home {
  
  registerMode = signal(false);

  showRegister(vaule: boolean) {
    this.registerMode.set(vaule);
  }
}
