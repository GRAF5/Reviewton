import { Product } from "./Product";
import { User } from "./User";

export class Article{    
    public idArticle?: number;
    public rating: number;
    public text: string;
    public time: Date;
    public product?: Product;
    public user?: User;
    public comments?: Comment[];

    constructor(params: Article = {} as Article){
        let{
            idArticle = undefined,
            rating = undefined,
            text = undefined,
            time = undefined,
            comments = [],
            product = undefined,
            user = undefined
        } = params;
        this.idArticle = idArticle;
        this.rating = rating;
        this.text = text;
        this.time = time;
        this.comments = comments;
        this.product = product;
        this.user = user;
    }
}