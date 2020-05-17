import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  ngOnInit() {
    this.obtenerPhoto();
  }
  imageURL: string = "https://cdn.clipart.email/75bb59ce70a79e68801ccd3eea203e5e_view-user-icon-png-user-circle-icon-png-transparent-png-_820-860.jpeg";
  private obtenerPhoto() {
    this.accountService.obtenerPhoto().subscribe(photo => {
      if (photo != null) {
        this.imageURL = 'data:image/png;base64,' + photo;
      }
    },
      error => console.log(error));
  }

  onUploadChange(evt: any) {
    const file = evt.target.files[0];

    if (file) {
      const reader = new FileReader();

      reader.onload = this.handleReaderLoaded.bind(this);
      reader.readAsBinaryString(file);
    }
  }

  handleReaderLoaded(e) {
    this.imageURL =('data:image/png;base64,' + btoa(e.target.result));
  }
}
