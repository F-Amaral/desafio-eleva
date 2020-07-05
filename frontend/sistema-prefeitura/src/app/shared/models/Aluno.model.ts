import { Deserializable } from './Deserializable.model';

export class Aluno implements Deserializable{
    id: string;
    nome: string;
    sobrenome: string;
    dataNascimento: string

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}