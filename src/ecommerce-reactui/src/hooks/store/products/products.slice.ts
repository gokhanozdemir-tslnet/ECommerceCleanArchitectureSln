
import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ProductType } from "@/types/card.type";


// const initialState: Array<ProductType> = [];

export interface ProductsType {
    items: Array<ProductType>
}

const initialState2: Array<ProductType> = [];

const initialState: ProductsType = {
    items: initialState2
}

export const productsSlice = createSlice({
    name: "products",
    initialState: initialState,
    reducers: {
        fetchProducts: (state, action: PayloadAction<Array<ProductType>>) => {
            console.log("****old state*****");
            console.log(state)
            console.log("****old state*****");
            state.items = action.payload;
            console.log("****new state*****");
            console.log(state)
            console.log("****new state*****");

        },
    }
});

export const { fetchProducts } = productsSlice.actions;
export default productsSlice.reducer;