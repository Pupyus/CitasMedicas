import { Injectable } from '@angular/core';
import { Observable, of, tap } from 'rxjs';
import { DOCTORS } from '../enums/doctors-mock';
import { Doctors } from '../models/doctors';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {

  constructor(private readonly http: HttpClient) { }

  getDoctors(): Observable<any> {
    return this.http.get<any>(`https://localhost:44375/api/Personas/Doctores`).pipe(
      tap(values => {
        values;
      })
    );
  }

  getFreeHours(): Observable<any> {
    return this.http.get<any>(`https://localhost:44375/api/Common/Horarios`).pipe(
      tap(values => {
        values;
      })
    );
  }

  getAvalability(idDoc: number, idTime: number, date: Date): Observable<any> {
    return this.http.get<any>(`https://localhost:44375/api/Citas/Disponibilidad?idDoctor=${idDoc}&idHorario=${idTime}&fecha=${date}`).pipe(
      tap(values => {
        values;
      })
    );
  }

  postData(data: any): Observable<any> {
    return this.http.post<any>(`https://localhost:44375/api/Citas`, data).pipe(
      tap(values => {
        values;
      })
    );
  }

  getSchedule(date: Date, id: number): Observable<any> {
    return this.http.get<any>(`https://localhost:44375/api/Citas/Agenda?idDoctor=${id}&fecha=${date}`).pipe(
      tap(values => {
        values;
      })
    );
  }

}