Eventuel flytte dette dokument over i jeres eget repo.

# Del 1 – Systemoverblik

Design et simpelt system med følgende komponenter:

- Order
- Payment
- Logger
- Storage
- PaymentSystem

Lav et klassediagram der viser systemets struktur.

# Del 2 – Singleton

Systemet skal have en Logger, som bruges til at logge:
- betalinger
- fejl
- ordreoprettelser

Der må kun eksistere én logger i systemet.

## Opgave

1) Design en Logger klasse.
1) Implementer den som Singleton.
1) Brug loggeren i mindst én anden klasse.

# Del 3 – Factory

Systemet skal kunne håndtere forskellige betalingsmetoder:
- CreditCard
- PayPal
- MobilePay

## Opgave

1) Lav et interface:
1) Implementer mindst to betalingstyper.
1) Lav en PaymentFactory, som opretter korrekt betalingstype.

# Del 4 – Adapter

Systemet skal integrere et nyt betalingssystem, som ikke passer til jeres IPayment interface.

Det nye system har følgende metode:

## Opgave

1) Lav en Adapter, så systemet kan bruge ExternalPayment.
1) Adapteren skal implementere IPayment.

# Del 5 – Facade

Systemet skal have en simpel indgang til ordrebehandling.

I stedet for at klienten selv skal kalde:
- payment
- logger
- storage

skal der laves en Facade.

## Opgave

Facaden skal:

1) vælge betalingsmetode via Factory
1) gennemføre betaling
1) logge resultatet
1) gemme ordren