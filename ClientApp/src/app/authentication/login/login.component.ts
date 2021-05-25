import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserForAuthenticationDto } from 'src/app/interfaces/userForAuthenticationDto';
import { User } from 'src/app/models/User';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string ='';
  public showError: boolean;
  private _returnUrl: string;

  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })

    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }

  public validateControl = (controlName: string) => {
    return this.loginForm.controls[controlName].invalid && this.loginForm.controls[controlName].touched
  }

  public hasError = (controleName: string, errorName: string) => {
    return this.loginForm.controls[controleName].hasError(errorName)
  }

  public loginUser = (loginFormValue) => {
    this.showError = false;
    const login = {... loginFormValue};
    const userForAuth: UserForAuthenticationDto = {
      Email: login.email,
      Password: login.password
    }
    this._authService.loginUser('api/accounts/login', userForAuth)
    .subscribe(res => {
      localStorage.setItem("token", res.token);      
      localStorage.setItem("user", JSON.stringify(res.user));
      this._authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
      this._router.navigate([this._returnUrl]);
    },
    (error) =>{
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
