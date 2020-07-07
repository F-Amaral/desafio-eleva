import { Deserializable } from './Deserializable.model';
import { Professor } from './Professor.model';

export class Disciplina implements Deserializable{
    id: string;
    nome: string;
    descricao: string;
    createdAt: Date;
    professorId: string;
    professor: Professor;

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}