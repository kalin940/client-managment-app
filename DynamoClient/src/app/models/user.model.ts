import {Contact} from './contact.model'
import {Country} from './country.model'

export class User {
    public ID:number;
    public Name:string;
    public Age:number;
    public Email:string;
    public CountryID:number;
    public Country:Country;
    public DateCreated:Date;
    public DateModified:Date;
    public Contacts:Contact[];

    public constructor(
        fields?: {
             ID?:number;
             Name?:string;
             Age?:number;
             Email?:string;
             CountryID?:number;
            Country?:Country;
             DateCreated?:Date;
             DateModified?:Date;
            Contacts?:Contact[];
        }) {
        if (fields) Object.assign(this, fields);
    }
}
