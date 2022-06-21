import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ApiService} from "../api.service";

@Component({
  selector: 'app-patientpage',
  templateUrl: './patientpage.component.html',
  styleUrls: ['./patientpage.component.scss']
})
export class PatientpageComponent implements OnInit {
  user: any;
  gender: any;
  role: any;
  constructor(
    private apiService: ApiService,
    private router:Router

  ) { }

  ngOnInit(): void {
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
        
       if(this.user.Gender == 1)
       {
         this.gender = 'Female'
       }

       else{
         this.gender = 'Male'
       }
       

       if(this.user.userType == 1){
         this.role = 'Patient'
       }
       
    
  }



}
