import { Component, OnInit } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import {NetworkService} from '../../../../../services/network/network.service';
import {MatDialog} from '@angular/material/dialog';
import axios from 'axios';
import {environment} from '../../../../../../environments/environment';
import {BedsPopupComponent} from '../beds-popup/beds-popup.component';
import Swal from 'sweetalert2';
import {BedquipmentFormPopupComponent} from './bedquipment-form-popup/bedquipment-form-popup.component';

@Component({
  selector: 'app-bedequipment-popup',
  templateUrl: './bedequipment-popup.component.html',
  styleUrls: ['./bedequipment-popup.component.scss']
})
export class BedequipmentPopupComponent implements OnInit {
  tableData = [];
  isPopupOpened: boolean;
  dialogRef: any;


  public constructor(
    private _snackBar: MatSnackBar,
    private networkService: NetworkService,
    private dialog?: MatDialog,
  ) {
  }

  ngOnInit(): void {
    axios.get(environment.serverURL + 'Equipment/', {
      headers: {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => {
        console.log(response);
        this.tableData = response.data;
        this.fireSuccesAlert()
      })
      .catch(error => {
        console.log(error.response);
        this.fireErrorAlert();
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
    localStorage.setItem('equipmentId', item.id);
    this.openPopUp('edit', item);
    this.closePopUp()
  }

  /**
   * Deletes element in table with HTMl entry data
   */
  deleteElement(item) {
    axios.delete(environment.serverURL + 'Equipment/' + item.id, {
      headers: {
        'Content-Type': 'application/json; charset=UTF-8'
      }
    })
      .then(response => {
        console.log(response);
        window.location.reload();
        this.fireSuccesAlert()
      })
      .catch(error => {
        console.log(error.response);
        this.fireErrorAlert();
      });
  }
  /**
   * Opens pop-up window
   */
  openPopUp(popUpType: string, sentItem) {
    // Call dialogRef to open window.
    this.isPopupOpened = true;
    this.dialogRef = this.dialog.open(BedquipmentFormPopupComponent, {
      data: {
        type: popUpType,
        item: sentItem
      },
    });
  }
  fireSuccesAlert(){
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: 'Everything went smoothly',
      showConfirmButton: false,
      timer: 1000,
      customClass: {
        popup: 'container-alert'
      }
    })
  }
  fireErrorAlert() {
    // Fire alert
    Swal.fire({
      position: 'center',
      icon: 'error',
      title: 'error',
      showConfirmButton: false,
      timer: 1000,
      customClass: {
        popup: 'container-alert'
      }
    })
  }
}

