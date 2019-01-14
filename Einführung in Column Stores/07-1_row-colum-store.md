***

[<< zurück](02_toc.md)

***

# 5. Row Store vs Column Store

In diesem Abschnitt sollen einige Unterschiede von zeilenorientierten Datenbanken und spaltenorientierten Datenbanken
aufgezeigt werden. Dafür betrachten wir die verschiedenen Anwendungsfälle von schreibenden und lesenden Datenbankzugriffen und die Datenstrukturen beider Modellen.

Im Allgemeinen eignen sich Row Stores, oder auch zeilenorientierte Datenbanken gut zum Speichern von Transaktionen, wobei spaltenorientierte Datenbanken eher geeignet sind wenn man große Datenmengen schnell lesen möchte. Dies liegt ander Art wie Festplatten Informationen beim Speichern schreiben. So wird beim  Speichern die Information nacheinander geschrieben, dies bedeutet für zeilenorientierte Datenbanken, dass  immer erst eine komplette Zeile, ein Tupel, geschrieben wird bevor das nächste Tupel geschrieben wird.
 
Beim spaltenorientierten Speichern stehend die zu einer Spalte gehörenden Daten auf der Platte beieinander, so können für Analysen zusammengehörige Daten schneller
gelesen werden.[MG15]

Im Folgenden werden die typischen Arten von Datenbankzugriffen betrachten.
 

***

[<< Performance](06-5_performance.md) | [Datenbankzugriffe >>](07-2_db-access.md)

***

```
Quellenangabe:

[MG15] - Marcel Gladbach, Spaltenorientierte Datenbanken, Hochschule für Technik, Wirtschaft und Kultur Leipzig, Paper, 2015, S.2

```

***