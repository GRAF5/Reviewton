import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { DataService } from 'src/app/data.service'
import { GroupType } from 'src/app/models/GroupTypes';
import { AuthenticationService } from '../shared/services/authentication.service';
 
@Component({
    templateUrl: './group-list.component.html',
    providers: [DataService]
})
export class GroupListComponent implements OnInit {
    private _isAdmin = new Subject<boolean>();
    public isAdmin:boolean;
    groupTypes: GroupType[];

    constructor(private dataService: DataService, private router: Router, private _authService: AuthenticationService,private cd: ChangeDetectorRef) {
        
    }
 
    ngOnInit() {
        this.load();
        this._authService.isAdmin
            .subscribe(res=>{
                this.isAdmin = res;
                this.cd.markForCheck();
            })
        this.isAdmin = this._authService.isUserAdmin();
        console.log(this.isAdmin);
        //this.isAdmin = this._authService.isUserAdmin();
    }
    load(){
        this.dataService.getGroupTypes().subscribe((data: GroupType[]) => this.groupTypes = data);
    }
    change(p:GroupType){
        this.router.navigateByUrl("group", { state: {data:{groupType: p}}});
    }
    delete(p: GroupType) {
    this.dataService.deleteGroupTypes(p.idGroupType).subscribe(data => this.load());
    }
}