import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Warehouse } from '../warehouse';
import { FormBuilder, Validators } from '@angular/forms';
import { WarehouseService } from '../warehouse.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  createForm;

  constructor(
    public warehouseService: WarehouseService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      maximumStockLevel: ['', Validators.required],
      allowedMaterialType: ['', Validators.required],
    });
  }

  ngOnInit(): void {

  }

  onSubmit(formData: any) {
    this.warehouseService.createNewWarehouse(formData.value).subscribe(res => {
      this.router.navigateByUrl('warehouse/list');
    });
  }
}
