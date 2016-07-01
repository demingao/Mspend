export class Category {
    public Id: number;
    public Name: string;
}
export class MspendRecord {
    public Id: number;
    public Name: string;
    public Money: number;
    public Description: string;
    public RecordTime: Date;
    public CreateTime: Date;
    public CatId:number;
}
