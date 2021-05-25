import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ForgotPasswordDto } from 'src/app/interfaces/forgotPasswordDto';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  public forgotPasswordForm: FormGroup;
  public successMessage: string;
  public errorMessage: string;
  public showSuccess: boolean;
  public showError: boolean;

  constructor(private _authService: AuthenticationService) { }

  ngOnInit(): void {
    this.forgotPasswordForm = new FormGroup({
      email: new FormControl("", [Validators.required])
    })
  }

  public validateControl = (controlName: string) =>{
    return this.forgotPasswordForm.controls[controlName].invalid && this.forgotPasswordForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) =>{
    return this.forgotPasswordForm.controls[controlName].hasError(errorName)
  }

  public forgotPassword = (forgotPasswordFormValue) =>{
    this.showError = this.showSuccess = false;

    const forgotPass = {...forgotPasswordFormValue};
    const forgotPassDto: ForgotPasswordDto = {
      email:forgotPass.email,
      clientURI: environment.urlAddress+'/authentication/resetpassword'
    }

    this._authService.forgotPassword('api/accounts/forgotpassword', forgotPassDto)
    .subscribe(_ =>{
      this.showSuccess = true;
      this.successMessage = 'Письмо отправлено, пожалуйста проверьте свою почту.'
    },
    err=>{
      this.showError = true;
      this.errorMessage = err;
    })
  }
}
