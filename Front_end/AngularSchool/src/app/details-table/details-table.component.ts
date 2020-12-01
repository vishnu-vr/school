import { Component, OnInit } from '@angular/core';
import { StaffService } from '../staff.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
// import { Location } from '@angular/common';


@Component({
  selector: 'app-details-table',
  templateUrl: './details-table.component.html',
  styleUrls: ['./details-table.component.css','../app.component.css']
})
export class DetailsTableComponent implements OnInit {

  extra: string;
  staffData:object[];
  StaffType: string;
  checkedStaffList:object[] = [];
  allChecked:boolean = false;

  // form modal properties
  addOrUpdateStaff:object;
  // showModalPopup: boolean = false;

  // confirmation box properties
  message:string = "message not set from details table component";
  showConfirmBox:boolean = false;

  // toast notification properties
  toastMessage: string = "";
  showToastMessage: boolean = false;
  success:boolean;

  constructor(
    private staffService: StaffService,
    private router: Router,
    private route: ActivatedRoute,
    // private location: Location
  ) { }

  ngOnInit(): void {
    this.selectStaff(this.route.snapshot.paramMap.get('staffType'));
   }

  getStaffData(staffType:string):void{
    if (staffType == "teacher") {
      this.extra = "Subject";
    }
    else if (staffType == "support") {
      this.extra = "Department";
    }
    else if (staffType == "administrator") {
      this.extra = "Role"
    }

    this.staffService.getStaff(staffType).subscribe(
    data => {
      this.staffData = data;
    },
    error => this.showToast(false));
  }

  showToast = (success:boolean): void => {
    this.showToastMessage = true;

    if (success) {
      this.toastMessage = "Success";
      this.success = true
    }
    else {
      this.toastMessage = "Failed";
      this.success = false;
    }

    setInterval(() => this.showToastMessage = false , 5000);
  }

  selectStaff(staffType:string): void{
    if (staffType == "None") return
    this.StaffType = staffType
    this.getStaffData(staffType)
  }

  staffChecked(staff:object, checked:boolean): void{
    // if the event is unchecking the box
    // then remove the staff from the list
    if (!checked){
      this.checkedStaffList = this.checkedStaffList.filter(obj => obj !== staff);
    }
    // else push the staff to the list
    else{
      this.checkedStaffList.push(staff)
    }
    console.log(this.checkedStaffList)
  }

  checkAll(checked:boolean): void{
    if(checked) {
      console.log("everything checked")
      this.allChecked = true
      // adding objects that already doesn't exist
      this.staffData.forEach(staff => {
        if (!this.checkedStaffList.includes(staff)){
          this.checkedStaffList.push(staff);
        }
      });
      console.log(this.checkedStaffList)
    }
    else {
      console.log("everything unchecked")
      this.allChecked = false
      this.checkedStaffList = []
      console.log(this.checkedStaffList)
    }
  }

  delete(): void{
    // console.log()
    // alert("delete function invoked")
    this.showConfirmBox = true;
  }

  hideConfirmBox = (confirmed:boolean):void => {
    this.showConfirmBox = false;
    if (confirmed) {
      while(this.checkedStaffList.length > 0){
        const staff:object = this.checkedStaffList.pop();
        console.log(this.checkedStaffList)
        this.staffService.deleteStaff(staff).subscribe(data => {
          console.log(data);
          this.getStaffData(this.StaffType);
        },
        error => this.showToast(false));
      }
    }
    // else alert("don't do it")
  }

  addStaff(): void{
    this.addOrUpdateStaff = {
      "empCode":"",
      "name":"",
      "email":""
    }
    this.addOrUpdateStaff[this.extra.toLowerCase()] = ""
    // this.showModalPopup = true
    this.routeTo('/form_popup');
  }

  update(staff:object):void{
    this.addOrUpdateStaff = staff
    // this.showModalPopup = true
    this.routeTo('/form_popup');
  }

  routeTo(page:string):void{
    this.router.navigate(
      [page,JSON.stringify(this.addOrUpdateStaff),this.extra.toLowerCase(),this.StaffType]
    );
  }

  // hideModalPopup = (refresh:boolean = false): void => {
  //   // hiding the modal
  //   this.showModalPopup = false
  //   // refreshing data
  //   if (refresh) this.getStaffData(this.StaffType);
  // }
}
