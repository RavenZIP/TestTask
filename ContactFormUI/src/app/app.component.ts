import { Component, EventEmitter, HostListener, OnInit } from '@angular/core';
import { Contacts } from 'src/models/Contacts';
import { HttpService } from './HttpServices';
import { Messages } from 'src/models/Messages';
import { ThemesMessages } from 'src/models/ThemesMessages';
import { FormBuilder, FormGroup, NgControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HttpService]
})
export class AppComponent implements OnInit {
  title = 'ContactForm';
  ContactsList: Contacts[] = [];
  ThemesList: ThemesMessages[] = [];
  LinesList: String[] = ["line", "line2", "line3", "line4", "line5", "line6"];
  message?: Messages;
  contact?: Contacts;
  formGrp: FormGroup;
  code: string = (10000 + Math.round(Math.random()*(99999-10000))).toString();
  contactUpdated = new EventEmitter<Contacts[]>();
  regexpPhone: RegExp;
  regexpCode: RegExp;
  done?: boolean;
  themeName = ""

  constructor(private httpService: HttpService, formBuilder: FormBuilder) {
    this.formGrp = formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['8', [Validators.required, Validators.pattern(/[0-9 ]/)]],
      message: ['', [Validators.required]],
      selectedTheme: '1',
      entered_code: ['', [Validators.required, Validators.pattern(/[0-9 ]/)]]
    }),
    this.regexpPhone = /[0-9 ]/
    this.regexpCode = /[0-9 ]/
    this.done = false
  }

  get status(){
    return this.formGrp.controls
  }

  onKeyPress(event: any, regexp: RegExp) {
    const regexpNumber = regexp;
    console.log(event)
    let inputCharacter = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !regexpNumber.test(inputCharacter)) {
      event.preventDefault();
    }
  }

  ngOnInit(): void {
    this.httpService
    .getContacts()
    .subscribe((result: Contacts[]) => (this.ContactsList = result));

    this.httpService
    .getThemes()
    .subscribe((result: ThemesMessages[]) => (this.ThemesList = result));
  };

  submit() {
    this.message = new Messages(this.formGrp.value.message, parseInt(this.formGrp.value.selectedTheme))
    this.contact = new Contacts(this.formGrp.value.name, this.formGrp.value.email, this.formGrp.value.phone, [this.message])
    console.log(this.ContactsList)
    if (this.formGrp.value.entered_code == this.code){
      this.httpService
      .createContact(this.contact)
      .subscribe(
        (contact_t: Contacts[]) => {
          this.contactUpdated.emit(contact_t)
          this.done = true
        });
      this.ThemesList.forEach(item => {
        if (item.id == parseInt(this.formGrp.value.selectedTheme)){
          this.themeName = item.theme
        }
      })
    }
    else{
      alert('Введенный вами код не совпадает!');
    }
  }
}