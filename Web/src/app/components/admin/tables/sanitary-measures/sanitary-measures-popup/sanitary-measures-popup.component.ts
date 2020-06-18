import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';

@Component({
  selector: 'app-sanitary-measures-popup',
  templateUrl: './sanitary-measures-popup.component.html',
  styleUrls: ['./sanitary-measures-popup.component.scss']
})
export class SanitaryMeasuresPopupComponent implements OnInit {

  public _contactForm: FormGroup;


  constructor(private _formBuilder: FormBuilder,
              private dialogRef: MatDialogRef<SanitaryMeasuresPopupComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    this._contactForm = this._formBuilder.group({
      ID: [this.data.ID],
      Brand: [ this.data.Brand, [Validators.required]],
      Name: [ this.data.Name, [Validators.required]],
      Category: [ this.data.Category, [Validators.required]],
      Description: [ this.data.Description , [Validators.required]],

    });
  }
}
