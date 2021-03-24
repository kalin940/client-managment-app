import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../contacts.service';
import { ToastrService } from 'ngx-toastr'; 
import { Router,ActivatedRoute } from '@angular/router';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.css']
})
export class ContactDetailsComponent implements OnInit {

  public Contact : Contact;
  public id : number;

  constructor(public contactsService: ContactsService,private toastr : ToastrService,private router: ActivatedRoute) { }

  ngOnInit(){
    // this.contactsService.show();
    this.router.params.subscribe(params => {
      this.id = params['id'];
    });
    this.contactsService.show(this.id)
  }

}
