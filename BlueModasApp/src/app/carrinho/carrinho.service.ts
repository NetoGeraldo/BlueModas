import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Identificacao } from '../identificacao/identificacao';
import { Produto } from '../produtos/produto';
import { Carrinho } from './carrinho';

@Injectable({
  providedIn: 'root'
})
export class CarrinhoService {

  constructor(private http: HttpClient) { 

  }

  protected url: string ="https://localhost:5001/api";

  obterDetalhesCarrinho() : Observable<Carrinho> {
    return this.http.get<Carrinho>(this.url + '/carrinho');
  }

  finalizarCompra(finalizarCompraViewModel: Identificacao) : Observable<any> {
    return this.http.post(this.url + '/carrinho/finalizar-pedido', {
      nome: finalizarCompraViewModel.nome,
      email: finalizarCompraViewModel.email,
      telefone: finalizarCompraViewModel.telefone
    });
  }

  
  adicionarUnidade(produtoId: String) : Observable<any>  {
    return this.http.post(this.url + '/carrinho/adicionar-item', 
    {
      produtoId: produtoId,
      quantidade: 1
    });
  }

  removerUnidade(produtoId: String) : Observable<any>  {
    return this.http.post(this.url + '/carrinho/adicionar-item', 
    {
      produtoId: produtoId,
      quantidade: -1
    });
  }

  removerDoCarrinho(produtoId: String) : Observable<any>  {
    return this.http.post(this.url + '/carrinho/remover-item', 
    {
      produtoId: produtoId
    });
  }
}
