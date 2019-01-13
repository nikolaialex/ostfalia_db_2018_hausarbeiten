
# 5.3 Ein Vergleich zwischen Google Spanner und Amazon DynamoDB

Die Datenbanksysteme Google Spanner und Amazon DynamoDB wurden annähernd zum gleichen Zeitpunkt entwickelt. Während die Entwicklung von Spanner 2007 begonnen wurde und der Produktivbetrieb 2011 erfolgte, stellte Amazon Dynamo 2007 und den Nachfolger DynamoDB 2012 vor.

Es gibt einige Gemeinsamkeiten zwischen Spanner und DynamoDB: es handelt sich um vollständig gemanagte Systeme, mit Hash-basiertem Sharding und Skalierbarkeit auf Knopfdruck, Rollen-basierte Rechtevergabe durch IAM (Identity and Access Management) und Monitoring und Metriken über die Konsole. [1]

DynamoDB führt auf der Webseite folgende Vorteile des Systems auf [2]:

- **Skalierbare Leistung:**  
Es werden konsistente Reaktionszeiten im Millisekundenbereich geboten, sowie unbegrenzten Durchsatz und Speicherplatz.
- **Serverlos:**  
Es wird kein Server bereitgestellt, der verwaltet werden muss. Tabellen werden automatisch skaliert, um die Kapazität anzupassen.
- **Enterprise-fähig:**  
ACID-Transaktionen werden unterstützt, alle Daten werden verschlüsselt und vollständige Backups können erstellt werden.

DynamoDB verwendet ein Key-Value-Interface und repliziert nur innerhalb einer Region. Spanner hingegen stellt ein semi-relationales Datenbankmodell bereit und eine ähnliche Schemasprache. [3]

Folgende Vorteile führt Spanner auf der offiziellen Webseite auf [4]:

- **Globale Skalierung:**  
Über Regionen und Kontinente skalierbar.
- **Vollständig verwaltet**
- **Relationale Semantik:**  
Schema, ACID-Transaktionen und SQL-Abfragen (ANSI 2011)
- **Transnationale Konsistenz**
- **Sicherheit auf Enterprise-Niveau:**  
Verschlüsslung von Datenschichten und IAM
- **Hochverfügbar**

Ein starker Unterschied zwischen den beiden Systemen ist, wie sie die Daten local verwalten. Schlüssel mit gleichem Präfix werden bei Spanner näher beieinander gespeichert, als bei DynamoDB. Wahlweise sogar auf dem gleichen Knoten. Dieses Vorgehen gewährt eine flexible Skalierbarkeit ohne die Latenz zu beeinflussen. [1]

Im Bereich Sicherheit liegt DynamoDB etwas vor Spanner. DynamoDB bietet eine anwenderseitige Verschlüsslung (AWS library) während der Entwickler bei Spanner selbst dafür sorgen muss. Dafür liegt Spanner im Bereich Query Language vorne. Spanner unterstützt SQL, wodurch eine Nutzung von Spanner bei relationalen Datenbanken möglich ist. [5]

Auch bei den Konsistenzkonzepten gibt es einen kleinen Unterschied. Während Spanner auf „Strong Consistency“ setzt, bietet DynamoDB zusätzlich noch „Eventual Consistency“ an. [5]

Beide Systeme bieten ähnliche Konzepte und teilen die gleichen Grundlagen. Zudem bieten Amazon wie auch Google sehr detaillierte Dokumentationen an, die den Einstieg für einen Entwickler erleichtern: https://aws.amazon.com/de/dynamodb/resources/ und https://cloud.google.com/spanner/docs/. Für welches System ein Entwickler sich entscheiden sollte, hängt stark von dem Projekt und den daraus resultierenden Anforderungen ab. 


***
[1] Hwang, J. (2017, September 12). Scaling Costs with DynamoDB. Retrieved January 12, 2019, from https://blog.polymail.io/post/scaling-costs-with-dynamodb

[2] AWS | Amazon DynamoDB – NoSQL Online Datenbank Service. (n.d.). Retrieved January 12, 2019, from https://aws.amazon.com/de/dynamodb/ 

[3] Corbett, J. C., Hochschild, P., Hsieh, W., Kanthak, S., Kogan, E., Li, H., . . . Heiser, C. (2013). Spanner. ACM Transactions on Computer Systems, 31(3), 1-22. doi:10.1145/2518037.2491245

[4] Cloud Spanner | Automatic Sharding with Transactional Consistency at Scale  |  Cloud Spanner  |  Google Cloud. (n.d.). Retrieved January 12, 2019, from https://cloud.google.com/spanner/ 

[5] Chaves, W. (2017, November 27). Current State of the NewSQL/NoSQL Cloud Arena. Retrieved January 12, 2019, from https://www.red-gate.com/simple-talk/cloud/cloud-data/current-state-newsqlnosql-cloud-arena/ 

***

[<< 5.2 Amazon Dynamo(DB)](5_2_Dynamo.md) | [6 Zusammenfassung >>](6_Zusammenfassung.md)

***
