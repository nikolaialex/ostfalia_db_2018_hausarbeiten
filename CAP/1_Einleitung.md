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
beschrieben [1]. Die dritte Eigenschaft wird heute meist
mit *Partition-tolerance* bezeichnet [3].  

Nach der Definition des CAP-Theorems und der einzelnen Eigenschaften werden
die Unterschiede in den Begriffsdefinitionen zum ACID-Modell dargestellt.  
Darauf folgen zwei moderne CAP-Implementierungsbeispiele:
[Google Cloud Spanner](https://cloud.google.com/spanner/ "Google Cloud Spanner")
und Amazon Dynamo.
Abschließend werden zwei Alternativen zu CAP aufgezeigt.

<br />

[1] Fox, A., & Brewer, E. A. (1999). Harvest, yield, and scalable tolerant systems. In
*Hot Topics in Operating Systems, 1999*.
*Proceedings of the Seventh Workshop on* (pp. 174-178). IEEE.

[2] Brewer, E. A. (2000, July). Towards Robust Distributed Systems.
*ACM Symposium on Principles of Distributed Computing*, Portland, Oregon

[3] Gilbert, S., & Lynch, N. (2002). Brewer's conjecture and the feasibility of consistent, available, partition-tolerant web services. *Acm Sigact News, 33*(2), 51-59.


***

[Entstehung und Definition des CAP-Theorems >>](2_Entstehung_und_Definition_des_CAP-Theorems.md)

***
