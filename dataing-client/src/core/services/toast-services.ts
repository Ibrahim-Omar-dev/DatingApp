import { Messages } from '../../features/messages/messages';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class ToastServices {
  constructor(private toastr:ToastrService) {
  }
  showSuccess(success:string) {
    this.toastr.success(success, 'Success');
  }

  showError(error:string) {
    this.toastr.error(error, 'Error');
  }

  showWarning(warn:string) {
    this.toastr.warning(warn, 'Warning');
  }

  showInfo(info:string) {
    this.toastr.info(info, 'Info');
  }

}


