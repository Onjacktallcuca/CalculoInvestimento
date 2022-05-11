import { HttpClientModule } from '@angular/common/http';
import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {CurrencyPipe, registerLocaleData} from '@angular/common';
import { AppComponent } from './app.component';
import { CalculoInvestimentoComponent } from './components/calculo-investimento/calculo-investimento.component';
import ptBr from '@angular/common/locales/pt';


registerLocaleData(ptBr);

@NgModule({
  declarations: [
    AppComponent,
    CalculoInvestimentoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'pt' },
    CurrencyPipe
  ],
  schemas: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
