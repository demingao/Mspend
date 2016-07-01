import {Page, NavController} from 'ionic-angular';
import {Record as RecordService} from '../../providers/record/record';
import {RecordCreatePage} from '../../pages/record-create/record-create';
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
    ser.load().then(data => {     
      this.recents=data;
    }).catch(e=>{
      console.log(e);
    });
    console.log(this.recents);
  }
}
