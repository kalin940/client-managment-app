import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactsListComponent} from './contacts-list/contacts-list.component';
import { ContactFormComponent} from './contact-form/contact-form.component';
import { ContactDetailsComponent} from './contact-details/contact-details.component';
import { ContactEditComponent} from './contact-edit/contact-edit.component';
const routes: Routes = [
  { path: 'home',  component: ContactsListComponent },
  { path: 'create',  component: ContactFormComponent },
  { path: 'edit/:id',  component: ContactEditComponent },
  { path: 'details/:id',  component: ContactDetailsComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
