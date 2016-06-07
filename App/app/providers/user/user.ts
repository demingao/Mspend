import {Injectable} from '@angular/core';
import {Http,Headers,RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';

/*
  Generated class for the User provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class User {
  data: any = null;

  constructor(public http: Http) { }
  login(username: string, password: string) {  
    let headers = new Headers({'Access-Control-Allow-Origin':'*','Content-Type':'application/json' });
    let options = new RequestOptions({ headers: headers });
   return new Promise(resolve => {
      let data = { UserName: username, Password: password };
      this.http.post(Config.UrlCtor('account','login'), JSON.stringify(data),options)
        .map(res => res.json())
        .subscribe(data => resolve(data));
    });
  }
  load() {
    if (this.data) {
      // already loaded data
      return Promise.resolve(this.data);
    }

    // don't have the data yet
    return new Promise(resolve => {
      // We're using Angular Http provider to request the data,
      // then on the response it'll map the JSON data to a parsed JS object.
      // Next we process the data and resolve the promise with the new data.
      this.http.get('path/to/data.json')
        .map(res => res.json())
        .subscribe(data => {
          // we've got back the raw data, now generate the core schedule data
          // and save the data for later reference
          this.data = data;
          resolve(this.data);
        });
    });
  }
}

