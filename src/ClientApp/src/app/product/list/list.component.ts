import { Component } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {

  products: Product[] = [];

  constructor(public productSertvice: ProductService) { }

  ngOnInit(): void {
    this.productSertvice.getAllProducts().subscribe((data: Product[]) => {
      this.products = data;
    });
  }

  // createNewProduct() {
  //   this.productSertvice.createNew(id).subscribe(res => {
  //     this.players = this.players.filter(item => item.id !== id);
  //   });
  // }
}
