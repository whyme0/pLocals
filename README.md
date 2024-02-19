# pLocals

pLocals - is private and secure password storage (yet another), which can be self-hosted on your machine. Main goal of this pet-project is to create password manager which I can trust 100% (because I am actually a creator 🤓).

# Technologies stack

pLocals is based on the following frameworks and stuff:
* ASP.NET WEB API (.net 8)
* PostgreSQL 16

# Project architecure schema

### Models:

`Account` - stores buisness logic such as password and login. Literally one of the most important project element in security terms.

`Note` - addition to `Account`, but dont shouldn't have any significant information.

### Controllers:

Class `AccountController` stands for:
- Create `Account` (cognominal `Create`)
- Read `Account` (in methods `Get` and `GetAll`)
- Update `Account` (cognominal `Update`)
- Delete `Account` (cognominal `Delete`)

Class `NoteController` stands for (all methods similar to `AccountController` besides it obviously haven't `GetAll` method):
- Create `Note`
- Read `Note`
- Update `Note`
- Delete `Note`