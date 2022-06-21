import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreatePrescriptionComponent } from './create-prescription/create-prescription.component';
import { DoctorPageComponent } from './doctor-page/doctor-page.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { FeedbacklistComponent } from './feedbacklist/feedbacklist.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { HistoryAppointmentComponent } from './history-appointment/history-appointment.component';
import { HospitalComponent } from './hospital/hospital.component';
import { LoginComponent } from './login/login.component';
import { MakeAppointmentComponent } from './make-appointment/make-appointment.component';
import { PatientpageComponent } from './patientpage/patientpage.component';
import { RegisterComponent } from './register/register.component';
import { UserListComponent } from './user-list/user-list.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path:'register',
    component: RegisterComponent
  },
  {
    path:'feedback',
    component: FeedbackComponent
  },
  {
    path:'appointment',
    component: MakeAppointmentComponent
  },
  {
    path:'history',
    component: HistoryAppointmentComponent
  },
  {
    path:'users',
    component: UserListComponent
  },
  {
    path:'patient',
    component: PatientpageComponent
  },
  {
    path:'hospital',
    component: HospitalComponent
  },
  {
    path:'doctorPage',
    component: DoctorPageComponent
  },
  {
    path:'prescription',
    component: CreatePrescriptionComponent
  },
  {
    path:'feedBackLists',
    component:FeedbacklistComponent
  },
  { path: 'home', component: FrontpageComponent },
  { path: '**', component: FrontpageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
