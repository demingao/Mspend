import {Http, Headers, RequestOptions} from '@angular/http';
import {Storage, LocalStorage} from 'ionic-angular';
import {Config} from '../../providers/config/config';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

export class Auth {
    private local: Storage = new Storage(LocalStorage);
    constructor(public http: Http) {

    }
    get(url: string) {
        return this.local.get('token').then(t => {
            let token = 'bearer ' + t;
            return this.http.get(url, this.InitRequestOptions(token)).toPromise();

        });
    }
    post(url: string, body: any) {
        return this.local.get('token').then(t => {
            let token = 'bearer ' + t;
            return this.http.post(url, JSON.stringify(body), this.InitRequestOptions(token)).toPromise();

        });
    }
    refreshToken() {
        let headers = new Headers({ 'Access-Control-Allow-Origin': '*', 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });
        return this.local.get('refresh_token').then(t => {
            let data = 'grant_type=refresh_token&refresh_token=' + t;
            return this.http.post(Config.UrlCtor('auth0', 'token'), data, options).toPromise();
        });
    }
    private InitRequestOptions(token: string) {
        let headers = new Headers({ 'Access-Control-Allow-Origin': '*', 'Content-Type': 'application/json', 'Authorization': token });
        let options = new RequestOptions({ headers: headers });
        return options;
    }
}