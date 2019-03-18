import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})

export class CounterComponent {
  public game: any;
  public gameData: any;
  public currentRoundNumber: number;
  public currentPlayer: any;
  public currentRound: any;
  public rollNumber: number = 1;
  public score: number;
  public http: HttpClient;
  public baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public startTheGame() {

    this.createPlayers();    
  }

  public addRollResult() {
    this.rollNumber++;

    let currentRoll = {
      "number": this.rollNumber,
      "score": this.score
    };

    this.currentRound.rolls.push(currentRoll);

    this.score = 0;

    if (this.rollNumber === 3) {

      this.sendRoundData();

    }, error => console.error(error));
    }

  


  createPlayers() {

    let players = [
      {
        "Name": "Player 1",
        "PlayOrder": "1",
      },
      {
        "Name": "Player 2",
        "PlayOrder": "2",
      }
    ];

    this.http.post(this.baseUrl + "api/line/1/game", players).subscribe(result => {

      this.game = result;

      this.getGameData();

      this.getCurrentRoundNumber();

    }, error => console.error(error));
  };

  getCurrentRoundNumber() {
    this.http.get<number>(this.baseUrl + "api/game/" + this.game.id + "/round/number").subscribe(result => {

      this.currentRoundNumber = result;

      this.getCurrentPlayer();

    }, error => console.error(error));
  }

  getCurrentPlayer() {
    this.http.get<any>(this.baseUrl + "api/game/" + this.game.id + "/round/" + this.currentRoundNumber + "/player").subscribe(result => {
      this.currentPlayer = result;

      this.currentRound = {
        "number": this.currentRoundNumber,
        "gameId": this.game.id,
        "playerId": this.currentPlayer.id,
        "rolls": []
      }
    }, error => console.error(error));
  }

  getGameData() {
    if (this.game != null) {
      this.http.get<any>(this.baseUrl + 'api/line/1/game/' + this.game.id).subscribe(result => {
        this.gameData = result;
      },error => console.error(error));
    }
  }

  sendRoundData() {
    this.http.post(this.baseUrl + "api/game/" + this.game.id + "/player/" + this.currentPlayer.id + "/round",
        this.currentRound)
      .subscribe(result => {
        let round = result;

        this.rollNumber = 1;

        this.getGameData();

        this.getCurrentRoundNumber();
      }, error => console.error(error));
  }

}
