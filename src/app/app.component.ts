import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {
  SocialAuthService,
  FacebookLoginProvider,
  SocialUser,
} from 'angularx-social-login';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Citas Médicas';

  loginForm!: FormGroup;
  socialUser!: SocialUser;
  isLoggedin?: boolean = undefined;
  aux?: string;
  users: any = undefined;

  constructor(
    private formBuilder: FormBuilder,
    private socialAuthService: SocialAuthService,
    private router: Router
  ) {
  }
  ngOnInit() {
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user;
      this.isLoggedin = user != null;
      localStorage.setItem('user', this.isLoggedin.toString());
      this.users = localStorage.getItem("user");
      if (this.isLoggedin) {
        this.router.navigate(['dashboard']);
      }
    });
  }
  loginWithFacebook(): void {
    this.socialAuthService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }
  signOut(): void {
    this.socialAuthService.signOut();
    this.router.navigate(['/dashboard']);
  }
}
