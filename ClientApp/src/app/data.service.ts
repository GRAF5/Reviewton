import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupType } from './models/GroupTypes';
import { Article } from './models/Article';
import { Product } from './models/Product';
import { Producer } from './models/Producer';
import { Country } from './models/Country';
import { ArticleAddDto } from './interfaces/articleAddDto';

@Injectable()
export class DataService {

  private url = "/api/Data";

  constructor(private http: HttpClient) {
  }

  //Получить все группы
  getGroupTypes() {
    return this.http.get(this.url+'/GroupType');
  }

  //получить группу по id
  getGroupType(id: number) {
    return this.http.get(this.url + '/GroupType/' + id);
  }

  //создать группу
  createGroupTypes(product: GroupType) {
    return this.http.post(this.url + '/GroupType/', product);
  }

  //обновить группу
  updateGroupTypes(product: GroupType) {

    return this.http.put(this.url + '/GroupType/', product);
  }

  //удалить группу
  deleteGroupTypes(id: number) {
    return this.http.delete(this.url + '/GroupType/' + id);
  }

  //Получить все категории
  getAtributesGroupsOf(id:number) {
    return this.http.get(this.url+'/AtributesGroup/'+id);
  }

  //Получить все атрибуты
  async getAtributesOf(id:number) {
    return await this.http.get(this.url+'/Atributes/'+id).toPromise();
  }

  //получить все продукты
  getProducts(){
    return this.http.get(this.url+'/Product');
  }

  //создать продукт
  async createProduct(product: Product) {
    return await this.http.post(this.url + '/Product/', product).toPromise();
  }

  //получить всех производителей
  getProducers(){
    return this.http.get(this.url+'/Producer');
  }

  //создать производителя
  async createProducer(product: Producer) {
    return await this.http.post(this.url + '/Producer/', product).toPromise();
  }

  //получить все страны
  getCountries(){
    return this.http.get(this.url+'/Country');
  }
  
  //создать производителя
  async createCountry(product: Country) {
    return await this.http.post(this.url + '/Country/', product).toPromise;
  }

  //создать статью
  createArticle(product: ArticleAddDto) {
    return this.http.post(this.url + '/Article/', product);
  }

  //обновить статью
  updateArticle(product: Article) {
    return this.http.put(this.url + '/Article/', product);
  }

  
}
