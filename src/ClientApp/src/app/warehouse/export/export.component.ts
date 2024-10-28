import { Component, OnInit } from '@angular/core';
import { Warehouse, WarehouseItem } from '../warehouse';
import { WarehouseService } from '../warehouse.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-import',
  templateUrl: './export.component.html',
  styleUrls: ['./export.component.css']
})

export class ExportComponent implements OnInit {
  warehouseId!: number;
  warehouse!: Warehouse;
  exportProductForm: any;

  constructor(
    public warehouseService: WarehouseService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.exportProductForm = this.formBuilder.group({
      productId: ['', Validators.required],
      quantity: [1, [Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    this.warehouseId = this.route.snapshot.params['warehouseId'];

    this.warehouseService.getWarehouseInfo(this.warehouseId).subscribe((data: Warehouse) => {
      this.warehouse = data;
    });
  }

  onSubmit(formData: { value: any; }) {
    this.warehouseService.exportProduct(this.warehouseId, formData.value).subscribe(res => {
      this.router.navigateByUrl('warehouse/' + this.warehouseId + '/details');
    });
  }
}