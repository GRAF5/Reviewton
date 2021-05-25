import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../shared/services/repository.service';

@Component({
  selector: 'app-privacy',
  templateUrl: './privacy.component.html',
  styleUrls: ['./privacy.component.css']
})
export class PrivacyComponent implements OnInit {
  public claims:[]=[];
  constructor(private _repository: RepositoryService) { }

  ngOnInit(): void {
    
  }

  public getClaims = () =>{
    this._repository.getData('api/')
  }
}
