import { Routes } from "@angular/router";
import { CarrinhoComponent } from "./carrinho/carrinho.component";
import { IdentificacaoComponent } from "./identificacao/identificacao.component";
import { HomeComponent } from "./navigation/home/home.component";
import { PedidoComponent } from "./pedido/pedido.component";
import { ListaProdutoComponent } from "./produtos/lista-produto/lista-produto.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'produtos', component: ListaProdutoComponent},
    { path: 'carrinho', component: CarrinhoComponent },
    { path: 'identificacao', component: IdentificacaoComponent},
    { path: 'pedidos/:id', component: PedidoComponent }
]