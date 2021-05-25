export class AtributeValue{
    public value: string;

    constructor(params: AtributeValue = {} as AtributeValue){
        let{
            value = undefined
        } = params;
        this.value = value;
    }
}