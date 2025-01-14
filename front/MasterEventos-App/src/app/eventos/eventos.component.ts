import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  standalone: false,
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
})
export class EventosComponent implements OnInit{
  isClicked = false;

  public toggleImage(){
    this.isClicked = !this.isClicked;
  }
  public eventos: any;
  public eventosFiltrados: any;
  widthImg = 100;
  marginImg = 2;
  private _filtrarLista: string = "";

  public get filtrarLista(): string{
    return this._filtrarLista;
  }

  public set filtrarLista(value: string){
     this._filtrarLista = value;
     this.eventosFiltrados = this.filtrarLista ? this.filtrarEventos(this.filtrarLista) : this.eventos;
  }

  public filtrarEventos(filtro: string): any{
    filtro = filtro.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtro) !== -1 || evento.local.toLocaleLowerCase().indexOf(filtro) !== -1
    )
  }



  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos();
  }

  public url:string = "http://localhost:5019/api/evento"

  public getEventos(): void {
   this.http.get<any[]>(this.url).subscribe(
    (response) => {
      this.eventos = response;
      this.eventosFiltrados = this.eventos;
    },
    (error) =>{
      console.error("Erro ao retornar os eventos: ", error);
    }
   )
  }

}
