import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Warehouse, WarehouseRequest } from './warehouse';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WarehouseService {
  baseUrl = 'http://localhost:5291/api/warehouses';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) {

  }

  getAllWarehouses(): Observable<Warehouse[]> {
    return this.httpClient.get<Warehouse[]>(this.baseUrl);
  }

  getWarehouseInfo(id: number): Observable<Warehouse> {
    return this.httpClient.get<Warehouse>(this.baseUrl + '/' + id);
  }

  createNewWarehouse(product: Warehouse): Observable<Warehouse> {
    return this.httpClient.post<Warehouse>(
      this.baseUrl,
      JSON.stringify(product),
      this.httpOptions);
  }

  importProduct(id: number, warehouseImportRequest: WarehouseRequest) {
    return this.httpClient.post<WarehouseRequest>(
      this.baseUrl + '/' + id + '/import',
      JSON.stringify(warehouseImportRequest),
      this.httpOptions
    )
  }

  exportProduct(id: number, warehouseImportRequest: WarehouseRequest) {
    return this.httpClient.post<WarehouseRequest>(
      this.baseUrl + '/' + id + '/export',
      JSON.stringify(warehouseImportRequest),
      this.httpOptions
    )
  }
}