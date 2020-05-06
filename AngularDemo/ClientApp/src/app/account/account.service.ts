import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IUserInfo } from './user-info';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
    private apiURL = this.baseUrl + 'api/account';
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
    create(userInfo: IUserInfo): Observable<any> {
        return this.http.post<any>(this.apiURL + "/create", userInfo);

    }
  login(userInfo: IUserInfo): Observable<any> {
    localStorage.removeItem("token");
    localStorage.removeItem("tokenExpiration");
        return this.http.post<any>(this.apiURL + "/login", userInfo);
    }

    obtenerToken(): string {
        return localStorage.getItem("token");
    }

    obtenerExpiracionToken(): string {
        return localStorage.getItem("tokenExpiration");
    }

    logout() {
        localStorage.removeItem("token");
        localStorage.removeItem("tokenExpiration");
    }

    estaLogueado(): boolean {

        var exp = this.obtenerExpiracionToken();

        if (!exp) {
            // el token no existe
            return false;
        }

        var now = new Date().getTime();
        var dateExp = new Date(exp);

        if (now >= dateExp.getTime()) {
            // ya expiró el token
            localStorage.removeItem('token');
            localStorage.removeItem('tokenExpiration');
            return false;
        } else {
            return true;
        }

    }
}
