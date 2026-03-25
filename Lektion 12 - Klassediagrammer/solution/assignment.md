# Opgave 1 – Fra Sekvens til Klasse


I får følgende beskrivelse fra et sekvensdiagram:


- User kalder createOrder()

- OrderService kalder validateOrder()

- OrderService kalder saveOrder() i Database

- Database returnerer OrderId

```mermaid
sequenceDiagram

    Actor cst as Customer
    cst ->> OrderService : createOrder()
    activate OrderService
    activate OrderService
    OrderService ->> OrderService : validateOrder()
    deactivate OrderService
    OrderService ->> Database : saveOrder()
    Database -->> OrderService : OrderId
    OrderService -->> cst : confirmation
    deactivate OrderService

```


## Opgave

1) Identificér hvilke klasser der skal eksistere \
OrderService, Database, Customer
1) Identificér hvilke metoder der skal være i hver klasse \
OrderService: validateOrder, createOrder. \
Database: saveOrder 
1) Tegn et simpelt klassediagram i Mermaid

```mermaid
classDiagram
    OrderService --> Database
    Customer --> OrderService

    class OrderService{
        - OrderId : string
        + OrderServer(Database db) OrderServicer
        + createOrder() string
        - validateOrder() bool
    }

    class Database{
        + saveOrder()  string
    }

    class Customer{
        + MakeOrder(OrderService order) void
    }

```

1) Implementér skeleton-klasser i C#

se program.cs

# Opgave 2 – Relationer


Udvid systemet:

- En Order har én Customer
- En Customer kan have mange Order
- En Order indeholder flere OrderLine
- En OrderLine indeholder ét Product



## Opgave

Identificér relationstyper:

1) Association?

1) Aggregation?

1) Composition?

Tilføj multiplicity korrekt

1) Tegn opdateret klassediagram i Mermaid
```mermaid
classDiagram
    Order "1" o-- "1" OrderService
    Customer "1" --o "*" Order
    Order "1" --* "*" OrderLine
    OrderLine "1" --o "1" Product

    class OrderService{
        - OrderId : string
        + OrderServer(Database db) OrderServicer
        + createOrder(roduct product, byte quantity) string
        - validateOrder() bool
    }

    class Order{
        - _orderId : string
        - _customer : Customer
        - _orderLines List<OrderLine> 

        + Order(Customer customer) Order
        + Customer GetCustomer() Customer
        + AddOrderLine(Product product, byte quantity) void
        + GetOrderLines() OrderLine[]
        + SetOrderId(string orderId) void
        + GetOrderId() string
    }


    class Customer{
        + MakeOrder(OrderService order, Product product, byte quantity) void
        + GetOrders() OrderService[]
    }


    class OrderLine{
        - _quantity : byte
        -  _product : Product
        + OrderLine(Product product, byte quantity) void
    } 
    
    class Product{
        - _name : string
        - _price : decimal

        + Product(string name, decimal price) void
    }

```

1) Implementér relationerne i C#


# Opgave 3 – Generalization & Realization


Udvid domænet: \
Product kan være:
- PhysicalProduct
- DigitalProduct

Begge skal kunne:

- CalculatePrice()

Ekstra krav:

Digitale produkter har ingen lagerstatus
Fysiske produkter har lagerantal



## Opgave

1) Brug nedarvning korrekt

1) Brug abstrakt klasse eller interface (argumentér for valg). \
Abstrakt klasse, da PhysicalProduct og DigitalProduct har en is-a relation til den abstrakte klasse AProduct. De har ikke en can-do relation til den abstrakte klasse. Så skal de begge to kunne lave en CalculatePrice(), som har samme beregningsgrundlag, men værdierne er forskellige fra de to. 

1) Tegn klassediagram med generalization/realization

```mermaid
classDiagram
    Product "1" o-- "1" DigitalProduct
    Product --> PhysicalProduct

    
    class Product{
        - _name : string
        # _price : decimal
        # _tax : decimal

        + Product() void
        + CalculatePrice() decimal
        + GetName() string
        + SetName(string Name) void
    }

    class PhysicalProduct{
        - _itemsInStock : byte 
    }

```

1) Implementér i C# \
Se koden.

# Opgave 4 – Samlet Model + Designovervejelse

::left::

Tilføj betalingssystem:

1) En Order skal kunne betales

Der findes:

- CreditCardPayment

- MobilePayment

- InvoicePayment



Krav:

1) Alle betalingstyper skal implementere ProcessPayment()

1) Order må ikke kende til konkrete betalingstyper

1) Systemet skal kunne udvides med nye betalingstyper uden at ændre Order

## Opgave

1) Design relationen korrekt (interface eller abstract?) \
Interface da relationen vil være can-do til interfacet. Implementering er også specifik til de enkelte metoder. 

1) Tegn komplet klassediagram med:

    1) Relationer

    1) Multiplicity

    1) Generalization

    1) Realization

```mermaid
classDiagram
    direction TB
    Order --o Pay
    Pay --* CreditCardPayment
    Pay --* MobilePayment
    Pay --* InvoicePayment
    CreditCardPayment --|> IPayment
    MobilePayment --|> IPayment
    InvoicePayment --|> IPayment

    

    class Order{
        - _orderId : string
        - _customer : Customer
        - _orderLines List<OrderLine> 

        + Order(Customer customer) Order
        + Customer GetCustomer() Customer
        + AddOrderLine(Product product, byte quantity) void
        + GetOrderLines() OrderLine[]
        + SetOrderId(string orderId) void
        + GetOrderId() string
    }

    class Pay{
        - _creditCard : CreditCardPayments
        - _mobile : MobilePayment
        - _invoice : InvoicePayment

        + GetPaymentMethod() IPayment
    }

    class IPayment{
        <<interface>>
        + ProcessPayment()
    } 
    
    class CreditCardPayment{
    }

    class MobilePayment{
    }

    class InvoicePayment{
    }


```

1) Implementér designet i C#



Argumentér kort:

- Hvilke OOP-søjler bruges?

- Hvis man laver det forkert, hvilke OOP søjler bryder man så ?
