import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-doctor-page',
  templateUrl: './doctor-page.component.html',
  styleUrls: ['./doctor-page.component.scss']
})
export class DoctorPageComponent implements OnInit {
user:any
appointmentSpecialists:any
patients:any
form: FormGroup;
public loginInvalid = false;
private formSubmitAttempt = false;

  constructor(
    private router:Router,
    private apiService:ApiService,
    private fb: FormBuilder,

  ) { 
    this.form = this.fb.group({
      appointment: ['', Validators.required],
      patient: ['', Validators.required],
      reason: ['', Validators.required]

      
    });
  }

  ngOnInit(): void {
    const userString = localStorage.getItem('user');
    if(userString == null) {
      this.router.navigate(['/home'], {queryParams: { login: 'false' } });
      return;
    }
  
    this.user = JSON.parse((userString));
    if(this.user.userType != 3)
    {
      this.router.navigate(['/home'], {queryParams: { permission: 'false' } });
      return;
    }
    this.apiService.getSpecialists().subscribe((response:any)=>{
      this.appointmentSpecialists = response
    })
    this.apiService.getExaminationsFromDoctor({
      doctorId : this.user.id
    }).subscribe((response:any)=>{
      this.patients = response
    })
  }

  async onSubmit(): Promise<void> {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const appointment = this.form.get('appointment')?.value;
        const patient = this.form.get('patient')?.value;
        const reason = this.form.get('reason')?.value;

      
        this.apiService.scheduleExaminationSpecialist({
          userId: patient,
          appointmentId: appointment,
          reason:reason
          
          
        }).subscribe((response : any) => {          
         
          
          
        });
        

      }
      catch (err) {
        this.loginInvalid = true;
      }
      
    }

    else {
      this.formSubmitAttempt = true;
    }
  }

  GetMedicine(){
    this.apiService.getMedicineGRPC().subscribe((response:any)=>{
      this.ngOnInit()
    })
  }

}
