export class Messages{
    id?: number;
    text = "";
    contactDataId?: number
    themesMessagesDataId?: number

    constructor(text: string, themesMessagesDataId: number){
        this.text = text;
        this.themesMessagesDataId = themesMessagesDataId
    }
}