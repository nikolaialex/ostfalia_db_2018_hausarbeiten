***

[<< zurück](02_toc.md)

***

# Datenbankzugriffe

## 5.1 Schreibende Datenbankzugriffe

Es gibt verschiedene Arten von Intentionen schreibend auf eine Datenbank zu zugreifen. Neben dem Einfügen komplett neuer Daten, kann es auch nötig sein einzelne Werte zu aktualisieren oder gar die Tabellenstruktur zu verändern.

### 5.1.1. Einfügen eines neuen Datensatzes
Einen neuen Datensatz einzufügen ist in einer zeilenorientierten Datenbank einfacher, da hier nur ein neues Tupel an die Tabelle an gehangen werden muss. In einer spaltenorientierten Datenbank muss man wahrscheinlich viele Dateien öffnen und schreiben. Hier werden in der Realität oft ganze Stapel (Bulk Loads) auf einmal verarbeitet.[MG15]

### 5.1.2. Update eines Wertes
Um einen Wert zu aktualisieren muss man in einer zeilenorientierten Datenbank nur den Wert an einer Stelle ändern. In einer spaltenorientierten Datenbank muss man die verschiedenen Dateien öffnen, suchen und dann den entsprechenden Wert überschreiben. Dies lässt sich ebenfalls durch eine Stapelverarbeitung eines UPDATE optimieren.[MG15]

### 5.1.3. Update einer Spalte
Um in einer zeilenorientierten Datenbank eine Spalte zu ändern muss man diese Suchen und in jedem Tupel der Tabelle ändern. Dabei  bietet die spaltenorientierte Datenbank den Vorteil, dass nur die einzelne Datei der betroffenen Spalte aktualisiert werden muss.[MG15]

### 5.1.4. Änderung der Tabellenstruktur
In einer zeilenorientierten Datenbank ist eine Änderung der Tabellenstruktur nur aufwendig möglich. In der spaltenorientierten Datenbank wird einfach eine neue Datei für die hinzukommende Spalte angelegt, wobei diese auch nicht an eine feste Objektart gebunden ist.[MG15]


## 5.2. Lesender Datenbankzugriff
Um transaktionale Operationen auszuführen oder einzelne komplette Datensatzes zu lesen sind spaltenorientierte Datenbanken nicht geeignet, da hier in jeder Datei gesucht werden muss. Hier bietet die zeilenorientierte Datenbank den Vorteil, dass mit einem Zugriff das gesamte Tupel ausgelesen werden kann, wenn ein Index vorhanden ist. Sollte der Index nicht vorhanden sein, muss die gesamte Tabelle durchsucht werden. 
Die Anzahl an Raw Bytes, die in spaltenorientierten Datenbanken benötigt werden sind im Vergleich zur zeilenorientierten Datenbanken ziemlich hoch, daher liegen die Daten, wie in “Kapitel 4 Datenmodell” bereits erwähnt komprimiert auf Platte vor.

Beim Auslesen vieler Datensätze (Aggregation), wobei nur wenig Spalten relevant sind, werden in einer spaltenorientierten Datenbank nur die entsprechenden Dateien gelesen und damit die I/O Zeiten reduziert. In zeilenorientierten Datenbanken muss die gesamte Tabelle gelesen werden, auch wenn nur die Werte aus zwei Spalten der Tabelle benötigt werden.[RSRG16]



***

[<< Row Store vs Column Store](07-1_row-colum-store.md) | [Datenstruktur >>](07-3_normalized_data_structure.md)

***

```
Quellenangabe:

[MG15] - Marcel Gladbach, Spaltenorientierte Datenbanken, Hochschule für Technik, Wirtschaft und Kultur Leipzig, Paper, 2015, S.3 ff
[RSRG16] R. Gobla, https://dzone.com/articles/row-store-and-column-store-databases, aufgerufen 22.12.18 

```

***

