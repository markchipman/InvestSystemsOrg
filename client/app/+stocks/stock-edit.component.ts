import { Component, OnInit } from '@angular/core';
import { Title }     from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';

import { MD_BUTTON_DIRECTIVES } from '@angular2-material/button';
import { MD_INPUT_DIRECTIVES } from '@angular2-material/input';

import { FirebaseObjectObservable } from 'angularfire2';

import { StockExchange } from './stock-exchange';
import { StockService } from './stock.service';

@Component({
    moduleId: module.id,
    selector: 'stock-edit',
    templateUrl: 'stock-edit.component.html',
    styleUrls: ['stock-edit.component.css'],
    directives: [MD_BUTTON_DIRECTIVES,MD_INPUT_DIRECTIVES]
})
export class StockEditComponent implements OnInit {
    stock: StockExchange;
    private routeParams: any;

    constructor(private companiesService: StockService, private route: ActivatedRoute, private titleService: Title) { }

    ngOnInit() {
        this.routeParams = this.route.params.subscribe(params => {
            let id = params['id'];
            if (id) {
                this.companiesService.getCompany(id).subscribe((stock: StockExchange) => {
                    this.stock = stock;
                    this.titleService.setTitle(`${stock.name} | Edit`)
                })
            }
        });
    }
}