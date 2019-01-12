# 5.1 Google Spanner

Seit 2011 wird Spanner im Produktivbetrieb als skalierbares, global-verteiltes Datenbanksystem
bei Google eingesetzt [1]. Die Entwicklung wurde in 2007 begonnen [4].
Spanner kann verteilt auf Hunderten von Datenzentren mit Millionen
von Maschinen ausgeführt werden [1]. Für weltweite Erreichbarkeit und
geografische Lokalität wird Replikation eingesetzt, welche automatisch
Daten zwischen Maschinen und sogar zwischen Datenzentren migriert [1].

Spanner hat sich von einem Bigtable-ähnlichen Datenbanksystem zu einem
zeitlich-multiversionierten System weiterentwickelt [1]. Daten werden durch
Zeitstempel (zum Commit-Zeitpunkt) mit Nanosekunden-Präzision geschrieben [1].
Google hebt starke Konsistenz, SQL Unterstützung (ANSI 2011 mit Erweiterungen)
und verwaltete Instanzen mit hoher Verfügbarkeit hervor [2]. Die Eigenschaften
sind in Abbildung 1 tabellarisch gegenübergestellt.

![Spanner Feature Comparison](/CAP/media/cloud-spanner-4vhuv.max-1000x1000.PNG)
Abbildung 1: Vergleich von Eigenschaften zwischen Spanner, traditionell relationalen
und traditionell nicht-relationalen Datenbanksystemen, übernommen von
[Google (2017)](https://cloud.google.com/blog/products/gcp/introducing-cloud-spanner-a-global-database-service-for-mission-critical-applications).

## 5.1.1 Architektur
Corbett et. al. (2012) stellen nur eine High-Level Sicht zur Verfügung (s. Abbildung 2).
Ganz oben finden sich die als Singleton implementierten *universemaster* und der
*placement driver*, wobei der *universemaster* im Wesentlichen eine Konsole mit
Statusinformationen für interaktives Debugging über alle Zonen bereitstellt [1].
Der *placement driver* kommuniziert periodisch mit den *spanservers*, um Daten zu
finden, die migriert werden müssen durch neue Replikations-Beschränkungen oder
zur Lastverteilung [1]. Eine Zone besteht aus einem *zonemaster* und zwischen
hundert bis mehreren tausend *spanservers* [1]. Ein *zonemaster* weist den
*spanservers* Daten zu und diese wiederum stellen die Daten den Clients bereit [1].
Die *location proxies* (pro Zone) dienen dem Client zum Aufinden von geeigneten
*spanservers* [1].

![Übersicht der High-Level Architektur von Google Spanner](/CAP/media/uebersicht-high-level-architektur-spanner.PNG)

Abbildung 2: Übersicht der High-Level Architektur von Google Spanner,
übernommen von Corbett et. al. (2012) [1].

Gemäß der offiziellen Dokumentation von Google ist diese Architektur wie folgt
geografisch verteilt (s. Tabelle 1).

<table>
<thead>
<tr>
<th></th>
<th>Region Name</th>
<th>Region Description</th>
</tr>
</thead>

<tbody>
<tr>
<td><strong>Americas</strong></td>
<td></td>
<td></td>
</tr>
<tr>
<td></td>
<td><code>northamerica-northeast1</code></td>
<td>Montréal</td>
</tr>
<tr>
<td></td>
<td><code>us-central1</code></td>
<td>Iowa</td>
</tr>
<tr>
<td></td>
<td><code>us-east1</code></td>
<td>South Carolina</td>
</tr>
<tr>
<td></td>
<td><code>us-east4</code></td>
<td>Northern Virginia</td>
</tr>
<tr>
<td></td>
<td><code>us-west1</code></td>
<td>Oregon</td>
</tr>
<tr>
<td></td>
<td><code>us-west2</code></td>
<td>Los Angeles</td>
</tr>
<tr>
<td><strong>Europe</strong></td>
<td></td>
<td></td>
</tr>
<tr>
<td></td>
<td><code>europe-north1</code></td>
<td>Finland</td>
</tr>
<tr>
<td></td>
<td><code>europe-west1</code></td>
<td>Belgium</td>
</tr>
<tr>
<td></td>
<td><code>europe-west4</code></td>
<td>Netherlands</td>
</tr>
<tr>
<td><strong>Asia Pacific</strong></td>
<td></td>
<td></td>
</tr>
<tr>
<td></td>
<td><code>asia-south1</code></td>
<td>Mumbai</td>
</tr>
<tr>
<td></td>
<td><code>asia-east1</code></td>
<td>Taiwan</td>
</tr>
<tr>
<td></td>
<td><code>asia-east2</code></td>
<td>Hong Kong</td>
</tr>
<tr>
<td></td>
<td><code>asia-northeast1</code></td>
<td>Tokyo</td>
</tr>
<tr>
<td></td>
<td><code>asia-southeast1</code></td>
<td>Singapore</td>
</tr>
</tbody>
</table>

Tabelle 1: Spanner Instanz Konfigurationsmöglichkeiten nach Region,
übernommen von [Google Cloud Spanner Dokumentation (2018)](https://cloud.google.com/spanner/docs/instances).

## 5.1.2 Datenmodell
Das Datenmodell basiert auf schemabehafteten semi-relationalen Tabellen, die wie
relationale Datenbanktabellen Zeilen, Spalten und versionierte Werte haben, einer
SQL-ähnlichen Abfragesprache und universell einsetzbaren Transaktionen [1].  

Jede Datenbank muss so partitioniert sein das es mindestens eine Hierarchie von
Tabellen existiert (mehrere sind möglich) [1].
Listing 1 zeigt ein SQL-ähnliches Code-Beispiel wie eine Hierarchie von Userdaten
und deren Fotoalbum erstellt werden kann.

~~~
CREATE TABLE Users {
  uid INT64 NOT NULL, email STRING
} PRIMARY KEY (uid), DIRECTORY;

CREATE TABLE Albums {
  uid INT64 NOT NULL, aid INT64 NOT NULL,
  name STRING
} PRIMARY KEY (uid, aid),
  INTERLEAVE IN PARENT Users ON DELETE CASCADE;
~~~
Listing 1: Schema für Foto-Metadaten in Spanner und die verschränkten Tabellen
(durch INTERLEAVE IN). Angepasst nach Corbett (2012) [1].

## 5.1.3 Datentypen
Google Spanner bietet die folgenden simplen und komplexen Datentypen an:
 **[ARRAY](https://cloud.google.com/spanner/docs/data-types#array-type)**,
 **[BOOL](https://cloud.google.com/spanner/docs/data-types#boolean-type)**,
 **[BYTES](https://cloud.google.com/spanner/docs/data-types#bytes-type)**,
 **[DATE](https://cloud.google.com/spanner/docs/data-types#date-type)**,
 **[FLOAT64](https://cloud.google.com/spanner/docs/data-types#floating-point-type)**,
 **[INT64](https://cloud.google.com/spanner/docs/data-types#integer-type)**,
 **[STRING](https://cloud.google.com/spanner/docs/data-types#string-type)**,
 **[STRUCT](https://cloud.google.com/spanner/docs/data-types#struct-type)** und
 **[TIMESTAMP](https://cloud.google.com/spanner/docs/data-types#timestamp-type)**.
 Für mehr Informationen zu einzelnen Datentypen
 ist jeder einzelne Typ zur offiziellen Dokumentation verlinkt.  

 Besonders hervorzuheben ist der Typ **[TIMESTAMP](https://cloud.google.com/spanner/docs/data-types#timestamp-type)**,
 der mit einer Größe von zwölf Bytes ermöglicht Zeitstempel mit
 Nanosekunden-Präzision zu speichern. Eine derart hohe Präzision ist für TrueTime
 entscheidend und wird näher im Abschnitt TrueTime beschrieben.

## 5.1.4 TrueTime
Zwei Stärken von TrueTime liegen in (1) sehr präzisen Zeitquellen an allen Standorten,
die sich untereinander abgleichen und bei hoher Divergenz selbst abwählen und (2)
der impliziten Umsetzung von Zeit als Intervall *TTinterval* mit einberechneter
Ungewissheit [1]. Dies zeigt sich ebenfalls in der Implementierung der TrueTime API [1].

### Wie wird Zeit in einem Datenzentrum *präzise gehalten*?
Damit jedes Datenzentrum eine möglichst präzise Zeit hat und halten kann, gibt es
bis zu zwei Mechanismen vor Ort [1].  
Ein GPS-Empfänger ist eine mögliche Zeitquelle. Weil GPS verschiedenen Fehleranfälligkeiten unterliegen kann, wie (1)
Referenzquellen Schwächen beinhalten Antennen- und Empfängerfehler, (2) lokale
Funkinterferenz, korrelierte Fehler (z. B. Design-Fehler, falsche Behandlung von
Schaltsekunden) und (3) GPS-Systemausfällen [1].  
Die zweite mögliche Zeitquelle für ein Datenzentrum ist eine lokale Atomuhr,
welche unabhängig von GPS und anderen Atomuhren unpräzise werden kann [1].  
TrueTime wurde so implementiert das es pro Datenzentrum mehrere *time master*
Maschinen gibt, die ihre Zeit entweder von entkoppelten GPS-Empfängern
oder von Atomuhren beziehen (genannt: *Armageddon masters*) [1]. Master Maschinen wiederum
vergleichen ihre Zeit untereinander. Hierbei vergleicht ein einzelner *time master*
die Abweichung seiner lokalen Zeit mit der vom Referenzzeitgeber. Ist die Differenz zu
groß, stellt er den Dienst als *time master* ein [1]. (**Anmerkung der Autoren**:
Corbett et. al. erläutern nicht, ob und wie ein *time master* zu einem späteren
Zeitpunkt nach Dienstbeendigung gegebenenfalls wieder seinen Dienst aufnimmt.)  
Des Weiteren gibt es pro Maschine einen *timeslave* Dienst, der zur
Fehlervermeidung von mehreren *time master* Maschinen die Zeit abfragt [1].

Wenn eine Transaktion T<sub>1</sub> angewendet bevor eine Transaktion T<sub>2</sub>
beginnt, dann ist der Zeitstempel von T<sub>1</sub> kleiner als von T<sub>2</sub> [1].

Im Jahr 2012 war Spanner das erste System, welches solche Garantien gab [1].

### Wozu dienen Zeitinvervalle bei hochpräzisen Uhren?
Die Verwendung von Zeitintervallen bietet auch mit Hochpräzisions-Zeitquellen Vorteile.
Unterschiedliche Faktoren sorgen für eine ungewollte Abweichung der gehaltenen Zeit in einem
Datenzentrum im Vergleich zu einem anderen (s. vorheriger Abschnitt).

Alle 30 Sekunden fragt der *timeslave* Dienst die Zeit ab [1]. Bereits die
Geschwindigkeit der Signalausbreitung und Signalverarbeitung erzeugen Latenzen.
Der Dienst berechnet eine Ungewissheit Epsilon mit ein, die sich in einem
Abfrageintervall zwischen 1 und 7 ms bewegt [1]. Also im Durchschnitt meist 4 ms.

Die zwei vorgestellten Mechanismen sorgen für starke Konsistenz der Daten.

## 5.1.3 Kritik
Penkava (2018) vergleicht Spanner als Drop-In für MySQL Varianten (unter anderem) [3].
Hierbei nennt Penkava folgende Verbesserungspotenziale: (1) Die Google JDBC-API
stellt keine Data Manipulation Language (DML) und Data Definition Language (DDL)
Befehle bereit und es muss auf Dritt-APIs zurückgegriffen werden,  
(2) Spanner unterstützt keine Views, welche oft als logische Abstraktionsschicht
und oder als Sicherheitsschicht verwendet werden,  
(3) keine Möglichkeit für eine firmen-lokale Bereitstellung,  
(4) eingeschränkte Möglichkeiten für Richtlinien und Sicherheitsberechtigungen  
und beides nur auf hoher Ebene mit *Google’s Identity & Access Management* Werkzeug,  
und (5) es gibt keine Backup Funktion.  

Die Google JDBC-API unterstützt seit 3.11.2017 DDL-Statements und seit
11.10.2018 auch DML-Statements und JDBC-Transaktionen [5].  
Seit 17.7.2018 ist es möglich in *Apache Avro*-Dateien [7] zu exportieren beziehungsweise
importieren [6].

<br />

[1] J. Corbett, J. Dean, M. Epstein, et. al.
Spanner: Google’s Globally-Distributed Database. Proceedings of OSDI ‘12: Tenth Symposium on
Operating System Design and Implementation, Hollywood, CA, October, 2012

[2] Google (2018). Cloud Spanner. URL:
https://cloud.google.com/spanner/docs/overview (letzter Aufruf: 01.01.2019)

[3] Ales Penkava (2018). Google Cloud Spanner: the good, the bad and the ugly.
URL: https://www.lightspeedhq.com/blog/google-cloud-spanner-good-bad-ugly/#tech.
(letzter Aufruf: 01.01.2019)

[4] Deepti Srivastava (2017). Introducing Cloud Spanner: a global database service for mission-critical applications.
URL: https://cloud.google.com/blog/products/gcp/introducing-cloud-spanner-a-global-database-service-for-mission-critical-applications.
(letzter Aufruf: 01.01.2019)

[5] Google (2018). Simba JDBC Driver with SQL Connector for Cloud Spanner Release Notes.
URL: https://storage.cloud.google.com/simba-cs-release/jdbc/CloudSpannerJDBC41-1.0.10.1019.zip
(letzter Aufruf: 01.01.2019)

[6] Deepti Srivastava (2018). Cloud Spanner adds import/export functionality to ease data movement
URL: https://cloud.google.com/blog/products/gcp/cloud-spanner-adds-import-export-functionality-to-ease-data-movement.
(letzter Aufruf: 01.01.2019).

[7] The Apache Software Foundation (2018). Apache Avro™ 1.8.2 Documentation.
URL: https://avro.apache.org/docs/current/.
(letzter Aufruf: 01.01.2019).

***

[Amazon DynamoDB >>](5_2_DynamoDB.md)

***
