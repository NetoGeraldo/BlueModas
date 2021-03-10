import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
}
