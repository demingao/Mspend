import {Page, NavController, Loading} from 'ionic-angular';
import {MspendRecord} from'../../model/model';
import {Category as CategoryService} from '../../providers/category/category';
import {Record as RecordService} from '../../providers/record/record';
import 'rxjs/add/operator/map';
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
  private year: number;
  private min: number;
  private max: number;
  constructor(public nav: NavController, public ser: CategoryService, public rser: RecordService) {
    let now = new Date();
    this.year = now.getFullYear();
    this.min = this.year - 1;
    this.max = this.year + 1;
    this.model = new MspendRecord();
    this.model.RecordTime = now.toISOString();
    ser.load().then(res => {
      this.cats = res;
    }).catch(ex => {

    });
  }
  doCreate() {
    let loading = Loading.create({
      content: "正在创建记录，请稍后..."
    });
    this.nav.present(loading);
    this.rser.create(this.model).then(res => {
      console.log(res.json());
      loading.dismiss();
    });
  }
}
