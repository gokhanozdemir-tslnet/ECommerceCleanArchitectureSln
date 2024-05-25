"use client"
import React from 'react'
import "./cartsummary.component.scss"
import Image from 'next/image'
{/* <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0" /> */ }

type Props = {}

const CartSummary = (props: Props) => {

  const cardSummaryClick = () => {
 
    let dvCard  = (document.getElementsByClassName('card-summary-pannel-context')[0]  as HTMLElement);
    dvCard.style.display = "block";
    

  }

  return (
    <>
      <div className="card-summary-pannel-icon" onClick={cardSummaryClick}>
        <span className="material-symbols-outlined">shopping_cart</span>
        <span className="badge">3</span>
        <label>Sepetim</label>
        <div  className='card-summary-pannel-context'>
          <div className=''>
          <Image
          src="/profile.png"
          width={500}
          height={500}
         alt="Picture of the author"
        />
          </div>
        </div>
      </div>
      

    </>
  )
}

export default CartSummary;