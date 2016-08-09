import {Injectable} from '@angular/core';
import {Auth} from '../../providers/auth/auth';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';
import {MspendRecord, Search} from'../../model/model';
import {Storage, LocalStorage} from 'ionic-angular';
import {Http} from '@angular/http';

/*
  Generated class for the Record provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class Record {
  data: any = null;
  auth:Auth;
  constructor(public http:Http) {
    this.auth=new Auth(http);
  }

  load(tab: number = 1) {
    let action = '';
    switch (tab) {
      case 1:
        action = 'recent'
        break;
    }
    return this.auth.get(Config.UrlCtor('mr', action));
  }
  create(record: MspendRecord) {
    return this.auth.post(Config.UrlCtor('mr', 'create'), record);
  }
  search(model: Search) {
    return this.auth.post(Config.UrlCtor('mr', 'search'), model);
  }
}

