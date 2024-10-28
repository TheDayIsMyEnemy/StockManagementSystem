import { Component, OnInit } from '@angular/core';
import { Warehouse } from '../warehouse';
import { WarehouseService } from '../warehouse.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/product/product';
import { ProductService } from 'src/app/product/product.service';
import { Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.css']
})

export class ImportComponent implements OnInit {
  warehouseId!: number;
  warehouse!: Warehouse;
  products!: Product[];
  importProductForm: any;

  constructor(
    public warehouseService: WarehouseService,
    public productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.importProductForm = this.formBuilder.group({
      productId: ['', Validators.required],
      quantity: [1, [Validators.min(1)]],
    });
  }

  ngOnInit(): void {
    this.warehouseId = this.route.snapshot.params['warehouseId'];

    this.warehouseService.getWarehouseInfo(this.warehouseId).subscribe((data: Warehouse) => {
      this.warehouse = data;

      this.productService.getAllProducts().subscribe((data: Product[]) => {
        this.products = data.filter(p => p.materialType == this.warehouse.allowedMaterialType);
      })
    });
  }

  onSubmit(formData: { value: any; }) {
    this.warehouseService.importProduct(this.warehouseId, formData.value).subscribe(res => {
      this.router.navigateByUrl('warehouse/' + this.warehouseId + '/details');
    });
  }
}