# 6 Zusammenfassung

Diese Arbeit konzentriert sich auf die Entstehung, die Definition, den zeitspezifischen Kontext, in dem das Theorem entwickelt wurde, und die heutigen Anwendungsbereiche und Weiterentwicklungen des CAP-Theorems. Es wurde festgehalten, dass das Theorem aus der Motivation heraus entwickelt wurde, zu dem bereits existierenden ACID-Modell, eine skalierbare Lösung für große Datenbanken zu entwickeln.

Da der Einsatz aller drei Attribute Consistency, Availabilty und Partition-tolerance Konflikte hervorrufen würden, können innerhalb eines Rechensystems immer nur zwei EIgenschaften erfüllt werden. Dadurch gibt es CA-, AP- und CP-Systeme. Da ACID bereits existierte, wurde ein Vergleich der beiden Modelle angestellt.

Da die Definition des CAP-Theorems missverständliche Komponenten aufweist, wurde es für die heutige Anwendung weiterentwickelt. Die Modelle PACELC von Abadi und BASE von Brewer, dem Entwickler des CAP-Theorems selbst, wurden präsentiert.

Abschließend wurden zwei Datenbanksysteme vorgestellt, die die Grundlagen von CAP anwenden. Google Spanner und Amazon DynamoDB sind Cloud-basierte Datenbanksysteme, die zwar nicht das klassische CAP-Theorem umsetzen, aber auf dieser Grundlage aufbauend, gute Lösungen für skalierbare NoSQL-Datenbanksysteme darstellen.

***

[<< 5.3 Ein Vergleich zwischen Google Spanner und Amazon DynamoDB](5_3_Ein_Vergleich_zwischen_Google_Spanner_und_Amazon_DynamoDB.md) | [7 Ausblick >>](7_Ausblick.md)

***
