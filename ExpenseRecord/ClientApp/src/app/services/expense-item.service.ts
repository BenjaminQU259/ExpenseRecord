import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ExpenseItem } from '../models/ExpenseItem';

@Injectable({
  providedIn: 'root',
})
export class ExpenseItemService {
  private url: string = 'http://localhost:5078/api/items/';
  private items: ExpenseItem[] = [];

  constructor(private http: HttpClient) {}

  getAll(): ExpenseItem[] {
    const items = this.read();
    return items;
  }

  getOne(id: number): Observable<ExpenseItem> {
    return this.http.get<ExpenseItem>(`${this.url}${id}`);
  }

  createOne(body: ExpenseItem): Observable<ExpenseItem> {
    const items = this.read();
    const item: ExpenseItem = {
      ...body,
      date: new Date(),
    };
    items.push(item);
    return this.http.post<ExpenseItem>(this.url, item);
  }

  deleteOne(id: number): Observable<ExpenseItem> {
    const items = this.read();
    const index: number = items.findIndex((t) => t.id === id);
    items.splice(index, 1);
    console.log(`Deleted item: ${this.url}${id}`);
    return this.http.delete<ExpenseItem>(`${this.url}${id}`);
  }

  private read(): ExpenseItem[] {
    this.http.get<ExpenseItem[]>(this.url).subscribe((t) => {
      this.items = t;
    });
    return this.items;
  }

  public readObservable(): Observable<ExpenseItem[]> {
    return this.http.get<ExpenseItem[]>(this.url);
  }
}
