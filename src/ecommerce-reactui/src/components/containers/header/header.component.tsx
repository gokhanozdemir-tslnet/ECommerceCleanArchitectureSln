

import CartSummary from "@/components/cart/cartsummary.component";
import "./header.style.scss"
const Header = () => {
	return (
		<header>
			<div className="header-container">
				<div className="header-nav-left">Navbar</div>
				<div className="header-nav-center">Center nav</div>
				<div className="header-nav-right">
					<div className="login">Login</div>
					<div className="sepet">
						<CartSummary></CartSummary>
					</div>
				</div>
			</div>
			{/* <meta name="viewport" content="width=device-width, initial-scale=1"> */}
			<section className="header-nav-menu-section">
				<div>
				<input id="menu-toggle" type="checkbox" />
				<label className='menu-button-container' htmlFor="menu-toggle">
					<div className='menu-button'></div>
				</label>
				</div>
				
				<ul className="menu">
					<li>One</li>
					<li>Two</li>
					<li>Three</li>
					<li>Four</li>
				</ul>
			
			</section>
		</header>
	);
}

export default Header;