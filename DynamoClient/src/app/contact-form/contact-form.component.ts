import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ContactsService } from '../contacts.service';
import { Country } from '../models/country.model';

import { ContactSlim } from '../models/contactSlim.model';
@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent implements OnInit {

  public phone: number;
  public countries : Country[];

  constructor(public contactsService: ContactsService, private toastr: ToastrService) { 
    this.countries = [
      new Country({ID:1, Name:'Bulgaria',CountryCode:null}),
      new Country({ID:2, Name:'Greece',CountryCode:null}),
      new Country({ID:3, Name:'Norway',CountryCode:null}),
      new Country({ID:4, Name:'France',CountryCode:null}),
      new Country({ID:5, Name:'Spain',CountryCode:null}),
    ]
  }

  ngOnInit() {
    //TODO : Get Countries list from api
    this.countries = [
      new Country({ID:1, Name:'Bulgaria',CountryCode:null}),
      new Country({ID:2, Name:'Greece',CountryCode:null}),
      new Country({ID:3, Name:'Norway',CountryCode:null}),
      new Country({ID:4, Name:'France',CountryCode:null}),
      new Country({ID:5, Name:'Spain',CountryCode:null}),
    ]
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.contactsService.selectedUser = {
          ID:0,
          Name:'',
          Age:null,
          Email:'',
          CountryID:0,
          Country:null,
          DateCreated: null,
          DateModified: null,
          Contacts:null
    }
  }


  onSubmit(form: NgForm) {
    console.dir(form);
     
       let country = this.countries.find(p => p.ID == form.value.Country);
       let contact =  new ContactSlim({Age:form.value.Age, Name:form.value.Name, Number:form.value.Number, Email:form.value.Email, CountryID:country.ID});
       this.contactsService.create(contact)
       .subscribe(data => {
         this.resetForm();
         this.toastr.success('New Record Added Succcessfully');
       })
     
  }
}
