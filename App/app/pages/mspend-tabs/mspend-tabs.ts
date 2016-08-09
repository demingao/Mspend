import {NavController, Page, Loading, Storage, LocalStorage} from 'ionic-angular';
import {RecentPage} from '../recent/recent';
import {StatisticsPage} from '../statistics/statistics';
import {MePage} from '../me/me';
import {Auth} from '../../providers/auth/auth';
import {Http} from '@angular/http';
import {LoginPage} from '../../pages/login/login'

@Page({
  templateUrl: 'build/pages/mspend-tabs/mspend-tabs.html'
})
export class MspendTabsPage {
  private recentRoot: any;
  private statisticsRoot: any;
  private meRoot: any;
  auth: Auth;
  local: Storage = new Storage(LocalStorage);
  constructor(public nav: NavController, public http: Http) {
    let loading = Loading.create({
      content: "数据加载中，请稍后..."
    });
    // set the root pages for each tab
    this.recentRoot = RecentPage;
    this.statisticsRoot = StatisticsPage;
    this.meRoot = MePage;
    this.auth = new Auth(http);
    this.nav.present(loading);
    this.auth.refreshToken().then(data => {
      let res = data.json();
      this.local.set('token', res.access_token)
      this.local.set('refresh_token', res.refresh_token)
      loading.dismiss();
    }, error => {
      let status = (error as any).status;
      if (status !== 200) {
        this.nav.setRoot(LoginPage);
      }
      loading.dismiss();
    }).catch(e => {
      loading.dismiss();
    });
  }
}
