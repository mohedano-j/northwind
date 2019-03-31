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
    this.productsService.getProducts().subscribe(
      data => { 
        this.productList = data;
      }
    );
  }

}