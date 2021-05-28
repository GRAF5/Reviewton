import { Atribute } from "./Atribute";
import { Product } from "./Product";

export class AtributeValue{
    public idAtributeValue?: number;
    public idAtribute?: number;
    public parent?: AtributeValue;
    public childrens?: AtributeValue[];
    public atribute?: Atribute;
    public idProduct?: number;
    public product?: Product;
    public value?: string;

    constructor(params: AtributeValue = {} as AtributeValue){
        let{
            idAtributeValue = undefined,
            idAtribute = undefined,
            parent = undefined,
            childrens = [],
            atribute = undefined,
            idProduct = undefined,
            product = undefined,
            value = undefined
        } = params;
        
        this.idAtributeValue = idAtributeValue;
        this.idAtribute = idAtribute;
        this.parent = parent;
        this.childrens = childrens;
        this.atribute = atribute;
        this.idProduct = idProduct;
        this.product = product;
        this.value = value;
    }
}