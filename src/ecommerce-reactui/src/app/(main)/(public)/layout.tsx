import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.style.scss";
import Header from "../../../components/containers/header/header.component";
import Footer from "@/components/containers/footer/footer.component";
import StoreProvider from "../StoreProvider";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
    title: "ECommerce NextJS React App",
    description: "Generated by create next app",
};

export default function RootLayout({
    children,
}: Readonly<{
    children: React.ReactNode;
}>) {
    return (
        <html lang="en">
            <body className={inter.className}>
                <StoreProvider>
                    <Header />
                    {children}
                    {/* <Footer /> */}
                </StoreProvider>
            </body>
        </html>
    );
}
