import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import { Contact } from './models/contact.model';
import {environment} from '../environments/environment';
import { map } from 'rxjs/operators';
import { User } from './models/user.model';
import { ContactSlim } from './models/contactSlim.model';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class ContactsService {
  public selectedContact : Contact;
  public selectedUser : User;
  public contactsList : Contact[];
  
  constructor(private http: HttpClient ) { }

  index(){
      this.http.get(`${environment.appApi.baseUrl}${environment.appApi.contactsUri}/GetContacts`).pipe(map((response: any) => response as Contact[])).toPromise().then(x => {
        this.contactsList = x;
    });
  }

  show(id: number) {
      return  this.http.get(`${environment.appApi.baseUrl}${environment.appApi.contactsUri}/GetContactById/${id}`).pipe(map((response: any) => response as Contact)).toPromise().then(x => {
      this.selectedContact = x;
      });
  }

  create(contact: ContactSlim) {
    var body = JSON.stringify(contact);
    return this.http.post(`${environment.appApi.baseUrl}${environment.appApi.contactsUri}/Create`,body,httpOptions).pipe(map((response: any) => response));
  }

  update(contact: Contact): Observable<Contact> {
    return this.http.patch<Contact>(`${environment.appApi.baseUrl}/contacts/${contact.ID}`, contact);
  }


  delete(id: number) {
    return this.http.post(`${environment.appApi.baseUrl}${environment.appApi.contactsUri}/Delete`,id,httpOptions).pipe(map((response: any) => response));
  }

}