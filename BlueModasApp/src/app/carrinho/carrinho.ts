import { Produto } from "../produtos/produto";

export class Carrinho {
    itensPedidos: Item[];
    valorTotal: number;
}

export class Item {
    produtoId: String;
    nome: String;
    quantidade: number;
    valorUnitario: number;
}