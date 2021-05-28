import { Article } from '../models/Article';

export interface ArticleAddDto{
    article: Article; 
    isNewProduct: boolean;
}