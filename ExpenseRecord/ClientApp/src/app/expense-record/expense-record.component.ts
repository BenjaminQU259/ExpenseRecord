import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ExpenseItem } from '../models/ExpenseItem';
import { ExpenseItemService } from '../services/expense-item.service';

@Component({
  selector: 'app-expense-record',
  templateUrl: './expense-record.component.html',
  styleUrls: ['./expense-record.component.css'],
})
export class ExpenseRecordComponent implements OnInit {
  public title: string = 'Expense Record';
  public recordedItems: ExpenseItem[] = [];
  private displayedItems: ExpenseItem[] = [];

  constructor(
    private expenseItemService: ExpenseItemService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    this.expenseItemService.readObservable().subscribe((t) => {
      this.recordedItems = t;
      this.displayedItems = [...this.recordedItems];
      console.log(this.recordedItems);
      console.log(this.recordedItems[0].description);
    });
  }

  add(): void {
    var item = {
      id: 1,
      description: 'description',
      type: 'type',
      amount: 1,
      date: new Date(),
    };
    this.expenseItemService.createOne(item).subscribe();
    this.loadData();
  }
}
