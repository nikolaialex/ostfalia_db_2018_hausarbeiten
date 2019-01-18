# Einleitung

Airbnb, Netflix, LinkedIn? - Das alles sind keine Unbekannten. Tausende Anwendungen von Unternehmen basieren heutzutage auf Apache Kafka (Confluent, 2019a). Was genau Apache Kafka ist und in welchen Fällen es angewendet werden kann, wird nun im Folgenden ausgearbeitet.

## Entstehung von Apache Kafka
Zunächst wurde Kafka bei LinkedIn als eine "Nachrichten-Queue" entwickelt, die "auf einer Abstraktion eines verteilten Commit-Logs [basiert]" (Confluent, 2019a). Kafka wurde 2011 von LinkedIn in ein Apache Software Foundation Open-Source-Projekt verwandelt (Narkhede, Shapira & Palino, 2017, S. 15) und konnte somit schnell in eine "vollwertige Streaming-Plattform entwickelt [werden]" (Confluent, 2019a; Shree, Choudhury, Gupta & Kumar, 2017, S. 1). Die ursprünglichen Entwickler von Apache Kafka Jay Kreps, Neha Narkhede und Jun Rao gründeten das Unternehmen Confluent, welches die vollständigste Kafka-Version zur Verfügung stellt und diese noch um weitere auch kommerzielle Funktionen erweitert (Confluent, 2019a).

## Der Name "Kafka"
Gemäß Narkhede et al. (2017, S. 16) lautet Jay Kreps' Antwort bezüglich der Namensgebung von Kafka wie folgt:
> "I thought that since Kafka was a system optimized for writing, using a writer’s name would make sense. I had taken a lot of lit classes in college and liked Franz Kafka. Plus the name sounded cool for an open source project. So basically there is not much of a relationship."

## Was ist Apache Kafka?
Kafka stellt eine verteilte Streaming-Plattform dar (Apache Software Foundation, 2017a), welche einerseits skalierbar ist und andererseits äußerst tolerant auf Fehler reagiert (Narkhede et al., 2017, S. 10). Es gibt laut der Apache Software Foundation (2017a) drei wesentliche Funktionen, die Apache Kafka bietet:
- Veröffentlichen und Abonnieren von Datensätzen, ähnlich einer Message-Queue oder einem Enterprise-Messaging-System
- Fehlertolerante sowie dauerhafte Speicherung von Datenströmen
- Verarbeitung von Datenströmen, sobald sie entstehen
Shree et al. (2017, S. 1) beschreiben, dass Kafka für das Messaging in sowie zwischen verteilten Systemen zum Einsatz kommt. Darüber hinaus findet es laut den Autoren Anwendung im Bereich des Realtime-Streamings, da es insbesondere für die Verarbeitung von Echtzeitdatenströmen - Big Data sowie Fast Data - geeignet ist. Diese Eignung für Software, welche beispielsweise Realtime-Data-Pipelines aufbauen und verwenden, resultiert unter anderem aus der losen Kopplung zwischen Produzent und Kafka sowie Kafka und Konsument. Hierzu werden in den folgenden Kapiteln detailliertere Informationen dargestellt.

## Wichtige Kafka-Konzepte
Gemäß der Apache Software Foundation (2017a) läuft Kafka in einem *Cluster* aus einem oder mehreren Servern, die sich auch über mehrere Daten-Center erstrecken können. "Datenströme eines Kafka-Clusters werden dabei in Kategorien gespeichert, die man *Topics* nennt." Außerdem beschreibt die Apache Software Foundation (2017a), dass jeder Datensatz aus einem Key, einem Value und einem Zeitstempel besteht.
Das bedeutet, unter einem Cluster wird ein vollständiges System für Kafka verstanden, welches mehrere Komponenten umfasst.

## Zentrale Kafka-Komponenten
Wichtige Komponenten im Zusammenhang mit Apache Kafka sind Folgende (Narkhede et al., 2017, S. 4 ff.):

Der *Sender* stellt den *Produzenten* von Nachrichten dar, durch den die Zuordnung der *Nachricht(en)* zu einer logischen Kategorie, dem sogenannten "Topic", erfolgt. Für die bessere Skalierbarkeit ist ein Topic in mehrere Partitionen unterteilt, in denen eine geordnete Speicherung aller Informationen erfolgt. Sobald eine Partition persistiert ist, besteht keine Möglichkeit mehr, Informationen zu verändern. Mit dem Senden erfolgt eine Replikation von Partitionen auf mehrere Broker für die erhöhte Ausfallsicherheit.

Eine weitere zentrale Komponente stellt der Broker (Kafka Server) dar, für den mehrere Instanzen im Cluster existieren (sollten). Diese, möglichst auf unterschiedlichen physischen Systemen verteilten, Instanzen bieten eine hohe Ausfallsicherheit. Grundlegend befasst sich der Broker mit Nachrichten, welche er als Schlüssel-Wert-Paar speichert.

Auch zu den Kafka-Komponenten werden weitere Details in den nachfolgenden Kapiteln beschrieben.

## Wichtige Kafka-Schnittstellen
Über die Komponenten hinaus lassen sich laut der Apache Software Foundation (2017a) in Bezug auf Kafka insbesondere vier wichtige Schnittstellen betrachten:

- Producer API
- Consumer API
- Connector API
- Kafka Streams API

Apache Kafka stellt daher grundsätzlich eine Möglichkeit dar, klassische Extract-Transform-Load- sowie Batch-Strukturen abzulösen und mit entsprechenden Optimierungen durch Kafka abzulösen.

---

| [<< Inhaltsverzeichnis](README.md) | Einleitung | [Grundlagen >>](02_grundlagen.md) |
|------------------------------------|------------|-----------------------------------|
