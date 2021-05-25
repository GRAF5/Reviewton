import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GroupType } from './models/GroupTypes';
import { Article } from './models/Article';

@Injectable()
export class DataService {

  private url = "/api/Data";

  constructor(private http: HttpClient) {
  }

  //Получить все категории
  getGroupTypes() {
    return this.http.get(this.url+'/GroupType');
  }

  //получить категорию по id
  getGroupType(id: number) {
    return this.http.get(this.url + '/GroupType/' + id);
  }

  //создать категорию
  createGroupTypes(product: GroupType) {
    return this.http.post(this.url + '/GroupType/', product);
  }

  //обновить категорию
  updateGroupTypes(product: GroupType) {

    return this.http.put(this.url + '/GroupType/', product);
  }

  //удалить категорию
  deleteGroupTypes(id: number) {
    return this.http.delete(this.url + '/GroupType/' + id);
  }

  //получить все продукты
  getProducts(){
    return this.http.get(this.url+'/Product');
  }

  //получить всех производителей
  getProducers(){
    return this.http.get(this.url+'/Producer');
  }

  //получить все страны
  getCountries(){
    return this.http.get(this.url+'/Country');
  }
  
  //создать статью
  createArticle(product: Article) {
    return this.http.post(this.url + '/Article/', product);
  }

  //обновить статью
  updateArticle(product: Article) {
    return this.http.put(this.url + '/Article/', product);
  }

  
}
