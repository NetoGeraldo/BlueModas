import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CarrinhoService } from '../carrinho/carrinho.service';
import { Identificacao } from './identificacao';

@Component({
  selector: 'app-identificacao',
  templateUrl: './identificacao.component.html',
  styleUrls: ['./identificacao.component.css']
})
export class IdentificacaoComponent {

  public nome: String;
  public email: String;
  public telefone: String;

  public form: FormGroup;

  constructor(private fb: FormBuilder,
              private carrinhoService: CarrinhoService,
              private router: Router)   { 
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(3),
        Validators.required
      ])],
      email: ['', Validators.compose([
        Validators.email,
        Validators.required
      ])],
      telefone: ['', Validators.required]
    });
  }

  finalizarCompra() {
    let identificacao = new Identificacao(this.form.controls.nome.value, 
                                          this.form.controls.email.value, 
                                          this.form.controls.telefone.value)

    this.carrinhoService.finalizarCompra(identificacao).subscribe(
      ok => {
        this.router.navigate([`/pedidos/${ok.pedidoId}`]);
      },
      error => console.log('ocorreu um erro ao realizar a compra'),
    );
  }

}
