import {Page, NavController} from 'ionic-angular';
import {Category as CategoryService} from '../../providers/category/category';
import {Recent} from '../../model/recent';
import {Category} from '../../model/model';

/*
  Generated class for the RecentPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/recent/recent.html',
  providers: [CategoryService]
})
export class RecentPage {
  private recents:any;
  constructor(public nav: NavController, public ser: CategoryService) {
    ser.load().then(data => {
      this.recents=data;
    });
    console.log(this.recents);
  }
}
