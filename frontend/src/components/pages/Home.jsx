import heroBG from "../../assets/hero-bg.webp"
const Home = () => {
    return (
        <>
            <div
                className="hero min-h-screen"
                style={{
                    backgroundImage: `url(${heroBG})`,
                }}>
                <div className="hero-overlay bg-opacity-60 bg-black"></div>
                <div className="hero-content text-neutral-content text-center">
                    <div className="max-w-2xl">
                        <h1 className="mb-5 text-5xl font-bold">Master Problem-Solving with CodeRev</h1>
                        <p className="mb-5">
                        Track your coding habits, get personalized problem reviews, and visualize your progress—all in one place. Stay consistent, improve efficiently, and master problem-solving with CodeRev! 
                        </p>
                        <button className="btn btn-primary forced-color:hidden bg-primary border-primary">Get Started</button>
                    </div>

                </div>
            </div>

        </>
    )
}

export default Home