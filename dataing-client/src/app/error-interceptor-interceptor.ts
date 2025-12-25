import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError } from 'rxjs';
import { ToastServices } from '../core/services/toast-services';
import { NotFound } from '../shared/not-found/not-found';
import { NavigationExtras, Router } from '@angular/router';

export const errorInterceptorInterceptor: HttpInterceptorFn = (req, next) => {
  const toast = inject(ToastServices);
  const router = inject(Router);
  return next(req).pipe(
    catchError(error => {
      if (error) {
        switch (error.status) {
          case 404:
            router.navigateByUrl("/NotFound");
            break;
          case 401:
            toast.showError("unAuthorize");
            break;
          case 500:
            const navagiateextras: NavigationExtras = { state: { error: error.error } };
            router.navigateByUrl("/server-error",navagiateextras)
            break;
          default:
            toast.showError("someThing Error");
            break;
        } 
      }
      throw error;
    })
  )
};
