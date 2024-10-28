import { Component } from '@angular/core';
import { Warehouse } from '../warehouse';
import { WarehouseService } from '../warehouse.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {

  warehouses: Warehouse[] = [];

  constructor(public productSertvice: WarehouseService) { }

  ngOnInit(): void {
    this.productSertvice.getAllWarehouses().subscribe((data: Warehouse[]) => {
      this.warehouses = data;
    });
  }
}
