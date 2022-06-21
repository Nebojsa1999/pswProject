import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-create-prescription',
  templateUrl: './create-prescription.component.html',
  styleUrls: ['./create-prescription.component.scss']
})
export class CreatePrescriptionComponent implements OnInit {

  public loginInvalid = false;
  private formSubmitAttempt = false;
  form: FormGroup;
  patients:any
  medicines:any
  user:any
  errorMessage:any
    constructor(
      private router:Router,
      private apiService:ApiService,
      private fb: FormBuilder,
  
    ) { 
      this.form = this.fb.group({
        patient: ['', Validators.required],
        medicine: ['', Validators.required],
        amount: ['',[Validators.min(1), Validators.max(20)]],
  
        
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
    this.apiService.getPatients().subscribe((respone:any)=>{
      this.patients = respone
    })
    this.apiService.getMedicine().subscribe((respone:any)=>{
      this.medicines = respone
    })
  }
  async onSubmit(): Promise<void> {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const patient = this.form.get('patient')?.value;
        const medicine = this.form.get('medicine')?.value;
        const amount = this.form.get('amount')?.value;

      
        this.apiService.createPrescription({
          patientUser: patient,
          doctor: this.user.name,
          amount:amount,
          medicineId:medicine
          
          
        }).subscribe((response : any) => {          
         this.router.navigate(['/doctorPage'])
          
          
        },(error:any) => {
          console.log(error)
          this.errorMessage = error.error;
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

}
