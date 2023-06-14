import { useEffect, useState } from 'react'
import './App.css'
import NavBar from './components/NavBar';
import PasswordGenerator from "./utils/PasswordGenerator.ts";
import {GeneratePasswordDto} from "./types/GeneratePasswordDto.ts";
import { ToastContainer, toast } from "react-toastify";

function App() {
  const passwordGenerator = new PasswordGenerator();

  const generatePasswordDto = new GeneratePasswordDto();

  const [password, setPassword] = useState<string>("");

  const myStyles = {
    iconStyles:{
      cursor:"pointer"
    }
  };

  useEffect(() => {
    generatePasswordDto.Length = 15;
    generatePasswordDto.IncludeNumbers = true;
    generatePasswordDto.IncludeLowerCaseCharacters = true;
    generatePasswordDto.IncludeUpperCaseCharacters = true;
    generatePasswordDto.IncludeSpecialCharacters = true;

    setPassword(passwordGenerator.Generate(generatePasswordDto));
  }, []);

  const handleGenerate = (): void => {
    generatePasswordDto.Length = 15;
    generatePasswordDto.IncludeNumbers = true;
    generatePasswordDto.IncludeLowerCaseCharacters = true;
    generatePasswordDto.IncludeUpperCaseCharacters = true;
    generatePasswordDto.IncludeSpecialCharacters = true;

    setPassword(passwordGenerator.Generate(generatePasswordDto));
  }
  const handleCopyToClipBoard = () => {
    navigator.clipboard.writeText(password);
    toast("The selected password copied to the clipboard.")
  }

  return (
      /* JSX'in değişiklikleri dönebileceği bir kök elemente ihtiyacı var => <></> (Fragment) */
    <>
      <ToastContainer/>
      <NavBar/>
      <div className="container">
        <div className="card-header is-justify-content-center">
          <h3 className="has-text-success is-size-2">Secure Password Generator</h3>
        </div>
        <div className="card">
      <div className="card-content">
      <div className="media">
        <div className="media-left">
          <p className="is-size-3">{password}</p>
        </div>
        <div className="media-right">
          <i className="is-size-3" style={myStyles.iconStyles}>♻️</i>
          <i className="is-size-3" style={myStyles.iconStyles} onClick={handleCopyToClipBoard}>♻️</i>
          <i className="is-size-3" style={myStyles.iconStyles} onClick={handleGenerate}>♻️</i>
        </div>
      </div>

      <div className="content">
      </div>
    </div>
</div>
    </div>
    </>
  )
}

export default App
