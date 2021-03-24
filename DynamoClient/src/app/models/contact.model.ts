import {User} from './user.model'

export class Contact {
    public ID : number;
    public UserId:number;
    public User: User;
    public Number:string;
    public DateCreated:Date;
    public DateModified:Date;

    public constructor(
        fields?: {
             ID? : number;
             UserId?:number;
             User?: User;
             Number?:string;
             DateCreated?:Date;
             DateModified?:Date;
        }) {
        if (fields) Object.assign(this, fields);
    }
}
