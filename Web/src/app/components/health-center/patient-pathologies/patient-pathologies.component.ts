import {Component, Inject, OnInit} from '@angular/core';
import {NetworkService} from "../../../services/network/network.service";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";
import axios from "axios";
import {environment} from "../../../../environments/environment";
import {MedicationsPopupComponent} from "../medications/medications-popup/medications-popup.component";
import {PatientPathologiesPopupComponent} from "./patient-pathologies-popup/patient-pathologies-popup.component";

@Component({
  selector: 'app-patient-pathologies',
  templateUrl: './patient-pathologies.component.html',
  styleUrls: ['./patient-pathologies.component.scss']
})
export class PatientPathologiesComponent implements OnInit {

  tableData = [{}];
  isPopupOpened: boolean;
  dialogRef: any;
  patientID: any;
  patientName: any;

  constructor(
    private networkService: NetworkService,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialog?: MatDialog
  ) {
  }

  ngOnInit(): void {
    // Assign patient ID of contacts to incoming data ID
    this.patientID = this.data.id;
    localStorage.setItem('patientSsn', this.patientID);
    this.patientName = this.data.fname + ' ' + this.data.lname;
    axios.get(environment.serverURL + 'PatientPathologies/' + this.patientID, {
      headers: {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => {
        console.log(response);
        this.tableData = response.data;
      })
      .catch(error => {
        console.log(error.response);
      });
  }

  /**
   * Adds element in table with HTML entry values
   */
  addElement() {
    this.openPopUp('add', null);
    this.closePopUp()
  }

  /**
   * Closes pop-up window
   */
  closePopUp() {
    // Call dialogRef when window is closed.
    this.dialogRef.afterClosed().subscribe(result => {
      this.isPopupOpened = false;
    });
  }

  /**
   * Edits element in table with HTML entry values
   */
  editElement(item) {
    localStorage.setItem('pathologyName', item.name);
    this.openPopUp('edit', item);
    this.closePopUp()
  }

  /**
   * Deletes element in table with HTMl entry data
   */
  deleteElement(item) {
    axios.delete(environment.serverURL + 'PatientPathologies/' + this.patientID + '/' + item.name, {
      headers: {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => {
        console.log(response);
        window.location.reload();
      })
      .catch(error => {
        console.log(error.response);
      });
  }

  /**
   * Opens pop-up window
   */
  openPopUp(popUpType: string, sentItem) {
    // Call dialogRef to open window.
    this.isPopupOpened = true;
    this.dialogRef = this.dialog.open(PatientPathologiesPopupComponent, {
      data: {
        type: popUpType,
        item: sentItem
      },
    });
  }

}
