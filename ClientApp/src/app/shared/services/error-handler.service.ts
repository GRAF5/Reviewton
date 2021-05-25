import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements HttpInterceptor{

  constructor(private _router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
    return next.handle(req)
    .pipe(
      catchError((error: HttpErrorResponse)=>{
        let errorMessage = this.handleError(error);
        return throwError(errorMessage);
      })
    )
  }

  private handleError = (error: HttpErrorResponse): string =>{
    if(error.status === 404){
      return this.handleNotFound(error);
    }
    else if(error.status === 400){
      return this.handleBadRequest(error);
    }
    else if(error.status === 401) {
      return this.handleUnauthorized(error);
    }
  }

  private handleUnauthorized = (error: HttpErrorResponse) => {
    if(this._router.url === '/authentication/login') {
      return 'Ошибка Аутентификации. Неверный пароль или email';
    }
    else {
      this._router.navigate(['/authentication/login']);
      return error.message;
    }
  }

  private handleNotFound = (error: HttpErrorResponse): string =>{
    this._router.navigate(['/404']);
    return error.message;    
  }

  private handleBadRequest = (error: HttpErrorResponse): string =>{
    if(this._router.url === '/authentication/register'){
      let message = '';
      const values = Object.values(error.error.errors);
      console.log(values);
      values.map((m:string)=>{
        message+=m+'<br>';
      })

      return message.slice(0,-4);
    }
    else{
      return error.error ? error.error:error.message;
    }
  }
}
