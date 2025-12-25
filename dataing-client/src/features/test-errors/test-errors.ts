import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  imports: [],
  templateUrl: './test-errors.html',
  styleUrl: './test-errors.css',
})
export class TestErrors {
  private http = inject(HttpClient);

  baseUrl = "https://localhost:7133/api/";

  get404Error()
  {
    this.http.get(this.baseUrl + "Error/notfound").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  getAuthError()
  {
    this.http.get(this.baseUrl + "Error/auth").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
  get500Error()
  {
    this.http.get(this.baseUrl + "Error/serverError").subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  
  }
}
