import {Page, NavController, Loading, Storage, LocalStorage} from 'ionic-angular';
import {MspendTabsPage} from '../../pages/mspend-tabs/mspend-tabs'
import {Login} from '../../model/login';
import {User as UserService} from '../../providers/user/user';

/*
  Generated class for the LoginPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/login/login.html',
  providers: [UserService]
})
export class LoginPage {
  private model: Login;
  local: Storage = new Storage(LocalStorage);
  constructor(public nav: NavController, public ser: UserService) {
    this.model = new Login("gdm", "123456");
  }
  doLogin() {
    let loading = Loading.create({
      content: "正在登录，请稍后..."
    });
    this.nav.present(loading);
    this.ser.login(this.model.LoginName, this.model.Password).then(data => {
      this.local.set('token', (data as any).access_token)
      this.local.set('refresh_token', (data as any).refresh_token)
      loading.dismiss();
      this.nav.setRoot(MspendTabsPage);
    }).catch(e => {
      loading.dismiss();
      console.log(e);
    });
  } 
}


