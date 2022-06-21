import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ApiService} from "../api.service";

@Component({
  selector: 'app-frontpage',
  templateUrl: './frontpage.component.html',
  styleUrls: ['./frontpage.component.scss']
})
export class FrontpageComponent implements OnInit {

  public feedbacks :  Array<Number> = [];
  infoMessage:any
  thisFeedBackList:any
  displayedColumns: string[] = ['User', 'Comment', 'Grade','Doctor'];

  constructor(
    private apiService: ApiService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.infoMessage = '';
    this.route.queryParams
    .subscribe(params => {
      if(params['login'] !== undefined && params['login'] === 'false') {
          this.infoMessage = 'Please Login!';
      }
    });
    this.route.queryParams
    .subscribe(params => {
      if(params['permission'] !== undefined && params['permission'] === 'false') {
          this.infoMessage = 'U dont have permission!';
      }
    });
    localStorage.removeItem("Token");
    localStorage.removeItem("user")
    this.apiService.getFeedbacksApproved().subscribe((response : any) => {
      for(let item2 of response){
        
          if(item2.annonimus == true)
          {
            item2.examination.user.name = "Anynonimus"
          }

          this.feedbacks.push(item2)
          this.thisFeedBackList = this.feedbacks
      }
    })
  }

}
