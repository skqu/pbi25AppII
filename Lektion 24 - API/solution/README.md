# Controller Diagram

The following diagram shows the inheritance for the controllers. 

```mermaid 
    classDiagram
    class BooksController{

    }

    class BookshelfsController{

    }

    class UsersController{

    }

    class ControllerBase{

    }

    ControllerBase --|> BooksController
    ControllerBase --|> BookshelfsController
    ControllerBase --|> UsersController

```

# Books Diagram

The Books diagram shows the relationship between books and the different commands connected to them.

This is an example of the Command design pattern, where:

1) Invoker -> Controller: Gets Assigned
1) Receiver -> Service: responsible for the logic
1) Action -> Commands: responsible for defining the available commands

A useful reflection is: who is the client, and why?

The controller knows about the available actions, but because of polymorphism it only needs to know the ICommand interface. The client is therefore the part of the system responsible for assigning the concrete commands.
Also note that this example is to keep responsible where it belongs. 

```mermaid 
    classDiagram
    class BooksController{

    }

    class ControllerBase{

    }

    ControllerBase --|> BooksController

    BooksController --> BooksDto
    BooksController --> BooksInvoker
    BooksController --> BooksService
    BooksInvoker --> ICommand
    RentBookCommand --> BooksService
    BooksDto <-- BooksService
    ReturnBookCommand --> BooksService
    NewBookCommand --> BooksService
    RemoveBookCommand --> BooksService
    ICommand <|.. RemoveBookCommand
    ICommand <|.. NewBookCommand
    ICommand <|.. RentBookCommand
    ICommand <|.. ReturnBookCommand


```

# Users Diagram

The Users diagram resembles the Books diagram, but an important point is that both users and books have knowledge about the rent and return commands.

```mermaid 
    classDiagram
    class UsersController{

    }

    class ControllerBase{

    }

    ControllerBase --|> UsersController

    UsersController --> UsersInvoker
    UsersController --> UsersService
    UsersInvoker --> ICommand
    RentBookCommand --> UsersService
    ReturnBookCommand --> UsersService
    UsersDto <-- UsersService
    ICommand <|.. ReturnBookCommand
    ICommand <|.. RentBookCommand


```

# Rental Diagram

To illustrate the point made in the Users diagram, the complete rental diagram is shown here.

It becomes clear that the commands are responsible for activating the concrete logic in both UsersService and BooksService when handling rental and return.

```mermaid 
    classDiagram


    RentBookCommand --> UsersService
    ReturnBookCommand --> UsersService
    UsersService --> UsersDto


    RentBookCommand --> BooksService
    ReturnBookCommand --> BooksService
    BooksService --> BooksDto


    ICommand <|.. ReturnBookCommand
    ICommand <|.. RentBookCommand

```


# Bookshelfs Diagram

The same overall idea as in the Books diagram applies here: this is also modeled using the Command pattern.

```mermaid 
    classDiagram

    class BookshelfsController{

    }

    class ControllerBase{

    }

    ControllerBase --|> BookshelfsController
    

    BookshelfsController --> BookshelfsDto
    BookshelfsController --> BookshelfsService
    BookshelfsController --> BooksService
    BookshelfsController --> BooksDto
    BookshelfsController --> BookshelfsInvoker
    BookshelfsInvoker --> ICommand
    BookshelfsDto <-- BookshelfsService
    BooksDto <-- BookshelfsService
    BooksDto <-- BooksService
    AddBookCommand --> BookshelfsService
    RemoveBookCommand --> BookshelfsService
    ICommand <|.. AddBookCommand
    ICommand <|.. RemoveBookCommand



```