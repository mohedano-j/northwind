import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http : HttpClient) { }

  getProducts() {
    return this.http.get("http://localhost/northwind.web/products");
  }

  getProductsBySearch(search: string) {
    return this.http.get("http://localhost/northwind.web/products/search/" + search);
  }

  getProductsByProductId(productId: number) {
    return this.http.get("http://localhost/northwind.web/products/" + productId);
  }
}
