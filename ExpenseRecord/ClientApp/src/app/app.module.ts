import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { AppComponent } from './app.component';
import { GreetingComponent } from './greeting/greeting.component';
import { AppRoutingModule } from './app-routing.module';
import { ExpenseRecordComponent } from './expense-record/expense-record.component';

@NgModule({
  declarations: [AppComponent, GreetingComponent, ExpenseRecordComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
