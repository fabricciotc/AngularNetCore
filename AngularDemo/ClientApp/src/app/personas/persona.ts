import { IDireccion } from "../direcciones/direccion";

export interface IPersona {
    id: string;
    nombre: string;
    fechaNacimiento: Date;
    direcciones: IDireccion[];
}
