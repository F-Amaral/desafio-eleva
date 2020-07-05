import { Deserializable } from './Deserializable.model';

export class Turma implements Deserializable{
    id: string;
    nome: string;
    ano: string;

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}