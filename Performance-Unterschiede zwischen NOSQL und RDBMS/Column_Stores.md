# Column Stores

Column Stores sind relationalen Datenbanken sehr ähnlich. Der Name deutet bereits an, dass der große Unterschied die Struktur betrifft. Dies soll an der folgenden Tabelle veranschaulicht werden.

| Matrikelnummer | Name             | Credit Points |
| -------------- | ---------------- | ------------- |
| 123456789      | Max Mustermann   | 30            |
| 234567890      | Erika Musterfrau | 60            |
| 345678901      | Peter Lustig     | 120           |

Speichermedien sind sequentiell aufgebaut, wobei das DBMS die Startpunkte der jeweiligen Zeile kennt. Relationale Datenbanken arbeiten zeilenbasiert. Die Tabelle wäre in folgender Form gespeichert:

```
123456789,Max Mustermann,30,234567890,Erika Musterfrau,60,345678901,Peter Lustig,120
```

Werden nur die Spalten Matrikelnummer und Credit Points benötigt, muss trotzdem der Name verarbeitet werden, da das DBMS nur am Stück arbeiten kann. In spaltenbasierten Datenbanken erfolgt die Speicherung stattdessen jeweils für eine Spalte. Die Datenstruktur verändert sich dabei wie folgt:

```
123456789,234567890,345678901,Max Mustermann,Erika Musterfrau,Peter Lustig,30,60,120
```

Das DBMS kennt hierbei die Startadressen der Zeilen. Anhang der Spaltenangaben sind die Bereiche klar, die gesucht sind. Da die Spalten potenziell die gleichen Daten enthalten, lassen sich die Spalten wesentlich besser komprimieren. Der entscheidende Vorteil ergibt sich hier bei Aggregat-Funktionen, da die betroffenen Daten am Stück gelesen und verarbeitet werden können. Auf der Kehrseite steht jedoch, dass sich Column Stores nicht für das Auslesen einzelner Zeilen eignen. Hierzu müsste nämlich jede Spalte gelesen und eine Zeile konstruiert werden. [1]



## Foreign Key



## Daten-Änderungen



## Strukturelle Änderungen



## Skalierung





## Performance-Vergleich (Fazit)

Im Vergleich zu relationalen Datenbanken ergeben sich folgende, die Performance betreffende Unterschiede:



* 



------

[< Key-Value-Stores](Key-Value-Stores.md) | [Graphen-Datenbanken >](Graphen-Datenbanken.md)

***

```
Quellen

[1]: https://www.youtube.com/watch?v=4bfX96C5644
```

***

