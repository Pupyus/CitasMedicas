import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { GuardGuard } from './guards/guard.guard';
import { AppointmentsComponent } from './pages/appointments/appointments.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ScheduleComponent } from './pages/schedule/schedule.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'appointments',
    canActivate: [GuardGuard],
    component: AppointmentsComponent
  },
  {
    path: 'schedule',
    canActivate: [GuardGuard],
    component: ScheduleComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
