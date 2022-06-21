import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ApiService} from "../api.service";


@Component({
  selector: 'app-history-appointment',
  templateUrl: './history-appointment.component.html',
  styleUrls: ['./history-appointment.component.scss']
})
export class HistoryAppointmentComponent implements OnInit {

  data: any;
  displayedColumns: string[] = ['AppointmentTimeStart', 'AppointmentTimeEnd', 'Hospital','UserDoctor','Cancel'];
  dataPast: any;
  displayedColumnsPast: string[] = ['AppointmentTimeStart', 'AppointmentTimeEnd', 'Hospital','UserDoctor','Feedback'];
  user:any
 
  div1:boolean=false;
  div2:boolean=false;
  div1Function(){
    this.div1=true;
    this.div2=false;
}

div2Function(){
    this.div2=true;
    this.div1=false;
}
  constructor(
    private apiService: ApiService,
    private router: Router

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
    this.data = []    
    this.apiService.historyAppointments({
    id:this.user.id
    }).subscribe((response : any) => {
       this.data = response;
    })

    this.apiService.historyAppointmentsPast({
      id:this.user.id
    }).subscribe((response:any)=>{
      this.dataPast = response;
    })

    

}

Cancel(id:any){
  this.apiService.cancel({
    id : id,
    userId: this.user.id
  }).subscribe((response:any)=>{
    this.router.navigate(['/patient'])
  })
}
}
