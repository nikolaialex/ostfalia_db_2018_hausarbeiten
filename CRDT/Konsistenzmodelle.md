[<- Gemeinsamer Datenbestand](Gemein.md "Gemeinsamer Datenbestand")

# Konsistenzmodelle

Konsistenz bezeichnet in Verteilten Systemen die Übereinstimmung der einzelnen Replikate eines verteilten Datenbestands. Konsistenzmodelle legen fest, wann zwischen einzelnen Replikaten Übereinkunft bezüglich ihrer Übereinstimmung erzielt wird und wann Lese- und Schreibvorgänge ausgeführt werden dürfen.

CRDTs realisieren eine Konsistenzbedingung, die als Strong Eventual Consistency bezeichnet wird. Daneben gibt es weitere Konsistenzmodelle.

## Strikte Konsistenz
Strikte Konsistenz erlaubt Lesevorgänge erst nachdem Schreibvorgänge alle übrigen Knoten erreicht haben.

## Sequentielle Konsistenz
Hier müssen alle Schreibvorgänge in allen Knoten durch alle Knoten in der Reihenfolge ihres Auftretens verarbeitet werden.

## Eventual Consistency
Dieses Konsistenzmodell garantiert, dass alle Replikate, die gleichermaßen mit Zustands- oder Aktualisierungsinformationen versorgt wurden, nach einer beliebigen endlichen Zeitspanne übereinstimmen. Dies wird durch ein im Einzelfall festzulegendes und typischerweise durch die Anwendungsdomäne bedingtes Verfahren der Konfliktbereinigung realisiert. Solange nicht alle Konflikte verarbeitet sind, kann ein Replikat inkonsistente, zum Beispiel veraltete Daten beinhalten und auf Nachfrage auch ausliefern. Das Konsistenzmodell wird in der Praxis oft genutzt, zum Beispiel in vielen NoSQL Datenbanken. Für viele Anwendungsfälle ist es gut geeignet. 

## Strong Eventual Consistency
Dieses Konsistenzmodell unterscheidet sich vom vorigen dadurch, dass die Konfliktlösung bereits in das Datenmodell integriert ist. Das bedeutet, dass sich eine Übereinstimmung zwischen den Replikaten schon allein dadurch ergibt, dass diese alle Aktualisierungsnachrichten, egal in welcher Reihenfolge, erhalten haben.

|                              | Zustellung    | Terminiertheit| Konvergenz    | Konsens
|------------------------------| ------------- |:-------------:| -------------:|----------|
| Strikte Konsistenz           | keine Aussage | keine Aussage | trivial gegeben | erfolgt nach jeder Aktualisierung systemweit
| Sequenzielle Konsistenz      | keine Aussage | keine Aussage | trivial gegeben | erfolgt so als wären alle Knoten über ideale Kommunikationskanäle verbunden
| Eventual Consistency         | Aktualisierungen werden auf allen korrekten Replikaten durchgeführt | alle Aktualisierungen terminieren | die Ausführung der gleichen Menge von Aktualisierungen führt schließlich zu gleichem Zustand | verteilt, durch Ausführung der Konfliktlösung impliziert
| Strong Eventual Consistency  | s. o. | s. o. | die Ausführung der gleichen Menge von Aktualisierungen ist der gleiche Zustand | nicht nötig, Konflikte kommen nicht vor

[Lösungskonzept der CRDT ->](Konzept.md "Lösungskonzept der CRDT")

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")