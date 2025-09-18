## User Story: Offline dínós játék indítása és játszása

Mint internetkapcsolat nélküli felhasználó (pl. János bácsi), szeretném, hogy a Chrome böngészőben a dínós játék automatikusan elérhető legyen, és a szóköz megnyomásával azonnal el tudjam indítani, hogy kapcsolat nélkül is szórakozhassak, amíg az internet helyreáll.

### Elfogadási kritériumok (Given/When/Then)
- Given: Nincs internetkapcsolat, a felhasználó megnyitja a Chrome-ot és egy `ERR_INTERNET_DISCONNECTED` hibát lát dínó ikonnal.
	When: A felhasználó megnyomja a `Space` vagy `Fel nyíl` billentyűt.
	Then: A játék teljes képernyős sávban elindul, a dínó futni kezd, és megjelenik a pontszámláló 0-ról indulva.

- Given: A játék fut és kaktusz akadály közeledik.
	When: A felhasználó megnyomja a `Space` vagy `Fel nyíl` billentyűt.
	Then: A dínó ugrik, és ha sikerül elkerülni az akadályt, a pontszám növekszik.

- Given: A játék fut és repülő pterodaktilus közeledik különböző magasságon.
	When: A felhasználó megnyomja a `Le nyíl` billentyűt.
	Then: A dínó leguggol, és elkerüli az ütközést.

- Given: A dínó akadályba ütközik.
	When: Ütközés történik.
	Then: A játék véget ér, megjelenik a Game Over felirat és a végső pontszám; `Space` megnyomásával újrakezdhető.

- Given: Hosszabb ideje fut a játék.
	When: A sebesség idővel növekszik és a háttér nappal/éjszaka váltakozik.
	Then: A játékmenet fokozatosan nehezedik, a pontszám folyamatosan nő, és 100 pontonként hangjelzés hallható (ha engedélyezett).

### Nem funkcionális követelmények
- Teljesítmény: Indítás billentyűre < 100 ms késleltetéssel reagál.
- Hozzáférhetőség: Billentyűvezérlés működik egér nélkül; kontraszt megfelelő.
- Stabilitás: A játék hibamentesen újraindítható Game Over után.
- Offline: Internetkapcsolat nélkül is elérhető a hibaképernyőről.

### Megjegyzések
- Támogatott billentyűk: `Space`, `Fel nyíl` (ugrás), `Le nyíl` (guggolás).
- Cél: Rövid, casual élmény várakozás közben; nem igényel beállítást.
