import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from './pedido';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  protected url: string ="https://localhost:5001/api";

  constructor(private http: HttpClient) { }

  obterPedido(id: string): Observable<Pedido> {
    return this.http.get<Pedido>(`${this.url}/pedidos/${id}`);
  }
}

