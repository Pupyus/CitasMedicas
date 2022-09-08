import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  socialUser!: SocialUser;
  isLoggedin?: boolean = undefined;
  constructor(
    private socialAuthService: SocialAuthService,
    private router: Router
  ) { }

  public auth(): void{
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user;
      this.isLoggedin = user != null;
      var URLactual = window.location.href;
      if (this.isLoggedin && URLactual.includes('dashboard')) {
        this.router.navigate(['appointments']);
      }
      else {
        this.router.navigate(['dashboard']);
      }
    });
  }

  public isLogin(){
    return this.isLoggedin;
  }
}
