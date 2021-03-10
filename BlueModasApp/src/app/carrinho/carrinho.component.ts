import { Component, OnInit } from '@angular/core';
import { Carrinho, Item } from './carrinho';
import { CarrinhoService } from './carrinho.service';


@Component({
  selector: 'app-carrinho',
  templateUrl: './carrinho.component.html',
  styleUrls: ['./carrinho.component.css']
})
export class CarrinhoComponent implements OnInit {

  carrinho: Carrinho;

  constructor(private carrinhoService: CarrinhoService) { 

  }

  subtrairUnidades(item: Item) {
    item.quantidade--;
  }

  adicionarUnidades(item: Item) {
    item.quantidade++;
  }

  removerItem(item: Item) {
    
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
