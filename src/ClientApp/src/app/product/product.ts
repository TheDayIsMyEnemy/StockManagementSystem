export interface Product {
    id: number;
    name: string;
    materialType: number;
}

export enum MaterialType {
    Hazardous,
    NonHazardous
}