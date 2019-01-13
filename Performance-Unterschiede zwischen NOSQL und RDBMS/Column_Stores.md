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

Das DBMS speichert jede Spalte als eine Seite im Speicher. Anhand der Spaltenangaben sind die Bereiche klar, die gesucht sind. Da die Spalten potenziell die gleichen Daten enthalten, lassen sich die Spalten wesentlich besser komprimieren. Der entscheidende Vorteil ergibt sich hier bei Aggregat-Funktionen, da die betroffenen Daten am Stück gelesen und verarbeitet werden können. Auf der Kehrseite steht jedoch, dass sich Column Stores nicht für das Auslesen einzelner Zeilen eignen. Hierzu müsste nämlich jede Spalte gelesen und eine Zeile konstruiert werden. [1]



## Foreign Key





## Daten-Änderungen

Das Ändern von Daten kann bei Column Stores ein teures Unterfangen werden. Bei neuen Datensätzen muss jede Spalte um einen Eintrag ergänzt werden. Analog dazu bedeutet das Löschen eines Datensatzes den Zugriff auf alle Spalten.



## Strukturelle Änderungen

Eine der großen Stärken von Column Stores besteht in der Änderungsgeschwindigkeit der Datenstruktur. Soll eine neue Spalte hinzugefügt oder eine vorhandene Spalte entfernt werden, muss lediglich die Spalte auf dem Medium gelöscht werden, ohne dass andere Spalten gelesen oder geschrieben werden. In relationalen Datenbanken müsste hier jeder Datensatz gelesen und ohne die gelöschte (bzw. mit hinzugefügter) Spalte erneut geschrieben werden.



## Skalierung

Column Stores folgen der NoSQL-Grundidee der verteilten Datenhaltung, indem (abhängig von der konkreten Implementierung) Hashing-Algorithmen den Zielknoten bestimmen, auf dem die Daten abgelegt werden sollen. [2] Durch die horizontale Skalierung kann das DBMS quasi beliebig skalieren. Auch bei riesigen Datenmengen und aggregierenden Lesezugriffen wird eine sehr hohe Performance geboten. [3]



## Performance-Vergleich (Fazit)

Im Vergleich zu relationalen Datenbanken ergeben sich folgende, die Performance betreffende Unterschiede:



* Gegenüber zeilenbasierten, relationalen Datenbanken liefern sie eine deutlich schlechtere Schreibgeschwindigkeit
* Auf der anderen Seite bieten Column Stores, vor allem beim Aggregieren von Spaltendaten, eine deutlich bessere Performance beim Lesen von Daten
* Durch die getrennte Speicherung der einzelnen Spalten lassen sich Spalten sehr schnell hinzufügen und entfernen, ohne dass benachbarte Spalten verarbeitet werden müssen



------

[< Key-Value-Stores](Key-Value-Stores.md) | [Graphen-Datenbanken >](Graphen-Datenbanken.md)

***

```
Quellen

[1]: https://www.youtube.com/watch?v=4bfX96C5644
[2]: https://www.youtube.com/watch?v=oawc4doC76U
[3]: https://aws.amazon.com/de/nosql/columnar/
```

***

