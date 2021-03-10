import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-identificacao',
  templateUrl: './identificacao.component.html',
  styleUrls: ['./identificacao.component.css']
})
export class IdentificacaoComponent implements OnInit {

  public nome: String;
  public email: String;
  public telefone: String;

  public form: FormGroup;

  constructor(private fb: FormBuilder) { 
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(3),
        Validators.required
      ])],
      email: ['', Validators.compose([
        Validators.email,
        Validators.required
      ])],
      telefone: ['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

}
