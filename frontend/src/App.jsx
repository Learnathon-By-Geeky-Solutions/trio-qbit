import { Outlet } from "react-router"
import "./App.css"
import Footer from "./components/shared/Footer"
import Header from "./components/shared/Header"

function App() {
  return (
    <>
      <Header></Header>
      <Outlet></Outlet>
      <Footer></Footer>
    </>
  )
}

export default App
