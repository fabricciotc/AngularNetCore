import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatSidenavModule, MatSidenav } from '@angular/material/sidenav';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { CounterComponent } from './counter/counter.component';
import { PersonasComponent } from './personas/personas.component';
import { PersonasService } from './personas/personas.service';
import { PersonasFormComponent } from './personas/personas-form/personas-form.component';
import { registerLocaleData } from '@angular/common';
import locale from '@angular/common/locales/es-US';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { LogInterceptorService } from './services/log-interceptor.service';
import { DireccionesService } from './direcciones/direccion.service';
import { LeaveFormService } from './personas/personas-form/leave-form.service';
import { RegisterComponent } from './account/register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatIconModule } from '@angular/material/icon';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AccountService } from './account/account.service';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { LoginComponent } from './account/login/login.component';
import { ProfileComponent } from './account/profile/profile.component';

registerLocaleData(locale);

@NgModule({

  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    PersonasComponent,
    PersonasFormComponent,
    RegisterComponent,
    LoginComponent,
    ProfileComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatToolbarModule,
    FontAwesomeModule,
      ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardService]  },
      { path: 'counter', component: CounterComponent, canActivate: [AuthGuardService]  },
      { path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService] },
        { path: 'personas', component: PersonasComponent, canActivate: [AuthGuardService] },
      { path: 'personas/agregar', component: PersonasFormComponent, canDeactivate: [LeaveFormService], canActivate: [AuthGuardService] },
      { path: 'personas/editar/:id', component: PersonasFormComponent, canDeactivate: [LeaveFormService], canActivate: [AuthGuardService] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ])
    ],
  providers: [
        {
          provide: LOCALE_ID, useValue: "en-US"
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: LogInterceptorService,
            multi:true
        },
        PersonasService,
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
