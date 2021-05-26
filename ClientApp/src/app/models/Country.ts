import {Producer} from "./Producer";
export class Country{    
    public idCountry?: number;
    public name?: string;
    public Producers?: Producer[];

    constructor(params: Country = {} as Country){
        let{
            idCountry = undefined,
            name = undefined,
            Producers = []
        } = params;
        this.idCountry = idCountry;
        this.name = name;
        this.Producers = Producers;
    }
}