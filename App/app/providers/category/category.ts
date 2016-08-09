import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';
import {Auth} from '../../providers/auth/auth';

/*
  Generated class for the Category provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class Category {
  auth:Auth;
  constructor(public http: Http) {
    this.auth=new Auth(http);
   }

  load() {
    return this.auth.get(Config.UrlCtor('cat', 'get'));
  }
}

