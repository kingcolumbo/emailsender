export class EmailMessage {

    constructor(
        public to: string,
        public cc: string,
        public bcc: string,
        public subject: string,
        public message: string
    ) { }

}
