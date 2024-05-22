# Webová aplikace pro předpověď počasí

## Úvod

### Účel dokumentu

Cílem tohoto dokumentu je nastínit koncept a upřesnit požadavky aplikace pro předpověď počasí. V první části tohoto dokumentu je popsán rozsah a kontext systému, obecný přehled jeho funkcí, charakteristika jeho cílové domény, omezení, předpoklady a závislosti. V druhé části pak vnější rozhraní, podrobnější funkce a popis databáze, softwarové i hardwarové požadavky systému, detailnější rozbor rizik.

### Účel systému

Systém nabízí aplikaci pro předpověď počasí v daném městě skrze webové rozhraní s možností registrace a přihlášení, přičemž pouze přihlášenému uživateli se zobrazují historická data o počasí. Uživatel může měnit město, pro které se předpověď zobrazuje, může sledovat aktuální počasí ve vybraném městě, hodinovou předpověď pro 5 dní a zobecněnou předpověď pro následujících 14 dní. Může se registrovat, případně přihlašovat.

## Obecné požadavky na systém

### Rozsah projektu - obecné funkcionality

- Aplikace s webovým rozhraním - optimalizovaná pro zobrazení na mobilním telefonu, desktopu i tabletu.
- Registrace a přihlašování
- Bez přihlášení
  - Výběr města, pro které se předpověď zobrazuje
  - Zobrazení současného počasí ve vybraném městě
    - Zobrazování teplot, pocitové teploty, slovního popisu počasí, ikony počasí, rychlosti větru, oblačnosti, úhrnu srážek v mm
  - Zobrazení hodinové předpovědi pro dnešek a následující 4 dny
    - Zobrazování teploty, slovního popisu počasí, rychlosti větru, úhrnu srážek
  - Zobrazení zobecněné předpovědi počasí pro následujících 14 dní
    - Zobrazení teploty, slovního popisu počasí, úhrnu srážek
- Po přihlášení
  - Navíc zobrazení historických dat 3 týdny nazpět
    - Zobrazení teploty, slovního popisu počasí, úhrnu srážek

## Uživatelské grafické rozhraní

- Vstupním bodem je hlavní stránka aplikace
  - Dominantní informací je současné počasí v hlavním městě ČR - Praze
  - Nad současným počasím je formulář pro výběr jiného města
  - Pod současným počasím je hodinová předpověď na dnešek a následující 4 dny, kde se předpověď rozbaluje až po kliknutí na dané datum
  - Pod hodinovou předpovědí je zobecněná předpověď na dnešek na následující 2 týdny
- V záhlaví stránky jsou 2 záložky
  - Registrace
    - Registrační formulář s poli pro uživatelské jméno, heslo a zopakování hesla
    - Heslo musí obsahovat alespoň 8 znaků a zároveň jedno číslo
  - Přihlášení
    - Přihlašovací formulář s poli pro uživatelské jméno a heslo
- Po přihlášení jsou uživateli zobrazena pod obecnou předpovědí počasí na příští 2 týdny i historická data 3 týdny nazpět formou obdobnou, jako je zobrazována obecná předpověď

## Chování systému

- Když se aplikaci z jakéhokoli důvodu nepodaří načíst data, je tato skutečnost uživateli sdělena hláškou
- Náležitá hláška je uživateli zobrazena když se nepodaří registrace nebo přihlášení
  - Zadání chybných hodnot v přihlašovacím formuláři - zobrazení hlášky o zadání chybných hodnot a umožnění zadání hodnot znovu
    - Za chybné hodnoty je považováno uživatelské jméno, pro které neexistuje účet, zadání chybného hesla
- Po přihlášení je uživatel informován, že nyní jsou mu historická data dostupná
- Ztráta internetového připojení - aplikace se uživateli nezobrazí, proto nemusí být tato informace uživateli nijak sdělována

## Kontext projektu

- Aplikace s webovým rozhraním určená pro použití na mobilních telefonech, tabletech i desktopech, nezávislá na operačním systému
- Aplikace je určena pro individuální, základně poučené uživatele

## Omezení, předpoklady, závislosti

- Pro správnou funkci aplikace je nutný přístup k internetu
- Předpokladem je nainstalovný vhodný internetový prohlížeč - není zaručena správná funkce na starších a jiných prohlížečích, než jsou prohlížeče s jádrem Chromium verze 112.0.5615
- Aplikace není vhodná pro uživatele se zrakovou, nebo jinou indispozicí znemožňující pohodlnou práci s běžným webovým rozhraním

## Využité technologie

- ASP .NET 7.0 s Razor Pages
- Apache server
- [OpenWeather](https://openweathermap.org/)

## Popis databáze

- Seznam měst ve formátu JSON
  - Id - celé číslo
  - Jméno - řetězec
  - Stát - zkratka - řetězec
  - Oblast - řetězec
  - Souřadnice - šířka a délka - číslo s plovoucí desetinnou čárkou
- Seznam uživatelů ve formátu JSON s jejich přihlašovacími údaji
  - Uživatelské jméno a heslo - řetězce

### Požadavky na hostitelský server

- 64-bit x86 CPU
- 1 GB RAM
- až 3 GB paměti na pevném disku
- operační systém preferovaný CentOS/RHEL 7.2+ nebo Ubuntu 16.04(.2) a vyšší

## Další rizika

- Když nebude API na OpenWeather z jakéhokoli důvodu dostupné, aplikace nebude fungovat
- Když jakkoli změní endpointy OpenWeather, aplikace bude vyžadovat úpravu

## Další poznámky

- Frontendová aplikace komunikuje s několika různými API
- Aplikace získává čerstvá data z api po každém načtení hlavní stránky nebo odeslání formuláře
- databáze měst obsahuje zhruba 20 tisíc položek z celého světa - rozlišení měst
- informace o očekávaném formátu dat poskytovaných od OpenWeather jsou k nalezení v dokumentaci této služby
- aplikace je umístěna na [Heroku](https://heroku.com/)

## Časové rozvržení

- Definice problematiky a definice prostředků - 1 týden
- Prototyp - 2 týdny
- Sestavení aplikace - 2 týdny
- Testování aplikace - 3 týdny
- Nasazení a případné úpravy - 2 týdny
