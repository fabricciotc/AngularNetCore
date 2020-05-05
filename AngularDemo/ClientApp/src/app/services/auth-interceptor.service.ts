import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpSentEvent, HttpHeaderResponse, HttpProgressEvent, HttpResponse, HttpUserEvent } from '@angular/common/http';
import { AccountService } from '../account/account.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {
    constructor(private accountService: AccountService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpSentEvent | HttpHeaderResponse
        | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
        var token = this.accountService.obtenerToken();
        req = req.clone({
            setHeaders: { Authorization: "Bearer " + token }
        });
        return next.handle(req);
    }
}
