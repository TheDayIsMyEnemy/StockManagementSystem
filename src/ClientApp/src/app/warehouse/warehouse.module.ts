import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehouseRoutingModule } from './warehouse-routing.module';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DetailsComponent } from './details/details.component';
import { ImportComponent } from './import/import.component';
import { ExportComponent } from './export/export.component';

@NgModule({
  declarations: [
    ListComponent,
    CreateComponent,
    DetailsComponent,
    ImportComponent,
    ExportComponent
  ],
  imports: [
    CommonModule,
    WarehouseRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class WarehouseModule { }
