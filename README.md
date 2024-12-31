# pLocals

pLocals - is private and secure password storage (yet another), which can be self-hosted on your machine. Main goal of this pet-project is to create password manager which I can trust 100% (because I am actually a creator 🤓).

# Technologies stack

pLocals is based on the following frameworks and stuff:
* ASP.NET WEB API (.net 8)
* PostgreSQL 16
* Entity Framework Core 8
* NextJS 15
* TailwindCSS
* Docker

# Project architecure schema

### Models:

`Account` - stores buisness logic such as password and login. Literally one of the most important project element in security terms.

### Controllers:

Class `AccountController` stands for:
- Create `Account` (cognominal `Create`)
- Read `Account` (in methods `Get` and `GetAll`)
- Update `Account` (cognominal `Update`)
- Delete `Account` (cognominal `Delete`)

# Trying out
## Using docker
Run `compose.yaml` file in your terminal within directory it located
```bash
docker compose up --build -d
```
After all containers start working go to `localhost:3000` in your browser

To stop them all use
```bash
docker compose down -v
```
