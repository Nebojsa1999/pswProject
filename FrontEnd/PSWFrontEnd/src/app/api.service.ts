import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseURL = "https://localhost:44311";
  constructor(private http: HttpClient) { }

  getAuthHeader() : any {

    const headers = {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
    }

    return {
      headers: headers
    };
  }

  

  register(data: any) {
    return this.http.post(this.baseURL + "/api/user/register", data);
  }

  login(data: any) : any {
    return this.http.post(this.baseURL + "/api/Auth/login", data);
  }

  getCurrentUser() : any {
    return this.http.get(this.baseURL + "/api/Auth/current", this.getAuthHeader());
  }

  historyAppointments(data:any) :any {
    return this.http.get(this.baseURL+ "/api/examination/getAllExaminationsUserId/" + data.id,data );
  }

  historyAppointmentsPast(data:any) :any {
    return this.http.get(this.baseURL+ "/api/examination/getAllExaminationsPastUserId/" + data.id,data );
  }

  userList() :any {
    return this.http.get(this.baseURL+ "/api/user" );
  }

  getDoctors() : any {
    return this.http.get(this.baseURL+ "/api/user/doctors")
  }

  getFeedbacks() :any {
    return this.http.get(this.baseURL+ "/api/feedback")
  }

  scheduleAppointment(data: any) {
    return this.http.post(this.baseURL+ "/api/appointment/schedule", data)
  }

  getHospital(data:any){
    return this.http.get(this.baseURL + "/api/hospital/" + data.id,data)
  }
  scheduleExamination(data:any){
    return this.http.post(this.baseURL + "/api/examination/scheduleExamination",data)
  }
  cancel(data:any){
    return this.http.put(this.baseURL + "/api/examination/cancel" ,data)
  }
  getSpecialists(){
    return this.http.get(this.baseURL + "/api/appointment/getAppointmentsSpecialists")
  }
  getExaminationsFromDoctor(data:any){
    return this.http.get(this.baseURL + "/api/examination/getPatientsFromExamination/" + data.doctorId ,data)
  }
  scheduleExaminationSpecialist(data:any){
    return this.http.post(this.baseURL + "/api/examination/scheduleExaminationSpecialist",data)

  }
  giveFeedback(data:any){
    return this.http.post(this.baseURL + "/api/feedback/giveFeedback",data);
  }
  getPatients(){
    return this.http.get(this.baseURL + "/api/user/patients")
  }
  getMedicine(){
    return this.http.get(this.baseURL + "/api/medicine")
  }
  createPrescription(data:any){
    return this.http.post(this.baseURL + "/api/prescriptionMedicine/makePrescription",data)
  }
  getFeedbacksApproved(){
    return this.http.get(this.baseURL+ "/api/feedback/getAllApproved")
  }
  changeFeedbackStatus(data:any){
    return this.http.put(this.baseURL+ "/api/feedback/changeFeedbackStatus/"+data.id,data)

  }
  getBlockedUser(){
    return this.http.get(this.baseURL + "/api/user/getBlockedUsers")
  }

  getPotentialSpammers(){
    return this.http.get(this.baseURL + "/api/user/getPotentialSpammer")
  }
  block(data:any){
    return this.http.put(this.baseURL + "/api/user/block/" + data.id,data)
  }
  unblock(data:any){
    return this.http.put(this.baseURL + "/api/user/unblock/" + data.id,data)
  }
  removeFromSpam(data:any){
    return this.http.put(this.baseURL + "/api/user/removeFromSpammerList/" + data.id,data)
  }
  getMedicineGRPC(){
    return this.http.get(this.baseURL + "/api/procurement/getMedicines")
  }
}