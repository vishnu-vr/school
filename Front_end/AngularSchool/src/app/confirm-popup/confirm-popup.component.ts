import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-confirm-popup',
  templateUrl: './confirm-popup.component.html',
  styleUrls: ['./confirm-popup.component.css','../app.component.css']
})
export class ConfirmPopupComponent implements OnInit {
  @Input() message:string = "MESSAGE NOT SET";
  @Input() hideConfirmBox: Function;

  constructor() { }

  ngOnInit(): void {
  }

}
