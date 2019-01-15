Vergleich von RDBMS und Neo4j
=============================

Autoren
-----

| Name         | Matrikelnummer | Hochschule | E-Mail                  |
|--------------|----------------|------------|-------------------------|
| Toni Möckel | 843227 | Beuth Hochschule Berlin | s64715@beuth-hochschule.de |
| Robert Neujahr | 848087 | Beuth Hochschule Berlin | s65911@beuth-hochschule.de |

## Inhalterverzeichnis

1. [Einleitung](#einleitung)
1. [Datenmodellierung](#datenmodellierung)
1. [Datenbankabfragen](#datenbankabfragen)
1. [Anwendungsfälle](#anwendungsfälle)
1. [Fazit](#fazit)
1. [Quellen](#quellen)

## Einleitung

Eine Datenbank ist ein wesentlicher Bestandteil einer Anwendung. Die Wahl des richtigen Datenbanksystems ist oft entscheid, wenn es um die Leistungsfähigkeit, Schnelligkeit und Skalierbarkeit einer Anwendung geht.

Der Einsatz von relationalen Datenbankmanagementsystemen (RDBMS) wie MSSQL, MySQL oder PostgreSQL ist weit verbreitet. Die Daten werden dabei in Tabellen gespeichert, die miteinander über Fremdschlüssel verbunden werden können. Ein Datensatz (Record) entspricht dabei einer Tabellenzeile (Tupel). Die Tabellenspalten stehen dabei für die entsprechenden Merkmale (Attribute).  RDBM-Systeme kommen oft an die Belastbarkeitsgrenzen wenn große Datenmengen über verschiedene Relationen abgefragt werden müssen. Grund dafür ist das aufwendige Zusammenführen von mehreren Tabellen um ein Ergebnis auswerten zu können. Die Komplexität und der Speicherverbrauch steigt mit der Anzahl der verknüften Tabellen.

Neben den relationalen Datenbankmanagementsystemen haben sich alternative Konzepte etabliert, mit deren Hilfe sich Daten in anderen Strukturen verwalten lassen. Ein Beispiel dafür sind graphbasierte Datenbanken mit dem populären Verträter Neo4j. Bei graphbasierenden Datenbank steht die Beziehung der einzelnen Datensätzen im Mittelpunkt. Statt Tabellen arbeiten Graphdatenbanken mit Knoten (Entität) und Kanten (Beziehungen).Komplexe n:m Beziehungen lassen sich mit Graphdatenbanken einfach realisieren. Besonders gut lassen sich Beziehungen der einzelnen Knoten in tiefere Ebenen abfragen. Im Vergleich zu relationalen Systemen sind die solche Abfragen in Graphdatenbanken einfacher und schneller zu realisieren.

## Datenmodellierung

Die starre Struktur einer relationalen Datenbank erfordert eine gründliche Planungs und Konzeptionsphase. Nach der Ermittlung der Informationsstruktur soll das Datenmodel einen Ausschnitt aus der realen Welt wiederspiegeln.
Es ist im Software-Design üblich, die Entitäten eines geplanten Projekts als Graphen zu modellieren. Üblicherweise wird das Datenmodell dabei ER-Modell zusammengefasst. Entitäten werden vorgeschlagen verknüpft und mit Attributen versehen. Diese Entitäten werden dann in verschiedenen Beziehungen mit anderen Entitäten verbunden. Die Modellierung auf diese Weise ist ein sehr natürlicher Prozess der nicht direkt auf die Struktur einer relationalen Datenbank angewendet werden kann. Damit das RDBMS optimal funktioniert muss eine Transformation des ER-Modells in ein Datenbankschema erfolgen. Dabei werden verschiedene Normalisierungsschritte angewendet um Redundanzen zu verhinden und die Datenbank konsistent zu halten. Erst am Ende werden die tatsächlichen Tabellen definiert und die Spalten mit Datentypen verknüpft um das Model in ein Datenbankschema zu überführen mit dem das RDBMS arbeiten kann.

Folgende Grafik zeigt ein Datenmodell von Angestellten, die einer Abteilung zugeordnet wurden. Dies ist eine klassische n:m Beziehung, bei der einer Abteilung mehrere Angestellte zugehören und ein Angesteller auch Mitglied mehrerer Abteilungen sein kann. Um dieses Problem in einem RDBMS zu lösen wird eine zusätzliche Tabelle (Lookup Table) benötigt, die eine Abteilung mit einem Angestellten verbindet. Diese Tabelle stellt die Beziehung der beiden Tabellen dar.
![relational-model]

Bei Graphdatenbanken wird versucht das natürlich Graphmodel direkt abzubilden.
Beim Beispiel der Angestellten die zu einer Abteilung gehören bedeutet das, dass es mehrere Knoten (Nodes) mit dem Label "Angestellte" geben kann, als auch mehrere Knoten mit dem Label "Abteilungen". Die Knoten werden nun direkt mit Beziehungen (Relationships) verknüpft. Es werden keine Lookup Tabellen benötigt.
![relational-graph-model]

Bei der Verwendung eines RDBMS sind Entwickler gezwungen, Überlegungen zum Softwaredesign anzustellen, da die Datenmodelle unflexibel sind. Jede neue Entität wird zu einer Verpflichtung, zu einer Tabellenstruktur, die die Erweiterung der Softwarefunktionalität aufgrund von Modellierungsbeschränkungen einschränkt. So schreibt beispielsweise das Designmuster Model View Controller (MVC) vor, dass Präsentation (View), Logik (Controller) und Daten (Model) vollständig voneinander getrennt sein müssen. Die Idee, dass das Datenmodell eine separate Entität sein muss, die eng mit dem erwarteten Verhalten gesteuert wird, ist dem RDBMS-Ansatz inhärent. Die Änderung muss streng kontrolliert werden und es müssen Lücken im Code durchbrochen werden, um zu versuchen, die RDMBs mit dem Objekt und den von ihm geforderten Beziehungsanforderungen in Übereinstimmung zu bringen. Dies ist die krasseste Einschränkung des RDBMS und hat die Erstellung des Graphenmodells vorangetrieben.

Frameworks wurden entwickelt, um zu versuchen, RDBMS natürlicher erscheinen zu lassen. Diese Frameworks werden als ObjectRelational Mapping Systems (ORMs) bezeichnet. Ein Beispiel für ein ORM wäre das Hibernate Framework für Java. ORMs versuchen, das Datenmodell in Objekte und Beziehungen zu abstrahieren, um die Softwareentwicklung natürlicher erscheinen zu lassen. Vorzugsweise sollte das Datenmodell kein treibender Faktor im Softwaredesign sein. Stattdessen sollten Software-Design-Anforderungen die treibende Kraft hinter dem Design des Datenmodells sein. Die Datenbank sollte Flexibilität unterstützen, und genau hier setzt die GDB an.

Die Trennung der Softwareentwickler von ihren RDBMS-Bindungen könnte zu einem viel flexibleren und dynamischeren Ansatz für das Softwaredesign führen. Diese Flexibilität eignet sich gut für die agile Entwicklungsmethodik, bei der sich Anforderungen und Lösungen ständig weiterentwickeln sollen. Ein leistungsstarkes Software-Design-Tool für Java und Neo4j ist Spring Data. Spring Data ermöglicht die POJO-basierte Entwicklung für die Neo4j GDB. Es ordnet kommentierte Entitätsklassen der Neo4j Graphen-Datenbank mit erweiterter Mapping-Funktionalität zu.

## Datenbankabfragen

Eine Abfragesprache ist eine Sammlung von Operatoren oder Inferenzregeln, die auf jede gültige Instanz der Datenstrukturtypen des Modells angewendet werden können, mit dem Ziel, Daten in diesen Strukturen in jeder gewünschten Kombination zu manipulieren und abzufragen. RDBM-Systeme verwenden einen gemeinsamen Standard namens SQL (Structured Query Language) für das Einfügen, Aktualisieren, Löschen, Abfragen, Erstellen und Ändern von Schemas. SQL basiert auf relationaler Algebra und Tupel-Relationsrechnung. Diese allgemeine Konsistenz im Ansatz macht Konzepte, die aus verschiedenen RDBMS-Implementierungen gelernt wurden, extrem portabel. Es gibt einen ähnlichen einheitlichen Ansatz für die Arbeit mit Graphendatenbanken.

Das effektive Abrufen von Informationen aus einem Graphen erfordert eine so genannte Traversierung. Eine Graphendurchquerung beinhaltet das "Gehen" entlang der Elemente eines Graphen. Die Traversierung ist eine grundlegende Operation für den Datenabruf. Ein wesentlicher Unterschied zwischen einer Traversal- und einer SQL-Abfrage besteht darin, dass es sich bei Traversals um lokalisierte Operationen handelt. Es gibt keinen globalen Adjazenzindex, sondern jeder Knoten und jede Kante im Diagramm speichert einen "Mini-Index" der damit verbundenen Objekte. Dies bedeutet, dass die Größe des Diagramms keinen Einfluss auf die Performance eines Traversals hat und die teuren Gruppierungsoperationen in SQL JOIN-Anweisungen unnötig sind. Es ist wichtig zu beachten, dass in Neo4J globale Indizes existieren, aber sie werden nur verwendet, wenn versucht wird, den Startpunkt einer Traversal zu finden. Indizes werden benötigt, um Eckpunkte basierend auf ihren Werten schnell abrufen zu können. Sie bilden einen Ausgangspunkt, an dem eine Traversierung beginnen kann. Ohne Indizes, die bestimmen, ob ein bestimmtes Element eine bestimmte Eigenschaft hat, würde eine lineare Abtastung aller Elemente auf Kosten von O(n) erfordern, wobei n die Anzahl der Elemente in der Sammlung ist. Alternativ sind die Kosten für ein Lookup auf einen Index bei O(log2n) viel geringer.

Die Welt der Graphendatenbanken hat noch keine Standardisierung auf eine Sprache für das Traversieren und Einfügen vorgenommen. Diese mangelnde Standardisierung hat zu sehr unterschiedlichen Implementierungen und Frameworks für die Dateninteraktion geführt. Die verfügbaren Implementierungen reichen von einer Java-API, einer REST-Schnittstelle, einer DSL-Sprache namens Gremlin und einer weiteren namens Cypher. Gremlin führt die Traversen durch ein System namens Piping durch. Jedes Teil der Anfrage ist ein Schritt zum nächsten in einer progressiven Weise. Cypher versucht jedoch, mehr von einem Keyword-System zu verwenden, das versucht, mehr wie SQL zu sein. Dies ist eine Schwäche gegenüber dem ausgereifteren RDBMS SQL. Es gibt einen Mangel an Konsistenz, der erfordert, dass man alle Implementierungen lernt, bevor man versteht, welcher Ansatz für das Problem am besten geeignet ist.

Gremlin und Cypher sind die beiden Hauptsprachen, in denen Neo4J-Graphen durchlaufen werden. Gremlin ist eine domänenspezifische (DSL) Programmiersprache, die sich auf das Durchlaufen und Manipulieren von Graphen konzentriert. Gremlin ist auf der Programmiersprache Groovy implementiert und wurde von den meisten Anbietern von Graphendatenbanken übernommen. Gremlin wird durch die Blueprints Java API unterstützt und kann bei Bedarf direkt mit Blueprints arbeiten. Groovy arbeitet auf der JVM und ist eng mit Java verbunden. Gremlin strebt danach, eine Standardsprache zu sein, die mit allen gängigen Implementierungen von Graphendatenbanken kompatibel ist. Cypher ist eine von SQL inspirierte deklarative Graph-Abfragesprache, die darauf abzielt, die Notwendigkeit zu vermeiden, Traversen im Code zu schreiben. Cypher befindet sich immer noch in intensiver Entwicklung, wobei kürzlich die Unterstützung für die Graphenmanipulation anstelle der reinen Abfragefähigkeit hinzugefügt wurde.

## Vergleich ausgewählter Kriterien

| Kriterium                    | RDBMS                                                                                  | Neo4j                                                                                                                                                                            |
|------------------------------|----------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Komplexität des Datenmodells | Einfach bis moderat                                                                    | Hohe Komplexität                                                                                                                                                                 |
| Anzahl der Beziehungen       | Gute Performance bei überschaubaren Beziehungen                                        | Anzahl der Beziehungen ohne Einschränkungen                                                                                                                                      |
| Performance einer Abfrage    | Einfach Abfragen werden sehr schnell ausgeliefert.                                     | Einzelne Datensätze ohne Berücksichtigung auf ein Beziehungen dauert etwas länger als bei RDBM-Systemen.                                                                         |
|                              | Erst wenn viele Tabellen zusammengeführt werden müssen steigt die Dauer einer Abfrage. | Bei einer Anfrage die über mehrere Beziehungen hinweg betrachtet werden soll steigt die Dauer nicht mit der Anzahl der Beziehungen und ist hier schneller als bei RDBM-Systemen. |
| Datenstruktur                | Statisches Tabellenschema, strukturiertes Datenbankmodell                              | Unstrukturiertes, dynamisches Datenbankmodell                                                                                                                                    |
| Konsistenz                   | Strenge Konsistenz (ACID)                                                              | Regelbare Konsistenz (BASE)                                                                                                                                                      |
| Verfügbarkeit                | Hoch (Meißtens zentralisiert)                                                          | Verteilte System (ohne Downtime über verteilte Systeme)                                                                                                                          |
| Skalierbarkeit               | Vertikal Skalierbar                                                                    | Horizontal Skalierbar                                                                                                                                                            |
| Abfragesprache               | SQL (weit verbreitet)                                                                  | Cypher und Gremlin (Anwendungsspezifisch für Neo4j)                                                                                                                              |

## Anwendungsfälle

Sowohl relationale Datenbankmanagementsysteme als auch graphbasierte Datenbanken können Beziehungen von Daten aufbauen und abfragen. Der große Unterschied zwischen beiden Systemen liegt dabei in der Komplexität der Beziehungen. RDBMS sind vorallem für einfache Beziehungen wie 1:1, 1:n oder auch n:m nützlich. Sofern mehrere Beziehungen dieser Art in einer Abfrage verwendet werden müssen, leidet darunter die Schnelligkeit der Auswertung.     
Graph Datenbanken wie Neo4j kommen vor allem dann zum Einsatz, wenn mit einer großen Menge von Daten gearbeitet werden muss, bei denen die einzelnen Datensätze in komplexen Beziehungen zueinander stehen. 

Im folgenden Kapitel werden Anwendungsfälle dargestellt die für das entsprechende Datenbanksystem geeignet sind. 

### Anwendungsfälle für relationale Datenbankmanagementsysteme

Die Stärke von relationalen Datenbankmanagementsystemen liegt vorallem in der Strukturierbarkeit des Datenmodells.

#### Speichern von Datensätzen ohne komplexe Zusammenhänge

Viele Anwendungen nutzen Datenbanken lediglich für das speichern einfacher Datensätze, wie z.b. Personen bei einem Kontaktbuch oder Logeinträge für Analyse etc. Bei einer Anwendung dieser Art ist die Datenbank primär für das Ablegen einfach strukturierte Daten verantworlich. Beziehungen der Datensätze spielt dabei keine große Rolle. Vielmehr steht das schnelle Speichern von einzelnen Datensätzen im Vordergrund.Die Verwendung von einem RDBM-System ist hier besser geeignet.

#### Anwendungen die mit einem festen Datenstruktur

Bei Anwendungen mit einer konstanten und unveränderlichen Datenstruktur sind relationale Datenbanksystem besser geeignet. In den Tabellen lassen sich diese Art von Daten ausgezeichnet definieren und miteinander verbinden. Bedingung dafür ist, dass die Struktur der Daten bereits im Vorfeld bekannt sind und sich mit hoher Wahrscheinlichkeit in Zukunft nicht gravierend ändern wird. 

Ein Beispiel dafür sind Anwendungen wie Kundenverwaltunen oder Kontaktbücher, bei denen Personen über Namen, Telefonnummer, E-Mail Adresse und weiteren Attributen definiert und abgespeichert werden müssen.
Die Entwickler kennen alle nötigen Metainformationen und können die Struktur der Tabellen fest definieren und miteinander verbinden.

#### Anwendungen die eine hohe Datenkonsistenz erfordern

Anwendungen wie Rechte-, SLA- oder Sessionmanagement benötigen eine zuverlässige Datenkonsistenz. Aus Anwendersicht führt fehlende Datenkonsistenz zu fehlerhafen Abfragen, Fehlern in der Konfiguration der Datenbank sowie falschen Formattierungen. Relationale Datenbanksysteme arbeiten mit dem "ACID Consistency Model", das für eine strenge Datenkonsistenz sorgt.
Das Model beschreibt vier Ziele, die jedes Datenbank Managementsystem erfüllen muss, um Datenkonsistenz zu erfüllen.

- A, für "atomic"
    - Jede Datenbankoperation wird komplett oder gar nicht durchgeührt. Diese Operationen werden atomar genannt.
- C, für "consistency"
    - Datenkonsistenz ist dann erreicht wenn nach Ausführung einer Sequenz von atomaren Operationen die Daten in konsistenter Form vorliegen.
- I, für "isolation"
    - Die Isolation verhindert, das parallel ausgeführte Operationen sich gegenseitig beinflussen können.
- D, für "durability"
    - Bezieht sich darauf das die Daten dauerhaft auf ein Speichermedium abgelegt werden.     

Graphdatenbanken arbeiten mit dem "BASE Consistency Model".
Dieses Modell lässt sich mit folgenden Eigenschaften beschreiben:
- Basic Availability: Das Datenbanksystem sollte eine hohe Verfügbarkeit aufweisen. Datenbanksysteme werden durch verschiedene Replikas verteilt um ein möglichst hohe Erreichbarkeit zugewährleisten.
- Soft-state: Durch die Prämisse, dass das System eine hohe Verfügbarkeit aufweisen muss, kann der Zustand des Datenbanksystems kurzzeitig unbestimmt sein.

### Anwendungsfälle für Neo4j

Neo4j bietet sich immer dann an, wenn die Struktur der Daten unklar oder flexibel sind, das System horizontal skalierbar sein muss und die über und die Datensätze über komplexe Beziehungen zu einander aufweißen.

Neo4j wirbt vorallem mit folgenden Einsatzgebieten:
- Soziale Netzwerke
- Services für Echtzeitempfehlungen
- Management für Netzwerkoperationen
- Identity and Access Management
- Fraud Detection
- Master Data Management

#### Soziale Netzwerke und Echtzeitempfehlungen

Datensätze in sozialen Netzwerken sind schwer im Vorraus zuplanen. 
Sie sind sehr flexibel und ändern sich ständig.
Die Beziehungen der einzelnen Datensätze können schnell anwachsen.
Verbunden werden nicht nur die Personen und deren Beziehungen zu einander, sondern auch Ort und Aktionen von anderen Anwendungen.
Ein Beispiel kann eine Anwendung sein, die Beziehungen zwischen Personen verwalten kann und registriert zu welchem Unternehmen oder auf welche Veranstaltungen die Personen gehen, um aus diesen Informationen Empfehlungen herrauszugeben.   
Um die Datenmodellierung solcher Beziehungen flexibel zu halten sind graphbasierte Datenbanken wie Neo4j ideal.

#### Logistik

Bei der Umsetzung eines globalen Paket-Routing Systems setzte das Unternehmen Accenture auf den Einsatz einer Neo4j Datenbank.
“A logistics network is a graph, and doesn’t fit the table structure of a relational database well” sagte Dominik Wagenknecht, Technology Architect bei Accenture.
Durch die aktuelle Verkehrslage und Baumaßnahmen verändert sich ein solches Netzwerk sehr rasch.
Bei der Umsetzung eines globalen Paket-Routing Systems wird daher ein flexibles, skalierbares Datenmodell benötigt, das mit der enormen Menge von Netzwerkknoten eine Routinganfrage schnell bearbeiten kann.
Solche Systeme müssen Anfragen in der Größenordnung von 2500 Paketen pro Sekunde standhalten. 
Die hohe Verfügbarkeit des Services ist ebenso wichtig wie die schnelle Ausführung einer Anfrage.
Neo4j bietet die optimalen Vorraussetzungen für diesen Einsatzbereich. Die extreme Verfügbarkeit wird das Neo4j Clustering ermöglicht.   

#### Fraud-Detection

Unter "Fraud-Detection" versteht ein System das betrügerische Handlungen erkennen soll. 
Vorallem im Finanz und Banksektor müssen ungewöhliche Handlungen erkannt und gestoppt werden. 
Bei der Funktionsweiße einer "Fraud-Detection" vergleicht ein Algorithmus eine Handlung mit bereits "gewöhnlichen" Handlungen. Wir ein abweichendes Muster festgestellt, kann mit Hilfe der "Fraud-Detection" Datenanalyse ein Scam festgestellt werden. Wichtig dabei ist, dass die Entscheidung in Echtzeit erfolgt, da die betrügerische Handlung sofort gestoppt werden muss. Anwendungsfälle sind das Erkennen von Scams im Onlinebanking, im E-Commercebereich oder bei Versicherungen. 

Die Funktionsweise einer "Fraud-Detection" kann anhand eines Szenarios aus dem Bereich der KFZ-Versicherungen dargestellt werden.  

![fraud-detection-insurance]

Das Szenario umfasst mehrere Datensätze: Personen, Fahrzeuge, Unfälle die mehrere Beziehungen zueinander aufweisen. Die Abfrage eines "Fraud-Detection" Rings mittels eines RDBM-Systems würden eine große Anzahl von Joins verlangen. Graphdatenbanken wie Neo4j können sich hingegen einfach durch den Graph arbeiten um einen Fraud zu identifizieren.  

## Fazit

Graphendatenbanken haben eine neue Art der Modellierung und Traversierung von miteinander verbundenen Daten hervorgebracht. Mit dem Aufkommen von produktionsreifen Systemen wie Neo4j können Probleme angegangen werden, ohne auf eine eingeschränkte Implementierung eines RDBMS zurückgreifen zu müssen. Für Graphendatenbanken gibt es zahlreiche Anwendungen im Bereich biologischer, semantischer, Netzwerk- und Empfehlungssysteme, die nur die Art des Datenmodells benötigen, welches sie anbieten können.

Sind diese Graphendatenbanken bereit, RDBMS vollständig zu ersetzen? Dass ist unsrer Meinung die falsche Frage. RDBMS sind für die meisten Datenspeicheranforderungen geeignet. Sie sind gut dokumentiert, unterstützt und erwiesenermaßen stabil. Die Entscheidung für die Verwendung einer Graphendatenbank sollte nicht auf der Grundlage des Wunsches getroffen werden, keine RDBMS zu verwenden. Die Anforderungen des Systems sollten berücksichtigt werden. Wenn ein dynamisches Datenmodell benötigt wird, das hochverknüpfte Daten darstellt, ist eine Graphendatenbank die beste Lösung. Für die meisten gängigen Probleme ist das RDMBS eine geeignete Lösung, die viel mehr architektonische Möglichkeiten bietet, als der GDB-Bereich derzeit bieten kann.

## Quellen

* [01] Batra, Shalini, and Charu Tyagi. "Comparative analysis of relational and graph databases." International Journal of Soft Computing and Engineering (IJSCE) 2.2 (2012): 509-512.

* [02] Vicknair, Chad, et al. "A comparison of a graph database and a relational database: a data provenance perspective." Proceedings of the 48th annual Southeast regional conference. ACM, 2010.

* [03] Miller, Justin J. "Graph database applications and concepts with Neo4j." Proceedings of the Southern Association for Information Systems Conference, Atlanta, GA, USA. Vol. 2324. 2013.

* [04] Neo Technology "Transforming Logistics - Real-Time Routing and Tracking - with Neo4j", San Mateo, CA 2015

* [05] Neo Technology "Concepts: Relational to Graph", San Mateo, CA 2019, Abgerufen 14.01.2019, Link: https://neo4j.com/developer/graph-db-vs-rdbms/

* [06] Jim Webber, Ian Robinson, "The Top 5 Use Cases of Graph Databases", San Mateo, CA 2017

[fraud-detection-insurance]: ./Images/fraud-detection-insurance.png "Graph eines Fraud-Detection-Netzwerks bei einer KFZ-Versicherung"
[relational-model]: ./Images/relational_model.jpg "Relationales Datenbank Modell"
[relational-graph-model]: ./Images/relational_graph_model.jpg "Graph Datenbank Modell"

