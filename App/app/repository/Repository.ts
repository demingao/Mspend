import {IRepository} from '../repository/IRepository';
export class Repository implements IRepository {
    Add<T>(entity: T) { }
    Delete<T>(entity: T) { }
    Update<T>(entity: T) { }
    Search() { }
}