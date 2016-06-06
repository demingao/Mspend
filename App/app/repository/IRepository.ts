 export interface IRepository{
    Add<T>(entity:T);
    Delete<T>(entity:T);
    Update<T>(entity:T);
    Search();
}