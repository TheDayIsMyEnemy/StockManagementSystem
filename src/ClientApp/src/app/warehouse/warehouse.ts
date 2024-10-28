import { MaterialType } from "../product/product";

export interface Warehouse {
    id: number;
    allowedMaterialType: MaterialType;
    maximumStockLevel: number;
    currentStockLevel: number;
    freeStockSpace: number;
    hasFreeSpace: boolean;
    items: WarehouseItem[];
    itemsLog: WarehouseItemLog[];
}

export enum OperationType {
    Import,
    Export
}

export interface WarehouseItem {
    productId: number;
    quantity: number;
}

export interface WarehouseItemLog {
    productId: number;
    previousQuantity: number;
    currentQuantity: number;
    operationType: OperationType;
    createdAtUtc: Date
}

export interface WarehouseRequest {
    productId: number;
    quantity: number;
}