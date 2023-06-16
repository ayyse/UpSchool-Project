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

  const [savedPasswords, setSavedPasswords] = useState<string[]>([]);

  const [passwordLength, setPasswordLength] = useState<number>(12);

  const [includeNumbers, setIncludeNumbers] = useState<boolean>(true);
  const [includeLowercase, setIncludeLowercase] = useState<boolean>(true);
  const [includeUppercase, setIncludeUppercase] = useState<boolean>(false);
  const [includeSpecialChars, setIncludeSpecialChars] = useState<boolean>(false);

  const myStyles = {
    iconStyles:{
      cursor:"pointer"
    }
  };

  useEffect(() => {
    handleGenerate();
  }, [passwordLength, includeNumbers, includeLowercase, includeUppercase, includeSpecialChars]);

  const handleGenerate = (): void => {
    generatePasswordDto.Length = passwordLength;
    generatePasswordDto.IncludeNumbers = includeNumbers;
    generatePasswordDto.IncludeLowerCaseCharacters = includeLowercase;
    generatePasswordDto.IncludeUpperCaseCharacters = includeUppercase;
    generatePasswordDto.IncludeSpecialCharacters = includeSpecialChars;

    setPassword(passwordGenerator.Generate(generatePasswordDto));
  }

  const handleSavePassword = () => {

    /* === tip kontrolü de yapar */
    const  samePassword = savedPasswords.find(x => x === password);

    if (!samePassword)
      setSavedPasswords([...savedPasswords, password]);
  }

  const handleSavedPasswordDelete = (selectedPass: string) => {
    const newSavedPasswords = savedPasswords.filter((pass) => pass !== selectedPass);
    setSavedPasswords(newSavedPasswords);
  }

  const handleChange = (value: string) => {
    setPasswordLength(Number(value));
    /*handleGenerate();*/
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
      <div className="container App">
        <div className="card-header is-justify-content-center">
          <h3 className="has-text-success is-size-2">Secure Password Generator</h3>
        </div>
        <div className="card" style={{backgroundColor: "#ECF8F9"}}>
      <div className="card-content">
      <div className="media">
        <div className="media-left">
          <p className="is-size-3">{password}</p>
        </div>
        <div className="media-right">
          <span className="is-size-3" style={myStyles.iconStyles} onClick={handleSavePassword}>💾</span>
          <span className="is-size-3" style={myStyles.iconStyles} onClick={handleCopyToClipBoard}>📋</span>
          <span className="is-size-3" style={myStyles.iconStyles} onClick={handleGenerate}>♻️</span>
        </div>
      </div>

      <div className="content has-text-centered">
        <div className="field">
          <input id="passwordLengthSelector" type="range" step={1} min={6} max={35} className="input mr-3"
            value={passwordLength} onChange={(event) => handleChange(event.target.value)} />
          <label htmlFor="passwordLengthSelector" style={{ fontSize: '24px', fontWeight: 'bold' }}>{passwordLength}</label>
        </div>
        <div className="field">
          <label className="checkbox mr-2">
            <input type="checkbox" className="mr-1" checked={includeNumbers}
                   onChange={(event) => setIncludeNumbers(event.currentTarget.checked)}
            />
            Numbers
          </label>
          <label className="checkbox mr-2">
            <input type="checkbox" className="mr-1" checked={includeLowercase}
                   onChange={(event) => setIncludeLowercase(event.currentTarget.checked)}/>
            Lowercase
          </label>
          <label className="checkbox mr-2">
            <input type="checkbox" className="mr-1"
                   checked={includeUppercase}
                   onChange={(event) => setIncludeUppercase(event.currentTarget.checked)}/>
            Uppercase
          </label>
          <label className="checkbox mr-2">
            <input type="checkbox" className="mr-1"
                   checked={includeSpecialChars}
                   onChange={(event) => setIncludeSpecialChars(event.currentTarget.checked)}/>
            Special Chars
          </label>
        </div>
        <ol className="list is-hoverable">
          {savedPasswords.map((pass, index) => (
              /* bu tarz dinamik işlemlerin takibi için unique bir key ataması yapılmalı*/
              <li className="list-item has-text-weight-bold" key={index}>
                {pass}
                <span style={myStyles.iconStyles} onClick={() => handleSavedPasswordDelete(pass)}>🗑️</span>
              </li>
          ))}
        </ol>
      </div>
    </div>
</div>
    </div>
    </>
  )
}

export default App
