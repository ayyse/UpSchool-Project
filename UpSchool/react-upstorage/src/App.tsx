import './App.css'
import NavBar from './components/NavBar';
import { ToastContainer } from "react-toastify";
import { Container } from "semantic-ui-react";
import {Route, Routes} from "react-router-dom";
import PasswordGeneratorPage from "./pages/PasswordGeneratorPage.tsx";
import AccountsPage from "./pages/AccountsPage.tsx";
import NotFoundPage from "./pages/NotFoundPage.tsx";

function App() {

  return (
      /* JSX'in değişiklikleri dönebileceği bir kök elemente ihtiyacı var => <></> (Fragment) */
    <>
      <ToastContainer/>
      <NavBar/>
      <Container className="App">
        <Routes>
          <Route path={"/"} element={ <PasswordGeneratorPage /> } />
          <Route path={"/accounts"} element={ <AccountsPage /> } />
          <Route path={"/*"} element={ <NotFoundPage /> } />
        </Routes>
      </Container>
    </>
  )
}

export default App
