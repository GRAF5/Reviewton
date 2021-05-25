import { AtributeValue } from "./AtributeValue";
import { Producer } from "./Producer";
import { Article } from "./Article";
export class Product{    
    public idProduct?: number;
    public name?: string;
    public AtributeValues?: AtributeValue[];
    public Articles?: Article[];
    public Producer?: Producer

    constructor(params: Product = {} as Product){
        let{
            idProduct = undefined,
            name = undefined,
            AtributeValues = [],
            Articles = [],
            Producer = undefined
        } = params;
        this.name = name;
        this.AtributeValues = AtributeValues;
        this.Articles = Articles;
        this.Producer = Producer;
    }
}