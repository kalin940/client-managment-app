import {User} from './user.model'

export class ContactSlim {
    public Age: number;
    public Name: string;
    public Number:string;
    public Email: string;
    public CountryID: number;

    public constructor(
        fields?: {
            Age?: number;
            Name: string;
            Number:string;
            Email?: string;
            CountryID: number;
        }) {
        if (fields) Object.assign(this, fields);
    }
}
