import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import axios from 'axios';
import {environment} from '../../../../../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-equipment-popup',
  templateUrl: './equipment-popup.component.html',
  styleUrls: ['./equipment-popup.component.scss']
})

export class EquipmentPopupComponent implements OnInit {
  public _elementForm: FormGroup;
  type: string;
  item: any;
  equipment: any;
  equipments = ['Surgical Lights', 'Ultrasound', 'Sterilizers', 'Defibrillators', 'Monitors', 'Art. Breathers', 'Cardiograph'];
  nameSelection = false;

  constructor(private _formBuilder: FormBuilder,
              private dialogRef: MatDialogRef<EquipmentPopupComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    // Assign form type 'add' or 'edit'
    this.type = this.data.type;
    this.item = this.data.item;
    // (document.getElementById('e1') as HTMLInputElement).disabled = true;

    // Initialize Material form
    if (this.item != null) {
      // Item exists, edit mode.
      this._elementForm = this._formBuilder.group({
        ID: [this.item.id],
        eNewName: [this.item.Name, [Validators.required]],
        ePredName: [this.item.Name, [Validators.required]],
        eProvider: [this.item.Provider, [Validators.required]],
        eAmount: [this.item.Quantity, [Validators.required]],
      });
    } else {
      // Item does not exist, add mode.
      this._elementForm = this._formBuilder.group({
        ID: [''],
        eNewName: ['', [Validators.required]],
        ePredName: ['', [Validators.required]],
        eProvider: ['', [Validators.required]],
        eAmount: ['', [Validators.required]],
      });
    }
  }

  /**
   * Closes the dialog on contact upgrade
   */
  closeDialogRefresh() {
    this.dialogRef.close({event: 'refresh'});
  }

  /**
   * Handles entry disabling in HTML
   */
  entryDisable() {
    const entry = this._elementForm.get('eNewName')
    if (this.nameSelection) {
      entry.disable();
    } else {
      entry.enable();
    }
  }

  /**
   * Refreshes pop-up window data
   */
  emptyEntryData() {
    // Empty entries
    (document.getElementById('e1') as HTMLInputElement).value = '';
    (document.getElementById('e2') as HTMLInputElement).value = '';
    (document.getElementById('e3') as HTMLInputElement).value = '';
    this.fireSuccessAlert()
  }

  /**
   * Fire sweet alert to indicate error
   */
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

  /**
   * Fire sweet alert to indicate success
   */
  fireSuccessAlert(){
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: 'Operation done.You are awesome',
      showConfirmButton: false,
      timer: 1000,
      customClass: {
        popup: 'container-alert'
      }
    })
  }

  /**
   * Manages equipment selector in HTML
   */
  selectedEquipment(event){
    this.equipment = event.value;
  }

  /**
   * Manages name selector in HTML
   */
  selectedName(){
    (document.getElementById('e1') as HTMLInputElement).disabled = this.nameSelection;
    this.nameSelection = !this.nameSelection;
  }

  /**
   * Updates changes in server depending on popup type
   */
  submit() {
    let eName;
    const eProvider = (document.getElementById('e2') as HTMLInputElement).value;
    const eQuantity = (document.getElementById('e3') as HTMLInputElement).value;

    if (!this.nameSelection){
      eName = (document.getElementById('e1') as HTMLInputElement).value;
    }
    else {
      eName = this.equipment;
    }

    if (eName !== '' && eProvider !== ''&& eQuantity !== ''){
      if (this.type === 'add') {
        axios.post(environment.secondWaveURL + 'Equipment', {
          Name: eName,
          Provider: eProvider,
          Quantity: eQuantity
        }, {
          headers: {
            'Content-Type': 'application/json; charset=UTF-8'
          }
        })
          .then(response => {
            console.log(response);
            this.closeDialogRefresh();
            this.fireSuccessAlert()
          })
          .catch(error => {
            console.log(error.response);
            this.fireErrorAlert()
          });
      } else {
        // Send selected item number to update in database
        axios.put(environment.secondWaveURL + 'Equipment/' + localStorage.getItem('equipmentId'), {
          Id: localStorage.getItem('equipmentId'),
          Name: eName,
          Provider: eProvider,
          Quantity: eQuantity
        }, {
          headers: {
            'Content-Type': 'application/json; charset=UTF-8'
          }
        })
          .then(response => {
            console.log(response);
            this.closeDialogRefresh();
            this.fireSuccessAlert()
          })
          .catch(error => {
            console.log(error.response);
            this.fireErrorAlert()
          });
      }
    }
  }

}
