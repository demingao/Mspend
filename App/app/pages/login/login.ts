import {Page, NavController, Loading} from 'ionic-angular';
import {MspendTabsPage} from '../../pages/mspend-tabs/mspend-tabs'
import {Login} from '../../model/login';
import {User} from '../../providers/user/user';

/*
  Generated class for the LoginPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/login/login.html',
  providers: [User]
})
export class LoginPage {
  private model: Login;
  constructor(public nav: NavController, public ser: User) {
    this.model = new Login("gdm", "123456");
  }
  login() {
    let loading = Loading.create({
      content: "正在登录，请稍后..."
    });
    this.nav.present(loading);
    this.ser.login(this.model.LoginName, this.model.Password).then(data => {
      console.log(data);
      loading.dismiss();
      this.nav.setRoot(MspendTabsPage);
    });
  }
}


