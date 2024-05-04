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
    const { title,
        description,
        linkUrl,
        imageUrl,
        imageAlt } = card;
    return (
        <div className='card-container'>
            <div className='card' >
                {/* <Image className="card-img-top"
                width={500}
                height={500}
                src="https://m.media-amazon.com/images/I/41kV6HXo+jL._AC._SR240,240.jpg"
                alt="Card image cap" /> */}
                <img className="card-img-top" src={imageUrl} alt={imageAlt} />
                <div className='card-body'>
                    <h5 className="card-title">{title}</h5>
                    <p className="card-text">{description}</p>
                    <LinkButton href={linkUrl}>Dashboard</LinkButton>
                </div>
            </div>
        </div>
    )
}

export default Card;