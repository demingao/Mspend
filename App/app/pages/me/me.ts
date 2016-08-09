import {Page, NavController} from 'ionic-angular';
import {User as UserService} from '../../providers/user/user';
import {Account} from '../../model/model';
import 'rxjs/add/operator/map';
/*
  Generated class for the MePage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/me/me.html',
  providers: [UserService]
})
export class MePage {
  private uinfo: Account;
  constructor(public nav: NavController, public ser: UserService) {
    this.uinfo = new Account();
    this.ser.uinfo().then(res => {
      this.uinfo = res.json() as Account;
      if (this.uinfo.User.ProfilePicture == '')
        this.uinfo.User.ProfilePicture = '../img/logo.jpg';
    }).catch(ex => {
      console.log(ex);
    });
  }
}
