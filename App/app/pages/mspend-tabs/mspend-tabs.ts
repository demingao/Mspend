import {NavController, Page} from 'ionic-angular';
import {RecentPage} from '../recent/recent';
import {StatisticsPage} from '../statistics/statistics';
import {MePage} from '../me/me';


@Page({
  templateUrl: 'build/pages/mspend-tabs/mspend-tabs.html'
})
export class MspendTabsPage {
  private recentRoot: any;
  private statisticsRoot: any;
  private meRoot: any;
  constructor(public nav: NavController) {
    // set the root pages for each tab
    this.recentRoot = RecentPage;
    this.statisticsRoot = StatisticsPage;
    this.meRoot = MePage;

  }
}
