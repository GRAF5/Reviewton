import { Product } from "./Product";
import { User } from "./User";

export class Article{    
    public idArticle?: number;
    public rating: number;
    public text: string;
    public time: Date;
    public Product?: Product;
    public User?: User;
    public Comments?: Comment[];

    constructor(params: Article = {} as Article){
        let{
            idArticle = undefined,
            rating = undefined,
            text = undefined,
            time = undefined,
            Comments = [],
            Product = undefined,
            User = undefined
        } = params;
        this.rating = rating;
        this.text = text;
        this.time = time;
        this.Comments = Comments;
        this.Product = Product;
        this.User = User;
    }
}