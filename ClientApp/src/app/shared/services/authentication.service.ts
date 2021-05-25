import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { AuthResponseDto } from 'src/app/interfaces/authResponseDto';
import { ForgotPasswordDto } from 'src/app/interfaces/forgotPasswordDto';
import { RegistrationResponseDto } from 'src/app/interfaces/registrationResponseDto';
import { UserForAuthenticationDto } from 'src/app/interfaces/userForAuthenticationDto';
import { UserForRegistrtionDto } from 'src/app/interfaces/userForRegistrtionDto';
import { EnvironmentUrlService } from './environment-url.service'

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>();
  private _isAdmin = new Subject<boolean>();

  public authChanged = this._authChangeSub.asObservable();
  public isAdmin = this._isAdmin.asObservable();

  constructor(private _http:HttpClient, private _envUrl:EnvironmentUrlService, private _jwtHelper: JwtHelperService) { }

  public isUserAdmin = (): boolean => {
    const token = localStorage.getItem("token");
    const decodeToken = this._jwtHelper.decodeToken(token);
    if(!decodeToken || this._jwtHelper.isTokenExpired(token)){
      this._isAdmin.next(false);
      return false;
    }
    const role = decodeToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    this._isAdmin.next(role === 'Administrator');
    return role === 'Administrator';
  }

  public isUserAuthenticated = (): boolean =>{
    const token = localStorage.getItem("token");

    return token && !this._jwtHelper.isTokenExpired(token);
  }

  public sendAuthStateChangeNotification = (isAuthenticated: boolean) => {
    if(isAuthenticated){
      this.isUserAdmin();
    }else{
      this._isAdmin.next(false);
    }

    this._authChangeSub.next(isAuthenticated);
  }

  public registerUser = (route: string, body: UserForRegistrtionDto) =>{
    return this._http.post<RegistrationResponseDto> (this.createComleteRoute(route, this._envUrl.urlAddress), body);
  }

  private createComleteRoute = (route: string, envAddress: string) =>{
    return `${envAddress}/${route}`;
  }

  public loginUser = (route: string, body: UserForAuthenticationDto) =>{
    return this._http.post<AuthResponseDto>(this.createComleteRoute(route, this._envUrl.urlAddress), body);
  }

  public logout = () =>{
    localStorage.removeItem("token");
    this.sendAuthStateChangeNotification(false);
  }

  public forgotPassword = (route: string, body: ForgotPasswordDto) => {
    return this._http.post(this.createComleteRoute(route, this._envUrl.urlAddress), body);
  }
}
