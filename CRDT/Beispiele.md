[<- Operationsbasierte CRDTs](Operation.md "Operationsbasierte CRDTs")

# Beispiele für CRDTs
## G-Counter
Der G-Counter ist ein verteilter Zähler. Er realisiert die Möglichkeit, durch eine Menge aktiver Knoten gemeinsam vorwärts zählen zu können. Konzeptionell muss also nur ein einzelner skalarer Wert verwaltet werden, der für den Zählerstand steht.

Die Implementierung des Zählers als State-Based CRDT verwendet stattdessen einen Vektor mit so vielen Einträgen n, wie es aktive Knoten mit Replikaten gibt. Dieser Vektor g der Dimension n wird mit 0n = [0, 0, …, 0] initialisiert. Ein aktiver Knoten k aktualisiert nur den k-ten Eintrag g[k] des Vektors. Erhält er das Replikat eines anderen Knotens g’, so bildet er zur Zusammenführung das elementweise Maximum der Vektoren gneu[i] = max(g[i], g’[i]) für alle 1 <= i <= n.

Der Wert des Zählers ergibt sich aus der Summe aller Elemente des Vektors. Dadurch ist jedes von irgendeinem Knoten registrierte Ereignis in ihm enthalten.

## G-N-Counter
Der G-N-Counter kann nicht nur inkrementieren, sondern auch dekrementieren. Um ihn zu implementieren, kann man aber nicht einfach zulassen, lokal zu dekrementieren, da die zur Zusammenführung genutzte Funktion max() dann keine richtigen Ergebnisse mehr liefert. Propagiert Knoten 1 einen Zustand [i, …] und nach Dekrementierung [i-1, …] erhielte ein anderer Knoten aus der Zusammenführung fälschlicherweise [i, …].

G-N-Counter verwenden zur Lösung zwei Vektoren pn und nn, von denen der erste Inkrementierungen zählt wie der G-Counter und der zweite Dekrementierungen. Der aktuelle Wert des Zählers ergibt sich dann aus der Differenz der elementweisen Summen der beiden Zähler: w = sum(p) - sum(n).

## OR-Set
OR-Sets realisieren verteilte Wertemengen. Jeder Knoten verwaltet für jedes bisher aufgetauchte Element der Menge zwei Listen. Die erste Liste gibt an, welche Knoten das Element zur gemeinsamen Menge hinzugefügt haben. Die zweite Liste gibt an, welche Knoten das Element aus der gemeinsamen Menge entfernt haben. Die Zusammenführung zweier Replikate erfolgt über die Bildung der Vereinigungsmenge der beiden Listen. Ein Element ist dann in der gemeinsamen Wertemenge enthalten, wenn es von mindestens einem Knoten hinzugefügt wurde, der es nicht wieder entfernt hat.

[Praxisbeispiel ->](Praxis.md "Praxisbeispiel")  

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")