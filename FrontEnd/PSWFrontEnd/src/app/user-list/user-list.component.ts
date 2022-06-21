import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {ApiService} from "../api.service";

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  spammers: any;
  blocked:any;
  displayedColumns: string[] = [ 'Name', 'Surname', 'CancelCount' , 'PotentialSpammer','Enabled','Block','RemoveFromSpam'];
  displayedColumnsBlocked: string[] = [ 'Name', 'Surname', 'CancelCount' , 'PotentialSpammer','Enabled','Unblock'];
  user:any

  constructor(
    private apiService: ApiService,
    private router: Router

  ) { }

  ngOnInit(): void {
    const userString = localStorage.getItem('user');
    if(userString == null) {
      console.log(userString)
      this.router.navigate(['/home'], {queryParams: { login: 'false' } });
      return;
    }
  
    this.user = JSON.parse((userString));
    if(this.user.userType != 0)
    {
      this.router.navigate(['/home'], {queryParams: { permission: 'false' } });
      return;
    }
    this.spammers = []    
    this.apiService.getPotentialSpammers().subscribe((response : any) => {
       this.spammers = response;
    })
    this.apiService.getBlockedUser().subscribe((response : any) => {
      this.blocked = response;
   })

}

Block(id:any){
  this.apiService.block({
    id : id,
    userId: this.user.id
  }).subscribe((response:any)=>{
    this.ngOnInit()
  })
}
Unblock(id:any){
  this.apiService.unblock({
    id : id,
    userId: this.user.id
  }).subscribe((response:any)=>{
    this.ngOnInit()
  })
}
RemoveFromSpam(id:any){
  this.apiService.removeFromSpam({
    id : id,
    userId: this.user.id
  }).subscribe((response:any)=>{
    this.ngOnInit()
  })
}

}
