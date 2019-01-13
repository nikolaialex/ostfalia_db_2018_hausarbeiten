# 5.2 Amazon Dynamo(DB)

Das Wachstum der Firma Amazon und die hierdurch verbundene gestiegene Anzahl von
(gleichzeitigen) Besuchern der Dienste-Webseiten, führen zu notwendigen
Schranken in denen andere Services und Datenbanksysteme eine Antwort auf eine
Anfrage liefern müssen [1]. Im Jahr 2007 stellt Amazon für diese Zwecke das
*key-value* basierte Datenbanksystem Dynamo vor. Dynamo bietet
eine hochverfügbare und skalierbare verteilte Datenbank [1].
Das *key-value* Design entspricht vieler interner Nutzungsszenarien bei Amazon [1].
Es hat im Vergleich zu (voll)relationalen Datenbanksystemen weniger
Performance-Overhead und bietet eine sehr einfache Schnittstelle durch die zwei
Methoden *put* und *get* [1].

**Anmerkung**: Im Jahr 2012 stellt Amazon den Dynamo Nachfolger DynamoDB vor.
DynamoDB baut in seinen Kerntechniken auf Dynamo auf [3]. Im Folgenden werden
daher die Kerntechniken von Dynamo vorgestellt, die ausführlich in einer
Veröffentlichung von Amazon vorgestellt werden [1].

## 5.2.1 Architektur
Die eingesetzten Kerntechniken werden in Amazons Veröffentlichung beschrieben,
nicht aber die Details der Systemarchitektur von Dynamo [1].
Die folgende Tabelle 1 bietet eine Übersicht dieser Techniken.

<table>
<thead>
<tr>
<th>Problem</th>
<th>Technik</th>
<th>Stärke</th>
</tr>
</thead>

<tbody>
<tr>
<td>Partitionierung</td>
<td>Konsistentes Hashing</td>
<td>Inkrementelle Skalierbarkeit</td>
</tr>
<tr>
<td>Hohe Verfügbarkeit für Schreibvorgänge</td>
<td>Vektor-Uhren mit Ausgleich beim Lesen</td>
<td>Die Versionsnummer ist von der Aktualisierungsrate entkoppelt.</td>
</tr>
<td>Behandlung von temporären Fehlern</td>
<td>Ungenaues Quorum und angedeutete Übergabe</td>
<td>Sorgt für hohe Verfügbarkeit und Langlebigkeit wenn einige Replikas nicht verfügbar sind.</td>
</tr>
<tr>
<td>Erholung von permanenten Fehlern</td>
<td>Anti-Entropie unter Verwendung von Merkle Bäumen</td>
<td>Synchronisiert divergierende Replikas im Hintergrund.</td>
</tr>
<tr>
<td>Mitgliedschaft- und Fehlererkennung</td>
<td>Gossip-basiertes Mitgliedschaft Protokoll und Fehlererkennung.</td>
<td>Erhält Symmetrie und vermeidet eine zentrale Registrierungsstelle, welche
  die Mitgliedschaften und Knoten Informationen vorhält.</td>
</tr>
</tbody>
</table>

Tabelle 1: Zusammenfassung der Kerntechniken in Dynamo und deren Stärken,
übersetzt nach DeCandia et. al. (2007) [1].

## 5.2.2 Datenmodell
Das Datenmodell entspricht im Wesentlichen einem *key-value* Modell mit den Methoden <code>put()</code>
und <code>get()</code> [1]. Bei Aufruf der Methode <code>get(key)</code> werden
die (unterschiedlichen) Objekt-Replikas entweder als einzelnes Objekt oder als
Liste von Objekten mit konfliktbehafteten Versionen gemeinsam mit einem
<code>context</code> zurückgegeben [1].

## 5.2.3 Algorithmus zur Partitionierung
Amazon definiert inkrementelle Skalierbarkeit als eine der Schlüsseleigenschaften
von Dynamo. Hierzu hat Amazon die Grundlagen zum *Consistent Hashing* von Karger et. al. erweitert [2].
Die Erweiterung war notwendig, damit die Daten auf der Ringstruktur nicht
zufällig verteilt werden [1]. Eine zufällige Verteilung führt zu nicht-uniformer
Verteilung der Daten und Last [1]. Um diese beliebige Verteilung zu verhindern,
implementiert Amazon das Konzept "virtueller Knoten", welche Zuordnungen
von Knoten zu mehreren Punkten auf dem Ring zulassen [1].  

Amazon sieht hierin drei wesentliche Vorteile [1]:
- Ist ein Knoten im Fehlerfall oder zur Wartung unerreichbar, so verteilt sich
  die Last des ausgefallenen Knotens gleichmäßig auf die verbleibenden
  verfügbaren Knoten
- Wird ein Knoten wieder verfügbar oder ein zusätzlicher Knoten wir dem System
  hinzugefügt (Kernanforderung), dann erhält der neue Knoten eine in etwa
  gleiches Maß an Last von den anderen verfügbaren Knoten.
- Die Anzahl an virtuellen Knoten für die ein einzelner Knoten zuständig ist,
  wird nach seiner verfügbaren Kapazität berechnet. Dies führt zu Heterogenität
  in der physischen Infrastruktur.

## 5.2.4 Replizierung

Die Ringstruktur wird ebenso für die Replizierung verwendet [1]. Pro Dynamo
Instanz wird konfiguriert auf wie vielen (N) Hosts ein Datenelement gespeichert
wird. Dabei führt eine Koordinator-Funktion die Replizierung so durch, dass ein
Knoten für einen Bereich auf dem Ring zuständig ist, der von sich selbst bis zu
seinem N-ten Vorgänger reicht [1].

## 5.2.5 Vektor Uhren zur Versionierung der Daten-Objekte
Durch Vektor Uhren können bei Dynamo, aufbauend auf der Arbeit von Leslie Lamport,
Aussagen über Chronologie und kausale Beziehungen getroffen werden [4].
Hier sind Vektor Uhren als Liste von (Knoten, Zähler)-Paaren implementiert [1].  
Ein Beispiel einer Vektor Uhr ist: <code>Objekt1([Sx, 2], [Sy, 1])</code>.
Jeder Version eines Datenobjektes ist eine Vektor Uhr zugeordnet [1]. Durch Analyse
der verknüpften Vektor Uhr kann überprüft werden, in welchem Verhältnis
(chronologisch, kausal) zwei Objektversionen zueinander stehen.
Seien <code>C<sub>1</sub>([Sx, 2], [Sy, 1])</code> und <code>C<sub>2</sub>([Sx, 3], [Sy, 2])</code> Vektor Uhren. Alle Knoten die sowohl in <code>C<sub>1</sub></code> als auch in
<code>C<sub>2</sub></code> vorkommen, haben in <code>C<sub>1</sub></code> einen
niedrigeren Zählerwert als in <code>C<sub>2</sub></code>, also ist <code>C<sub>1</sub></code>
ein Vorgänger von <code>C<sub>2</sub></code> und <code>C<sub>1</sub></code> kann
ignoriert werden [1].

## 5.2.6 Kritik

Aufbauend auf Dynamo wurde der Nachfolger DynamoDB entwickelt, der als Konkurrent zu Google Spanner bei Cloud-basierten Datenbaksystemen gilt. Dieser Nachfolger bietet ein paar Kritikpunkte, die hier näher erläutert werden.

DynamoDB hat kein öffentliches Service Level Agreement, worunter die Kontrollmöglichkeit für den Nutzer leidet. Zudem besitzt es zwar ein flexibles Schema und arbeitet mit komplexen Datentypen wie JSON-Dokumenten, aber SQL wird als Abfragesprache nicht unterstützt. Zwar sind die JSON-Anfragen nicht nennenswert umfangreicher als die SQL-Anfragen, aber die Lesbarkeit und die Qualität der Anfrage ist bei SQL höher. Außerdem unterstützt DynamoDB keine Gruppierung (GROUP BY), Aggregationsfunktionen oder Verbindungen (JOIN). [5]

DynamoDB repliziert die Daten über drei Standorte in einer Region, um eine hohe Verfügbarkeit zu gewähren. Im Falle einer grenzübergreifenden Replikation bietet DynamoDB allerdings keine Lösung an. Es wird hingegen eine Replikationsbibliothek und ein Kommandozeilenprogramm angeboten, die mit zusätzlichen Kosten verbunden sind. [5]

<br />

[1] Giuseppe DeCandia, Deniz Hastorun, Madan Jampani, Gunavardhan Kakulapati,
Avinash Lakshman, Alex Pilchin, Swaminathan Sivasubramanian, Peter Vosshall
and Werner Vogels (2007). Dynamo: Amazon’s Highly Available Key-value Store.

[2] Karger, D., Lehman, E., Leighton, T., Panigrahy, R., Levine,
M., and Lewin, D. 1997. Consistent hashing and random
trees: distributed caching protocols for relieving hot spots on
the World Wide Web. In Proceedings of the Twenty-Ninth
Annual ACM Symposium on theory of Computing (El Paso,
Texas, United States, May 04 - 06, 1997). STOC '97. ACM
Press, New York, NY, 654-663.

[3] Vogels, W. (2012). Amazon DynamoDB – a Fast and Scalable NoSQL Database Service Designed for Internet Scale Applications.
URL: https://www.allthingsdistributed.com/2012/01/amazon-dynamodb.html.
(letzter Aufruf: 02.01.2019)

[4] Lamport, L. (1978). Time, clocks, and the ordering of events in a
distributed system. ACM Communications, 21(7), pp. 558-
565.

[5] Chaves, W. (2017, November 27). Current State of the NewSQL/NoSQL Cloud Arena. Retrieved January 12, 2019, from https://www.red-gate.com/simple-talk/cloud/cloud-data/current-state-newsqlnosql-cloud-arena/

***
[<< 5.1 Google Spanner](5_1_Spanner.md) | [5.3 Ein Vergleich zwischen Google Spanner und Amazon DynamoDB >>](5_3_Ein_Vergleich_zwischen_Google_Spanner_und_Amazon_DynamoDB.md)
***
