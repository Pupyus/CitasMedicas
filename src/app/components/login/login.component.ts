import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { FacebookLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  socialUser!: SocialUser;
  isLoggedin?: boolean = undefined;
  constructor(private socialAuthService: SocialAuthService,
    private router: Router,
    private authService: AuthService) { }

  ngOnInit() {
    this.authService.auth();
    // this.auth();
  }

  loginWithFacebook(): void {
    this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }

  auth(){
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

}
