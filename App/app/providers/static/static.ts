import {Injectable} from '@angular/core';
import {Http} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';
import {Storage, LocalStorage} from 'ionic-angular';
import {Auth} from '../../providers/auth/auth';

/*
  Generated class for the Static provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class Static {
  local: Storage = new Storage(LocalStorage);
  auth:Auth;
  constructor(public http: Http) {
    this.auth=new Auth(http);
   }

  load() {
    return this.auth.get(Config.UrlCtor('static', 'searchmodel'));
  }
}

