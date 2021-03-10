import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Produto } from '../produto';
import { ProdutosService } from '../produtos.service';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html',
  styleUrls: ['./lista-produto.component.css']
})
export class ListaProdutoComponent implements OnInit {

  constructor(private ProdutosService: ProdutosService,
              private sharedService: SharedService) { }

  public produtos: Produto[];

  ngOnInit() {
    this.ProdutosService.obterProdutos()
      .subscribe(
        produtos => {
          this.produtos = produtos;
          console.log(produtos)
        },
        error => console.log(error)
      );
  }

  adicionarAoCarrinho(produto: Produto) {
    this.ProdutosService.adicionarAoCarrinho(produto)
      .subscribe(
        ok => {
          this.sharedService.produtoAdicionadoEvent(produto);
          console.log('alterar a quantidade do carrinho');
        },
        error => console.log(error)
      );
  }

}
