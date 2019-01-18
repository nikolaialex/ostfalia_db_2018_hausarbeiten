[<- Lösungskonzept der CRDT](Konzept.md "Lösungskonzept der CRDT")

# Zustandsorientierte CRDTs

Zustandsorientierte CRDTs senden zwecks Synchronisation ihren Gesamtzustand an die übrigen Replikate. Diese müssen daher über eine Zusammenführungsfunktion verfügen, die es erlaubt, einen empfangenen Zustand mit dem lokalen Zustand zu synchronisieren. Für zustandsorientierte CRDTs ist die Assoziativität der verwendeten Operation wichtig, da jeder empfangene Zustand vorherige Aktualisierungen einschließt, können mehrere von ihnen gleiche Aktualisierungen enthalten. Diese werden dann im Rahmen der ersten durchgeführten Zusammenführung angewendet. Damit es nicht darauf ankommt, welche Zusammenführung dabei zuerst durchgeführt wird, müssen die einzelnen Operationen assoziativ sein.

Die Übertragung des gesamten Zustands kann in Systemen mit umfangreichen Datenbeständen zu erheblichem Bedarf an Bandbreite und Verarbeitungskapazitäten führen.

Zustandsorientierte CRDTs werden daher vor allem als Mittel der theoretischen Analyse eingesetzt und nicht in produktivem Umfeld.  

[Operationsbasierte CRDTs ->](Operation.md "Operationsbasierte CRDTs") 

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")