import { Component, EventEmitter } from '@angular/core';
import { Contacts } from 'src/models/Contacts';
import { Messages } from 'src/models/Messages';
import { ThemesMessages } from 'src/models/ThemesMessages';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ContactForm';
  contact: Contacts = new Contacts();
  message: Messages = new Messages();
  themeMessage: ThemesMessages = new ThemesMessages();
  code: Number = 10000 + Math.round(Math.random()*(99999-10000));
  entered_code = "";

  submit() {
    if (parseInt(this.entered_code) == this.code){
      alert('Код введен верно!');
      //Отправка данных
    }
    else{
      alert('Введенный вами код не совпадает!');
    }
  }
}