import { Component, OnInit } from '@angular/core';
import {RouterExtService} from 'src/app/router.ext.service';
import { DataService } from './data.service';
import { AtributesGroup } from './models/AtributesGroup';
import { GroupType } from './models/GroupTypes';
import { Router, RoutesRecognized } from '@angular/router';
import { filter, pairwise } from 'rxjs/operators';
import { AuthenticationService } from './shared/services/authentication.service';

@Component({

  selector: 'app-root',
  templateUrl: './app.component.html'
  //providers: [DataService]
})
export class AppComponent implements OnInit{
  
  constructor(private _authService: AuthenticationService){}

  ngOnInit(): void{
      this._authService.sendAuthStateChangeNotification(this._authService.isUserAuthenticated());
  }
}
/*
export class AppComponent implements OnInit {

  groupType: GroupType = new GroupType([]);   // изменяемый товар
  groupTypes: GroupType[];                // массив товаров

  newAtributeGroupName: string;       //Имя новой категории
  atributeGroup: AtributesGroup = new AtributesGroup(); //изменяемая категория
  //atributeGroups: AtributesGroup[];
  tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    //this.loadProducts();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadProducts() {
    this.dataService.getGroupTypes()
      .subscribe((data: GroupType[]) => this.groupTypes = data);
  }
  */
  // сохранение данных
  /*
  save() {
    if (this.groupType.idGroupType == null) {
      this.dataService.createGroupTypes(this.groupType)
        .subscribe((data: GroupType) => this.groupTypes.push(data));
    } else {
      this.dataService.updateGroupTypes(this.groupType)
        .subscribe(data => this.loadProducts());
    }
    this.cancel();
  }
  editProduct(p: GroupType) {
    this.groupType = p;
    //this.atributeGroups = p.atributesGroups;
  }
  editAtributeGroup(ag: AtributesGroup){
    this.atributeGroup = ag;
  }
  cancel() {
    this.groupType = new GroupType([]);
    this.tableMode = true;
  }
  delete(p: GroupType) {
    //this.dataService.deleteGroupTypes(p.idGroupType).subscribe(data => this.loadProducts());
  }
  addAtributeGroup(){
    this.groupType.atributesGroups.push(new AtributesGroup(undefined,this.newAtributeGroupName));
    this.newAtributeGroupName = "";
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}*/
