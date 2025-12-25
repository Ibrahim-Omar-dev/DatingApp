import { ApplicationConfig, inject, provideAppInitializer, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withViewTransitions } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { filter, lastValueFrom } from 'rxjs';
import { InitServices } from '../core/init-services';
import { errorInterceptorInterceptor } from './error-interceptor-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes,withViewTransitions()),
    provideHttpClient(withInterceptors([errorInterceptorInterceptor])),
    provideAnimations(),
    provideToastr({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    }),
    provideAppInitializer(async () => {
      const initServices = inject(InitServices)
       try {
            return lastValueFrom(initServices.init())
          }
      finally {
            const splash = document.getElementById("splash");
            if(splash) {
              splash.remove();
            }
          }
    })
  ]
};
