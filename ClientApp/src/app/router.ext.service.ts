import { Injectable } from '@angular/core';
import { Router, RoutesRecognized } from '@angular/router';
import { filter, pairwise } from 'rxjs/operators';
 /** A router wrapper, adding extra functions. */
@Injectable()
export class RouterExtService {

  private previousUrl: string = undefined;
  private currentUrl: string = undefined;

  constructor(private router : Router) {
    this.router.events
        .pipe(filter((evt: any) => evt instanceof RoutesRecognized), pairwise())
        .subscribe((events: RoutesRecognized[]) => {
            this.previousUrl = events[0].urlAfterRedirects;
            this.currentUrl = events[1].urlAfterRedirects;
});
  }

  public getPreviousUrl(){
    return this.previousUrl;
  }
} 