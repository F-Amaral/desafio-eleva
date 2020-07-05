import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Escola } from 'src/app/shared/models/Escola.model';
import { map, catchError } from 'rxjs/operators';
import { Aluno } from 'src/app/shared/models/Aluno.model';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {
  getAlunos(id: string): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(`/api/v1/escolas/${id}/alunos`).pipe(
      map(data => data.map(data => new Aluno().deserialize(data)))
    );
  }
  public getEscolas(): Observable<Escola[]> {
    return this.http.get<Escola[]>('/api/v1/escolas').pipe(
        map(data => data.map(data => new Escola().deserialize(data)))
        );
  }

  public getEscola(id: string): Observable<Escola> {
    return this.http.get<Escola>(`api/v1/escolas/${id}`).pipe(
      map(data => new Escola().deserialize(data)),
      catchError(() => throwError('Escola não encontrada'))
    );
  }

  public deleteEscola(id: string) {
    this.http.delete("/api/v1/escolas/{id}")
    .pipe(catchError(() => throwError('Falha ao deletar a escola')))
  }

  constructor(private http: HttpClient) {
  }

}
