import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddArticleComponent } from './add-article/add-article.component';
import { MaterialModule } from '../material/material.module';
import { DataService } from '../data.service';



@NgModule({
  declarations: [AddArticleComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: 'add', component: AddArticleComponent}
    ]),
    FormsModule,
    NgbModule,
    MaterialModule
  ],
  providers: [DataService]
})
export class ArticleModule {


 }
