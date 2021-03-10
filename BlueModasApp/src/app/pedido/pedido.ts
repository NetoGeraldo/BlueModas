export class Pedido {
    numeroPedido: String;
    itensPedidos: ItemPedido[];
    valorTotal: number;
    nome: String;
    email: String;
    telefone: String;

}

export class ItemPedido {
    produtoId: String;
    nome: String;
    quantidade: number;
    valorUnitario: number;
}