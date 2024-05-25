"use client"
import React from 'react'
import { LinkButton } from '../ui/styles'
import Image from 'next/image'
import "./card.style.scss"
import { CardType } from '@/types/card.type'

type Props = {
    card: CardType
}

const Card = ({ card }: Props) => {
    const {
        title,
        description,
        linkUrl,
        imageUrl,
        image,
        price,
        imageAlt } = card;
    return (
        <div className='card-container'>
            <div className='card' >
                {/* <Image className="card-img-top"
                width={500}
                height={500}
                src="https://m.media-amazon.com/images/I/41kV6HXo+jL._AC._SR240,240.jpg"
                alt="Card image cap" /> */}
                <img className="card-img-top" src={image} alt={imageAlt} width={20} />
                <div className='card-body'>
                    <h5 className="card-title">{title.substring(0, 40)}...</h5>
                    <p className="card-text">{description.substring(0, 40)}...</p>
                    <p className="card-text">{price}</p>
                    {/* <LinkButton href={linkUrl}>Dashboard</LinkButton> */}
                    <button>Add To Cart</button>
                    <button>sdfsdf</button>
                </div>
            </div>
        </div>
    )
}

export default Card;