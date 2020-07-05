import { Deserializable } from './Deserializable.model';

export class Escola implements Deserializable{
    id: string;
    nome: string;
    descricao: string;
    createdAt: Date;

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}