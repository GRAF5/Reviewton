import {GroupType} from './GroupTypes';
import {Atribute} from './Atribute';
//type AtributesGroup={
//  idAtrbutesGroup: number
//}
export class AtributesGroup {  
  public atributes: Array<Atribute>;
  public idAtrbutesGroup?: number;
  public name?: string;
  //constructor(atributes: Array<Atribute>,  idAtrbutesGroup?: number, name?: string)
  //constructor(atributesGroup: AtributesGroup)
  constructor(params:AtributesGroup = {}as AtributesGroup){
    let{
      atributes = [],
      idAtrbutesGroup = undefined,
      name = undefined
    } = params;
    this.atributes = atributes;
    this.idAtrbutesGroup = idAtrbutesGroup;
    this.name = name;
  }
}
