import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { SafeService } from '../../services/safe.service';
import { SafeModel } from '../../models/safe.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { AccountTreeEnum } from 'src/app/shared/enums/account-tree.enum';

@Component({
  selector: 'app-safe-form',
  templateUrl: './safe-form.component.html'
})

export class SafeFormComponent {

  safeModel: SafeModel = new SafeModel;
  accountTreeList: any;
  accountTreeType: any;
  constructor(private router: Router, private safeService: SafeService, private avtiveRoute: ActivatedRoute,
    public dialogRef: MatDialogRef<SafeFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
  }

  ngOnInit() {
    if (this.data && this.data.id) {
      this.getSafeById(this.data.id);
    }
    this.prepareAccountTreeList();
  }

  private getSafeById(id) {
    this.safeService.getById(id).subscribe(response => {
      this.safeModel = response;
      this.safeModel.Date = new Date(response.Date);
      this.accountTreeType = AccountTreeEnum[this.safeModel.AccountTreeType];
    }, err => {
    });
  }

  private prepareAccountTreeList() {
    var options = Object.keys(AccountTreeEnum);
    this.accountTreeList = options.slice(options.length / 2);
  }

  public onAccountTreeChange(event: any) {
    let accounName: string = event.target.value;
    this.safeModel.AccountTreeType = AccountTreeEnum[accounName];
  }

  public save(form: NgForm) {
    // this.safeModel = new Date(this.safeModel.Date);
    this.safeService.save(this.safeModel).subscribe(response => {
    }, err => {
    });
  }

  public hide(): void {
    this.dialogRef.close();
  }

  onFarmChange(farm) {
    this.safeModel.AccountId = farm.Id;
  }

  onDriverChange(driver) {
    this.safeModel.AccountId = driver.Id;
  }

  onStationChange(station) {
    this.safeModel.AccountId = station.Id;
  }

  onReaperChange(reaper) {
    this.safeModel.AccountId = reaper.Id;
  }

  onSelectorChange(selector) {
    this.safeModel.AccountId = selector.Id;
  }
}
