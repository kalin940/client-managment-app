import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ContactsListComponent } from './contacts-list/contacts-list.component';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactEditComponent } from './contact-edit/contact-edit.component';
import { FormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ContactsListComponent,
    ContactFormComponent,
    ContactDetailsComponent,
    ContactEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
