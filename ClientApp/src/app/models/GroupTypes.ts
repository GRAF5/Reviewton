import { AtributesGroup } from './AtributesGroup';
//type GroupTypes = {
//  atributesGroups: Array<AtributesGroup>,
//  idGroupType?: number,
//  name?: string
//}
export class GroupType {
  constructor(
    public atributesGroups: Array<AtributesGroup>,
    public idGroupType?: number,
    public name?: string
  ) { }
}
