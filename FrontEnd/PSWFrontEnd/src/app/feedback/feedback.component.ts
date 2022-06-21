import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import {ApiService} from "../api.service";

@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit {
  form: FormGroup;
  user:any
  annonymus = false
  private formSubmitAttempt = false;
  public loginInvalid = false;
  examinationId:any;
  examinationIdString:any
    displayedColumns: string[] = ['AppointmentTimeStart', 'AppointmentTimeEnd', 'Hospital','UserDoctor','Cancel'];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private apiService: ApiService
  ) {

    this.form = this.fb.group({
      comment: ['',Validators.required],
      grade: ['', Validators.required],
      annonymus: false
    });
    
  }

  change(){
    this.annonymus = true 
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
    this.examinationIdString = this.route.snapshot.queryParamMap.get('id');
    this.examinationId = parseInt(this.examinationIdString);
  }

  async onSubmit(): Promise<void> {
    this.loginInvalid = false;
    this.formSubmitAttempt = false;
    if (this.form.valid) {
      try {
        const grade = this.form.get('grade')?.value;
        const comment = this.form.get('comment')?.value;
        const annonymus = this.form.get('annonymus')?.value;

        this.apiService.giveFeedback({
          comment: comment,
          grade: grade,
          ExaminationId : this.examinationId,
          Annonimus   : annonymus       
        }).subscribe((response : any) => {
          this.router.navigate(['/patient'])

         
        })

      } catch (err) {
        this.loginInvalid = true;
      }
    } else {
      this.formSubmitAttempt = true;
    }
  }
}