import { Component, OnInit, Input, ViewChildren, QueryList } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/data.service'
import { GroupType } from 'src/app/models/GroupTypes';
import { AtributesGroup } from 'src/app/models/AtributesGroup';
import { Atribute } from 'src/app/models/Atribute';
@Component({
    templateUrl: './group-add-or-edit.component.html',
    providers: [DataService],
    styleUrls: ['./group-add-or-edit.component.css']
})
export class GroupAddOrEditComponent implements OnInit {
    groupType: GroupType;                                        //изменяемая группа
    atributesGroup: AtributesGroup = new AtributesGroup();     //изменяемая категория  
    editableAtributesGroup: AtributesGroup = new AtributesGroup();   
    atribute: Atribute;                                          //изменяемый атрибут
    editGroup: boolean = true;     
    newGroup: boolean; 
    newAtributeName: string;
    changeAtributeName:string;              // режим изменения Группы
    //newAtributeGroupName: string;
 
    constructor(private dataService: DataService, private router: Router) {}
 
    ngOnInit() {
        this.loadProducts();
    }

    // получаем данные через сервис
    loadProducts() {  
        if(history.state.data != undefined){
            this.newGroup = false;
        this.groupType = history.state.data.groupType;
        }else{
            this.newGroup = true;
            this.groupType = new GroupType([]);
        }
    }
    // сохранение данных
    saveGroup() {
        if(this.newGroup){
            this.dataService.createGroupTypes(this.groupType).subscribe(data => this.router.navigateByUrl("/"));
        }else{
        this.dataService.updateGroupTypes(this.groupType).subscribe(data => this.router.navigateByUrl("/"));
        }
    }
    startEditAtributeGroup(ag: AtributesGroup){
        this.atributesGroup = ag;
        var atributes=Array<Atribute>();
        ag.atributes.forEach(a=>atributes.push(new Atribute(a)));
        this.editableAtributesGroup = new AtributesGroup({atributes:atributes, idAtrbutesGroup:ag.idAtrbutesGroup, name: ag.name});
        this.editGroup = false;
    }
    saveAtributesGroup(){
        var n = this.groupType.atributesGroups.indexOf(this.atributesGroup);
        if(n == -1){
            this.groupType.atributesGroups.push(this.editableAtributesGroup);
        }else{
            this.groupType.atributesGroups[n] = this.editableAtributesGroup;
        }
        this.editGroup = true;
        this.atributesGroup = new AtributesGroup();
        this.editableAtributesGroup = new AtributesGroup();
    }
    cancelAtributesGroup(){
        this.editGroup = true;
        this.atribute = new Atribute();
        this.atributesGroup = new AtributesGroup();
    }
    deleteAtributeGroup(ag: AtributesGroup){
        this.groupType.atributesGroups.splice(this.groupType.atributesGroups.indexOf(ag),1);
    }
    addAtribute(){
        this.editableAtributesGroup.atributes.push(new Atribute({name:this.newAtributeName}));
        this.newAtributeName = "";
    }
    editAtribute(ag: Atribute){
        this.atribute = ag;
        this.changeAtributeName = ag.name;
    }
    saveAtribute(){
        this.atribute.name = this.changeAtributeName;
        this.atribute = new Atribute();
    }
    cancelAtribute(){
        this.atribute = new Atribute();
    }
    deleteAtribute(ag: Atribute){
        this.editableAtributesGroup.atributes.splice(this.atributesGroup.atributes.indexOf(ag),1);
    }
}