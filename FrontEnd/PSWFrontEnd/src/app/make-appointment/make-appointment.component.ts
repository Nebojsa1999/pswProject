import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import {ApiService} from "../api.service";
@Component({
  selector: 'app-make-appointment',
  templateUrl: './make-appointment.component.html',
  styleUrls: ['./make-appointment.component.scss']
})
export class MakeAppointmentComponent implements OnInit {
  doctors: any;
  form: FormGroup;
  minDate = new Date();
  user: any;
  data: any;
  public loginInvalid = false;
  private formSubmitAttempt = false;
  appointments:any
  displayedColumns: string[] = ['AppointmentDate', 'AppointmentTime', 'Hospital','Doctor','Schedule'];
  DropdownVar = 0;

  onSelect(x: number){
   this.DropdownVar = x;
  }
  constructor(
    
    private fb: FormBuilder,
    private apiService: ApiService,
    private router: Router
    
    
    ){
    this.form = this.fb.group({
    doctor: ['', Validators.required],
    dateBegin: ['', Validators.required],
    dateEnd: ['', Validators.required],
    priority: ['',Validators.required]
    
  });
  
}

async ngOnInit(): Promise<void> {

 
    const userString = localStorage.getItem('user');
    if(userString == null) {
      this.router.navigate(['/home'], {queryParams: { login: 'false' } });
      return;
    }
  
    this.user = JSON.parse((userString));
    if(this.user.userType != 1)
    {
      this.router.navigate(['/home'], {queryParams: { permission: 'false' } });
      return;
    }
    
      this.doctors = []    
      this.apiService.getDoctors().subscribe((response : any) => {
        this.doctors = response;
     
  })

  
}
  
  async onSubmit(): Promise<void> {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const doctor = this.form.get('doctor')?.value;
        const dateBegin = this.form.get('dateBegin')?.value;
        const dateEnd = this.form.get('dateEnd')?.value;
        const priority = this.form.get('priority')?.value;
        this.apiService.scheduleAppointment({
          doctor: doctor,
          dateBegin: dateBegin,
          dateEnd: dateEnd,
          priority: priority
          
        }).subscribe((response : any) => {
          this.appointments = response
          
         
          
          
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

  Schedule(id:any){
    console.log('dasdas')
    this.apiService.scheduleExamination({
      userId : this.user.id,
      appointmentId : id
    }).subscribe((response:any)=>{
      this.router.navigate(['/patient'])
    })
  }

 
}
