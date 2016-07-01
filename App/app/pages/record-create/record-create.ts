import {Page, NavController, Loading} from 'ionic-angular';
import {MspendRecord} from'../../model/model';
import {Category as CategoryService} from '../../providers/category/category';
import {Record as RecordService} from '../../providers/record/record';

/*
  Generated class for the RecordCreatePage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/record-create/record-create.html',
  providers: [CategoryService, RecordService]
})
export class RecordCreatePage {
  private model: MspendRecord;
  private cats: any;
  constructor(public nav: NavController, public ser: CategoryService, public rser: RecordService) {
    this.model = new MspendRecord();
    ser.load().then(res => {
      this.cats = res;
    }).catch(ex => {

    });
  }
  create() {
    let loading = Loading.create({
      content: "正在登录，请稍后..."
    });
    this.nav.present(loading);
    this.rser.create(this.model).then(res => {
      console.log(res);
      loading.dismiss();
    });
  }
}
