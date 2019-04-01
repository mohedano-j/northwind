import { Component, OnInit } from '@angular/core';
import { ProductsService } from "../products-service";

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  private productList: any;

  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getProducts().subscribe( productList => { 
      this.productList = productList;
    });
  }

  getByProductId(productId: number) {
    this.productsService.getProductsByProductId(productId).subscribe( product => {
      this.productList = [];
      this.productList.push(product);
    });
  }

  addProduct() {
    console.log("product-list Adding Product");
    this.productsService.addProduct();

    console.log("product-list Reloading Products");
    this.productsService.getProducts().subscribe(products => {
      this.productList = products;
    });
  }
}
