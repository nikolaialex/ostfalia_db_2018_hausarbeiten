# Key-Value-Stores

Bei der Verwendung von relationale Datenbanken werden viele und verhältnismäßig große Tabellen verwendet. Key-Value-Stores lassen sich, verglichen mit den relationalen Datenbanken, wie eine einzige Tabelle mit zwei Spalten vorstellen. Ein einzelner Wert (Value) wird durch einen eindeutigen Schlüssel (Key) identifiziert. Die einzelnen Werte werden vom DBMS als Text betrachtet. Die Validierung der Daten liegt vollständig bei der verwendenden Anwendung. Die einzige Einschränkung ist die durch das DBMS vorgegebene maximale Länge je eingetragenem Wert. [1]



## Foreign Key

Das DBMS speichert sämtliche Keys ohne Zusammenhang. Es erfolgt keine Überprüfung auf das Vorhandensein bestimmter Werte. Hierfür ist einzig und allein die zugreifende Anwendung zuständig. 



## Daten-Änderungen





## Strukturelle Änderungen

Die Struktur der Datenbank kann nicht verändert werden. Die Struktur einzelner Werte wird durch die jeweilige Anwendung vorgegeben. Soll diese Struktur verändert werden, muss eine Migration durch die Anwendung erfolgen. Manche DBMS bieten hierfür eine Versionierung, über die die Migration im laufenden Betrieb durchgeführt werden kann. Der Benutzer sieht noch die alte Version, Änderungen werden aber für die neue Version vorgemerkt.



## Skalierung





## Performance-Vergleich (Fazit)

Im Vergleich zu relationalen Datenbanken ergeben sich folgende, die Performance betreffende Unterschiede:



* 



------

[< Document Stores](Document_Stores.md) | [Column Stores >](Column_Stores.md)

***

```
Quellen

[1]: https://www.pro-linux.de/artikel/2/1455/4,key-value-stores.html
```

***

