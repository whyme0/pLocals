import { Account, OpenAccountCreationFormButton, Paging, SearchBox } from "./elements";


export default async function Home(props) {
  const searchParams = await props.searchParams;
  
  const BACKEND_API_URL = process.env.NEXT_PUBLIC_API_URL ? process.env.NEXT_PUBLIC_API_URL : process.env.NEXT_PUBLIC_API_FOR_CLIENT

  let url = new URL(`${BACKEND_API_URL}/account/get`);

  if(searchParams.pageNumber){
    url.searchParams.append("pageNumber", searchParams.pageNumber);
  }

  if(searchParams.title){
    url = new URL(`${BACKEND_API_URL}/account/get/${searchParams.title}`);
  }

  let response = await fetch(url, {cache:'no-cache'});
  let data = await response.json();
  let accountList = response.status != 200 ? "No accounts found" : data.map((acc)=>{return <Account key={acc.id} account={acc}/>});

  response = await fetch(`${BACKEND_API_URL}/account/count`);
  let numberOfAccounts = await response.json();
  let numberOfPages = numberOfAccounts != 0 ? Math.ceil(numberOfAccounts / 15 ) : 1;

  let paging;
  if(!searchParams.title){
    paging = <>
      <p className="mb-3">All pages:</p>
      <Paging pageCount={numberOfPages}></Paging>
    </>
  }

  return (
    <div className="w-full mx-auto px-10 md:px-1 md:w-1/2 xl:w-1/2">
      <div className="flex items-center mt-5">
        
        <SearchBox />
        
        <OpenAccountCreationFormButton />
      
      </div>

      {accountList}

      {paging}
    </div>
  );
}
