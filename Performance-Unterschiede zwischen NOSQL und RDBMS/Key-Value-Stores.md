# Key-Value-Stores

Bei der Verwendung von relationale Datenbanken werden viele und verhältnismäßig große Tabellen verwendet. Key-Value-Stores lassen sich, verglichen mit den relationalen Datenbanken, wie eine einzige Tabelle mit zwei Spalten vorstellen. Ein einzelner Wert (Value) wird durch einen eindeutigen Schlüssel (Key) identifiziert. Die einzelnen Werte werden vom DBMS als Text betrachtet. Die Validierung der Daten liegt vollständig bei der verwendenden Anwendung. Die einzige Einschränkung ist die durch das DBMS vorgegebene maximale Länge je eingetragenem Wert. [1]

Eine Beispiel-Struktur in einer relationalen Datenbank könnte wie folgt aussehen:

| Matrikelnummer | Name           | Credit Points |
| -------------- | -------------- | ------------- |
| 123456789      | Max Mustermann | 10            |

In einem Key-Value-Store gibt es nur einzelne Schlüssel. Sollen die Attribute eines Objekts gespeichert und später wieder zu einem Objekt rekonstruiert werden können, muss der Schlüssel entsprechend gewählt sein. Hierfür wird der Primärschlüssel mit dem Namen des jeweiligen Feldes kombiniert. Hieraus ergibt sich folgende Struktur:

| Key                     | Value          |
| ----------------------- | -------------- |
| 123456789;Name          | Max Mustermann |
| 123456789;Credit Points | 10             |



## Foreign Key

Das DBMS speichert sämtliche Keys ohne Zusammenhang. Es erfolgt keine Überprüfung auf das Vorhandensein bestimmter Werte. Hierfür ist einzig und allein die zugreifende Anwendung zuständig. 



## Daten-Änderungen

In einem Key-Value-Store lassen sich die vorhandenen Daten einfach durch Angabe des Keys und des neuen Werts aktualisieren. Bei der Verwendung mehrerer Knoten wird die Änderung nur am aktuellen Zielknoten geschrieben und erst anschließend auf die anderen Knoten (abhängig vom verwendeten Verteilsystem und Hashing-Algorithmus) verteilt. [2]



## Strukturelle Änderungen

Die Struktur der Datenbank kann nicht verändert werden. Die Struktur einzelner Werte wird durch die jeweilige Anwendung vorgegeben. Soll diese Struktur verändert werden, muss eine Migration durch die Anwendung erfolgen. Manche DBMS bieten hierfür eine Versionierung, über die die Migration im laufenden Betrieb durchgeführt werden kann. Der Benutzer sieht noch die alte Version, Änderungen werden aber für die neue Version vorgemerkt. [3]



## Skalierung

Key-Value-Stores sind auf die Verteilung der enthaltenen Werte ausgelegt. Anhand bestimmter Hashing-Algorithmen erfolgt die redundante Verteilung der Daten auf verschiedene Knoten. Die Verteilung skaliert mit der Anzahl der Knoten, wodurch sich die Lese-Leistung quasi beliebig steigern lässt. Die Kehrseite hiervon ist, dass das Ändern oder Löschen der Daten mit steigender Knotenzahl entsprechende Zeit benötigt.



## Performance-Vergleich (Fazit)

Im Vergleich zu relationalen Datenbanken ergeben sich folgende, die Performance betreffende Unterschiede:



* Da das Lesen eines einzelnen Werts bereits verteilt auf die Knoten ausgeführt wird, sind einzelne Lesezugriffe entsprechend schnell
* Die Verteilung von Änderungen kann abhängig von der Knotenzahl sehr langsam werden
* Wenn mehr als ein Wert (etwa für ein ganzes Objekt) benötigt wird und der Key-Value-Store nicht wie ein Document Store betrieben wird, sind ggf. sehr viele Lesezugriffe notwendig



------

[< Document Stores](Document_Stores.md) | [Column Stores >](Column_Stores.md)

***

```
Quellen

[1]: Schnelle, Jochen; unter https://www.pro-linux.de/artikel/2/1455/4,key-value-stores.html (abgerufen am 13.01.2019)
[2]: Preuss, Thomas; unter https://www.youtube.com/watch?v=_fw0I5SmR0Y (abgerufen am 13.01.2019)
[3]: Begerow, Markus; unter http://www.datenbanken-verstehen.de/lexikon/key-value-datenbanksysteme/ (abgerufen am 13.01.2019)
```

***

