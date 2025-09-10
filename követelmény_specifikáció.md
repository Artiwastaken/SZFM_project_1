#### Követelmény specifikáció

##### Jelenlegi helyzet: 
A cégünk szeretne egy olyan Google dínós endless runnert csinálni ami felülmúlja a már meglévő játékot. A mostani Google dínót nem találjuk elég jónak ahhoz hogy elterelje a figyelmet arról hogy nincsen internete az embernek. Például nincsenek benne elég izgalmas dologok, többféle akadály vagy ellenfél. A jelenlegi játék színtelen, csak egy score-t mutat amit el se ment. Nem elég immerzívek a játékban a hangok. Csak a sivatagban lehet futni, ez is elég sivár. Egy szó mint száz, szeretnénk egy jobb Google dínó játékot csinálni.

##### Vágyálom rendszer:
Célunk hogy a játékunk kibővüljön azzal az alábbi funkciókkal hogy minden területen felülmúlja az eredeti játékot. Legyen arra képes hogy elmentse a high score-t. Szeretnénk hogy jobbak legyenek a hangeffektek a játékban az erősebb immerziós élmény érdekében, valamint egy hangulatos aláfestő zenét is akarunk a játékunkba. Szándékunkban áll az hogy több "ellenfél" és akadály színesítse a játékot hogy még izgalmasabb legyen. A játék kezdésekor külömböző "biomok" közül lehessen választani. Szeretnénk megtartani az eredeti játékban lévő éj-nappal körforgást mert ez egy fontos ismertetőjegye, valamint ünnepnapokhoz kötött stílusokat hozzáadni a játékhoz. 

##### Jelenlegi játék:
1. 2D endless runner
2. Stílus: pixel art, 8-bit
3. Fekete-fehér
4. Egyszerű akadályok (kaktusz), ellenfelek (madár)
5. Retro, 8-bit hangeffektek
6. Számolja a pontokat de nincs high score mentés
7. A dínó tud: ugrani, lehajolni
8. Monoton játékmenet

##### Igényelt játék:
1. 2D endless runner
2. Stílus: pixel art
3. Színes
4. Többféle akadály és ellenfél
5. Magával ragadó hangeffektek 
6. Atmoszférikus aláfestőzene
7. A dínó tud: ugrani, lehajolni
8. Menürendszer
9. Megállítógomb
10. High score mentés lokálisan
11. Rádiógomb: zenét lehet vele váltani

##### Követelménylista:

| ID | Név | Követelmény | Verzió | Megjegyzések |
|----------|----------|----------|----------|----------|
| K01 | Sprite-ok és general art | A játékban található spriteok és hátterek elkészítése. Karakter, ellenfelek, talaj, háttér, akadályok | 0.1 | Stílus: pixelart. Téma: a dínós játék színes és nagyobb felbontású verziója |
| K02 | Alap játék logika | Karakter mozgatása, az alap játékciklus elkészítése | 0.1 | - |
| K03 | Dizájn | Reszponzív dizájn | 0.4 | A játék igazodjon monitorokhoz, teljesképernyős mód |
| K04 | Felhasználói felület  | Könnyen kezelhető, egyértelmű kialakítású felhasználói felület. Főmenü, Pause menü | 0.5 | - |
| K05 | Optimalizáció | Alacsony erőforrásigény | verziófüggetlen | Az egész folyamat alatt úgy készíteni mindent hogy alacsony erőforrású rendszereket is figyelembe vegyünk. Tesztelés, bétatesztelés |
| K06 | Kiadás | Eléhetővé tétel | 1.0 | Legyen a projekt olyan állapotban, hogy egy megosztott linken keresztül a futtatható játék letölthető legyen |
| K07 | Extra funkciók | Kiadás után a játék frissítése | 1.0+ | Easter egg, több szintes, több életes játékmód, játékrádió |


##### A játékra vonatkozó törvények, szabályok:
MIT licence, a projekt egy hosszútávú támogatottságú játékmotorban készüljön. Használt képformátumok: PNG, JPG, BMP, TGA, ASPERITE, ASE, és TIF.

##### Fogalomszótár:
Biom: Egy különböző tájjal, növényekkel és állatokkal rendelkező területet jelent a játék világán belül (pl. erdő, sivatag, hómező).
Pixel art: egy digitális művészeti stílus, amelyben a képet apró képpontokból (pixelekből) építik fel, és ezeket tudatosan láthatóan „szögletesen” hagyják.
Immerzió: Az immerzív szó azt jelenti, hogy valami annyira magával ragadó vagy valósághű, hogy teljesen belemerülsz az élménybe, mintha benne lennél az adott környezetben vagy eseményben.
High score: Legmagasabb elért pontszám.
Endless runner: Egy videojáték műfaj, amelyben a játékos karaktere folyamatosan halad előre, és a cél az, hogy minél tovább túlélj anélkül, hogy nekiütköznél akadályoknak vagy meghalnál.
8-bit: Játékokban és művészetekben egy retró, pixeles, egyszerű stílust jelöl.