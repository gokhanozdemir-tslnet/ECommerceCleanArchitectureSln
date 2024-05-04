import Categories from '@/components/containers/categories/categories.component'
import React from 'react'

type Props = {
    params: {
        slug: string[]
    }
    searchParams: {}
}
//pd: product detail
//ci: category items
const Page = ({ params, searchParams }: Props) => {

    //Note: .some methods returns true if exists or false
    const isProductDetail: boolean = params.slug.some(item => item === "pd");
    const isCategoryItems: boolean = params.slug.some(item => item === "ci");

    return (
        <>



            {isCategoryItems && <Categories />}

        </>

    );
};

export default Page;