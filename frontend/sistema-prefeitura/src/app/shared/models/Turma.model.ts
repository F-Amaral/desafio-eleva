import { Deserializable } from './Deserializable.model';
import { Disciplina } from './Disciplina.model';
import { Escola } from './Escola.model';
import { Aluno } from './Aluno.model';

export class Turma implements Deserializable{
    id: string;
    nome: string;
    ano: string;
    disciplinas: Disciplina[];
    escola: Escola;
    alunos: Aluno[];

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}