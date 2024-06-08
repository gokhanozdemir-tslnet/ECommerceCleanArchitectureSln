import { ProductsType } from "@/hooks/store/features/products/products.slice"
import { ProductType } from "@/types/card.type"


export const fetchProductsFromService = async () => {
  return fetch('https://fakestoreapi.com/products')
    .then(data => data.json())
    .then(items => (items as Array<ProductType>))

}


export const fetchProductsFromService2 = async () => {
  return makeGet<Array<ProductType>>('https://fakestoreapi.com/products');

}


export const makeGet = async <T>(
  url: string,
  headers: Record<string, string> = {}
): Promise<T> => {
  const response = await fetch(url, {
    headers: {
      "Content-Type": "application/json",
      ...headers
    }
  });

  if (!response.ok) {
    return Promise.reject(response.statusText);
  }

  return (await response.json()) as T;
};


export const makePost = async <ReqType, ResType>(
  url: string,
  body: ReqType,
  headers: Record<string, string> = {}
): Promise<ResType> => {
  const response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      ...headers
    },
    body: JSON.stringify(body)
  });

  if (!response.ok) {
    return Promise.reject(response.statusText);
  }

  return (await response.json()) as ResType;
};


// const productJSON = (await fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;

// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));

// fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;
// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));




// const productJSON = (await fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;

// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));

// fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;
// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));
