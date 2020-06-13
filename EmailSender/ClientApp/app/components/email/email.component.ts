import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { EmailMessage } from './EmailMessage';
import { EmailValidator } from '@angular/forms';

import 'rxjs/add/operator/map';

@Component({
    selector: 'email',
    templateUrl: './email.component.html'
})
export class EmailComponent{
    submitted = false;
    response = "";
    error = "";
    model = new EmailMessage("", "", "", "", "");

    constructor(private http: Http) {  
        //this.http = http;
    }

    public sendEmail() {
        this.response = "";
        this.error = "";
        //console.log(data);
        let data = {
            "to": this.model.to,
            "cc": this.model.cc,
            "bcc": this.model.bcc,
            "subject": this.model.subject,
            "message": this.model.message
        }
        let headers: any = {
            'Content-Type': 'application/json; charset=utf-8',
            'Accept': 'application/json'
        }
        let body = JSON.stringify(data);
        this.http.post('/api/Email/SendEmail/' + data, body, { headers: headers })
            .map(
            (res: Response) => res.json())
                .subscribe(
                (data) => this.response = data,
                (err) => this.error = err
                );
    }
 
    onSubmit() {
        this.submitted = true;
        this.sendEmail();
    }

    // get diagnostic() { return JSON.stringify(this.model); }
}
