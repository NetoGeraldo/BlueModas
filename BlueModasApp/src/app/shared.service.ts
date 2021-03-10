import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Produto } from './produtos/produto';

@Injectable()
export class SharedService {

  private messageSource = new BehaviorSubject<Produto>(null);
  produtoAtual = this.messageSource.asObservable();

  produtoAdicionadoEvent(produto: Produto) {
    this.messageSource.next(produto);
  }

  constructor() { }
}
