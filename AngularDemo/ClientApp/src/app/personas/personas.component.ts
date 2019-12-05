import { Component, OnInit } from '@angular/core';
import { IPersona } from './persona';
import { PersonasService } from './personas.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.css']
})
export class PersonasComponent implements OnInit {

    personas: IPersona[];
    constructor(private personasServices: PersonasService) { }

    ngOnInit() {
        this.cargarData();
    }
    delete(persona: IPersona) {
        this.personasServices.deletePersona(persona.id.toString()).subscribe(
            ok => this.cargarData(),
            error => console.error(error)
        );
    }
    cargarData() {
        this.personasServices.getPersonas().subscribe(
            personasWS => this.personas = personasWS,
            error => console.error(error)
        );
    }

}
