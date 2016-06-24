export class Config {
  public static ServiceUrl:string="http://localhost:55001/api";
  public static UrlCtor(controller:string,action:string):string{
    return Config.ServiceUrl+"/"+controller+"/"+action;
  }
}

