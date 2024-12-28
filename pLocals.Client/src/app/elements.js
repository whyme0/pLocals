'use client';

import { useSearchParams } from "next/navigation";
import { useEffect, useState } from "react";

function handleTextCopy(event){
  navigator.clipboard.writeText(event.target.value);
}

function ReadonlyAccountField({value, name, type = null}){
  if(type=="notetext") {
    if(value){
      return <input className="bg-inherit tracking-wider text-slate-700 mb-2 focus:outline-none w-full" defaultValue={value} type="text" name={name} readOnly={true}></input>
    }
    else{
      return null;
    }
  }
  else if (type=="title"){
    return <input className="bg-inherit focus:outline-none" defaultValue={value} type="text" name={name} readOnly={true}></input>
  }
  else{
    return <input className="bg-inherit cursor-pointer focus:outline-none w-full" onClick={handleTextCopy} defaultValue={value} type="text" name={name} readOnly={true}></input>  
  }
}

function EditableAccountField({value, name, onChange}){
  if(name=="notetext") {
    return <>
      <textarea className="bg-gray-200 outline-none tracking-wider text-slate-700 mb-2 w-full" type="text" defaultValue={value} name={name} onChange={onChange}></textarea>
    </>
  }
  return <>
    <input className="bg-gray-200 outline-none w-full" type="text" defaultValue={value} name={name} onChange={onChange}></input>
  </>
}

export function Account({account}){
    const [accountUpdateErros, setAccountUpdateErrors] = useState([]);
  
    const [isAccountVisible, setAccountVisible] = useState(true);
    const [isAccountReadonly, setAccountState] = useState(true);
    
    const [loginField, setLoginField] = useState(<ReadonlyAccountField value={account.login} name="loginField"/>);
    const [passwordField, setPasswordField] = useState(<ReadonlyAccountField value={account.password} name="passwordField" />);
    const [noteTextField, setNoteTextField] = useState(<ReadonlyAccountField value={account.noteText} name="noteTextField" type="notetext"/>);
    const [titleField, setTitleField] = useState(<ReadonlyAccountField value={account.title} name="titleField" type="title"/>)
    
    const [saveChangesButton, setSaveChangesButton] = useState(null);
    const [editButton, setEditButton] = useState(
      <button type="button" onClick={setEditableState} className="size-6 bg-slate-200 hover:bg-slate-300 active:bg-slate-400 p-1 rounded-md border border-gray-300 hover:border-gray-400 active:border-gray-500" title="Edit/Cancel editing">
        <svg className="stroke-gray-500 active:stroke-black" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
          <path d="M21.2799 6.40005L11.7399 15.94C10.7899 16.89 7.96987 17.33 7.33987 16.7C6.70987 16.07 7.13987 13.25 8.08987 12.3L17.6399 2.75002C17.8754 2.49308 18.1605 2.28654 18.4781 2.14284C18.7956 1.99914 19.139 1.92124 19.4875 1.9139C19.8359 1.90657 20.1823 1.96991 20.5056 2.10012C20.8289 2.23033 21.1225 2.42473 21.3686 2.67153C21.6147 2.91833 21.8083 3.21243 21.9376 3.53609C22.0669 3.85976 22.1294 4.20626 22.1211 4.55471C22.1128 4.90316 22.0339 5.24635 21.8894 5.5635C21.7448 5.88065 21.5375 6.16524 21.2799 6.40005V6.40005Z" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
          <path d="M11 4H6C4.93913 4 3.92178 4.42142 3.17163 5.17157C2.42149 5.92172 2 6.93913 2 8V18C2 19.0609 2.42149 20.0783 3.17163 20.8284C3.92178 21.5786 4.93913 22 6 22H17C19.21 22 20 20.2 20 18V13" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
        </svg>
      </button>
    );
    
    const [titleInput, setTitleInput] = useState(account.title);
    const [loginInput, setLoginInput] = useState(account.login);
    const [passwordInput, setPasswordInput] = useState(account.password);
    const [noteTextInput, setNoteTextInput] = useState(account.noteText);

    const [title, setTitle] = useState(account.title);
    const [login, setLogin] = useState(account.login);
    const [password, setPassword] = useState(account.password);
    const [noteText, setNoteText] = useState(account.noteText);

    function setReadonlyState(){
      setAccountState(isAccountReadonly);
      setTitleField(<ReadonlyAccountField value={titleInput} type="title"/>)
      setNoteTextField(<ReadonlyAccountField value={noteTextInput} type="notetext"/>);
      setLoginField(<ReadonlyAccountField value={loginInput}/>);
      setPasswordField(<ReadonlyAccountField value={passwordInput}/>);
      setEditButton(
        <button type="button" onClick={setEditableState} className="size-6 bg-slate-200 hover:bg-slate-300 active:bg-slate-400 p-1 rounded-md border border-gray-300 hover:border-gray-400 active:border-gray-500" title="Edit">
          <svg className="stroke-gray-500 active:stroke-black" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M21.2799 6.40005L11.7399 15.94C10.7899 16.89 7.96987 17.33 7.33987 16.7C6.70987 16.07 7.13987 13.25 8.08987 12.3L17.6399 2.75002C17.8754 2.49308 18.1605 2.28654 18.4781 2.14284C18.7956 1.99914 19.139 1.92124 19.4875 1.9139C19.8359 1.90657 20.1823 1.96991 20.5056 2.10012C20.8289 2.23033 21.1225 2.42473 21.3686 2.67153C21.6147 2.91833 21.8083 3.21243 21.9376 3.53609C22.0669 3.85976 22.1294 4.20626 22.1211 4.55471C22.1128 4.90316 22.0339 5.24635 21.8894 5.5635C21.7448 5.88065 21.5375 6.16524 21.2799 6.40005V6.40005Z" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
            <path d="M11 4H6C4.93913 4 3.92178 4.42142 3.17163 5.17157C2.42149 5.92172 2 6.93913 2 8V18C2 19.0609 2.42149 20.0783 3.17163 20.8284C3.92178 21.5786 4.93913 22 6 22H17C19.21 22 20 20.2 20 18V13" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
          </svg>
        </button>
      );
      setSaveChangesButton(null);
      setAccountUpdateErrors([]);
    }
    
    function setEditableState(){
      setAccountState(!isAccountReadonly);
      setTitleField(<EditableAccountField value={titleInput} name="title" onChange={(e)=> {setTitleInput(e.target.value)}}/>);
      setNoteTextField(<EditableAccountField value={noteTextInput} name="notetext" onChange={(e)=> setNoteTextInput(e.target.value)}/>);
      setLoginField(<EditableAccountField value={loginInput} name="login" onChange={(e)=> setLoginInput(e.target.value)}/>);
      setPasswordField(<EditableAccountField value={passwordInput} name="password" onChange={(e)=> setPasswordInput(e.target.value)}/>);
      setEditButton(
        <button type="button" onClick={setReadonlyState} className="size-6 bg-slate-200 hover:bg-slate-300 active:bg-slate-400 p-1 rounded-md border border-gray-300 hover:border-gray-400 active:border-gray-500" title="Cancel editing">
          <svg className="stroke-gray-500 active:stroke-black" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
            <circle cx="12" cy="12" r="9" stroke="#222222"/>
            <path d="M18 18L6 6" stroke="#222222"/>
          </svg>
        </button>
      );
      setSaveChangesButton(
        <button type="submit" id="saveChangesButton" className="size-6 bg-slate-200 hover:bg-slate-300 active:bg-slate-400 p-1 rounded-md border border-gray-300 hover:border-gray-400 active:border-gray-500" title="Save changes">
          <svg className="stroke-gray-500 active:stroke-black" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M5 14L8.23309 16.4248C8.66178 16.7463 9.26772 16.6728 9.60705 16.2581L18 6" strokeWidth="1.5" strokeLinecap="round"/>
          </svg>
        </button>
      );
    }

    function onSubmit(e) {
      e.preventDefault();

      const formData = {}

      if(loginInput != login){
        formData.login = loginInput
      }
      if(passwordInput != password){
        formData.password = passwordInput
      }
      if(noteTextInput != noteText){
        formData.noteText = noteTextInput
      }
      if(titleInput != title){
        formData.title = titleInput
      }

      fetch(`http://localhost:5187/account/update/${account.id}`, {
        method: 'PUT',
        headers: {
          'Accept': "application/json, text/plain, */*",
          'Content-Type': "application/json;charset=utf-8"
        },
        body: JSON.stringify(formData),
      }).then(res => {
        if(res.status == 200){
          setLoginInput(loginInput);
          setPasswordInput(passwordInput);
          setNoteTextInput(noteTextInput);
          setTitleInput(titleInput);
          
          setReadonlyState(e);
        }
        else if(res.status == 400){
          return res.json();
        }
      }).then(data => {
        if(data){
          setAccountUpdateErrors(data.Errors);
        }
      });
    }

    function onDeleteButton(e){
      fetch(`http://localhost:5187/account/delete/${account.id}`, {
        method: 'DELETE'
      }).then(res => {
        if(res.status==202){
          setAccountVisible(false);
        }
      });
    }
    
    if(isAccountVisible){
      return <>
        <div key={account.id} id={`account`+account.id} className="text-lg my-10 bg-gray-100 py-2 px-4 rounded-md border border-gray-300 shadow-md">

          <form onSubmit={onSubmit}>
            {accountUpdateErros.map(err=><p className="text-red-500">{err}</p>)}
            <div className="flex justify-between align-middle mb-1">
              <div className="font-bold">
                {titleField}
              </div>

              <div className="space-x-2">
                {saveChangesButton}
                
                {editButton}
                
                <button type="button" onClick={onDeleteButton} className="size-6 bg-slate-200 hover:bg-slate-300 active:bg-slate-400 p-1 rounded-md border border-gray-300 hover:border-gray-400 active:border-gray-500" title="Delete">
                  <svg className="stroke-gray-500 active:stroke-black" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                    <path d="M10 11V17"  strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M14 11V17"  strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M4 7H20"  strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M6 7H12H18V18C18 19.6569 16.6569 21 15 21H9C7.34315 21 6 19.6569 6 18V7Z" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                    <path d="M9 5C9 3.89543 9.89543 3 11 3H13C14.1046 3 15 3.89543 15 5V7H9V5Z" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"/>
                  </svg>
                </button>
              </div>
            </div>
          
            <div>
              {noteTextField}
            </div>
          
            <table className="border-separate border-spacing-y-1">
              <tbody>
                <tr className="pb-4">
                  <td className="pr-3"><span className="font-mono text-slate-400">Login:</span></td>
                  <td className="text-left" id="loginField">{loginField}</td>
                </tr>
                <tr>
                  <td className="pr-3"><span className="font-mono text-slate-400">Password: </span></td>
                  <td className="text-left w-full" id="passwordField">{passwordField}</td>
                </tr>
              </tbody>
            </table>
          </form>

        </div>
    </>;
    } else {
      return null;
    } 
}

export function SearchBox(){
  
  const [titleFieldInput, setTitleFieldInput] = useState(useSearchParams().get('search'));
  const [titleField, setTitleField] = useState(<input type="text" defaultValue={titleFieldInput} onKeyDown={onTitleInput} placeholder="Searching by account title" className="px-2 py-3 w-full outline-none text-gray-600 text-sm" />)

  function onTitleInput(e){
    if(e.key == "Enter"){
      setTitleField(e.target.value);

      let goTo = new URL(window.location);
      
      goTo.searchParams.set("title", e.target.value);
      goTo.searchParams.delete("pageNumber");

      window.location.href = goTo;
    }
  }

  
  return <>
    <div className="flex justify-between rounded-full px-2 border-2 bg-white border-gray-300 overflow-hidden w-full font-[sans-serif]">
      {titleField}

      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 192.904 192.904" width="16px" className="fill-gray-400">
        <path
          d="m190.707 180.101-47.078-47.077c11.702-14.072 18.752-32.142 18.752-51.831C162.381 36.423 125.959 0 81.191 0 36.422 0 0 36.423 0 81.193c0 44.767 36.422 81.187 81.191 81.187 19.688 0 37.759-7.049 51.831-18.751l47.079 47.078a7.474 7.474 0 0 0 5.303 2.197 7.498 7.498 0 0 0 5.303-12.803zM15 81.193C15 44.694 44.693 15 81.191 15c36.497 0 66.189 29.694 66.189 66.193 0 36.496-29.692 66.187-66.189 66.187C44.693 147.38 15 117.689 15 81.193z">
        </path>
      </svg>
    </div>
    <div>

    </div>
  </>
}

export function OpenAccountCreationFormButton(){  
  const [accountCreationForm, setAccountCreationForm] = useState(null);

  const [openFormBtn, setOpenFormBtn] = useState(<button type="button" onClick={handleOpen} className="border-2 border-green-600 text-green-600 font-bold rounded-full w-[44px] h-[44px] text-center">+</button>);

  function handleOpen(e){
    e.preventDefault();
    
    setAccountCreationForm(<CreateAccountForm />);
    setOpenFormBtn(<button type="button" onClick={handleClose} className="border-2 border-red-600 text-red-600 font-bold rounded-full w-[44px] h-[44px] text-center">X</button>);
  }
  function handleClose(e){
    e.preventDefault();

    setAccountCreationForm(null);
    setOpenFormBtn(<button type="button" onClick={handleOpen} className="border-2 border-green-600 text-green-600 font-bold rounded-full w-[44px] h-[44px] text-center">+</button>);
  }
  
  return <>    
    <div className="flex ml-2">
      {openFormBtn}   
    </div>

    {accountCreationForm}
  </>
}

export function CreateAccountForm(){
  const [errorMessages, setErrorMessages] = useState([]);

  const [titleInput, setTitleInput] = useState("");
  const [loginInput, setLoginInput] = useState("");
  const [passwordInput, setPasswordInput] = useState("");
  const [noteTextInput, setNoteTextInput] = useState("");
  
  function onSubmit(e){
    e.preventDefault();
    
    const formData = {
      title: titleInput,
      login: loginInput,
      password: passwordInput,
      noteText: noteTextInput
    }

    fetch(`http://localhost:5187/account/create/`, {
      method: 'POST',
      headers: {
        'Accept': "application/json, text/plain, */*",
        'Content-Type': "application/json;charset=utf-8"
      },
      body: JSON.stringify(formData),
    })
    .then(res => {
      if(res.status == 204){
        window.location.href = `http://localhost:3000/`;
      }
      return res.json();
    })
    .then(data => {
      console.log(Object.values(data).flat());
      if(data){
        const combinedErrors = Object.values(data).flat();

        setErrorMessages(combinedErrors);
      }
    })
    .catch((e) => {console.log(e)});
  }

  return <>
    <div className="absolute md:mx-auto md:w-1/3 xl:w-1/3 mx-10 left-0 right-0 top-20 flex items-center z-10 bg-gray-100 border-gray-300 border-2 shadow-3xl rounded-md">
      <form onSubmit={onSubmit} className="w-full m-3">
        <p className="border-l-4 border-black pl-2 algin-middle">Create new account</p>

        {errorMessages.length > 0 && ( errorMessages.map(err => (
            <p key={err} className="text-red-500">{err}</p>
          )))}
        
        <input onChange={e => setTitleInput(e.target.value)} className="border-gray-300 block border-2 outline-none bg-inherit mt-2 w-full font-mono p-1" placeholder="Title"></input>
        <input onChange={e => setLoginInput(e.target.value)} className="border-gray-300 block border-2 outline-none bg-inherit mt-2 w-full font-mono p-1" placeholder="Login"></input>
        <input onChange={e => setPasswordInput(e.target.value)} className="border-gray-300 border-2 outline-none bg-inherit block mt-2 w-full font-mono p-1" placeholder="Password"></input>
        <textarea onChange={e => setNoteTextInput(e.target.value)} className="border-gray-300 border-2 outline-none bg-inherit block my-2 w-full font-mono h-16 p-1" placeholder="Note text" type=""></textarea>

        <button className="bg-blue-600 text-white focus-within:bg-blue-700 px-2 py-1 rounded-md" type="submit">Create account</button>
      </form>
    </div>
  </>
}

export function Paging({pageCount}){
  const [pages, setPages] = useState(Array(pageCount).fill(null).map((_,i)=>i+1));
  
  function handleClick(e){
    let goTo = new URL(window.location);
    goTo.searchParams.set("pageNumber", e.target.value);
    goTo.searchParams.delete("title");
    
    window.location.href = goTo;
  }

  return <>
    <div className="flex space-x-3">
      {pages.map((currValue, _) => <button className="text-black bg-gray-200 hover:font-bold focus:ring-4 focus:outline-none focus:ring-gray-300 font-medium rounded-lg p-2.5 text-center dark:bg-gray-600 dark:hover:bg-gray-700 dark:focus:ring-gray-800" key={currValue} defaultValue={currValue} value={currValue} onClick={handleClick}>{currValue}</button>)}
    </div>
  </>
}