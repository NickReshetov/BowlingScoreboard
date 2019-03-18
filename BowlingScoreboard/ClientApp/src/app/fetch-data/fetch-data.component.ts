import { Component, Inject, Input} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public gameData: any;

  @Input() gameId: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    
  }
}


