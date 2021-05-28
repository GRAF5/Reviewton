import { AtributeValue } from "./AtributeValue";
import { Producer } from "./Producer";
import { Article } from "./Article";
export class Product{    
    public idProduct?: number;
    public name?: string;
    public rating?: number;
    public AtributeValues?: AtributeValue[];
    public Articles?: Article[];
    public Producer?: Producer

    constructor(params: Product = {} as Product){
        let{
            idProduct = 0,
            name = "",
            rating = 0,
            AtributeValues = [],
            Articles = [],
            Producer = undefined
        } = params;
        this.idProduct = idProduct;
        this.name = name;
        this.rating = rating;
        this.AtributeValues = AtributeValues;
        this.Articles = Articles;
        this.Producer = Producer;
    }
}