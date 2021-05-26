import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule,Routes } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {GroupListComponent} from './groups/group-list.component';
import {GroupAddOrEditComponent} from './groups/group-add-or-edit.component';

import {DataService} from './data.service';
import {RouterExtService} from './router.ext.service';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { AuthGuard } from './shared/guards/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatLineModule } from '@angular/material/core';
import { MaterialModule } from './material/material.module';

const appRoutes: Routes=[
      {path: '', component: GroupListComponent},
      {path: 'group', component: GroupAddOrEditComponent, canActivate: [AuthGuard]},
      {path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m=> m.AuthenticationModule)},
      {path: 'article', loadChildren:()=>import('./article/aricle.module').then(m=>m.ArticleModule), canActivate: [AuthGuard]},
      {path: '**', redirectTo:'/'},
]

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    GroupListComponent,
    GroupAddOrEditComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5001"],
        blacklistedRoutes: []
      }
    }),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgbModule

  ],
  providers: [
    DataService,
    RouterExtService,
    {
      provide: HTTP_INTERCEPTORS, 
      useClass: ErrorHandlerService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
