import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Carrinho } from '../carrinho/carrinho';
import { CarrinhoService } from '../carrinho/carrinho.service';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-icone-carrinho',
  templateUrl: './icone-carrinho.component.html',
  styleUrls: ['./icone-carrinho.component.css']
})
export class IconeCarrinhoComponent implements OnInit {

  ProdutoAdicionadoSubscription: Subscription;
  Carrinho: Carrinho;

  quantidadeItens: number = 0;

  constructor(private sharedService: SharedService,
              private carrinhoService: CarrinhoService) { }

  ngOnInit(): void {
    this.sharedService.produtoAtual.subscribe(produto => {
      this.obterDetalhesCarrinho();
    })

  }

  obterDetalhesCarrinho() {
    this.carrinhoService.obterDetalhesCarrinho()
      .subscribe(
        carrinho => {
          this.Carrinho = carrinho;
          console.log(this.Carrinho);
          this.quantidadeItens = this.Carrinho.itensPedidos.length;
          
        },
        error => console.log(error),
      );
  }

}
