import { Atribute } from "./Atribute";
import { Product } from "./Product";

export class AtributeValue{
    public idAtributeValue?: number;
    public idAtribute?: number;
    public Parent?: AtributeValue;
    public Childrens?: AtributeValue[];
    public Atribute?: Atribute;
    public idProduct?: number;
    public Product?: Product;
    public value?: string;

    constructor(params: AtributeValue = {} as AtributeValue){
        let{
            idAtributeValue = undefined,
            idAtribute = undefined,
            Parent = undefined,
            Childrens = [],
            Atribute = undefined,
            idProduct = undefined,
            Product = undefined,
            value = undefined
        } = params;
        
        this.idAtributeValue = idAtributeValue;
        this.idAtribute = idAtribute;
        this.Parent = Parent;
        this.Childrens = Childrens;
        this.Atribute = Atribute;
        this.idProduct = idProduct;
        this.Product = Product;
        this.value = value;
    }
}