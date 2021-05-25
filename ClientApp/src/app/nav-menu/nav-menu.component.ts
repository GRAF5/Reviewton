import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../shared/services/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isUserAuthenticated: boolean;

  isExpanded = true;

  constructor(private _authService: AuthenticationService, private _router: Router){
    this._authService.authChanged
    .subscribe(res => {
      this.isUserAuthenticated = res;
    })
  }
  ngOnInit(){
    this._authService.authChanged
    .subscribe(res=>{
      this.isUserAuthenticated = res;
    })
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public logout = () => {
    this._authService.logout();
    this._router.navigate(["/"]);
  }
}
