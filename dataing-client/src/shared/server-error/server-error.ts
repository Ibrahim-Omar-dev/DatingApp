import { Component, inject } from "@angular/core";
import { ApiError } from "../../types/ApiError";
import { Router } from "@angular/router";

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.html',
  standalone:true,
  styleUrls: ['./server-error.css'],
})
export class ServerError {
  protected error!: ApiError;
  protected showDetails = false;

  private router = inject(Router);

  constructor() {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation?.extras?.state?.['error'] ?? {
      message: 'Unknown server error'
    };
  }

  DetailsToggle() {
    this.showDetails = !this.showDetails;
  }
}
