/* eslint-disable @next/next/no-img-element */

import React from 'react'
import "./categories.style.scss"
import { LinkButton, StyledLink } from '@/components/ui/styles'
import Link from 'next/link'
import Card from '@/components/card/card.component'
import { CardType } from '@/types/card.type'

type Props = {}


const Categories = (props: Props) => {
    const card: CardType = {
        title: "card titlex",
        description: "ome quick example text to build on the card title and make up the b",
        linkUrl: "/shop",
        imageUrl: "https://m.media-amazon.com/images/I/41kV6HXo+jL._AC._SR240,240.jpg",
        imageAlt: "Card image cap"

    };
    return (
        <div className="card-list-container">
            {/* <Link href="/selectedcat"> */}
            <Card card={card} />
            {/* </Link> */}


        </div>
    )
}

export default Categories; 