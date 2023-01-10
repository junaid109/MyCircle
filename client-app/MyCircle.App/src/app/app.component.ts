import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  url = "https://localhost:7185/api"
  title = 'app';
  users: any;

  constructor(private http: HttpClient) {
    this.http.get(this.url + '/users').subscribe({
      next: data => this.users = data,
      error: error => console.error('There was an error!', error),
      complete: () => console.log('Done')
    });

  }

  ngOnInit(): void {
    this.http.get(this.url + '/users').subscribe(data => {
      console.log(data);
    }
    );

  }

}
