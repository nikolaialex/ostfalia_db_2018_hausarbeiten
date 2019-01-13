# 2. Entwicklung und Ursprung

Erstaunlicherwesie begann die Geschichte der NoSQL-Datenbank Systeme schon parallel zu der der relationalen Datenbank Systeme. Bereits 1979 entwickelte Ken Thompson eine Key/Hash-Datenbank namens DBM. Erst 1998 tauchte der Begriff NoSQL zum ersten Mal im Zusammenhang mit einer Datenbank von Carlo Strozzi auf. Seiner Datenbank lag zwar immer noch ein relationales Datenbankmodell zu Grunde, er stellte aber keine SQL-API zur Verfügung.

Der eigentliche Durchbruch für NoSQL kam erst ab 2000, mit der Einführung des Web 2.0 und dem Versuch auch große Datenmengen zu verarbeiten. Google kann man mit seinem BigTable-Datenbanksystem (2004) als den NoSQL-Vorreiter schlechthin betrachten. Später zogen Firmen wie Yahoo, Amazon und nachfolgend auch alle sozialen Netzwerke wie MySpace, Facebook, LinkedIn usw. nach. 

Bis 2005 entstanden einige, im Vergleich kleinere hochinteressante Datenbanken, die in vielen Facetten schon NoSQL-Charakter (wie zB. Graphendatenbanken, objektorientierte Datenbanken) aufwiesen. [1] 

Von 2006 bis 2009 entstanden die heutigen klassischen NoSQL-Systeme. Doch erst 2009 tauchte der heutige Begriff "NoSQL" in einem Weblog von Eric Evans zum ersten Mal auf. [2]  

Um den Bogen zurück zu Document Stores zu spannen, ist es wichtig zu wissen, dass der Bereich der dokumentenorientierten Datenbanken für einen der interessantesten Teile der NoSQL-Bewegung gehalten wird. [2]

Jedoch muss man mit dem Begriff “Document Stores” vorsichtig sein. Sie sind im eigentlichen Sinne keine echten Dokumentendatenbanken. Der Begriff selbst stammt noch aus der Zeit von Lotus Notes, wo tatsächlich echte Anwenderdokumente gespeichert wurden. Wahrscheinlich wurde der Begriff sogar vom ehemaligen Lotus Notes-Entwickler Damien Katz geprägt, der später das Datenbanksystem CouchDB entwickelte.

Jedoch ist die Anzahl der wirklich relevanten dokumentenorientierten Datenbanken relativ gering. Neben MongoDB haben vor allem Couchbase, CouchDB und Redis eine große Bedeutung. [3]  

## 2.1 Geschwister von Document Stores

Document Stores gehören zweifelsohne zu den wichtigsten NoSQL Datenbanken. Nachfolgend findet ein Vergleich mit anderen wichtigen No-SQL Datenbanken statt:

- **Schlüssel/Wert-orientiert (engl. Key/Value):** 

   Das Key-Value-Datenbankmodell verwendet ein einfaches Schema zur Verknüpfung von Schlüsseln und Werten. Jeder Schlüssel liefert bei der Abfrage bestimmte Werte zurück. Diese Werte können aus willkürlichen Zeichenketten oder strukturierten Zeichen bestehen, z. B. XML oder ein serialisiertes Objekt. [4, 5]

- **Spaltenorientiert:** 

   Wie der Name bereits verrät, ist die Besonderheit des spaltenorientierten Datenbankmodells die Speicherung der Einträge in Spalten statt in Zeilen. Der Vorteil dieses Datenbanksystems (DBS) gegenüber eines zeilenorientierten Modells ist die erhöhte Leistung der Leseprozesse, da keine unnötigen Daten gelesen werden müssen. Über einen Schlüssel wird gezielt auf einen bestimmten Wert einer Spaltenfamilie zugegriffen. [4, 5]

- **Dokumentenorientiert:**

   Dieses Datenbankmodell setzt auf die Speicherung der Daten in Dokumente. In diesen Dokumenten werden die Daten schemalos gespeichert, sie können jedoch mit einer Struktur (z. B. JSON) versehen werden, die von der Datenbank gelesen werden kann. Mehrere Dokumente besitzen keine Relationen zueinander. [4, 5]

- **Graphenorientiert:** 

  Beim graphenorientierten Datenbankmodell werden die Daten durch Knoten (Entitäten) und Kanten (Beziehungen) dargestellt bzw. gespeichert. Diese können jeweils mit Eigenschaften oder Attributen beschrieben werden. Ein Graph beginnt normalerweise mit einem Startknoten und durchläuft dann entlang der Kanten die weiteren Knoten. Durch dieses lineare Verfahren werden Verschachtelungen vermieden und gegenüber relationalen SQL-Datenbanken eine höhere Performance erreicht. [4, 5]

In der nachfolgenden Tabelle wurde ein Vergleich der einzelnen NoSQL Datenbanksysteme mit Hilfe der Kriterien Aufbau, Skalierbarkeit/Performance und Komplexität durchgeführt. Außerdem wurden jedem Modell wichtige Vertreter bzw. verwandte Modelle zugeordnet. 

| | Schlüssel–Wert| Spalten| Dokument | Graph |
|------|------------------|------------	| ------------|------------------|
| **Aufbau** | Collections von Schlüssel-Wert-Paaren | Spalten und Spaltenfamilien. Zugriff erfolgt direkt auf die Spaltenwerte (einzeln oder aggregiert) | Schlüssel-Wert-Paare - mit dem Zusatz, dass die Datenstruktur im Value interpretiert wird | Fokus auf Datenverbindungen und schnelles Durchwandern dieser Beziehungen |
| **Skalierbarkeit/Performance** | +++ | +++ | ++ | ++ |
| **Komplexität** | + | ++ | ++ | +++ |
| **Inspiration &Verwandtschaft** | Berkeley-DB, Memcache | Sybase IQ, BigTable | Lotus Notes | Graphen-Theorie |
| **NoSQL-Vertreter** | Voldemort, Redis, Riak | Hbase, Cassandra, Hypertable | CouchDB, Couchbase, MongoDB, Redis | Sones, Neo4j, InfoGrid |

[4]

------

[1] Top 5 Considerations When Evaluating NoSQL Databases. (2018, Juni). Abgerufen 17. November, 2018, von https://www.mongodb.com/collateral/top-5-considerations-when-evaluating-nosql-databases

[2] Edlich, S. (2011). NoSQL. München: Hanser.

[3] DB-Engines Ranking. (o.D.). Abgerufen 16. November, 2018, von https://db-engines.com/de/ranking/document+store

[4] Lingstädt, D. (2011, 1. Januar). NoSQL - Einsatzgebiete für die neue Datenbank-Generation. Abgerufen 15. November, 2018, von https://www.innoq.com/de/articles/2011/01/nosql-einsatzgebiete/

[5] Litzel, N. (2017, 12. Juni). Was ist NoSQL? Abgerufen 3. Januar, 2019, von https://www.bigdata-insider.de/was-ist-nosql-a-615718/

------

[< Einleitung](03_introduction.md)		|   [Datenmodell >](05_Datenmodell.md)
