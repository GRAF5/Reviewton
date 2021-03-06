import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PasswordConfirmationValidatorService } from 'src/app/shared/custom-validators/password-confirmation-validator.service';
import { UserForRegistrtionDto } from './../../interfaces/userForRegistrtionDto';
import { AuthenticationService } from './../../shared/services/authentication.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;
  public errorMessage: string = '';
  public showError:boolean;

  constructor(private _authService: AuthenticationService, private _passConfValidator: PasswordConfirmationValidatorService,
    private _router: Router) { }
  ngOnInit() {
    this.registerForm = new FormGroup({
      name: new FormControl('',[Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('',[Validators.required]),
      confirm: new FormControl('')
    });
    this. registerForm.get('confirm').setValidators([Validators.required,
    this._passConfValidator.validateConfirmPassword(this.registerForm.get('password'))]);
  }
  
  public validateControl = (controlName: string)=>{
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string)=>{
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public registerUser = (registerFormValue)=>{
    this.showError = false;
    const formValues = {...registerFormValue};

    const user: UserForRegistrtionDto = {
      name: formValues.name,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };

    this._authService.registerUser("api/accounts/registration", user)
    .subscribe(_=>{
      this._router.navigate(["/authentication/login"]);
    },
    error=>{
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
