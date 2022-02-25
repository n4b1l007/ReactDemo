import ReactDOM from "react-dom";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./pages/Layout";
import Home from "./pages/Home";
import Blogs from "./pages/Blogs";
import Contact from "./pages/Contact";
import NoPage from "./pages/NoPage";
import Sidebar from "./components/Layout/Sidebar";
import TopNav from './components/Layout/Navbar';
import Footer from "./components/Layout/Footer";

export default function App() {
  return (
    <div className="">
      <TopNav />
      <Sidebar />
      <Footer />
    </div>

  );
}

ReactDOM.render(<App />, document.getElementById("root"));