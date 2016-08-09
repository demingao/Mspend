export class Category {
    public Id: number;
    public Name: string;
}
export class MspendRecord {
    public Id: number;
    public Name: string;
    public Money: number;
    public Description: string;
    public RecordTime: any;
    public CreateTime: any;
    public CatId:number;
}
export class Search{
    public DateType:number;
    public CategoryTypes:number[];
}
export class SearchModel{
    public Cats:any;
    public DateTypes:any;
}

export class Account{
    public User:any;
    public LastMonthMoney:any;
    public TotalMoney:any;
}