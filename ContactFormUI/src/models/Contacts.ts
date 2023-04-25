import { Messages } from "./Messages";

export class Contacts{
    id?: number;
    name: string;
    email: string;
    phone: string;
    messages: Messages[];

    constructor(name: string, email: string, phone: string, messages: Messages[]){
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.messages = messages
    }
}