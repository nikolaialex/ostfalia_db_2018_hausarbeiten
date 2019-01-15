## 2. Grundlagen
Sowohl relationale als auch NoSQL Datenbanken arbeiten in der Regel nach dem Prinzip, dass sie bei Aktualisierungsvorgängen die Master-Daten des zu aktualisierenden Datensatzes direkt verändern. Abbildung x zeigt diesen Vorgang bei einer klassischen Datenbank. Hier soll die Location des ersten Eintrags geändert werden, was direkt im Master-Datensatz geschieht. Der alte Wert wird einfach überschrieben und kann nicht mehr abgerufen werden.

![Alt-Text](/images/Update-klassischeDB.png)[3] 

Dabei werden die betroffenen Zeilen in der Datenbank blockiert, bis der Vorgang abgeschlossen ist, was bedeutet, dass der entsprechende Datensatz von anderer Stelle aus für diese Zeitperiode nicht bearbeitet werden kann. Je nachdem, wie lange der Aktualisierungsvorgang dauert, kann er die Verfügbarkeit und Performance des Systems stakt ins Negative beeinflussen. [1]  

Dieser Vorgang wird in der Lambda-Architektur anders gehandhabt. Während klassische Datenbanken bei Aktualisiersvorgängen ihre Master-Daten manipulieren, sind diese bei der Lambda-Architektur nicht veränderbar. Stattdessen wird bei jeder Aktualisierung eine Kopie der Master-Daten erzeugt, mit einem Zeitstempel versehen und an den Master-Datensatz angehängt. Jeder so entstandene Datensatz gilt zu einem bestimmten Zeitpunkt als wahr. Abbildung x zeigt den Vorgang bei der Lambda-Architektur. [3]  
 
![Alt-Text](/images/Update-lambdaDB.png)[3]  

Die bereits vorhandenen Einträge werden weder geändert noch gelöscht, sodass nicht nur auf den letzten Stand des Datensatzes zugegriffen werden kann, sondern auch auf alle Werte und Veränderungen seit der Erstellung.
Bei entstehenden Fehlern kann das Ergebnis so ganz einfach verworfen und mit Hilfe der alten Daten neu berechnet werden, was das System fehlertolerant gestaltet. [1]

[☜ vorheriges Kapitel](1_Einleitung.md)
   |   [nächstes Kapitel ☞](3_Architektur.md)