import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterUserComponent } from './register-user/register-user.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';



@NgModule({
  declarations: [RegisterUserComponent, LoginComponent, ForgotPasswordComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: 'register', component: RegisterUserComponent},
      {path: 'login', component: LoginComponent},
      {path: 'forgotpassword', component: ForgotPasswordComponent}
    ]),
    FormsModule
  ]
})
export class AuthenticationModule { }
