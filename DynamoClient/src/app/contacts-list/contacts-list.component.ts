import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../contacts.service';
import { ToastrService } from 'ngx-toastr'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.css']
})
export class ContactsListComponent implements OnInit {

  constructor(public contactsService: ContactsService,private toastr : ToastrService,private router: Router ) {

  }

  ngOnInit() {
    this.contactsService.index();
  }

  CreateNew(){
    this.router.navigate(['/create'])
  }

  showForEdit(id: number) {
    this.router.navigate(['/edit',id])
  }
  showDetails(id: number) {
    this.router.navigate(['/details',id])
  }
  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      this.contactsService.delete(id)
      .subscribe(x => {
        this.toastr.success("Deleted Successfully");
        this.contactsService.index();
      })
    }
  }


  
}
