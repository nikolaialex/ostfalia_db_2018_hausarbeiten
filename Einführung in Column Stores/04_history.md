***

[<< zurück](02_toc.md)

***

# 2. Hintergrund und Überblick

Immer mehr Menschen nutzen das Internet und hinterlassen Daten und Informationen, die von Firmen gesammelt und ausgewertet werden wollen. Im sehr großen Bereich geschieht dies auf sozialen Medien, wie Facebook, Instagram und co. Im Januar 2018 verzeichnet Facebook rund 2.17 Milliarden monatlich aktiven Nutzern und stellt damit den weltweit größten sozialen Netzwerk dar. [ST18] Für diese große Menge von Daten und Abfragen eignen sich vor allem verteilte nichtrationale Wide Column Stores. Spaltenorientierte Datenbank-Systeme wurden speziell für den effektiven und effiziente Speicherung und Auswertung von Datenmengen geschaffen.

Die gesammelten Datenmengen möchten von den Firmen analysiert und ausgewertet werden. Dafür wird das Online Analytics Processing, kurz OLAP, für das Extrahieren und Auswerten der Daten aus verschiedenen Blickwinkeln, genutzt. [SES18] Wichtig ist, dass man die Ausführungsdauer dieser analytischen Abfragen gering hält. Das Datenmodell der spaltenorientierten Datenbanken-Systeme passt gut zu den Anforderungen dieser OLAP-Abfragen.

## Überblick

Die ersten Anfänge einer Art spaltenorientierten Datenbankstruktur kann man aus dem Gebiet der Verwaltung von medizinischen Akten aus den 70er Jahren erkennen.[DHJ07]  Einer der ersten Vorgänger von Column Store war Cantor. Es war ein transportables, rein relationales System für die Analyse von von großen Datenmengen, die komplexe Informationsstrukturen bilden können. [KS14]

Heutzutage steigt das Volumen von gespeicherten Datenmengen in Rechenzentren weltweit immer weiter an. Im Jahr 2007 beträgt die Datenmenge rund 397 Exabyte weltweit. Die Prognosen für 2020 sieht eine Steigerung auf 985 Exabyte. Das ist fast eine Verdreifachung der Datenmenge.[ST18-2]

Besonders die Firma Google mit ihren zahlreichen Diensten, wie Google Websuche, Google Mail, Google Maps, Google Earth, Youtube und viele weitere Dienste benötigen ein Datenbanksystem, um diese Datenmengen im Petabyte-Bereich speichern zu können. In dem 2006 veröffentlichten Paper “Bigtable: A Distributed Storage System for Structured Data” beschreibt F. Chang et al, wie Google mit Bigtable ein eigenes verteiltes Datenbanksystem geschaffen hat, mit dem die heutigen Google Dienste arbeiten. Darunter Google Analystics, Google Finance, Orkut und viele mehr. Bigtable baut aus dem verteilten Dateisystem GFS (Google File System) auf, welches für die Google Websuche entwickelt und optimiert worden wurde. Die großen technischen Anforderungen sind dabei die breiten Anwendungsmöglichkeiten, Skalierbarkeit, hohe Performance und sowie Verfügbarkeit.[CDG06]

Auch die andere große Unternehmen, wie Amazon und Facebook, wussten einen für sich eigenen Weg finden, ihre Daten zu speichern. 

In dem Paper “Dynamo: Amazon´s Highly Available Key-value Store”, welches 2007 veröffentlicht worden ist, präsentiert G.DeCandia et al. den Aufbau und Umsetzung von Dynamo. Dynamo ist ein Key-Value-Datenbanksystem speziell für die Bedürfnisse von Amazon entwickelt. Bei Online-Shopping kann schon ein kleiner Ausfall der Datenbank sehr schnell hohe finanzielle Konsequenzen bedeuten. Deshalb war es für Amazon sehr wichtig ein Datenbanksystem zu entwickeln, der die größtmögliche Verlässlichkeit vor Ausfällen bietet. Auch bei Dynamo wird mit einem verteilten Dateisystem gearbeitet. [DHJ07]

Facebook entwickelte im Jahr 2008 das recht bekannte Open Source Datenbanksystem Cassandra, welches im Kapitel 6.1 näher eingegangen wird. Es stellt ein verteiltes System für große strukturierte Datenmengen, welches besonders die Wichtigkeit auf hohe Skalierbarkeit und Ausfallsicherheit legt. [WAC18]

***

[<< Inhaltsverzeichnis](02_toc.md) | [Grundlagen und Begriffe >>](05_basics.md)

***

```
Quellenangabe:

- [ST18]  https://de.statista.com/statistik/daten/studie/181086/umfrage/die-weltweit-groessten-social-networks-nach-anzahl-der-user/, abgerufen 25.12.2018
- [SES18]  https://www.searchenterprisesoftware.de/definition/Online-Analytical-Processing-OLAP, abgerufen 25.12.2018
- [DHJ07]   D. Abadi et al,  The Design and Implementation of Modern Column-Oriented Database Systems, Foundations and Trends  in Databases, 2012, S. 2007
- [KS14]   I. Karasalo und P. Svensson, The Design of Cantor - A New System for Data Analysis, 2014, S. 224
- [ST18-2] https://de.statista.com/statistik/daten/studie/819487/umfrage/prognose-zum-weltweit-gespeicherten-datenvolumen-in-rechenzentren/, abgerufen 26.12.2018
- [CDG06] F. Chang et al,  Bigtable: A Distributed Storage System for Structured Data. 2006,  S. 1.
- [DHJ07]G. DeCandia et al,  Dynamo: Amazon’s Highly Available Key-Value Store. 2007, S. 205
- [WAC18] https://de.wikipedia.org/wiki/Apache_Cassandra, abgerufen am 25.12.2018

```

***