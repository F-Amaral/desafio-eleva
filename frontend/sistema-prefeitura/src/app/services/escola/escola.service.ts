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
import { LoadingService } from '../loading/loading.service';

@Injectable({
  providedIn: 'root'
})
export class EscolaService {
  public async updateTurma(escolaId: string, turma: Turma) {
    this.loadingService.show();
    return await this.http.put<Turma>(`api/v1/escolas/${escolaId}/turmas/${turma.id}`, turma).toPromise().finally(() => this.loadingService.hide())
  }
  public async updateProfessor(escolaId: string, professor: Professor) {
    this.loadingService.show();
    return await this.http.put<Professor>(`api/v1/escolas/${escolaId}/professores/${professor.id}`, professor).toPromise().finally(() => this.loadingService.hide())
  }
  public async updateAluno(escolaId: string, aluno: Aluno) {
    this.loadingService.show();
    return await this.http.put<Aluno>(`api/v1/escolas/${escolaId}/alunos/${aluno.id}`, aluno).toPromise().finally(() => this.loadingService.hide())
  }
  public async updateDisciplina(escolaId: string, disciplina: Disciplina) {
    this.loadingService.show();
    return await this.http.put<Disciplina>(`api/v1/escolas/${escolaId}/disciplinas/${disciplina.id}`, disciplina).toPromise().finally(() => this.loadingService.hide())
  }
  public async removeDisciplinaFromTurma(escolaId: string, turmaId: string, disciplinaId: string) {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${escolaId}/turmas/${turmaId}/disciplinas/${disciplinaId}`).toPromise().finally(() => this.loadingService.hide())
  }
  public async addDisciplinasToTurma(escolaId: string, turmaId: string, disciplinasToInclude: string[]) {
    this.loadingService.show();
    return await this.http.post<Turma>(`api/v1/escolas/${escolaId}/turmas/${turmaId}/disciplinas`, disciplinasToInclude).toPromise().finally(() => this.loadingService.hide());
  }
  public async removeAlunoFromTurma(escolaId: string, turmaId: string, alunoId: string) {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${escolaId}/turmas/${turmaId}/alunos/${alunoId}`).toPromise().finally(() => this.loadingService.hide())
  }
  public async addAlunosToTurma(escolaId: string,turmaId: string, alunosToInclude: string[]) {
    this.loadingService.show();
    return await this.http.post<Turma>(`api/v1/escolas/${escolaId}/turmas/${turmaId}/alunos`, alunosToInclude).toPromise().finally(() => this.loadingService.hide());
  }
  public async getDisciplinasByTurma(escolaId: string, turmaId: string) {
    this.loadingService.show();
    return await this.http.get<Disciplina[]>(`/api/v1/escolas/${escolaId}/turmas/${turmaId}/disciplinas`).toPromise().finally(() => this.loadingService.hide())
  }
  
  public async getTurma(escolaId: string, turmaId: string) {
    this.loadingService.show();
    return await this.http.get<Turma>(`api/v1/escolas/${escolaId}/turmas/${turmaId}`).toPromise().finally(() => this.loadingService.hide());
  }

  public async addTurma(escolaId: string, turma: Turma) {
    this.loadingService.show();
    return await this.http.post<Turma>(`api/v1/escolas/${escolaId}/turmas`, turma).toPromise().finally(() => this.loadingService.hide());
  }
  public async addDisciplina(escolaId: string, disciplina: Disciplina) {
    this.loadingService.show();
    return await this.http.post<Disciplina>(`api/v1/escolas/${escolaId}/disciplinas`, disciplina).toPromise().finally(() => this.loadingService.hide())
  }
  public async deleteDisciplina(escolaId: string, disciplinaId: string) {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${escolaId}/disciplinas/${disciplinaId}`).toPromise().finally(() => this.loadingService.hide())
  }
  public async addProfessor(escolaId: string, professor: Professor) {
    this.loadingService.show();
    return await this.http.post<Professor>(`api/v1/escolas/${escolaId}/professores`, professor).toPromise().finally(() => this.loadingService.hide())
  }
  public async deleteProfessor(escolaId: string, professorId: string) {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${escolaId}/professores/${professorId}`).toPromise().finally(() => this.loadingService.hide())
    
  }
  public async addAluno(escolaId: string, aluno: Aluno): Promise<Aluno>{
    this.loadingService.show();
    return await this.http.post<Aluno>(`api/v1/escolas/${escolaId}/alunos`, aluno).toPromise().finally(() => this.loadingService.hide())
  }
  public async deleteAluno(escolaId: string, alunoId: string) {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${escolaId}/alunos/${alunoId}`).toPromise().finally(() => this.loadingService.hide())
  }
  public async getTurmas(id: string) {
    this.loadingService.show();
    return await this.http.get<Turma[]>(`/api/v1/escolas/${id}/turmas`).toPromise().finally(() => this.loadingService.hide())
  
  }
  public async getDisciplinas(id: string) {
    this.loadingService.show();
    return await this.http.get<Disciplina[]>(`/api/v1/escolas/${id}/disciplinas`).toPromise().finally(() => this.loadingService.hide())
  }
  
  public async getProfessores(id: string) {
    this.loadingService.show();
    return await this.http.get<Professor[]>(`/api/v1/escolas/${id}/professores`).toPromise().finally(() => this.loadingService.hide())
  }

  public async getAlunos(id: string): Promise<Aluno[]> {
    this.loadingService.show();
    return await this.http.get<Aluno[]>(`/api/v1/escolas/${id}/alunos`).toPromise().finally(() => this.loadingService.hide())
  }

  public async getAlunosByTurma(escolaId: string, turmaId: string): Promise<Aluno[]> {
    this.loadingService.show();
    return await this.http.get<Aluno[]>(`/api/v1/escolas/${escolaId}/turmas/${turmaId}/alunos`).toPromise().finally(() => this.loadingService.hide())
  }


  public async getEscolas(): Promise<Escola[]> {
    this.loadingService.show();
    return await this.http.get<Escola[]>('/api/v1/escolas').toPromise().finally(() => this.loadingService.hide())
  }

  public async getEscola(id: string): Promise<Escola> {
    this.loadingService.show();
    return await this.http.get<Escola>(`api/v1/escolas/${id}`).toPromise().finally(() => this.loadingService.hide())
  }

  public async deleteEscola(id: string): Promise<void> {
    this.loadingService.show();
    await this.http.delete(`/api/v1/escolas/${id}`).toPromise().finally(() => this.loadingService.hide())
  }

  public async updateEscola(escola: Escola): Promise<Escola> {
    this.loadingService.show();
    return await this.http.put<Escola>(`api/v1/escolas/${escola.id}`, escola).toPromise().finally(() => this.loadingService.hide())
  }

  public async addEscola(escola: Escola): Promise<Escola> {
    this.loadingService.show();
    return await this.http.post<Escola>(`api/v1/escolas/`, escola).toPromise().finally(() => this.loadingService.hide())
    
  }

  constructor(private http: HttpClient, private loadingService: LoadingService) {
  }

}
