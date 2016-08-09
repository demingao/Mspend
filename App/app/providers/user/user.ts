import {Injectable} from '@angular/core';
import {Http, Headers, RequestOptions} from '@angular/http';
import 'rxjs/add/operator/map';
import {Config} from '../../providers/config/config';
import {Auth} from '../../providers/auth/auth';
/*
  Generated class for the User provider.

  See https://angular.io/docs/ts/latest/guide/dependency-injection.html
  for more info on providers and Angular 2 DI.
*/
@Injectable()
export class User {
  data: any = null;
  auth: Auth;
  constructor(public http: Http) {
    this.auth = new Auth(http);
  }
  login(username: string, password: string) {
    let headers = new Headers({ 'Access-Control-Allow-Origin': '*', 'Content-Type': 'application/x-www-form-urlencoded' });
    let options = new RequestOptions({ headers: headers });
    return new Promise(resolve => {
      let data = 'grant_type=password&UserName=' + username + '&Password=' + password;
      this.http.post(Config.UrlCtor('auth0', 'token'), data, options)
        .map(res => res.json())
        .subscribe(data => resolve(data));
    });
  }
 
  uinfo() {
    return this.auth.get(Config.UrlCtor('account', 'uinfo'));
  }
}

