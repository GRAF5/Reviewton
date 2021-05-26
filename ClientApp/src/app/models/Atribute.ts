import {AtributeValue} from "./AtributeValue";
export class Atribute{    
    public idAtribute?: number;
    public name?: string;
    public AtributeValues?: AtributeValue[];
    public isCanBeMany?: boolean;

    constructor(params: Atribute = {} as Atribute){
        let{
            idAtribute = undefined,
            name = undefined,
            AtributeValues = [],
            isCanBeMany = false
        } = params;
        this.idAtribute = idAtribute;
        this.name = name;
        this.AtributeValues = AtributeValues;
        this.isCanBeMany = isCanBeMany;
    }
}