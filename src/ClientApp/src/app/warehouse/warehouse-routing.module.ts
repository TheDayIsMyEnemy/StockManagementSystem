import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { DetailsComponent } from './details/details.component';
import { ImportComponent } from './import/import.component';
import { ExportComponent } from './export/export.component';

const routes: Routes = [
  { path: 'warehouse/list', component: ListComponent },
  { path: 'warehouse/create', component: CreateComponent },
  { path: 'warehouse/:warehouseId/details', component: DetailsComponent },
  { path: 'warehouse/:warehouseId/import', component: ImportComponent },
  { path: 'warehouse/:warehouseId/export', component: ExportComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehouseRoutingModule { }
