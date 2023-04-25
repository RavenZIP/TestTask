import { HttpClient} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Contacts } from "src/models/Contacts";
import { enviroment } from 'src/enviroments/enviroment';
import { ThemesMessages } from "src/models/ThemesMessages";

@Injectable({
    providedIn: 'root'
})
export class HttpService {
    private contactsURL = "Contacts"
    private themesURL = "ThemesMessages"
        
    constructor(private http: HttpClient) { }

    public createContact(contact: Contacts) : Observable<Contacts[]>{
        return this.http.post<Contacts[]>(
            `${enviroment.apiUrl}${this.contactsURL}/${contact.messages[0].themesMessagesDataId}`, contact
        );
    }

    public getContacts(): Observable<Contacts[]> {
      return this.http.get<Contacts[]>(`${enviroment.apiUrl}${this.contactsURL}`);
    }

    public getThemes(): Observable<ThemesMessages[]> {
      return this.http.get<ThemesMessages[]>(`${enviroment.apiUrl}${this.themesURL}`);
    }
}