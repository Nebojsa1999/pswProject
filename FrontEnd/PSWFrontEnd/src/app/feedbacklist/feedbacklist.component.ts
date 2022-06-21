import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-feedbacklist',
  templateUrl: './feedbacklist.component.html',
  styleUrls: ['./feedbacklist.component.scss']
})
export class FeedbacklistComponent implements OnInit {

  infoMessage:any
  feedbacks:any
  displayedColumns: string[] = ['User', 'Comment', 'Grade','Doctor','Shown','Change'];
  user:any
  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute,
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
    this.apiService.getFeedbacks().subscribe((response : any) => {
      this.feedbacks = response
    })
  }

  Change(id:any){
    this.apiService.changeFeedbackStatus({
      id : id,
    }).subscribe((response:any)=>{
      this.ngOnInit()
    })
  }

}
