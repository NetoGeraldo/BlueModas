import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Produto } from '../produtos/produto';
import { Observable } from 'rxjs';

@Injectable()
export class ProdutosService {

  constructor(private http: HttpClient) { 

  }

  protected url: string ="https://localhost:5001/api";

  obterProdutos() : Observable<Produto[]> {
    return this.http.get<Produto[]>(this.url + '/produtos');
  }

  adicionarAoCarrinho(produto: Produto) {
    return this.http.post(this.url + '/carrinho/adicionar-item', 
    {
      produtoId: produto.id,
      quantidade: 1
    });
  }

}
