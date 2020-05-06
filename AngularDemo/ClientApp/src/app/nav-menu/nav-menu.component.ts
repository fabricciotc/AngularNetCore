import { Component } from '@angular/core';
import { AccountService } from '../account/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {


    constructor(private accountService: AccountService,
        private router: Router) { }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
    }

  private obtenerUniqueName(): string {
    let token = localStorage.getItem("token");
    let jwtData = token.split('.')[1];
    let decodedJwtJsonData = window.atob(jwtData);
    let decodedJwtData = JSON.parse(decodedJwtJsonData);
    return decodedJwtData.fullname;
  }
    logout() {
        this.accountService.logout();
      this.router.navigate(['/']);
    }

    estaLogueado() {
        return this.accountService.estaLogueado();
    }
}
