import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { Doctors } from '../../models/doctors';
import { DoctorsService } from '../../services/doctors.service';


@Component({
  selector: 'app-appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.scss']
})
export class AppointmentsComponent implements OnInit {

  public doctorsList: any;
  socialUser!: SocialUser;
  isLoggedin?: boolean = undefined;
  ifCalendar: boolean = false;
  doctor: string = "";
  date: Date = new Date;
  hours: any;
  selected: any;
  alerts: string = "";
  modals: string = "none";
  showFillData: boolean = false;
  name!: string;
  email!: string;
  time!: string;
  id!: number;
  idDoctor!: number;
  showButton!: boolean;

  constructor(private doctorService: DoctorsService,
    private socialAuthService: SocialAuthService,
    private router: Router) {
    
   }

  ngOnInit(): void {
    this.socialAuthService.authState.subscribe((user) => {
      this.socialUser = user;
      this.isLoggedin = user != null;
    });
    this.getDoctors();
  }

  getDoctors(){
    localStorage.getItem("user");
    this.doctorService.getDoctors().subscribe(result => {
      if (result) {
        this.doctorsList = result;
      }
    });
  }

  selectedDoctor(id: number, name: string, lastname: string){
    if (id) {
      this.idDoctor = id;
      this.doctor = name + " " + lastname;
      this.ifCalendar = true;
    }
  }

  selectedDate(e: any){
    this.date = e.target.value;
    this.doctorService.getFreeHours().subscribe(result => {
      if (result) {
        this.hours = result;
      }
    });
  }

  selectedTime(e: any){
    if (e.target.value) {
      this.doctorService.getAvalability(this.idDoctor, e.target.value, this.date).subscribe(result => {
        debugger;
        if (result.disponible) {
          this.hours.forEach((element: { id: any; nombre: string; }) => {
            if (element.id == e.target.value) {
              this.id = element.id;
              this.time = element.nombre;
              this.showButton = true;
              this.alerts = "¿Este el horario que elegiste? " + element.nombre;
              this.modals = "block";
            }
          });
        }else{
          this.showButton = false;
          this.alerts = "El horario que elegiste ya no esta disponible!";
          this.modals = "block";
        }
      });
      
    }
  }

  close(){
    this.modals = "none";
    this.showButton = false;
  }

  showFields(){
    this.modals = "none";
    this.showFillData = true;
  }

  newAppointment(){
    let data = {
      IdDoctor: this.idDoctor,
      Name: this.name,
      Email: this.email,
      Date: this.date,
      IdTime: this.id
    }
    this.doctorService.postData(data).subscribe(result => {
      if (result == null) {
        this.router.navigate(['schedule']);
      }
    });
  }

}
