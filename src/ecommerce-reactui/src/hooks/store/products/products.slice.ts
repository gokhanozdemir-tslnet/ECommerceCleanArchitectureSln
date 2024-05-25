
import { PayloadAction, createSlice } from "@reduxjs/toolkit";
import { ProductType } from "@/types/card.type";

//rtk query 
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";


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


//step 1 create api slice 
export const productsApi = createApi({
    baseQuery: fetchBaseQuery({ baseUrl: "https://fakestoreapi.com/" }),
    endpoints: (builder) => ({
        getProducts: builder.query<Array<ProductType>, string>({
            query: (id) => `products/${id}`
        }),
    }),
})

export const { fetchProducts } = productsSlice.actions;
export default productsSlice.reducer;


//step 2 export getProducts query
export const { useGetProductsQuery } = productsApi;