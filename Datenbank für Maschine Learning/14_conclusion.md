## Fazit

Die vorigen Beispiele haben gezeigt, dass MLDB nahezu alle beschriebenen Anforderungen an eine ML-Datenbank, die im Abschnitt ["Anforderungen an ein DBMS für ML"](09_dbml_requirements.md) genannt sind, erfüllt. Aus diesem Grund stellt MLDB eine vielversprechende Datenbank dar, mithilfe der ML-Algorithmen auf eigene Datensätze angewendet und anschließend standardtisiert abgerufen werden können.

Nichtsdestotrotz wird jedes Modell auf einem einzelnen Knoten trainiert, sodass die Trainingsgeschwindigkeit durch die CPU des Knotens und die Eingangsgröße durch den RAM des Knotens begrenzt ist[1401]. Folglich ist das parallele Trainieren von Modellen auf einer Instanz nicht möglich. Aus diesem Grund wird eine performante Hardware vorausgesetzt, damit Millionen von Datensätzen auf einen einzelnen Knoten in zumutbarer Zeit verarbeitet werden können. Viele Cloud Lösungen, wie beispielsweise Amazon Elastic Compute Cloud, bieten solche Kapazitäten an. Dennoch kann es vorkommen, dass der Anwender MLDB im eigenen Rechenzentrum laufen lassen möchte. Hierbei muss das Rechenzentrum entsprechend mit performanter Hardware ausgestattet sein. Als Lösung wäre die Erhöhung der Anzahl der MLDB-Knoten und das Vorschalten eines Loadbalancers denkbar.

---

[1401] Scaling MLDB

---

[< Anwendung von MLDB](13_mldb_example.md) | [Literaturverzeichnis >](15_references.md)
