import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product';
import { FormBuilder, Validators } from '@angular/forms';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent {
  createForm;

  constructor(
    public productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.createForm = this.formBuilder.group({
      name: ['', Validators.required],
      materialType: [Number, Validators.required],
    });
  }

  ngOnInit(): void {

  }

  onSubmit(formData: any) {
    this.productService.createNewProduct(formData.value).subscribe(res => {
      this.router.navigateByUrl('product/list');
    });
  }
}
