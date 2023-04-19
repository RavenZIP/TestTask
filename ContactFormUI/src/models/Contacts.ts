import { Messages } from "./Messages";
import { ThemesMessages } from "./ThemesMessages";

export class Contacts{
    id?: number;
    name = "";
    email = "";
    phone = "";
    message: Messages = new Messages();
    themes: ThemesMessages = new ThemesMessages();
}