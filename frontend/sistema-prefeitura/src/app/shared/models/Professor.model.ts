import { Deserializable } from './Deserializable.model';

export class Professor implements Deserializable{
    id: string;
    nome: string;
    sobrenome: string;
    createdAt: string

    deserialize(input: any): this {
        return Object.assign(this, input);
      }
}