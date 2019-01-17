# 3.2 RDBMS im Vergleich zu spaltenorientierten Datenbanken

Die Grundlage relationaler Datenbanksysteme bildet die mathematisch definierte Relation, die auch relationale Algebra genannt wird. Alle Daten in relationalen Datenbanken sind in Tabellen gespeichert, die miteinander in genau definierten Beziehungen stehen. Tabellen bestehen aus Zeilen, die auch Tupel genannt werden, und Spalten. Die Spalten sind mit Attributen gleichzusetzen. Attribute nehmen einen Bereich von Werten an, die über ein Relationsschema den Typ und die Anzahl der Attribute festlegen. In relationalen Datenbanken wird jedes Tupel (Datensatz) eindeutig über den Schlüssel identifiziert. Sämtliche Daten müssen konsistent und redundanzfrei abgelegt werden, was durch Normalisierung erreicht wird. In relationalen Datenbanksystemen wird als Datenbankabfragesprache SQL verwendet.

Der Modellierungsprozess relationaler Datenbanksysteme startet, ähnlich wie bei Softwareprojekten, mit einer Anforderungsanalyse. Mit den Anforderungen als Grundlage, wird ein ER (Entity-Relationchip) Modell erstellt. Das ER-Modell besteht aus Entitäten und Attributen. Entitäten sind Objekte der realen Welt, die durch Attribute näher beschrieben werden. Diese Entitäten stehen mit anderen Entitäten in Beziehung. Die Beziehungen werden mit Kardinalitäten gekennzeichnet. Entitäten werden Primär- und Fremdschlüssel zugewiesen. Die Schlüssel bilden die spätere Grundlage für JOIN-Operationen, die aus mehreren Tupeln, unterschiedlicher Tabellen, ein Ergebnistupel erzeugen.

Das fertige ER-Modell ist eine erste Grundlage für das Datenbankschema. Der nächste Schritt ist die sogenannte Normalisierung. Durch Normalisierung wird verhindert das Redundanzen auftreten. Nach der Normalisierung kann mithilfe der DDL (Data Definition Language) das Datenbankschema geschrieben werden.

Dieser Modellierungsprozess wurde stark komprimiert beschrieben. Eine sehr genaue Beschreibung der Abläufe findet der interessierte Leser in [#Elmasri2009]. 

Entscheidend ist folgende Tatsache. Im ganzen Modellierungsprozess wurde nicht darauf eingegangen, welche Abfragen letztendlich an die Datenbank gestellt werden. Das ist ein gravierender Unterschied zur Modellierung von spaltenorientierten Datenbanken, denn hier wird das Datenmodell anhand der Abfragen an die Datenbank entwickelt.

Die folgenden Beschreibungen zur Modellierung beziehen sich auf Cassandra, einem populären Vertreter spaltenorientierter Datenbanken. Bevor einige Regeln zur Modellierung von spaltenorientierten Datenbanken genannt werden, ist es wichtig daran zu denken, dass es sich um verteilte Datenbanken handelt. Das Ziel sollte immer sein, das Modell so zu wählen, dass linear skaliert werden kann, wenn dem Ring (siehe Kapitel 2.2) Knoten hinzugefügt werden. Ferner gibt es bei spaltenorientierten Datenbanken keine Fremdschlüsselbeziehungen und keine JOIN-Operationen, da diese Datenbanksysteme schemafrei sind. Die Datensätze sind in verschachtelten Hashmaps organisiert. 

Auch bei spaltenorientierten Datenbanken beginnt der Modellierungsprozess mit der Analyse der Anforderungen. Auch hier kann ein ER-Modell zur Modellierung der realen Welt verwendet werden. Auch sind die Beziehungen zwischen den Entitäten zu modellieren. Das fertige ER-Modell wird allerdings jetzt genutzt, um Abfragen an die Datenbank zu formulieren, die für die Anwendung wichtig sind. 

Diese Art der Modellierung wird auch als Abfrage-Modell bezeichnet. Damit eine gute Performance erzielt werden kann, sollten die Abfragen so wenige Partitionen wie möglich lesen. Optimal wäre, eine Partition wird pro Abfrage gelesen. 

Eine Partition ist ein Datensatz, der mithilfe des Partitionsschlüssels (Row-Key) gelesen werden kann. Dies hat zur Folge, dass das Datenmodell De-Normalisiert wird. Es werden bewusst Redundanzen in Kauf genommen bzw. sind Redundanzen ein Mittel zur besseren Modellierung. Das Datenmodell sollte zwei Zielen genügen. Die Daten müssen gleichmäßig im Cluster verteilt werden und die Anzahl der gelesenen Partitionen sollte minimiert werden.

Folgende Tabelle fasst die unterschiedlichen Ansätze der Modellierung zusammen. 

|                   | Relationale Datenbank | Spaltenorientierte Datenbank |
| ----------------- | --------------------- | ---------------------------------- |
| Use Cases         | Ja                    | Ja                                 |
| ER-Modell         | Ja                    | Ja                                 |
| Analyse von  Abfragen an die Datenbank | Nein | Ja - Abfrage-Getriebene-Modellierung. Die Abfrage von Partitionen muss minimiert werden. |
| Normalisierung | Ja | De-Normalisierung (Redundanzen als Werkzeug der Modellierung) |
| Primärschlüssel | Ja | Ja - Wahl des Primärschlüssels (Partitionsschlüssel) ist wichtig für gleichmäßige Verteilung im Ring. |
| Fremdschlüssel | Ja | Nein |
| JOIN-Operation | Ja | Nein - Muss auf Anwendungsebene verlagert werden. |


---

[<< 3.1 Datenmodell spaltenorientierter Datenbanken](modellierung_3_1.md) | [4 Fallbeispiel Datenmodellierung >>](beispiel_4.md)

---
