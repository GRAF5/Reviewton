export class User{
    public ID: string;
    public Nickname: string;
    public Email: string;

    constructor(params: User = {} as User){
        let{
            ID = undefined,
            Nickname = undefined,
            Email = undefined
        } = params;
        this.ID = ID;
        this.Nickname = Nickname;
        this.Email = Email;
    }
}