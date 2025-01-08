import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { response } from 'express';
import { error } from 'node:console';
import { promises } from 'node:dns';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Component({
  selector: 'app-eventos',
  standalone: false,
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent implements OnInit{

  public eventos: any;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    this.getEventos();
  }

  public url:string = "http://localhost:5019/api/evento"

  public getEventos(): void {
   this.http.get<any[]>(this.url).subscribe(
    (response) =>{
      this.eventos = response;
    },
    (error) =>{
      console.error("Erro ao retornar os eventos: ", error);
    }
   )
  }

}
