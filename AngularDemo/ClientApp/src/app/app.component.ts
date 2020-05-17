import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
import { AccountService } from './account/account.service';
import { faHeadset, faEnvelope, faAward, faBookOpen, faSchool, faBars, faDoorClosed } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnDestroy{
  mobileQuery: MediaQueryList;

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private accountService: AccountService ,private router: Router) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }
    faHeadset = faHeadset;
  faEnvelope = faEnvelope;
  faAward = faAward;
  faBookOpen = faBookOpen;
  faSchool = faSchool;
  faDoorClosed = faDoorClosed;
  isExpanded = false;
  faBars = faBars;
  imageURL: string = "https://cdn.clipart.email/75bb59ce70a79e68801ccd3eea203e5e_view-user-icon-png-user-circle-icon-png-transparent-png-_820-860.jpeg"; //DEFAULT PICTURE
  ngOnInit() {
    this.obtenerPhoto();
  }
  private obtenerUniqueName(): string {
    let token = localStorage.getItem("token");
    let jwtData = token.split('.')[1];
    let decodedJwtJsonData = window.atob(jwtData);
    let decodedJwtData = JSON.parse(decodedJwtJsonData);
    return decodedJwtData.fullname;
  }
  private obtenerPhoto() {
    this.accountService.obtenerPhoto().subscribe(photo => {
      if (photo != null) {
        this.imageURL = 'data:image/png;base64,' + photo
      }
    },
      error => console.log(error));
  }

  logout() {
    this.accountService.logout();
    this.router.navigate(['/login']);
  }
  estaLogueado() {
    return this.accountService.estaLogueado();
  }
  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

}
