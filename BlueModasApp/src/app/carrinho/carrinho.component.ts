import { Component, OnInit } from '@angular/core';
import { Produto } from '../produtos/produto';
import { SharedService } from '../shared.service';
import { Carrinho, Item } from './carrinho';
import { CarrinhoService } from './carrinho.service';


@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

  carrinho: Carrinho;

  constructor(private carrinhoService: CarrinhoService,
              private sharedService: SharedService) { 

  }

  subtrairUnidades(item: Item) {
    this.carrinhoService.removerUnidade(item.produtoId)
    .subscribe(
      carrinho => {
        this.obterDetalhesCarrinho();
        this.sharedService.produtoAdicionadoEvent(new Produto());
      },
      error => console.log(error),
    );    
  }

  adicionarUnidades(item: Item) {
    this.carrinhoService.adicionarUnidade(item.produtoId)
    .subscribe(
      carrinho => {
        this.obterDetalhesCarrinho();
        this.sharedService.produtoAdicionadoEvent(new Produto());
      },
      error => console.log(error),
    );
  }

  removerItem(item: Item) {
    this.carrinhoService.removerDoCarrinho(item.produtoId)
    .subscribe(
      carrinho => {
        this.obterDetalhesCarrinho();
        this.sharedService.produtoAdicionadoEvent(new Produto());
      },
      error => console.log(error),
    );
  }

  ngOnInit(): void {
    this.obterDetalhesCarrinho();

  }

  obterDetalhesCarrinho() {
    this.carrinhoService.obterDetalhesCarrinho()
      .subscribe(
        carrinho => {
          this.carrinho = carrinho;
          
        },
        error => console.log(error),
      );
  }

}
