import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { iCalculoSaida } from '@app/models/iCalculoSaida';
import { ICalculoEntrada } from '@app/models/ICalculoEntrada';
import { Config } from "./config";


@Injectable({
  providedIn: 'root'
})

export class CalculoInvestimentoCDBService 
{
  constructor(private httpClient: HttpClient) { }

  public getCalculo(dados: ICalculoEntrada): Observable<iCalculoSaida> 
  {
    const url = `${Config.APICDB}`;
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.httpClient.post<iCalculoSaida>(url, dados, httpOptions).pipe(take(1));
  }
}
