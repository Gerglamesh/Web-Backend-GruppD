**4/27**

vi började med att skapa en repo för oss alla som heter web-backend-gruppD

sen började vi planera api vilka frågor vi skulle ställa. Vi började med att brainstorma massa frågor och sen valde vi dom bästa.

Sen delade vi upp vilka tabeller vi skulle ha och hur många beroende på frågorna. Vi använde draw.io för att skissa upp tabeller och relationer mellan dom.

Vi började efter lunch med att skriva get request. Därefter började vi med crc card

**4/28**

Vi lärde oss hur man använder olika branch i git. sedan gjorde vi klart våra user stories och så ändrade vi get dokumentet till plural. Vi gjorde också klart exempel på json filer som vi kan använda oss av. Därefter fick vi inspiration av en annan grupp så vi bestämde oss för att göra om våran get request dokumentation och våra user stories mer tydligare för att göra det lättare att använda sen .

**4/29**

Vi började med att testa jira för att förstå programmet.  Sen började vi med att skriva riktiga backlog som vi behövde göra klart och även det vi redan var klara med. Vi kollade även på repetitions video.

**4/30**

Vi började med att skriva daliy stand up som är en slags planering för vad vi skulle göra idag.
Sen följde vi planeringen bara och gjorde klart det vi skulle göra klart tsm i grupp som var:

att skapa en sprint på jira och
sen sätta upp development enviroment 

sen planerade och gjore klart vad vi skulle göra i mindre grupper som var:

ställa in local environment variables
skapa en controller prototyp
skapa en  Repo prototyp
skapa en Model prototyp
ställa in DbContex  prototyp i EF Core

**5/5**

Började dagen med att göra en första stand-up som mest gick ut på att planera vad vi gemensamt behövde göra inför sprinten. Vi var medvetna om att vi skulle behöva göra en stand-up till senare när vi startade sprinten. 

Vi skapade dokument med arbetsdagsschema, regler för hur arbetsflödet ska se ut samt för hur man får committa kod. 

Vi skapade även vår första riktiga sprint i det riktiga projektet.

Efter detta gjorde vi en ny stand-up och fördelade ut issues som vi skulle arbeta med under dagen. Första sprinten satt med fredag 16:30 som slutdatum.

Dagen flöt på bra och vi har hunnit med att göra nästan alla issues. Vi har även lärt oss mycket bra saker om arbetsflöde samt om hur vi ska hantera git och pull requests i gitHub.

All kod har det gjorts pull request på innan merge till master och all kod har review:ats och godkänts innan den merge:ats.

##### 6/5

Började dagen med lektion.

Färdigställde våran föregående sprint.

Hade Standup med +Joakim.

Startade en ny sprint men nya issues.

Gjorde klart några issues och det flöt på bra.

Studerande även Git Bash en stund.

Vi alla har gjort kod-reviews och har mergat det. Tutti för idag.

**7/5**

Dagens uppgifter har kretsat mycket kring sådant vi ännu inte riktigt ordentligt gått igenom ännu.

Vi har försökt oss på att skapa get requests hela vägen genom repo och controller. 

Vi har försökt att skapa DTO.

Inget av detta är helt klart ännu men vi har fått värdefulla inblickar i vad det handlar om och kommit en bit på vägen.

Vi har även finslipat koden och testat att öra en första migration med testdata. Det fungerar inte riktigt heller ännu men även där är vi en god bit påväg.


**13/5**

Vi har missat att skriva dagbok de senaste 4-5 dagarna men här kommer en summering:

VI har börjat med en ny sprint och finslipat metoderna och klasserna.

Vi har utökat funktionaliteten i projektet genom att lägga till get requests där det behövs (i både repon och controllers).

Vi har reviderat om CountryInfo och TravelRestrictions verkligen behöver ha egna get metoder då de inte är intressanta annat än när de paras ihop med ett land. Svaret blir att de inte kommer ha get requests då vi ej ser att det fyller någon funktion i dagsläget.

En generisk klass har skapats för CRUDs som våra repon ärver av.

En logger har implementerats i våra repon.

Vi har lärt oss hur man matar in data i httpGET för att differensiera mellan olika frågeställningar i controllern (alltså hur man anropar de olika metoderna med hjälp av URL).

Vi har ännu inte gått igenom hur man skapar DTO:er så vi avvaktar med det sålänge.

Vi har börjat skapa tester för repon med mocks och testdata i xUnit.

Vi har gjort några bugfixar, bland annat att vi hade problem med hur vår app hämtade rätt connection string.

**14/5**

Vi började med att skriva daliy stand up som är en slags planering för vad vi skulle göra idag.
Sen följde vi planeringen bara:

vi alla i gruppen höll på med unit tester hela/nästan hela dagen och vi alla blev klara med dom
