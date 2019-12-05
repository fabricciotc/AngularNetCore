import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPersona } from './persona';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

    private apiUREL= this.baseUrl + "api/personas";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}


    getPersonas(): Observable<IPersona[]> {
            return this.http.get<IPersona[]>(this.apiUREL);
    }
    getPersona(personId: string): Observable<IPersona> {
        let params = new HttpParams().set('incluiDirecciones', "true");
        return this.http.get<IPersona>(this.apiUREL + '/' + personId, { params: params });
    }
    createPersona(persona: IPersona): Observable<IPersona> {
        return this.http.post<IPersona>(this.apiUREL, persona);
    }
    editPersona(persona: IPersona): Observable<IPersona> {
        var h = persona.id.toString();
        return this.http.put<IPersona>(this.apiUREL + '/' + h, persona );
    }
    deletePersona(personID: string): Observable<IPersona> {
        return this.http.delete<IPersona>(this.apiUREL + "/" + personID);
    }
    
}
