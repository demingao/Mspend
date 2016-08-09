import {Page, NavController} from 'ionic-angular';
import {Record as RecordService} from '../../providers/record/record';
import {RecordCreatePage} from '../../pages/record-create/record-create';
import 'rxjs/add/operator/map';
/*
  Generated class for the RecentPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/recent/recent.html',
  providers: [RecordService]
})
export class RecentPage {
  private recents:any;
  private record:any;
  constructor(public nav: NavController, public ser: RecordService) {
    this.record=RecordCreatePage;
    ser.load().then(res => {     
      this.recents=res.json();
    }).catch(e=>{
      console.log(e);
    });
  }
}
