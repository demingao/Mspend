import {Page, NavController, Loading} from 'ionic-angular';
import {Static as StaticService} from '../../providers/static/static';
import {Record as RecordService} from '../../providers/record/record';
import {Search, SearchModel} from '../../model/model';
import {RecordCreatePage} from '../../pages/record-create/record-create';
import 'rxjs/add/operator/map';
/*
  Generated class for the StatisticsPage page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Page({
  templateUrl: 'build/pages/statistics/statistics.html',
  providers: [StaticService, RecordService]
})
export class StatisticsPage {
  private searchModel: SearchModel;
  private model: Search;
  private records: any;
  private record: any;
  constructor(public nav: NavController, public ser: StaticService, public rser: RecordService) {
    this.record = RecordCreatePage;
    this.model = new Search();
    this.searchModel = new SearchModel();
    ser.load().then(res => {
      this.searchModel = res.json() as SearchModel;
      this.search();
    }).catch(e => {
      console.log(e);
    });
  }

  search() {
    let loading = Loading.create({
      content: "数据加载中..."
    });
    this.nav.present(loading);
    this.rser.search(this.model).then(res => {
      this.records = res.json();
      console.log(res);
      loading.dismiss();
    });
  }
}
