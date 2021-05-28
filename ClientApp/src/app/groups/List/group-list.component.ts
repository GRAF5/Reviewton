import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { DataService } from 'src/app/data.service'
import { FilterProductDto } from 'src/app/interfaces/filterProductDto';
import { Article } from 'src/app/models/Article';
import { AtributesGroup } from 'src/app/models/AtributesGroup';
import { AtributeValue } from 'src/app/models/AtributeValue';
import { GroupType } from 'src/app/models/GroupTypes';
import { Product } from 'src/app/models/Product';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
 
@Component({
    templateUrl: './group-list.component.html',
    styleUrls: ['./list.css','./star.scss','./star2.scss'],
    providers: [DataService]
})
export class GroupListComponent implements OnInit {
    private _isAdmin = new Subject<boolean>();
    public isAdmin:boolean;
    stars:number[] = [1,2,3,4,5];

    groupTypes: GroupType[];
    categories: AtributesGroup[];
    atributeValues: AtributeValue[];
    products: Product[];
    articles: Article[];

    selectedAV: AtributeValue[] = [];
    selectedGroupName: string;
    selectedCategoryName: string;
    selectedCategory: AtributesGroup;
    selectedAtrName:string;
    selectedProductName: string;
    selectedProduct: Product;
    atributeName: string;

    isGroupChoise: boolean = true;
    isCategoriesChoise: boolean = false;
    isAtributeValueChoise: boolean = false;
    isProductChoise: boolean = false;
    isArticleChoise: boolean = false;

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

    async selectGroup(gt: GroupType){
        this.selectedGroupName = gt.name;
        this.categories = (await this.dataService.getAtributesGroupsOf(gt.idGroupType) as AtributesGroup[]);
        this.modeSelect(2);
    }

    async selectCategory(category: AtributesGroup){
        this.selectedCategory = category;
        this.selectedCategoryName = category.name;
        this.atributeName = category.atributes[0].name;
        this.atributeValues = (await this.dataService.getAtributeValuesOf(category.atributes[0].idAtribute) as AtributeValue[]);
        this.modeSelect(3);
    }

    async selectAV(av: AtributeValue){
        this.selectedAV.push(av);
        if(av.childrens.length > 0){
            this.atributeValues = (await this.dataService.getAtributeValuesChildren(av.idAtribute,av.value) as AtributeValue[]);
            this.atributeName = this.atributeValues[0].atribute.name;
            this.modeSelect(3);
        }
        else{
            var fp:FilterProductDto = {
                selectedAV: this.selectedAV
            };
            console.log(fp);
            this.products = (await this.dataService.getFilteredProducts(fp) as Product[]);
            this.modeSelect(4);
        }
    }

    async selectProduct(pr:Product){
        this.selectedProduct = pr;
        this.selectedProductName = pr.name;
        this.articles = (await this.dataService.getArticles(pr.idProduct) as Article[]);
        console.log(this.articles);
        this.modeSelect(5);
    }

    async modeSelect(modeNum, aVNum?: number){
        switch (modeNum){
            case 1:
                this.selectedAV.length = 0;
                this.isGroupChoise = true;
                this.isCategoriesChoise = false;
                this.isAtributeValueChoise = false;
                this.isProductChoise = false;
                this.isArticleChoise = false;
                break;
            case 2:
                this.selectedAV.length = 0;
                this.isGroupChoise = false;
                this.isCategoriesChoise = true;
                this.isAtributeValueChoise = false;
                this.isProductChoise = false;
                this.isArticleChoise = false;
                break;
            case 3:
                if(aVNum >=0){
                    if(aVNum<=0){
                        console.log("<=0");
                        this.atributeName = this.selectedCategory.atributes[0].name;
                        this.atributeValues = (await this.dataService.getAtributeValuesOf(this.selectedCategory.atributes[0].idAtribute) as AtributeValue[]);
                    }
                    else{
                        console.log(">=0");
                        this.atributeValues = (await this.dataService.getAtributeValuesChildren(this.selectedAV[aVNum - 1].idAtribute, this.selectedAV[aVNum - 1].value) as AtributeValue[]);
                        this.atributeName = this.atributeValues[0].atribute.name;
                    }
                    this.selectedAV.length = aVNum;
                }
                this.isGroupChoise = false;
                this.isCategoriesChoise = false;
                this.isAtributeValueChoise = true;
                this.isProductChoise = false;
                this.isArticleChoise = false;
                break;
            case 4:
                this.isGroupChoise = false;
                this.isCategoriesChoise = false;
                this.isAtributeValueChoise = false;
                this.isProductChoise = true;
                this.isArticleChoise = false;
                break;
            case 5:
                this.isGroupChoise = false;
                this.isCategoriesChoise = false;
                this.isAtributeValueChoise = false;
                this.isProductChoise = false;
                this.isArticleChoise = true;
                break;
        }
    }

    calcRate(rate:number){
        return (rate/5)*100;
    }
}