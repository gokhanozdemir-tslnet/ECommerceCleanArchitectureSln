import "./slug.style.scss";

export default function SlugLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return <div className="slugContent">{children}</div>
}