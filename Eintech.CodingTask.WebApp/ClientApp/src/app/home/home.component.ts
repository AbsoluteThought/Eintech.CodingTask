import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public people: Person[];
  public name = new FormControl('');

  public personForm = new FormGroup({
    name: new FormControl(''),
  });

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Person[]>(baseUrl + 'api/person').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }

  onSubmit() {
    this.http.post<Person>(this.baseUrl + 'api/person', this.personForm.value, this.httpOptions).subscribe(_ => {
      var person: Person = { name: this.personForm.get('name').value, createdDate: new Date };
      this.people.push(person);
    }, error => console.error(error));
  }

  public addPerson() {

  }
}

interface Person {
  name: string;
  createdDate: Date;
}
