import {Injectable} from '@angular/core';
import {Http,Headers,RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';

/*
  Generated class for the Category provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class Category {
  constructor(public http: Http) {}
  load() {
    let headers = new Headers({'Access-Control-Allow-Origin':'*','Content-Type':'application/json' });
    let options = new RequestOptions({ headers: headers });
   return new Promise(resolve => {     
      this.http.get(Config.UrlCtor('mr','recent'),options)
        .map(res => res.json())
        .subscribe(data => resolve(data));
    });
  }
}

