# 1 Einleitung

> most real-world systems today are forced to settle with returning "most of the data, most of the time." [3]
>
> Seth Gilbert, Nancy Lynch (2002)

Die Anwender, Entwickler, Tester und Administratoren von (großen) Software-Systemen
sind heutzutage nahezu darauf angewiesen jederzeit und überall auf diese Systeme
von unterschiedlichen Endgeräten zugreifen zu können.

Software-Systeme und ihre Datenbestände sollen daher bestimmte Eigenschaften erfüllen,
welche in dieser Arbeit erläutert und in Kontext gesetzt werden.
Drei Eigenschaften solcher Systeme werden in der englischen Sprache mit den
Begriffen *Consistency* (C), *Availability* (A) und *Partition-resilience* (P)
beschrieben. Die dritte Eigenschaft wird heute meist
mit *Partition-tolerance* bezeichnet.  

Nach der Definition des CAP-Theorems und der einzelnen Eigenschaften werden
die Unterschiede in den Begriffsdefinitionen zum ACID-Modell dargestellt.  
Darauf folgen zwei moderne CAP-Implementierungsbeispiele:
[Google Cloud Spanner](https://cloud.google.com/spanner/ "Google Cloud Spanner")
und [Amazon DynamoDB](https://aws.amazon.com/dynamodb/ "Amazon DynamoDB").
Abschließend werden zwei Alternativen zu CAP aufgezeigt.

## Kurze Geschichte des CAP-Theorems
Im Jahr 1999 veröffentlichten Eric A. Brewer und Armando Fox ihre Arbeit
*Harvest, Yield, and Scalable Tolerant Systems* [1]. Die Autoren zeigen zwei
Strategien auf wie in Software-Systemen pragmatisch mit den drei Eigenschaften
CAP umgegangen werden kann und vermuten das zu einem beliebigen Zeitpunkt nur
zwei der drei Eigenschaften erfüllt werden können. Zu
diesem Zeitpunkt formulieren Brewer und Fox dies als *CAP Principle* [1].

Brewer formuliert das *CAP Principle* im Folgejahr (2000) als Hypothese [2]; also
den Sachverhalt nur zwei von drei Eigenschaften zu erreichen. In 2002 beweisen
Seth Gilbert und Nancy Lynch diese Hypothese in ihrer Arbeit
*Brewer's Conjecture and the Feasibility of Consistent, Available,
Partition-Tolerant Web Services* [3].

Der Beweis dieser Hypothese führte zur verstärkten Erforschung von
System-Architekturen, welche die CAP Eigenschaften bestmöglich erfüllen.
Gilbert und Lynch formulierten dies als Systeme die Daten meistens vollständig
die meiste Zeit zurückliefern [3].

<br />

[1] Fox, A., & Brewer, E. A. (1999). Harvest, yield, and scalable tolerant systems. In
*Hot Topics in Operating Systems, 1999*.
*Proceedings of the Seventh Workshop on* (pp. 174-178). IEEE.

[2] Brewer, E. A. (2000, July). Towards Robust Distributed Systems.
*ACM Symposium on Principles of Distributed Computing*, Portland, Oregon

[3] Gilbert, S., & Lynch, N. (2002). Brewer's conjecture and the feasibility of consistent, available, partition-tolerant web services. *Acm Sigact News, 33*(2), 51-59.


***

[Definition des CAP-Theorems >>](2_Definition_CAP-Theorem.md)

***
