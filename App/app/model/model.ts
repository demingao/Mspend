export class Category {
    public Id: number;
    public Name: string;
    public Description: string;
    public TotalPrice: number;
    public CreateTime: Date;
    public Records:MspendRecord[];
}
export class MspendRecord {
    public Id: number;
    public Name: string;
    public Money: number;
    public Description: string;
    public RecordTime: Date;
    public CreateTime: Date;
}
