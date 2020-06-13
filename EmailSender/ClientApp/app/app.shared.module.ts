import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { EmailComponent } from './components/email/email.component';

@NgModule({
    declarations: [
        AppComponent,
        EmailComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: EmailComponent },
            { path: '**', redirectTo: 'fetch-data' }
        ])
    ]
})
export class AppModuleShared {
}
