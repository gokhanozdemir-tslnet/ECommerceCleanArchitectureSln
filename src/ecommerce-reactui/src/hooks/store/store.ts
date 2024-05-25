
import { configureStore } from "@reduxjs/toolkit"
import productsReducer, { productsApi } from './products/products.slice';


export const makeStore = () => {
    return configureStore({
        reducer: {
            products: productsReducer,
            [productsApi.reducerPath]: productsApi.reducer,//step 3 add api reducer
        },
        middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(productsApi.middleware) // step 4 add middler ware
    });
}

//Infer the type of makestore
export type AppStore = ReturnType<typeof makeStore>;
//Infer the RootState and AppDispatch
export type RootState = ReturnType<AppStore["getState"]>;
export type AppDispatch = AppStore["dispatch"];

/*****react**********/
/*
"use client";

import { configureStore } from "@reduxjs/toolkit";
import rootReducer from "./root-reducer";



//middlware
const myMiddleware = (store: any) => (next: any) => (action: any) => {
    if (!action.type) {
        return next(action);
    }
    console.log("****************Store Reducer*****************");
    console.log("store:action type=", action.type);
    console.log("store:payload=", action.payload);
    console.log("currentState in store=", store.getState());
    console.log("****************end of Store Reducer*****************");

    next(action);
};




const middleWares = [process.env.NODE_ENV === "development" && myMiddleware].filter(Boolean);

const store = () => configureStore({
    reducer: rootReducer,
    // middleware: (getDefaultMiddleware) =>
    //    getDefaultMiddleware().concat(middleWares),
});

export default store;

// Infer the type of makeStore
export type AppStore = ReturnType<typeof store>
export type RootState = ReturnType<AppStore["getState"]>;
export type AppDispatch = AppStore["dispatch"];
*/