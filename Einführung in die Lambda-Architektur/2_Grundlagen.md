## 2. Grundlagen
Sowohl relationale als auch NoSQL Datenbanken arbeiten in der Regel nach dem Prinzip, dass sie bei Aktualisierungsvorgängen die Master-Daten des zu aktualisierenden Datensatzes direkt verändern. Abbildung 2 zeigt diesen Vorgang bei einer klassischen Datenbank. Hier soll die Location des ersten Eintrags geändert werden, was direkt im Master-Datensatz geschieht. Der alte Wert wird einfach überschrieben und kann nicht mehr abgerufen werden.

![Update auf klassischer DB](/images/Update-klassischeDB.png)  
Abbildung 2: Update auf einer klassischen Datenbank [**[HaBi17]**](7_Literaturverzeichnis.md)

Dabei werden die betroffenen Zeilen in der Datenbank blockiert, bis der Vorgang abgeschlossen ist, was bedeutet, dass der entsprechende Datensatz von anderer Stelle aus für diese Zeitperiode nicht bearbeitet werden kann. Je nachdem, wie lange der Aktualisierungsvorgang dauert, kann er die Verfügbarkeit und Performance des Systems stakt ins Negative beeinflussen. [**[Soul14]**](7_Literaturverzeichnis.md)  

Dieser Vorgang wird in der Lambda-Architektur anders gehandhabt. Während klassische Datenbanken bei Aktualisiersvorgängen ihre Master-Daten manipulieren, sind diese bei der Lambda-Architektur nicht veränderbar. Stattdessen wird bei jeder Aktualisierung eine Kopie der Master-Daten erzeugt, mit einem Zeitstempel versehen und an den Master-Datensatz angehängt. Jeder so entstandene Datensatz gilt zu einem bestimmten Zeitpunkt als wahr. Abbildung 3 zeigt den Vorgang bei der Lambda-Architektur. [**[HaBi17]**](7_Literaturverzeichnis.md)  
 
![Update auf Lambda DB](/images/Update-lambdaDB.png)  
Abbildung 3: Update auf einer Lambda-Architektur [**[HaBi17]**](7_Literaturverzeichnis.md)

Die bereits vorhandenen Einträge werden weder geändert noch gelöscht, sodass nicht nur auf den letzten Stand des Datensatzes zugegriffen werden kann, sondern auch auf alle Werte und Veränderungen seit der Erstellung.
Bei entstehenden Fehlern kann das Ergebnis so ganz einfach verworfen und mit Hilfe der alten Daten neu berechnet werden, was das System fehlertolerant gestaltet. [**[Soul14]**](7_Literaturverzeichnis.md)  

[☜ vorheriges Kapitel](1_Einleitung.md)
   |   [nächstes Kapitel ☞](3_Architektur.md)