import { Component, HostListener, Input, OnInit } from '@angular/core';
import { StaffService } from '../staff.service';

@Component({
  selector: 'app-form-popup',
  templateUrl: './form-popup.component.html',
  styleUrls: ['./form-popup.component.css','../app.component.css']
})
export class FormPopupComponent implements OnInit {
  @Input() staff: object;
  @Input() inpExtraField: string;
  @Input() hideModalPopup:Function;
  @Input() showToast:Function;

  extraField:string;
  lockEmpCodeInput:boolean = false;
  newStaff:object = {};
  // showPopup: boolean = true;

  constructor(private staffService: StaffService) { }

  ngOnInit(): void {
    console.log("pop up called")

    // lock the empcode input
    // if its an update request
    if (this.staff['empCode'] != ""){
      this.lockEmpCodeInput = true;
    }

    // for the key in object
    this.extraField = this.inpExtraField
    // copying contents
    this.insertIntoNewStaff()
    // for displaying label
    this.inpExtraField = this.inpExtraField[0].toUpperCase() + this.inpExtraField.slice(1,)
  }

  add(): void{
    this.newStaff['type'] = this.GetType()
    console.log(this.newStaff)
    this.staffService.addStaff(this.newStaff).subscribe(data => {
      console.log(data);
      // setting the parameter true to re-fetch new data
      this.hideModalPopup(true);
      this.showToast(true);
    },
    error => this.showToast(false));
  }

  GetType():number{
		if (this.extraField == "subject") return 1
		else if (this.extraField == "department") return 2
		else if (this.extraField == "role") return 3
	}

  update(): void{
    console.log(this.newStaff)
    this.staffService.updateStaff(this.newStaff).subscribe(data => {
      console.log(data);
      this.hideModalPopup(true);
      this.showToast(true);
    },
    error => this.showToast(false));
  }

  insertIntoNewStaff(){
    this.newStaff['empcode'] = this.staff['empCode']
    this.newStaff['name'] = this.staff['name']
    this.newStaff['email'] = this.staff['email']
    this.newStaff[this.extraField] = this.staff[this.extraField]
  }

  // if user clicks anywhere outside the modal
  // hide the popup
  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    if (event.target['classList'].value == 'modal') {
      this.hideModalPopup();
    }
  }

}
