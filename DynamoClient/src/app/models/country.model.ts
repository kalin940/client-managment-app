export class Country{
    ID : number;
    Name:string;
    CountryCode:string;

    public constructor(
        fields?: {
             ID?:number;
             Name?:string;
             CountryCode?:string;
         
        }) {
        if (fields) Object.assign(this, fields);
    }
}
