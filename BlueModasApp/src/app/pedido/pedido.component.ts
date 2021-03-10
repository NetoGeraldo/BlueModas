import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pedido } from './pedido';
import { PedidoService } from './pedido.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent implements OnInit {

  pedido: Pedido;

  constructor(private pedidoService: PedidoService,
              private route: ActivatedRoute  ) { }

  ngOnInit(): void {
    const pedidoId = this.route.snapshot.paramMap.get('id');

    this.pedidoService.obterPedido(pedidoId).subscribe(
      pedido => { this.pedido = pedido; },
      error => console.log(error),
    )
  }

}
