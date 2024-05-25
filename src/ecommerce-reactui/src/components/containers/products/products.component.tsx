"use client";
// import { getServerSideProps } from "next/dist/build/templates/pages"
import Card from "@/components/card/card.component"
import { CardType, ProductType } from "@/types/card.type"
import { useAppDispatch, useAppSelector } from "@/hooks/hooks"
import { ProductsType, fetchProducts } from "@/hooks/store/products/products.slice";
import { fetchProductsFromService, fetchProductsFromService2 } from "@/lib/fetcher";

// type Props = {
//     name: Awaited<ReturnType<typeof getServerSideProps>>["props"]
// }
type Props = {
}

const Products = (props: Props) => {


    const dispatch = useAppDispatch();
    const products = useAppSelector(state => state.products);

    // if (products.items.length === 0) {   
      
    //      fetchProductsFromService2().then(list => dispatch(fetchProducts(list)));
    // }

    return (<div className="card-list-container">

        {products.items.map(product => <Card card={product} key={product.id} />)}


    </div>);
};

export default Products;


// const productJSON = (await fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;

// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));

// fetch('https://fakestoreapi.com/products').then(data => data.json())) as Array<CardType>;
// fetch('https://fakestoreapi.com/products')
//     .then(data => data.json())
//     .then(items => dispatch(fetchProducts((items as Array<ProductType>))));




