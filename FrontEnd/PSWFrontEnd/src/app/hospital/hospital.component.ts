import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrls: ['./hospital.component.scss']
})
export class HospitalComponent implements OnInit {
hospital:any
  constructor(
    private apiService:ApiService
  ) { }

  ngOnInit(): void {
    this.apiService.getHospital({id:1}).subscribe((response:any)=>
    {
      this.hospital = response
    })
  }

}
