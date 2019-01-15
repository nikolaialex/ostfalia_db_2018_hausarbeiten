***

[<< zurück](02_toc.md)

***

# 5.3. Datenstruktur
Zeilenorientierte Datenbanken haben eine normalisierte Datenstruktur, dies bedeutet in jeder Tabelle gibt es eine feste Struktur, welcher Datentyp in welcher Spalte gespeichert werden darf. Durch die Normalisierung können Schreiboperationen schneller ausgeführt werden. Spaltenorientierte Datenbanken haben eine denormalisierte Datenstruktur, dies bedeutet das in einer Spalte verschiedene Datentypen und Datenstrukturen gespeichert werden können. Durch die Denormalisierung kann die Notwendigkeit von JOINS reduziert werden, und somit können Abfragen schneller verarbeitet werden. Spalten in denen Spalten gespeichert werden nennt man Column Family.[RSRG16]


Wenn wir zum Beispiel in einer zeilenorientierten Datenbank ein Kundensystem für ein Zeitungsabonnement abbilden wollen, haben wir eine Tabelle für alle Kunden die eine bestimmte Form von Abonnement haben. Es gibt in diesem Beispiel die Abonnements “Premium, Student, Test”. Des Weiteren gibt es eine Tabelle mit den registrierten Kundendatensätzen, eine Tabelle mit der Zuordnung welcher Kunde welches Abonnement hat. In der Abonnementtabelle steht die Information wie lang jeder Abonnementtyp läuft. Es könnte auch noch eine Tabelle geben, welche die zusätzlichen Einkäufe zum Abonnement erfasst, diese lassen wir aber für unser Beispiel ausser Betracht. 
Die folgenden Abbildungen 11-13 in diesem Abschnitt zeigen die zum Beispielfall gehörigen Datenbanktabellen. Die Tabellen sind vereinfacht dargestellt und würden in der Praxis eher noch Referenzen zu Geodatenbanken etc. haben, für unser Beispiel reicht jedoch jeweils eine Tabelle mit Kundendaten, den angebotenen Abonnementformen und der Zuordnung welcher Kunde welches Abonnement hat. Dies erfolgt über eine Aggregationstabelle von kundenId zu aboId.


 _Skizzenhafter Aufbau für das Beispiel eines Zeitungsabos in einem zeilenorientierten Datenbanksystem:_



![Kundendaten](files/KundendatenRow.PNG)   
Abbildung 11: Beispiel Kundentabelle für Anwendungsfall "Zeitschriften Abo"  </br>


![Abonnementarten](files/AbonnementArten-Row.PNG)   
Abbildung 12: Beispiel Abonnementtabelle für Anwendungsfall "Zeitschriften Abo"  </br>


![Aggregation](files/AggregationRow.PNG)   
Abbildung 13: Beispiel Aggregationstabelle Kunde zu Abonnement  </br>


Wird die Information benötigt, wann das Abonnement des Kunden mit der `kundenId = 2` ausläuft benötigt man zwei Werte zur Berechnung des Enddatums. Aus der Kundentabelle das Startdatum des Abonnements und aus der Abonnementtabelle die Laufzeit. Hierfür muss erst die Aggregationstabelle gefragt werden welches Abonnement der Kunde mit der `ID 2` hat. Mit der erhaltenen `aboId = 1` kann nun die Standard Laufzeit des Abonnements (hier: 3 Monate) ausgelesen werden. Dann muss in der Tabelle Kundendaten auf das komplette Tupel zur `kundenId = 2` abgefragt werden, um das Startdatum auszulesen. Nun kann aus _Startdatum + Laufzeit_ berechnet werden, dass der Vertrag zum 01.02.2019 ausläuft.  
Für diesen Anwendungsfall ist ein zeilenorietniertes Datenbanksystem gut geeignet.

In einer spaltenorientierten Datenbank könnten die Daten wie ind er folgenden _Abbildung 14_ strukturiert sein:

![Spaltendarstellung](files/spaltendarstellung.PNG)   
Abbildung 14: Beispiel Variante Spaltendarstellung für Anwendungsfall "Zeitschriften Abo"  </br>

Hier gibt es fünf Spalten in der fünf verschiedene Informationen gespeichert sind. Der Index stellt die kundenId dar, für unser Beispiel ist also jeweils die 2. Zeile relevant. Die benötigten Werte zur Berechnung des Enddatums können mit einem Zugriff auf nur zwei Spalten ausgelsen werden, die Spalte _"AboStartdatum"_ und die Spalte _"Laufzeit"_. Die Datensätze zu Name, Vorname und Adresse werden nicht benötigt und daher muss auf die entsprechenden Dateien nicht zu gegriffen werden, es werden nur relevante Spalten abgefragt.  
Einen wirklichen Vorteil bietet dies, wenn das Unternehmen beispielsweise herausfinden möchte, wann die meisten Verträge geschlossen werden und von welcher Abonnementart diese sind.

Es könt auch in einer spaltenorientierten Datenbank eine einzige Tabelle die Informationen mit den Kundendaten und den Einkäufen abbilden, da die Keys auch frei vergeben werden können.
Die Normalisierung der Daten, die feste Struktur, macht es in zeilenorientierten Datenbanken schneller Daten zu aktualisieren, da man dann beim Aktualisieren von Kundendaten nur an einer Stelle ändern muss und alle anderen Transaktionen beziehen sich die Aktualisierung aus der einen Zelle. In der spaltenorientierten Datenbank würde man die Kundendaten zusammen mit den zusätzlichen Einkäufen speichern und müsste dann um beispielsweise die Adresse zu aktualisieren, an mehreren Stellen die Aktualisierung vornehmen.


Man kann auch in einer zeilenorientierten Datenbank Datenanalysen machen. Diese Analyse läuft im Zweifel nur langsamer, als sie in einer spaltenorientierten Datenbank brauchen.  
Wenn nur einige wenige Felder einer Wide Table Datenstruktur gebraucht werden sind spaltenorientierte Datenbanken das Richtige. Sie sollten jedoch nicht für normale Online Transactional Processing (OLTP) verwendet werden. Will man etwas wie `SELECT * FROM TABLE` machen, dann ist eine spaltenorientierte Datenbank, bei der alle Tabellenspalten in separate Dateien gespeichert werden, nicht geeignet, da man auf unzählige Dateien zugreifen muss, um die Abfrage auszuführen. Für Dienste die Online Analytical Processing (OLAP) Anwendungen unterstützen sollen, bieten spaltenorientierte Datenbanken in Verbindung mit den in Abschnitt 4.4 beschriebenen Kompressionsverfahren eine hohe Performancesteigerung [MG15]






***

[<< Datenbankzugriffe](07-2_db-access.md) | [Anwendungsbeispiele >>](08_use_cases.md)
***

```
Quellenangabe:

[MG15] - Marcel Gladbach, Spaltenorientierte Datenbanken, Hochschule für Technik, Wirtschaft und Kultur Leipzig, Paper, 2015, S.3 ff
[RSRG16] R. Gobla, https://dzone.com/articles/row-store-and-column-store-databases, aufgerufen 22.12.18 

```

***