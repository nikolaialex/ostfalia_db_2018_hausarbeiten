# 6. Übersicht wichtiger dokumentenorientierter Datenbanken

Im Gegensatz zu beispielsweise relationalen Datenbanken gibt es für dokumentenorientierte Datenbanken keine vergleichbare Standardisierung. Aus diesem Grund können unter den verschiedenen Systemen deutlich stärkere Unterschiede festgestellt werden. Es gibt eine Vielzahl von dokumentenorientierten Datenbanken. Die Wahl einer geeigneten Datenbank hängt vor allem von dem Anwendungfall ab, in dem diese eingesetzt wird. So sollte individuell entschieden werden welche am geeignetsten erscheint, da sich die Datenbanken in einigen Punkten starkt unterscheiden können. In der nachfolgenden Tabelle sind die zehn dokumentenorienten Datenbanken, die laut DB-Engines Ranking zu den wichtigsten Vertretern ihrer Art gehören, dargestellt. [1, 2] Mit in die Bewertung fließen Kriterien ein, wie die Anzahl der Nennungen des Systems auf Websites, das allgemeine Interesse am System (Google Trends), die Häufigkeit von technischen Diskussionen, die Anzahl an assoziierten Job-Angeboten, die Anzahl an Profilen in professionellen Netzwerken, sowie die Relevanz in sozialen Netzwerken (z.B Erwähnungen auf Twitter). MongoDB erzielt dabei mit 369,48 Punkten das höchste Ergebnis. Couchbase kommt auf 34,85, CouchDB auf 18,73 (Stand November 2018). Die Datenbanken wurden anhand der Aspekte unterschützte Sprachen, RESTful API und Datenbankmodell verglichen. 


| Name | unterstützte Sprachen| RESTful API| Anmerkung | Datenbankmodell |
|------|------------------|------------	| ------------|------------------|
| Mongo DB  | C, C++, C#, Java, Perl, PHP, Python, Node.js, Ruby, Rust, Scala   | Ja	| Dokumentdatenbank mit Replikation und Sharding, BSON Store (Binärformat JSON)| Document Store |
|Amazon DynamoDB |.Net, ColdFusion, Erlang, Groovy, Java, JavaScript, Perl, PHP, Python, Ruby |Ja | Gehosteter, skalierbarer Datenbankservice von Amazon mit den in der Amazons Cloud gespeicherten Daten | Document Store, Key-Value Store |
|Couchbase |C, .NET, Java, Python, Node.js, PHP, SQL, Go, Spring Framework, LINQ |Ja | Verteilte NoSQL-Dokumenten-Datenbank, JSON-Modell und SQL-basierte Abfragesprache| Document Store |
|Microsoft Azure Cosmos DB |	.NET, Java, Python, Node.js, JavaScript, SQL | Ja | Platform-as-a-Service Angebot, Teil der Microsoft Azure-Plattform. Basiert und erweitert die frühere Azure DocumentDB. | Document Store,  Key-Value Store, Graph DBMS, Wide Colum Store |
| Couch DB |Jede Sprache, die HTTP-Anfragen stellen kann | Ja  | JSON über REST/HTTP mit Multi-Version Concurrency Control und begrenzten ACID-Eigenschaften. Verwendet map und reduce für views und queries | Document Store |
|MarkLogic |REST, Java, JavaScript, Node.js, XQuery, SPARQL, XSLT, C++ | Ja |Verteilte dokumentenorientierte Datenbank für JSON-, XML- und RDF-Tripel. Integrierte Volltextsuche, ACID-Transaktionen, Hochverfügbarkeit und Disaster Recovery, zertifizierte Sicherheit | Document Store, Native XML DBMS, RDF Store, Search Engine |
|Firebase Realtime Database | 	Java,JavaScript, Objective-C| Ja |eine cloud-hosted Datenbank. Die Daten werden als JSON gespeichert.  iOS-, Android- und JavaScript-Clients teilen sich eine Echtzeit-Datenbankinstanz und erhalten automatisch Updates mit den neuesten Daten  | Document Store |
|OrientDB |Java | Ja | JSON über HTTP, SQL-Unterstützung, ACID-Transaktionen |  Document Store,  Key-Value Store, Graph DBMS |
|RethinkDB |C++, Python, JavaScript, Ruby, Java | Nein | Verteilte dokumentenorientierte JSON-Datenbank mit Replikation und Sharding | Document Store |
|ArangoDB |C, .NET, Java, Python, Node.js, PHP, Scala, Go, Ruby, Elixir | Ja | Das Datenbanksystem unterstützt die Dokumentenablage sowie Schlüssel/Wert- und Diagrammdatenmodelle mit einem Datenbankkern und einer einheitlichen Abfragesprache AQL (ArangoDB Query Language) | Document Store,  Key-Value Store, Graph DBMS |

[2, 3, 4, 5]

In den nachfolgenden Kapiteln wird auf zwei dokumentenorientierte Datenbanken sowie deren technische Umsetzung näher eingegangen. Hier wurde sich für den wichtigsten Vertreter MongoDB, sowie für den fünft platzierten CouchDB entschieden. 

---

[1] Edlich, S. (2011). NoSQL. München: Hanser.

[2] DB-Engines Ranking. (o.D.). Abgerufen 16. November, 2018, von https://db-engines.com/de/ranking/document+store

[3] Wikipedia contributors. (2018, 19. Dezember). Document-oriented database - Wikipedia. Abgerufen 20. Dezember, 2018, von https://en.wikipedia.org/wiki/Document-oriented_database

[4] Firebase Realtime Database. (2018, 1. November). Abgerufen 20. Dezember, 2018, von https://firebase.google.com/docs/database/

[5] What Is MongoDB? (o.D.). Abgerufen 18. November, 2018, von https://www.mongodb.com/de/what-is-mongodb

---

[< Anwendung von Document-Stores](07_Anwendung-von-DocumentStores.md)		|   [CouchDB >](09_CouchDB.md)


