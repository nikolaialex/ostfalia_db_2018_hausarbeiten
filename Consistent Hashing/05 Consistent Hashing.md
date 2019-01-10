# Consistent Hashing  

## Warum  

Mit der Zeit werden immer mehr anspruchsvollere Systeme bzw. Software entwickelt und eingesetzt. Auch deren Ansprüche haben sich weiterentwickelt. Dies hat zur folge, dass immer mehr Daten gespeichert, verwaltet und angefragt werden. Solche wachsenden Lasten können mit klassischen Servern nicht  abgedeckt werden, außerdem ist der Speicher der Server begrenzt. Hier schafft das Verfahren von verteilten Netzwerk mit vielen Servern abhilfe.  

In den folgenden Abschnitt wird die Frage beantwortet: Wie verhält sich ein verteiltes Datenbanksystem?  Im Einsatz einer verteilten Datenbank sind weitere Fragen zu klären, wie welche Daten werden auf welchen Servern geschrieben? Wie können Anfragen am besten auf alle Server gleich verteilt werden?  Und Was passiert, wenn ein Server ausfällt?

## Das Verfahren  

Mittels _Distributed Hashing_ (verteilte Hashtabelle)  werden die Daten gleichmäßig auf die _Server_ (Knoten) verteilt,  dabei entspricht jeder Knoten einem Eintrag in der Hashtabelle. In einem solchen Verfahren werden die Datenobjekte mit Schlüssel auf die Server verteilt.

In der Tabelle 1.1 werden den drei Servern A, B, und C die Schlüssel zugewiesen, dabei wird von jedem Schlüssel der Hashwert berechnet und die Modulo-Operation (Anzahl der Server) durchgeführt. Das Ergebnis weist durch einen Index den entsprechenden Server an, siehe Tabelle 1.2.  

| Schlüssel        | Hash           | Hash mod 3  |
| :-------------: |:-------------:| :-----:|
| "john"      | 1633428562 | 1 |
| "bill"      | 7594634739      |  0 |
| "jane" | 5000799124      |    1 |
| "kate" | 3421657994      |    2 |
