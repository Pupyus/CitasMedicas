import { Component, OnInit } from '@angular/core';
import { DoctorsService } from 'src/app/services/doctors.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.scss']
})
export class ScheduleComponent implements OnInit {

  list: any;
  public doctorList: any;
  idDoctor!: number;
  constructor(private doctorService: DoctorsService) { }

  ngOnInit(): void {
    this.getDoctors();
  }

  selectedDate(e: any){
    const date = e.target.value;
    this.doctorService.getSchedule(date, this.idDoctor).subscribe(result => {
      debugger;
      if (result) {
        this.list = result;
      }
    });
  }

  getDoctors(){
    this.doctorService.getDoctors().subscribe(result => {
      if (result) {
        this.doctorList = result;
      }
    });
  }

  selectedDoctor(e: any){
    console.log(e.target.value)
  }

}