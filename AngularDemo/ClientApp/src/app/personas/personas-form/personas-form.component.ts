import { Component, OnInit, LOCALE_ID } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { IPersona } from '../persona';
import { PersonasService } from '../personas.service';
import { Router,ActivatedRoute } from '@angular/router';
import { DatePipe, registerLocaleData, CurrencyPipe } from '@angular/common';
import { DireccionesService } from 'src/app/direcciones/direccion.service';
@Component({
  selector: 'app-personas-form',
  templateUrl: './personas-form.component.html',
  styleUrls: ['./personas-form.component.css']
})
export class PersonasFormComponent implements OnInit {


    constructor(private fb: FormBuilder,private direccionService:DireccionesService, private personasServices: PersonasService, private router: Router, private router2 : ActivatedRoute) {
    }


    
    modoEdicion: boolean = false;
    formGroup: FormGroup;
    personaID: string;
    direccionesABorrar: number[] = [];
    ignorarExistenCambiosPendientes: boolean = false;

   

    existenCambiosPendientes(): boolean {
        if (this.ignorarExistenCambiosPendientes) { return false; };
        return !this.formGroup.pristine; //Saber si en formulario a sido editados
      }

      agregarDireccion() {
        let direccionArr = this.formGroup.get('direcciones') as FormArray;
        let direccionFG = this.construirDireccion();
        direccionArr.push(direccionFG);
      }
    
      construirDireccion() {
        return this.fb.group({
          id: '0',
          calle: '',
          provincia: '',
          personaId: this.personaID != null ? this.personaID : 0
        });
      }
    
      removerDireccion(index: number) {
        let direcciones = this.formGroup.get('direcciones') as FormArray;
        let direccionRemover = direcciones.at(index) as FormGroup;
        if (direccionRemover.controls['id'].value != '0') {
          this.direccionesABorrar.push(<number>direccionRemover.controls['id'].value);
        }
        direcciones.removeAt(index);
      }
      
      borrarPersonas() {
        if (this.direccionesABorrar.length === 0) {
          this.onSaveSF();
          return;
        }
    
        this.direccionService.deleteDirecciones(this.direccionesABorrar)
          .subscribe(() => this.onSaveSF(),
            error => console.error(error));
      }
    
    
    ngOnInit() {
        this.formGroup = this.fb.group({
            nombre: '',
            fechaNacimiento: '',
            direcciones: this.fb.array([])
        });
        this.router2.params.subscribe(params => {
            if (params["id"] == undefined) {
                return;
            }
            this.modoEdicion = true;
            this.personaID = params["id"];
            this.personasServices.getPersona(this.personaID.toString()).subscribe(persona => this.cargarFormulario(persona),
                error => console.error(error),
                () => console.log(this.personaID));
        }); 
    }


    save() {
        this.ignorarExistenCambiosPendientes = true;
        let persona: IPersona = Object.assign({}, this.formGroup.value);
        console.table(persona);
        if (this.modoEdicion) {
          // editar el registro
         persona.id = this.personaID;
         this.personasServices.editPersona(persona)
           .subscribe(persona => this.borrarPersonas(),
             error => console.error(error));
       } else {
         // agregar el registro
       
       this.personasServices.createPersona(persona)
         .subscribe(persona => this.onSaveSF(),
           error => console.error(error));
       }
    }
    cargarFormulario(person: IPersona) {
        var dp = new DatePipe("en-IN");
        var format = 'yyyy-MM-dd';
        this.formGroup.patchValue(
            {
                nombre: person.nombre,
                fechaNacimiento: dp.transform(person.fechaNacimiento, format)
            });
            let direcciones = this.formGroup.controls['direcciones'] as FormArray;
            person.direcciones.forEach(direccion => {
              let direccionFG = this.construirDireccion();
              direccionFG.patchValue(direccion);
              direcciones.push(direccionFG);
            });
    }
    onSaveSF() {
        this.router.navigate(["/personas"]);
    }

}
