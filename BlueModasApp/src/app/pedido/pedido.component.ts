import { Component, OnInit } from '@angular/core';
import { Pedido } from './pedido';
import { PedidoService } from './pedido.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {

  pedido: Pedido;

  constructor(private pedidoService: PedidoService) { }

  ngOnInit(): void {
    this.pedidoService.obterPedido('c844ffe5-81e5-469e-988b-332a43cd6086').subscribe(
      pedido => { this.pedido = pedido; },
      error => console.log(error),
    )
  }

}
