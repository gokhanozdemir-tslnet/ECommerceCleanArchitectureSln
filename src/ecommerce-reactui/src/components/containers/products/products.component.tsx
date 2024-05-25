"use client";
// import { getServerSideProps } from "next/dist/build/templates/pages"
import Card from "@/components/card/card.component"
import { CardType, ProductType } from "@/types/card.type"
import { useAppDispatch, useAppSelector } from "@/hooks/hooks"
import { ProductsType, fetchProducts, useGetProductsQuery } from "@/hooks/store/products/products.slice";
import { fetchProductsFromService, fetchProductsFromService2 } from "@/lib/fetcher";

// type Props = {
//     name: Awaited<ReturnType<typeof getServerSideProps>>["props"]
// }
type Props = {
}

const Products = (props: Props) => {


    const dispatch = useAppDispatch();
    const products = useAppSelector(state => state.products);

    const { data, error, isLoading } = useGetProductsQuery("");

    // if (products.items.length === 0) {   

    //      fetchProductsFromService2().then(list => dispatch(fetchProducts(list)));
    // }

    return (<div className="card-list-container">

        {products.items.map(product => <Card card={product} key={product.id} />)}

        {isLoading ? <div> Loading....</div> :
            data?.map(productItem => <Card card={productItem} key={productItem.id} />)
        }



    </div>);
};

export default Products;





