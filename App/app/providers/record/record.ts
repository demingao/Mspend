import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';
import {MspendRecord} from'../../model/model';

/*
  Generated class for the Record provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class Record {
  data: any = null;

  constructor(public http: Http) { }

  load(tab: number = 1) {
    let headers = new Headers({ 'Access-Control-Allow-Origin': '*', 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    let action = '';
    switch (tab) {
      case 1:
        action = 'recent'
        break;
    }
    return new Promise(resolve => {
      this.http.get(Config.UrlCtor('mr', action), options)
        .map(res => res.json())
        .subscribe(data => resolve(data));
    });
  }
  create(record: MspendRecord) {
    let headers = new Headers({ 'Access-Control-Allow-Origin': '*', 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return new Promise(resolve => {
      this.http.post(Config.UrlCtor('mr', 'create'), JSON.stringify(record), options)
        .map(res => res.json())
        .subscribe(data => resolve(data));
    });
  }
}

