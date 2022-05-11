import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CurrencyPipe } from '@angular/common';
import { CalculoInvestimentoCDBService } from '@app/services/CalculoInvestimentoCDBService';
import { ICalculoEntrada } from '@app/models/ICalculoEntrada';
import { iCalculoSaida } from '@app/models/iCalculoSaida';

@Component({
  selector: 'app-calculo-investimento',
  templateUrl: './calculo-investimento.component.html',
  styleUrls: ['./calculo-investimento.component.scss']
})

export class CalculoInvestimentoComponent implements OnInit 
{
  form!: FormGroup;
  getCalculo = this.clearData();
  enviandoDados = false;
  ivalor = 'R$ 1000,00';
  imeses = '24';
  erro  = false;

  constructor(
    private _fb: FormBuilder,
    private _service: CalculoInvestimentoCDBService,

    /*
    Claase do modulo Common para transofrma números em determiando formato/string,
    Quando chamado sem o parâmetro de região, o padrão é o En-US.
    */
    private currencyPipe: CurrencyPipe
  ) { }

  ngOnInit(): void 
  {
    this.setFields();
    this.onValueChange();
  }

  public get f(): any 
  {
    return this.form.controls; 
  }

  public enviaDados(): void 
  {
    const valorSemFormatacao = parseFloat(this.gertOnlyNumber(this.form.value.valor)) / 100.0;
  
    const dadosParaEnvio = {
      valor: valorSemFormatacao,
      meses: +this.form.value.meses
    } as ICalculoEntrada;
    this.enviandoDados = true;
    this.getCalculo = this.clearData();

    this._service.getCalculo(dadosParaEnvio).subscribe({
      next: (response: iCalculoSaida) => {
        this.erro = false;
        this.getCalculo = { ...response };
      },
      error: (error: Error) => {
        this.erro = true;
        console.error(JSON.stringify(error));
      },
    }).add(() => this.enviandoDados = false);
  }

  private setFields(): void 
  {
    this.form = this._fb.group({
      valor: [this.ivalor, [Validators.required, Validators.min(0.01)]],
      meses: [this.imeses, [Validators.required, Validators.min(2), ]]
    });
  }

  private onValueChange(): void 
  {
    this.form.valueChanges.subscribe(f => 
    {
      if (f.valor) {
        const newValue = parseFloat(this.gertOnlyNumber(f.valor)) / 100.0;
        this.form.patchValue({
          valor: this.currencyPipe.transform(newValue, 'BRL', 'symbol', '1.2-2')
        }, { emitEvent: false });
      }

      if (f.meses) {
        this.form.patchValue({
          meses: this.gertOnlyNumber(f.meses)
        }, { emitEvent: false });
      }
    });
  }

  private gertOnlyNumber(valor: string): string 
  {
    return valor.replace(/\D/g, '').replace(/^0+/, '') || '0';
  }

  private clearData(): iCalculoSaida 
  {
    return {
      valor_bruto: 0.00,
      valor_liquido: 0.00
    } as iCalculoSaida;
  }

  
  public clearScreen() : void 
  {
    this.getCalculo = this.clearData();
    this.form.reset();
    this.erro = false;

    this.form.patchValue({
      valor: this.ivalor,
      meses: this.imeses
    });
  }
  
  public cssValidator(field: FormControl): any 
  {
    return { 'is-invalid': field.errors && field.touched };
  }

}
