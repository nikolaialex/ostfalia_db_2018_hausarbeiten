[<<1. Abstract](Abstract.md)

[>>3. Implementierung](Implementierung.md)

***


## 2. Einleitung
Google Spanner ist eine skalierbare, global verteilte Datenbank, die von Google designt, gebaut und deployed wird. Die einzelnen Daten liegen verteilt in Rechenzentren auf der ganzen Welt. Repliktation wird für globale Verfügbarkeit genutzt. Kunden greifen auf verschiedene Datenquellen zu, ohne es zu merken. Spanner verteilt die Daten je nach Bedarf über verschiedene Server, verschiedene Maschinen, sogar über verschiedene Rechenzentren. Im Falle eines Stromausfalls oder gar einer nationalen Naturkatastrophe können die Daten von einem Rechenzentrum zu einem anderen oder hunderten von anderen Rechenzentren migriert werden. Spanner ist so konzipiert, dass die Datenbank bis zu Millionen von Maschinen in allen Bereichen skaliert in hunderten von Rechenzentren und Milliarden von Datenbankzeilen.<sup>5</sup> 

Vorherige Lösungen anderer Anbieter hatten meistens als Ausfallsicherheit eine Fallback-Lösung auf ein oder zwei andere Rechenzentren, diese jedoch meistens ebenfalls national. Im Falle einer nationalen Naturkatastrophe also keine geeignete Lösung, um trotzdem eine Ausfallsicherheit garantieren zu können.<sup>6</sup>  

Spanners Hauptfokus richtet sich auf die Replikation zwischen verschiedenen Rechenzentren, aber die Entwickler der Google  Spanner Datenbank haben auch einen großen Teil ihrer Zeit für die Entwicklung von Datenbankenfeatures verwendet.<sup>7</sup> 

Viele Projekte verwenden das Format „Bigtable“, es gab jedoch Beschwerden von Usern, die „Bigtable“ für einige Applikationen für ungeeignet betrachten. Zum Beispiel Applikationen mit komplexen, sich entwickelnden Schemata oder solche, die eine starke Konsistenz wünschen trotz Wide-Area Replikation. Viele Applikationen nutzen „Megastore“ wegen seines semi-relationalen Datenmodells und seiner Unterstützung für die synchrone Replikation trotz seines relativ geringen Schreibdurchsatzes.<sup>8</sup>  

Als Konsequenz dieser Rückmeldungen hat Spanner sich von einer Bigtable-artigen  Schlüsselwertspeicher in eine zeitliche Multiversionsdatenbank entwickelt. Die Daten werden in schematisierten semirelationalen Tabellen gespeichert. Die Daten werden versioniert, und jede Version wird automatisch mit einem Commit mit Zeitstempel versehen. Alte Versionen von Daten unterliegen konfigurierbaren Richtlinien (Garbage-Collection-Policies). Anwendungen können Daten zu alten Zeitstempeln auslesen. Cloud Spanner unterstützt allgemeine Transaktionen und bietet eine SQL-basierte Abfragesprache.<sup>9</sup>  

Als global verteilte Datenbank bietet Spanner einige interessante Funktionen: 

Erstens können die Replikationskonfigurationen für Daten feingranular dynamisch gesteuert werden von den unterschiedlichen Applikationen. 

Applikationen können Bedingungen spezifizieren, welche Rechenzentren welche Daten erhalten sollen, wie weit entfernt die Daten von den Benutzern gelagert werden sollen (um damit die Latenzzeit der Lesezugriffe gering zu halten), und wie viele Replikationen beibehalten werden sollen (zur Kontrolle der Lebensdauer, Verfügbarkeit und Leseleistung).

Daten können auch dynamisch und transparent zwischen den Rechenzentren vom System verschoben werden, um die Ressourcen der verschiedenen Rechenzentren effizient auszunutzen. 

Google Spanner hat zwei Features, die schwierig in verteilten Datenbanken zu implementieren sind: Spanner bietet konsistente Lese- und Schreibzugriffe von extern an und global konsistente Lese-Zugriffe über die ganze Datenbank zu einem bestimmten Timestamp/Zeitpunkt.  Diese Features ermöglichen es Spanner konsistente Backups zu liefern, konsistente MapReduce Executions durchzuführen (MapReduce ist ein vom Unternehmen Google eingeführtes Programmiermodell für nebenläufige Berechnungen über (mehrere Petabyte) große Datenmengen auf Computerclustern<sup>10</sup>) und Atomic Schema Updates, alle diese Operationen auf globaler Ebene und sogar während laufender Transaktionen.<sup>11</sup>  

Diese Features kann Google Spanner zur Verfügung stellen, weil ein neuartiges Timestamp-Verfahren es möglich macht. Spanner legt Zeitstempel auch fest, wenn verteilte Transaktionen durchgeführt werden. Wenn eine Transaktion T1 ausgeführt wird, bevor eine andere Transaktion T2 startet, dann ist T1s commit Timestamp kleiner als der Timestamp von T2. Spanner ist das erste System das das weltweit anbietet.<sup>12</sup>  

Zugrunde liegt diesen Funktionen die TrueTime API und ihre Implementierung.

Die TrueTime API macht die Uhrabweichungen direkt sichtbar, und die Garantien für die Zeitstempel von Spanner hängen von den Grenzen ab, die die Implementierung bietet. Wenn die Unsicherheit zu groß ist, verlangsamt Spanner sich, um diese Ungewissheit abzuwarten. Googles Cluster-Management-Software bietet eine Implementierung der TrueTime-API. Diese Implementierung hält die Unsicherheit gering (im Allgemeinen weniger als 10 ms), indem drei moderne Uhrreferenzen (GPS und Atomuhren) genutzt werden. 
Es muss abgewogen werden zwischen der korrekten Zeitauszeichnung (Timestamp), diese muss aus Perfomance-Gründen jedoch gering gehalten werden.<sup>13</sup>

***

Quellen:

<sup>5</sup> James C. Corbett (2012), S. 1

<sup>6</sup>James C. Corbett (2012), S. 1 - 2

<sup>7</sup> James C. Corbett (2012), S. 2

<sup>8</sup>James C. Corbett (2012), S. 2

<sup>9</sup> James C. Corbett (2012), S. 2

<sup>10</sup>Titzel, Nico (2017)

<sup>11</sup>James C. Corbett (2012), S. 2

<sup>12</sup>James C. Corbett (2012), S. 2

<sup>13</sup>James C. Corbett (2012), S. 2


