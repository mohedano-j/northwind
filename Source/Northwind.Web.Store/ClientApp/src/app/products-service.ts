import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin': '*',
      'Authorization': 'authkey',
      'userid': '1'
    })
  };

  constructor(private http : HttpClient) { }

  //serviceRoot: string = "http://localhost/northwind.web/"; 
  serviceRoot: string = "http://localhost:5000/";

  getProducts() {
    return this.http.get(this.serviceRoot + "products", this.httpOptions);
  }

  getProductsBySearch(search: string) {
    return this.http.get(this.serviceRoot + "products/search/" + search, this.httpOptions);
  }

  getProductsByProductId(productId: number) {
    return this.http.get(this.serviceRoot + "products/" + productId, this.httpOptions);
  }

  addProduct() {

    let product = {
      CategoryId: "1",
      ProductName: "Foo"
    }

    console.log("products-service Posting to.." + this.serviceRoot + "products");
    console.log(product);
    this.http.post(this.serviceRoot + "products", product, this.httpOptions).subscribe(
      data => {
        console.log("products.service Post completed successfully");
      },
      err => {
        console.log("products.service Post had errors");
        console.log(err);
      }
    );
    console.log("products-service Done posting");
  }
}
