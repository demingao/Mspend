import {Page, NavController} from 'ionic-angular';
import{MspendTabsPage} from '../../pages/mspend-tabs/mspend-tabs'

/*
  Generated class for the LoginPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/login/login.html',
})
export class LoginPage {
  constructor(public nav: NavController) {}
  login()
  {
    this.nav.setRoot(MspendTabsPage);
  }
}
