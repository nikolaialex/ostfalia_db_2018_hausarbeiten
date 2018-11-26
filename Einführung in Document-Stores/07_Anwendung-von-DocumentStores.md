# 5. Anwendung von Document-Stores

Im Folgenden sind Beispiele aufgeführt, bei denen Document Stores zur Anwendung kommen.

## 5.1 Benutzerprofile

Ein Benutzerprofil hat meist eine Reihe von Attributen, jedoch kann die Menge der vorhandenen Attribute von Benutzer zu Benutzer variieren. Zum Beispiel werden einige Benutzer das Geburtsdatum nicht zur Verfügung stellen, andere möglicherweise keine politische Zugehörigkeit offenbaren, usw. Diese Attribute werden dann beim Neuanlegen erst gar nicht zugewiesen. Zudem gibt es in der heutigen Zeit immer mehr Informationen, die Profilen nachträglichen hinzugefügt werden, was es quasi unmöglich macht, ein vordefiniertes Schema zu benutzen. Benutzer in Twitter werden dann z.B. in einer dokumentenorientierten Datenbank gespeichert, in der jedes Dokument das Profil und einige aktuelle Tweets der entsprechenden Benutzer enthält. [1]

## 5.2 Produkt/Katalog Daten

Dokumentorientiere Datenbanken kommen auch dann zum Einsatz, wenn es darum geht komplizierte Produktinformationen abzubilden. Bestehen Produkte zum Beispiel wiederum aus einer Anzahl von Produktkomponenten und gibt es zusätzlich noch mehrere Hersteller, oder andere individuelle Attribute, die nicht bei jedem Produkt zu finden sind, lässt sich die gesammelte Information am besten in Document Stores abspeichern. [1]

## 5.3 Geoinformationsdaten

Geoinformationsdaten liefern Informationen zu einem Standort in Form von Werten der Latitude und Longitude. MongoDB beispielsweise hat eigene spezifische Geoinformationsfeatures. Diese können zum Einsatz kommen, wenn z. B. die Distanz einer Bike Tour abgerufen, oder gespeichert werden soll. [1]

## 5.4 Speichern von Gesprächsverläufen

In den letzten zehn Jahren wurden Exabytes an sozialen Daten generiert. Document Stores leisten gute Arbeit, wenn es darum geht, massive Datenmengen von Gesprächsverläufen auf sozialen Kanälen oder ähnlichen abzuspeichern und diese Last zu bewältigen. [1]

## 5.5 IoT

Beim IoT (Internet of Things), bezieht sich die Anwendung nicht direkt auf dokumentorientierte Datenbanken, sondern allgemeiner auf NoSQL Datenbanken, die im Bereich IoT, aufgrund von Performance und Kostengründen, hohe Beliebtheit erfahren. IoT-Applikationen sind darauf angewiesen Prozesse mit großen Datenvolumen durchzuführen. Dies erfordert eine schnelle und kostengünstige Skalierbarkeit und ist somit nur mit neuen BigData Technologien wie MongoDB durchzuführen. [2]

## 5.6 Zusammenfassung
Das Paradigma der Document Stores passt somit auf Anwendungsbereiche, bei denen ein relationales Schema die Flexibilität der Anwendung einschränkt. [3]
Sie kommen häufig dann zum Einsatz, wenn Objekte sich in mehrere Objekte schachteln und die Objekte wiederum nicht nach einem strengen Gerüst mit Attributen aufgebaut sind, häufigen Änderungen unterliegen und die Datenmenge enorm ist. Außerdem werden sie angewandt, wenn verteiltes Arbeiten mit großen bis sehr großen Datenmengen erforderlich ist und bieten diesem Einsatzzweck entsprechende Datenstrukturen und verzichten bewusst auf Transaktionen. [1]

------

[1] Oliver, A. C. (2013, 31. Oktober). 10 common tasks for MongoDB. Abgerufen 16. November, 2018, von https://www.infoworld.com/article/2612785/application-development/10-common-tasks-for-mongodb.html <br>
[2] Berthelsen, E. (2014, April). Why NoSQL DWhy NoSQL Databases for the Internet of Things: Machina Researchatabases for the Internet of Things: Machina Research. Abgerufen 17. November, 2018, von https://www.mongodb.com/collateral/why-nosql-databases-internet-things-machina-research <br>
[3] Edlich, S. (2011). NoSQL. München: Hanser. 

------

[< Vergleich mit anderen Datenbankmodellen](06_Vergleich-mit-anderen-Datenbankmodellen.md)		|   [Übersicht wichtiger dokumentorientierter Datenbanken >](08_Übersicht-wichtiger-dokumentorientierter-Datenbanken.md)
