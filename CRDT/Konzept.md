[<- Konsistenzmodelle](Konsistenzmodelle.md "Konsistenzmodelle")

# Lösungskonzept der CRDTs

Um die genannten Ziele zu erreichen, bedienen CRDTs sich einer Idee, durch deren Anwendung die geschilderten Schwierigkeiten von Vornherein vermieden werden.

Dazu müssen insbesondere die Probleme gelöst werden, die sich daraus ergeben, dass Operationen nicht reihenfolgerichtig oder doppelt ausgeführt werden.

Es stellt sich heraus, dass Mengen M mit einer Operation o eine Semantik besitzen, die diesen Anforderungen genügt, wenn sie die folgenden Eigenschaften besitzt:

Assoziativität: (m1 o m2) o m3 = m1 o (m2 o m3)
Kommutativität: m1 o m2 = m2 o m1
Idempotenz: o(o(m)) = o(m)

Ein einfaches Beispiel für solches (M, o) ist die reelle max-Funktion

max: (x, y) -> x, wenn x > y, sonst y. x, y e R.

max ist assoziativ, da max(max(x, y), z) = max(x, max(y, z)),
kommutativ, da max(x, y) = max(y, x)
und idempotent, da max(max(x, y)) = max(x, y)

Die Kommutativität der Operation führt dazu, dass die Reihenfolge ihrer Anwendung unwichtig ist, wodurch die Erfordernis entfällt, Nachrichten in der richtigen Reihenfolge zu verarbeiten. Wegen Idempotenz ist auch die mehrfache Anwendung einer Operation unproblematisch.

CRDTs implementieren als Datentypen die beschriebene Charakteristik und sind daher für die verteilte Datenhaltung prädestiniert, sofern obige Einschränkungen unter Berücksichtigung der Anforderungen aus der Anwendungsdomäne akzeptiert werden können. Zwei Arten von Umsetzungen der CRDTs werden unterschieden.

* Zustandsorientierte CRDTs und
* Operationsbasierte CRDTs

Erstere führen einen Abgleich mittels paarweiser Synchronisation der Gesamtzustände zwischen Replikaten durch. Letztere senden zu diesem Zweck Nachrichten über lokale Operationen an die übrigen Replikate.

[Zustandsorientierte CRDTs ->](State.md "Zustandsorientierte CRDTs")

[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")