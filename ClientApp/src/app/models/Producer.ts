import { Country } from "./Country";
import {Product} from "./Product";
export class Producer{    
    public idProducer?: number;
    public name?: string;
    public Products?: Product[];
    public Country: Country

    constructor(params: Producer = {} as Producer){
        let{
            idProducer = undefined,
            name = undefined,
            Products = [],
            Country = undefined
        } = params;
        this.name = name;
        this.Products = Products;
        this.Country = Country;
    }
}