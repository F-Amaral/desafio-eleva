import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Escola } from 'src/app/shared/models/Escola.model';
import { map, catchError } from 'rxjs/operators';
import { Aluno } from 'src/app/shared/models/Aluno.model';
import { promise } from 'protractor';
import { Professor } from 'src/app/shared/models/Professor.model';
import { Disciplina } from 'src/app/shared/models/Disciplina.model';
import { Turma } from 'src/app/shared/models/Turma.model';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {
  public async getTurmas(id: string) {
    return await this.http.get<Turma[]>(`/api/v1/escolas/${id}/turmas`).toPromise();
  
  }
  public async getDisciplinas(id: string) {
    return await this.http.get<Disciplina[]>(`/api/v1/escolas/${id}/disciplinas`).toPromise();
  }
  
  public async getProfessores(id: string) {
    return await this.http.get<Professor[]>(`/api/v1/escolas/${id}/professores`).toPromise();
  }

  public async getAlunos(id: string): Promise<Aluno[]> {
    return await this.http.get<Aluno[]>(`/api/v1/escolas/${id}/alunos`).toPromise();
  }
  public async getEscolas(): Promise<Escola[]> {
    return await this.http.get<Escola[]>('/api/v1/escolas').toPromise();
  }

  public async getEscola(id: string): Promise<Escola> {
    return await this.http.get<Escola>(`api/v1/escolas/${id}`).toPromise();
  }

  public async deleteEscola(id: string): Promise<void> {
    await this.http.delete(`/api/v1/escolas/${id}`).toPromise();
  }

  public async updateEscola(escola: Escola): Promise<Escola> {
    return await this.http.put<Escola>(`api/v1/escolas/${escola.id}`, escola).toPromise();
  }

  public async addEscola(escola: Escola): Promise<Escola> {
    return await this.http.post<Escola>(`api/v1/escolas/`, escola).toPromise();
    
  }

  constructor(private http: HttpClient) {
  }

}
