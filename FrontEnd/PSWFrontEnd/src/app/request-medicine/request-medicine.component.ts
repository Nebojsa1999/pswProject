import { identifierName } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-request-medicine',
  templateUrl: './request-medicine.component.html',
  styleUrls: ['./request-medicine.component.scss']
})
export class RequestMedicineComponent implements OnInit {
user:any
medicines:any
form: FormGroup;
newAmount:any
errorMessage:any
public loginInvalid = false;
private formSubmitAttempt = false;
  constructor(
    private router:Router,
    private api:ApiService,
    private fb: FormBuilder,

  ) { 
    this.form = this.fb.group({
      medicine: ['', Validators.required],
      amount: ['',[Validators.min(1), Validators.max(50)]],

      
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
    this.api.getMedicinePharmacy().subscribe((response:any)=>
    {
      this.medicines=response
    })
  }

  async onSubmit(): Promise<void> {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const medicine = this.form.get('medicine')?.value;
        const amount = this.form.get('amount')?.value;

      
        this.api.getMedicineGRPC({
          id: medicine,
          amount:amount,
          
          
        }).subscribe((response : any) => {                    
          this.newAmount = response
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
