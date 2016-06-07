export class Login{
  /**
   *
   */
  constructor(loginName:string,password:string) {
    this.LoginName=loginName;
    this.Password=password;
  }
  public LoginName:string;
  public Password:string;
}