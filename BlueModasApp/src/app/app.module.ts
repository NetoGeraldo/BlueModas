import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';

import { registerLocaleData } from '@angular/common'
import localePt from '@angular/common/locales/pt'
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { MenuComponent } from './navigation/menu/menu.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { HomeComponent } from './navigation/home/home.component';
import { rootRouterConfig } from './app.routes';
import { CarrinhoComponent } from './carrinho/carrinho.component';
import { IconeCarrinhoComponent } from './icone-carrinho/icone-carrinho.component';
import { ProdutosService } from './produtos/produtos.service';
import { ListaProdutoComponent } from './produtos/lista-produto/lista-produto.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    HomeComponent,
    CarrinhoComponent,
    IconeCarrinhoComponent,
    ListaProdutoComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig, { useHash: false})]
  ],
  providers: [
    ProdutosService,
    {provide: APP_BASE_HREF, useValue: '/'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
