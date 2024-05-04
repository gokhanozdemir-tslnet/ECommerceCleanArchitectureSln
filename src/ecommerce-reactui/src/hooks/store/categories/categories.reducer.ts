"use client";
import { } from "react"
type State<T> = {
    payload: T,
    isLoading: boolean,
    error: string
}

type Category = {
    title: string
}


const InitialState: State<Array<Category>> = {
    isLoading: false,
    error: "",
    payload: [{ "title": "sdfsdf" }]
}


/*****0. CREATE REDUCER ACTION UTILS  utils/recuer.utils.ts******/
export type ActionWithPayload<T, P> = {
    type: T;
    payload: P;
};

export type Action<T> = {
    type: T;
};

export function createAction<T extends string, P>(type: T, payload: P): ActionWithPayload<T, P>;
export function createAction<T extends string>(type: T, payload: void): Action<T>;
export function createAction<T extends string, P>(type: T, payload: P): any {
    return { type, payload };
}
/*****0. CREATE REDUCER ACTION UTILS  utils/recuer.utils.ts******/


/*****1.CREATE REDUCER TYPES*******store/categories/categories.type.ts***********************/


export const CATEGORIES_ACTION_TYPES = {
    FETCH_CATEGORIES_START: "categories/FETCH_CATEGORIES_START",
    FETCH_CATEGORIES_SUCCESS: "categories/FETCH_CATEGORIES_SUCCESS",
    FETCH_CATEGORIES_FAILED: "categories/FETCH_CATEGORIES_FAILED",
};
/*****1.CREATE REDUCER TYPES*******store/categories/categories.type.ts***********************/



/*****2.CREATE REDUCER SELECTOR*******store/categories/categories.selector.ts***********************/

export const selectCategories = (state: State<Array<Category>>): Array<Category> => state.payload;

/*****2.CREATE REDUCER SELECTOR*******store/categories/categories.selector.ts***********************/




/*****3.CREATE REDUCER ACTION*******store/categories/categories.selector.ts***********************/
export const fetchCategoriesStart = () => createAction(CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_START);
export const fetchCategoriesSucces = (categories: Array<Category>) => createAction(CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_SUCCESS, categories);
export const fetchCategoriesFailed = (error: string) => createAction(CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_FAILED, error);
/*****3.CREATE REDUCER ACTION*******store/categories/categories.selector.ts***********************/


//we use reducer to manage state and watch the changes by action on state
export const categoriesReducer = (state: State<Array<Category>>, action: { type: any, payload: any }) => {
    const { type, payload } = action;
    switch (type) {
        case CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_START:
            return { ...state, isloading: true };
        case CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_SUCCESS:
            return { ...state, isloading: false, products: payload };
        case CATEGORIES_ACTION_TYPES.FETCH_CATEGORIES_FAILED:
            return { ...state, isloading: false, error: payload };
        default:
            return state;
    }
};