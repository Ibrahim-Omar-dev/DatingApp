import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../core/services/account-services';
import { ToastServices } from '../core/services/toast-services';

export const authGuard: CanActivateFn = () => {
  const accountService = inject(AccountService)
  const toast = inject(ToastServices)
  if (accountService.currentUser())
  {
    return true
  }
  else
  {
    toast.showError("You should login")
    return false;
  }
};
