import {App, Platform} from 'ionic-angular';
import {StatusBar} from 'ionic-native';
import {LoginPage} from './pages/login/login';
import {MspendTabsPage} from './pages/mspend-tabs/mspend-tabs';

@App({
  templateUrl: 'build/app.html',
  config: {mode:"md"} // http://ionicframework.com/docs/v2/api/config/Config/
})
export class MspendApp {
  rootPage: any = MspendTabsPage;

  constructor(platform: Platform) {
    platform.ready().then(() => {
      // Okay, so the platform is ready and our plugins are available.
      // Here you can do any higher level native things you might need.
      //StatusBar.styleDefault();
    });
  }
}
