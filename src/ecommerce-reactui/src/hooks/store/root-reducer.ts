"use client";
import { combineReducers } from "@reduxjs/toolkit";
import { categoriesReducer } from "./categories/categories.reducer";


const rootReducer = combineReducers(
    {
        categories: categoriesReducer,
    }
);

export default rootReducer;