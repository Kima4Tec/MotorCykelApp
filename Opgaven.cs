//Opgave C# -  Klassen Motorcycle

//Opret følgende klasse Motorcycle og afprøv ved at oprette et motorcycle-objekt, benytte de forskellige ressourcer og udskrive i forskellige tilstande. 

//Fields
//   started 	– af typen boolean
//   rpm		- heltal
//   gear		- heltal, kan være 0-5
//   name		- tekst

//Constructors
//En constructor, der ikke modtager nogen parametre, og sætter den nye motorcycle til at have intet navn, være stoppet, rpm til 0 og gear til 0.
//En constructor, der modtager navn som string og en bool om den er startet. Hvis startet skal rmp være 1000, ellers skal rmp være 0. Gear skal være 0.

//Properties
//Name
//Henter og bringer til field name

//Metoder
//setRpm()/getRpm()
//Med denne skal omdrejninger kunne sættes og hentes. Omdrejningerne kan kun sættes hvis motor er startet. Omdrejninger må ikke komme over 8000 og hvis de kommer under 1000 skal motor stoppes.

//isStarted()
//Som returnerer værdien af attributten started.

//start()
//Hvis motoren ikke er startet, skal den sætte motoren til startet, omdrejninger til 1000 og gear til 0.

//stop()
//Skal sætte motor til stoppet , omdrejninger til 0 og gear til 0.

//getSpeed()
//Skal returnere hastigheden som omdrejninger * gear / 200.

//shiftGearsUp()
//Skal forøge gearet med 1 hvis det er under 5 og motoren er startet.

//shiftGearsDown(int g)
//Skal geare ned til det angivne, hvis g er lavere end det aktuelle gear, og gear er højere end 0.

//getGear()
//Skal returnere det aktuelle gear.

//toString()
//Skal returnere tekst med samlede oplysninger inkl. hastighed.
