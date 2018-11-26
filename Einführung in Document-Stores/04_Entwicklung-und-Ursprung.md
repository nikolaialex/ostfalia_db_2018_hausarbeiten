# 2. Entwicklung und Ursprung

Erstaunlicherwesie begann die Geschichte der NoSQL-Datenbank Systeme schon parallel zu der der relationalen Datenbank Systeme. Bereits 1979 entwickelte Ken Thompson eine Key/Hash-Datenbank namens DBM. Erst 1998 tauchte der Begriff NoSQL zum ersten Mal im Zusammenhang mit einer Datenbank von Carlo Strozzi auf. Seiner Datenbank lag zwar immer noch ein relationales Datenbankmodell zu Grunde, er stellte aber keine SQL-API zur Verfügung.

Der eigentliche Durchbruch für NoSQL kam erst ab 2000, mit der Einführung des Web 2.0 und dem Versuch auch große Datenmengen zu verarbeiten. Google kann man mit seinem BigTable-Datenbanksystem (2004) als den NoSQL-Vorreiter schlechthin betrachten. Später zogen Firmen wie Yahoo, Amazon und nachfolgend auch alle sozialen Netzwerke wie MySpace, Facebook, LinkedIn usw. nach. 

Bis 2005 entstanden einige, im Vergleich kleinere hochinteressante Datenbanken, die in vielen Facetten schon NoSQL-Charakter (wie zB. Graphendatenbanken, objektorientierte Datenbanken) aufwiesen. [1] 

Von 2006 bis 2009 entstanden die heutigen klassischen NoSQL-Systeme. Doch erst 2009 tauchte der heutige Begriff "NoSQL" in einem Weblog von Eric Evans zum ersten Mal auf. [2]  

Um den Bogen zurück zu Document Stores zu spannen, ist es wichtig zu wissen, dass der Bereich der dokumentenorientierten Datenbanken für einen der interessantesten Teile der NoSQL-Bewegung gehalten wird. [2]

Jedoch muss man mit dem Begriff “Document Stores” vorsichtig sein. Sie sind im eigentlichen Sinne keine echten Dokumentendatenbanken. Der Begriff selbst stammt noch aus der Zeit von Lotus Notes, wo tatsächlich echte Anwenderdokumente gespeichert wurden. Wahrscheinlich wurde der Begriff sogar vom ehemaligen Lotus Notes-Entwickler Damien Katz geprägt, der später das Datenbanksystem CouchDB entwickelte.

Jedoch ist die Anzahl der wirklich relevanten dokumentenorientierten Datenbanken relativ gering. Neben MongoDB haben vor allem Couchbase und CouchDB eine große Bedeutung. [3]  

## 2.1 Geschwister von Document Stores

Document Stores gehören zweifelsohne zu den wichtigsten NoSQL Datenbanken. Andere wichtige No-SQL Datenbanken sind:

- **Schlüssel/Wert-orientiert (engl. Key/Value):** 

   Abgefragt wird auf den Schlüssel, der einen beliebigen String (z. B. XML oder ein serialisiertes Objekt) zurück liefert.

- **Spaltenorientiert:** 

   Dieser Speichertyp greift über einen Schlüssel gezielt auf Einzelwerte einer Struktur (Spaltenfamilie) zu.

- **Graphenorientiert:** 

  Entscheidender Anwendungsfall ist das Traversieren der Objekte, wie z. B. bei Verbindungen in Social Networks oder Produktempfehlungen. Die Daten werden in Knoten (Entitäten) und Kanten (Beziehungen) aufgeteilt, welche mit Attributen versehen werden können. [4] 



------

[1] Top 5 Considerations When Evaluating NoSQL Databases. (2018, Juni). Abgerufen 17. November, 2018, von https://www.mongodb.com/collateral/top-5-considerations-when-evaluating-nosql-databases <br>
[2] Edlich, S. (2011). NoSQL. München: Hanser. <br>
[3] DB-Engines Ranking. (o.D.). Abgerufen 16. November, 2018, von https://db-engines.com/de/ranking/document+store <br>
[4] NoSQL - Einsatzgebiete für die neue Datenbank-Generation. (2011, 1. Januar). Abgerufen 15. November, 2018, von https://www.innoq.com/en/articles/2011/01/nosql-einsatzgebiete/ <br>



------

[< Einleitung](03_introduction.md)		|   [Datenmodell >](05_Datenmodell.md)
