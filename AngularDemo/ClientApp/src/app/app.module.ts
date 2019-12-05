import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { PersonasComponent } from './personas/personas.component';
import { PersonasService } from './personas/personas.service';
import { PersonasFormComponent } from './personas/personas-form/personas-form.component';
import { registerLocaleData } from '@angular/common';
import locale from '@angular/common/locales/es-US';
import { LogInterceptorService } from './services/log-interceptor.service';
import { DireccionesService } from './direcciones/direccion.service';
import { LeaveFormService } from './personas/personas-form/leave-form.service';
import { RegisterComponent } from './account/register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { AccountService } from './account/account.service';
import { AuthInterceptorService } from './services/auth-interceptor.service';

registerLocaleData(locale);

@NgModule({

  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonasComponent,
    PersonasFormComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
        { path: 'fetch-data', component: FetchDataComponent },
        { path: 'personas', component: PersonasComponent, canActivate: [AuthGuardService] },
        { path: 'personas/agregar', component: PersonasFormComponent, canDeactivate: [LeaveFormService] },
        { path: 'personas/editar/:id', component: PersonasFormComponent, canDeactivate: [LeaveFormService] },
        { path: 'register-login', component: RegisterComponent },
    ])
    ],
    providers: [PersonasService, { provide: LOCALE_ID, useValue: "en-US" },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: LogInterceptorService,
            multi:true
        },
        DireccionesService,
        LeaveFormService,
        AuthGuardService,
        AccountService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptorService,
            multi: true
        }
    ],
  bootstrap: [AppComponent]
})
export class AppModule {

}
