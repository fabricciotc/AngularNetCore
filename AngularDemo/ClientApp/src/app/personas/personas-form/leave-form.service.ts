import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { PersonasFormComponent } from './personas-form.component';

@Injectable({
  providedIn: 'root'
})
export class LeaveFormService implements CanDeactivate<PersonasFormComponent> {


    canDeactivate(component: PersonasFormComponent): boolean
    {
        if (component.existenCambiosPendientes()) {
            return confirm("Tiene cambios pendientes, ¿Dese salir de todos modos?");
        }
        return true;
    }

  constructor() { }
}
