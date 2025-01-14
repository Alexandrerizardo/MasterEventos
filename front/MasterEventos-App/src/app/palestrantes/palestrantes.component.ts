import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';

@Component({
  selector: 'app-palestrantes',
  standalone: false,
  templateUrl: './palestrantes.component.html',
  styleUrl: './palestrantes.component.scss'
})
export class PalestrantesComponent implements OnInit{

  public palestrantes: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getPalestrantes();
  }

  public url:string = "http://localhost:5019/api/palestrante"

  public getPalestrantes(): void{
      this.http.get<any[]>(this.url).subscribe(
        (response) => {
          console.log(response);
          this.palestrantes = response;
        },
        (error) => {
          console.error("Erro ao buscar palestrantes: ", error)
        }
      )
  }

}
