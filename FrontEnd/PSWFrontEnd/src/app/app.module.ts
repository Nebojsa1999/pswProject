import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule} from '@angular/material/radio';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatTableModule } from '@angular/material/table';
import { MatDividerModule } from '@angular/material/divider';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatSliderModule} from '@angular/material/slider';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FeedbackComponent } from './feedback/feedback.component';
import { MakeAppointmentComponent } from './make-appointment/make-appointment.component';
import { HistoryAppointmentComponent } from './history-appointment/history-appointment.component';
import { UserListComponent } from './user-list/user-list.component';
import { FrontpageComponent } from './frontpage/frontpage.component';
import { HospitalComponent } from './hospital/hospital.component';
import { PatientpageComponent } from './patientpage/patientpage.component';
import { DoctorPageComponent } from './doctor-page/doctor-page.component';
import { CreatePrescriptionComponent } from './create-prescription/create-prescription.component';
import { FeedbacklistComponent } from './feedbacklist/feedbacklist.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    FeedbackComponent,
    MakeAppointmentComponent,
    HistoryAppointmentComponent,
    UserListComponent,
    FrontpageComponent,
    HospitalComponent,
    PatientpageComponent,
    DoctorPageComponent,
    CreatePrescriptionComponent,
    FeedbacklistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatToolbarModule,
    MatCheckboxModule,
    MatInputModule,
    MatCardModule,
    MatNativeDateModule,
    MatMenuModule,
    MatSliderModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatDividerModule,
    MatSlideToggleModule,
    MatRadioModule,
    MatDatepickerModule,
    MatSelectModule,
    MatOptionModule,
    MatProgressSpinnerModule,  
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
