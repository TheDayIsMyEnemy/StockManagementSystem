import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})

export class ProductsComponent {
  public products: Product[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Product {
  id: number;
  name: string;
  materialType: number;
}
