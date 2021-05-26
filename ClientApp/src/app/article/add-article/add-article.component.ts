import { Component, NgModule, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { MatAutocompleteActivatedEvent, MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatOptionSelectionChange } from '@angular/material/core';
import { Router } from '@angular/router';
import { NgbTypeahead } from '@ng-bootstrap/ng-bootstrap';
import { from, merge, Observable, OperatorFunction, Subject } from 'rxjs';
import { catchError, debounceTime, distinctUntilChanged, filter, map, startWith } from 'rxjs/operators';
import { DataService } from 'src/app/data.service';
import {ArticleAddDto} from 'src/app/interfaces/articleAddDto'
import { Article } from 'src/app/models/Article';
import { Atribute } from 'src/app/models/Atribute';
import { AtributesGroup } from 'src/app/models/AtributesGroup';
import { AtributeValue } from 'src/app/models/AtributeValue';
import { Country } from 'src/app/models/Country';
import { GroupType } from 'src/app/models/GroupTypes';
import { Producer } from 'src/app/models/Producer';
import { Product } from 'src/app/models/Product';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-add-article',
  templateUrl: './add-article.component.html',
  styleUrls: ['./add-article.component.css','./add-article.component.scss'],
  providers: [DataService]
})
export class AddArticleComponent implements OnInit {
  public addArticleForm: FormGroup;
  options: any[];
  filteredOptions: Observable<any[]>;

  nowSelectName:string;

  public errorMessage: string;
  public showError: boolean;

  public products: Product[];
  public groups: Array<GroupType>;
  public categories: AtributesGroup[];
  public atributes: Atribute[];
  public producers: Producer[];
  public countries: Country[];

  public isNewProduct:boolean = true;
  public isNewProducer:boolean=true;
  public isNewCountry:boolean=true;
  public selectedProduct: Product;
  public selectedGroup: GroupType;
  public selectedCategory: AtributesGroup;
  public selectedAtributes: AtributeValue[] = [];
  public selectedProducer: Producer;
  public selectedCountry: Country;
  public selectedRate: number = 0;
  public selectedText: string;
  
  productFormControl = new FormControl('', [Validators.required,]);
  groupFormControl = new FormControl('', [Validators.required,]);
  categoryFormControl = new FormControl('', [Validators.required,]);
  public atrFormControl: FormControl[] = [new FormControl('', [Validators.required,])];
  producerFormControl = new FormControl('', [Validators.required,]);
  countryFormControl = new FormControl('', [Validators.required,]);

  constructor(private dataService: DataService, private router: Router) { 
  }

  ngOnInit(): void {
    this.load();
    this.addArticleForm = new FormGroup({
      productFormControl: new FormControl('', [Validators.required,]),
      groupFormControl: new FormControl('', [Validators.required,]),
      categoryFormControl: new FormControl('', [Validators.required,]),
      producerFormControl: new FormControl('', [Validators.required,]),
      countryFormControl: new FormControl('', [Validators.required,])
    });
  }

  //проверка валидности формы
  public isValid(){
    if(!this.isNewProduct){
      if(this.selectedRate>0 && this.selectedProduct) return true;
    }
    else{
      if(this.selectedRate>0 && this.selectedProduct && this.selectedGroup && this.selectedCategory
        && this.producerFormControl.valid && this.countryFormControl.valid && this.isAtrControlvalid()) return true;
    }
    return false;
  }

  load(){
    this.dataService.getProducts().subscribe((data: Array<Product>) => this.products = data);
    this.dataService.getGroupTypes().subscribe((data: Array<GroupType>) => this.groups = data);
    this.dataService.getCountries().subscribe((data: Array<Country>) => this.countries = data);
    this.dataService.getProducers().subscribe((data: Array<Producer>) => this.producers = data);
  }

  public validateControl = (controlName: string) =>{
    return this.addArticleForm.controls[controlName].invalid && this.addArticleForm.controls[controlName].touched
  }

  public hasError = (controlName: string, errorName: string) =>{
    return this.addArticleForm.controls[controlName].hasError(errorName)
  }  

  public addArticle=async ()=>{
    var article: Article = new Article();

    for(let i = 0; i < this.selectedAtributes.length;i++){
      //this.selectedAtributes[i].Atribute = this.atributes[i];
      this.selectedAtributes[i].idAtribute = this.atributes[i].idAtribute;
      this.selectedAtributes[i].Parent = this.selectedAtributes[i-1];
      //this.selectedAtributes[i].Childrens.push(this.selectedAtributes[i+1])
      //this.selectedAtributes[i].Product = this.selectedProduct;
    }
    if(this.isNewProduct){     
      if(this.isNewProducer){
        this.selectedProducer.Country = this.selectedCountry;    
        //this.selectedProducer = (await this.dataService.createProducer(this.selectedProducer));
          
      }

      this.selectedProduct.Producer = this.selectedProducer;
      this.selectedProduct.AtributeValues = this.selectedAtributes;
      //this.selectedProduct.Articles =[];
    }

    //this.selectedProduct.Articles.push(article);

    article.Product = this.selectedProduct;
    article.rating = this.selectedRate;
    article.text = this.selectedText;
    article.time = new Date();
    article.User = JSON.parse(localStorage.getItem("user")) as User;
    const atricleDto: ArticleAddDto ={
      article: article
    };
    this.dataService.createArticle(atricleDto).subscribe(data => this.router.navigateByUrl("/"));
    //this.selectedProduct.Articles.push(article);
    //(await this.dataService.createProduct(this.selectedProduct));
  }

  //смена группы
  changeGroup(e) {
    this.selectedGroup = this.groupFormControl.value;
    this.dataService.getAtributesGroupsOf(this.selectedGroup.idGroupType).subscribe((data: Array<AtributesGroup>) => this.categories = data);
  }
  
  //смена категории
  async changeCategory(e) {
    this.selectedCategory = this.categoryFormControl.value;
    this.atributes = (await this.dataService.getAtributesOf(this.selectedCategory.idAtrbutesGroup) as Atribute[]);
    this.atrFormControl.length = 0;
    for(let i = 0; i < this.atributes.length; i++){
      this.atrFormControl.push(new FormControl('', [Validators.required,]));
    }    
  }

  //получить соответсвующий валидатор для autocerect атрибута
  getAtrControlAt(index:number){
    return this.atrFormControl[index];
  }

  //проверка валидности для одного autocerect атрибута
  isAtrControlAtHasError(index: number, err:string){
    return this.atrFormControl[index].hasError(err);
  }

  //проверка валидности для всех autocerect атрибутов
  isAtrControlvalid(){
    for(let i = 0; i<this.atrFormControl.length;i++){
      if(this.atrFormControl[i].value == undefined || this.atrFormControl[i].value == "")
        return false;
    }  
    return true;
  }

  //правильное отображение выбранного значения в autocorect
  public displayProperty(value) {
    switch(this.nowSelectName){
      case "Product":
        if(value.name)
          return value.name;
        else
          return value;
      case "Group":
      case "Producer":
      case "Country":
        if(value.name)
          return value.name;
        else
          return value;
      case "AtributeValue":
        return value.value;
      default:
        return value;
    }
  }

  //фильтр занчений autocorrect
  public _filter(value: string): any[]{
    try{
      switch(this.nowSelectName){
        case "Product":  
        case "Group":
        case "Producer":
        case "Country": 
          return this.options.filter(option => option.name.toLowerCase().indexOf(value) === 0);       
        case "AtributeValue":
          return this.options.filter(option => option.value.toLowerCase().indexOf(value) === 0);
        default:
          return this.options.filter(option => option.toLowerCase().indexOf(value) === 0);
      }
    }
    catch(e){
    }
  }

  //выбор, начало ввода в autocorrect
  selectionMade(data:any, name:string, i?:number) {
    this.options = data;
    this.nowSelectName = name;
    var matControl: FormControl;
    switch(name){
      case 'Product':
          matControl = this.producerFormControl;
        break;
      case 'Producer':
        matControl = this.producerFormControl;
        break;
      case 'Country':      
        matControl = this.countryFormControl;
        break;  
      case 'AtributeValue':
        matControl = this.atrFormControl[i];
        break;
      default:
        return;
    }
    this.filteredOptions = matControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))      
    );
  }

  //проверка соответсвия типа массив
  isArrayOf<T>(array:any[], cls: new (...args: any[]) => T) : array is T[] {
  for(let item of array) {    
      if(item != null) return  item instanceof cls;
  }
  return  false;
  }

  //проверка соответствия типа двух массивов
  isArrayOfArray(array1:any[], array2:any[]){
    for(let item1 of array1) {
      for(let item2 of array1){
        if(item1 != null && item2 != null) return  Object.getPrototypeOf(item1) == Object.getPrototypeOf(item2);
      }
    }
    return  false;
  }

  //изменение, но не выбор значения autocorrect
  changed(name, index?:number){
    switch(name){
      case 'Product':
          this.isNewProduct = true;
          this.selectedProduct = new Product({name:this.productFormControl.value});
        break;
      case 'Producer':
        this.isNewProducer = true;
        this.selectedProducer = new Producer({name:this.producerFormControl.value});
        break;
      case 'Country':      
        this.isNewCountry = true;
        this.selectedCountry = new Country({name:this.countryFormControl.value});
        break;  
      case 'AtributeValue':
        this.selectedAtributes[index] = new AtributeValue({Atribute: this.selectedCategory.atributes[index],value:this.atrFormControl[index].value});
        break;
      default:
        return;
    }
  }

  //выбор опции из autocorrect
  optionSelected(value, name, index?:number){
    switch(name){
      case 'Product':  
          this.isNewProduct = false;
          this.selectedProduct = value;
        break;
      case 'Producer':   
          this.isNewProducer = false;
          this.selectedProducer = value;
        break;
      case 'Country':  
          this.isNewCountry = false;
          this.selectedCountry = value;
        break;
      case 'AtributeValue':
        this.selectedAtributes[index] = value;
        break;
      default:
        return value;
    }
  }


  stars: number[] = [1, 2, 3, 4, 5];
//подсчёт рейтинга
countStar(star) {
  this.selectedRate = star;
}
//добавление очко рейтинга
addStar(star) {
   let ab = "";
   for (let i = 0; i < star; i++) {
     ab = "starId" + i;
     document.getElementById(ab).classList.add("selected");
   }
}
//минус очко рейтинга
removeStar(star) {
   let ab = "";
  for (let i = star-1; i >= this.selectedRate; i--) {
     ab = "starId" + i;
     document.getElementById(ab).classList.remove("selected");
   }
}
}
