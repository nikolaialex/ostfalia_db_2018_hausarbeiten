# Frameworks
Stream Processing Applikationen haben ein komplexes Ökosystem, das aus einer Reihe von verschiedenen Komponenten besteht. Im folgenden werden einige dieser Komponenten beschrieben.

## Message Broker
Es folgt eine Übersicht über die größten und populärsten Message Broker:
### Apache Kafka
Apache Kafka bezeichnet sich selbst als verteilte Streaming-Plattform<sup id="a1">[1](#f1)</sup>. Das bedeutet, dass die Kafka-Applikation auf mehreren Servern in einem Cluster-Betrieb läuft. Dies verstärkt die Ausfallsicherheit.

Die eigentlichen Datenstreams werden in so genannten Topics gespeichert. Die Einträge in den Streams heißen Records und besitzen jeweils einen Schlüssel, einen Wert sowie einen Zeitstempel.
Kafka stellt 4 grundlegende APIs zur Verfügung:

	- Mithilfe der Producer API kann eine Applikationen Records erzeugen und diese an das Kafka-Topic übertragen.
	- Durch die Consumer-API ist eine Applikation in der Lage, Topics zu abonnieren und jegliche Records des Topics zu konsumieren.
	- Die Streams-API ermöglicht es einer Applikation, selbst als ein Stream Processor tätig zu werden. Diese API verbindet die Producer-API mit der  Consumer-API: die Applikation konsumiert einen Stream und gibt den veränderten Stream wieder aus.
	- Mit der Connector-API kann die Verbindung zwischen Kafka-Cluster und Applikation hergestellt werden.
### RabbitMQ
RabbitMQ ist ein Message Broker, der das Advanced Message Queuing Protocol (AMQP) implementiert<sup id="a2">[2](#f2)</sup>. Auch RabbitMQ kann als verteiltes System deployed werden. 

| ![RabbitMQ Architektur](https://www.cloudamqp.com/img/blog/workflow-rabbitmq.png)|
|---| 
| *Abbildung 1: Übersicht über Systemarchitektur RabbitMQ* |
| *Quelle: https://www.cloudamqp.com/img/blog/workflow-rabbitmq.png* |

In Abbildung 1 ist das grundlegende Prinzip von RabbitMQ zu sehen. Wie zu sehen ist, gibt es neben dem Message Broker, dessen Rolle RabbitMQ übernimmt, noch Producer und Consumer. Hier liegt ein ähnliches Prinzip wie bei Kafka vor. Allerdings wird deutlich, dass RabbitMQ eine kleinere API im Vergleich zu Kafka anbietet.
### ActiveMQ
ActiveMQ ist ein Open-Source Message-Broker, der genau wie RabbitMQ AMQP implementiert. Weiterhin gibt es eine Java-Message-Service (JMS) Integration. Genau wie Kafka und RabbitMQ ist auch ActiveMQ als verteiltes System deploybar. ActiveMQ ist auch als reine In-Memory Lösung verfügbar, was Integrationstests deutlich vereinfacht.
## Vergleich der Message-Broker
Vergleicht man Kafka mit RabbitMQ bzw. ActiveMQ wird schnell ersichtlich, dass es ein unfairer Vergleich ist. Kafka ist eine komplette Streaming-Plattform, während RabbitMQ/ ActiveMQ lediglich Message-Broker sind. Daher wird im folgenden Vergleich nur der Message-Broker-Teil von Kafka in den Vergleich mit einbezogen.

| | Kafka | ActiveMQ | RabbitMQ |
| --- | --- | --- | --- |
| Sterne Github (Nutzer) | ~10,8k | ~1,3k | ~5,1k |
| 1 Thread Msg./s schreiben | 165k | 5k | 20k |
| AMQP Support | nur mit Middleware | ja | ja |
| JMS Support | nein | ja | ja |
| Standalone Deployment | nein, braucht Zookeeper | ja | ja |
| Client Libraries | nur Java first class | Java, C/++/#, Ruby, Python, PHP | Java, .NET, PHP, Python, uvm. |
| Historie der Nachrichten | ja | nein | nein |

Wie man sieht, unterscheiden sich die Message Broker in ihrem Funktionsumfang. Daher sollte immer genau bewertet werden, welche Features gebraucht werden, um die ideale Lösung zu wählen
## Frameworks für Agenten
Im folgenden werden einige der Frameworks, mit denen Stream Processing Agenten entwickelt werden können, vorgestellt:
### Akka Streams
Akka Streams ist ein Submodul von Akka, einem Framework, dass für agentenorientierte Programmierung gemacht ist. Es ist mit Kafka einsetzbar, bietet aber auch die Möglichkeit, via AMQP zu kommunizieren. Back pressure wird von Akka Streams verwaltet, sodass sich der User darüber keine Sorgen machen muss.
### Storm
Storm ist das älteste Streaming Framework und somit sehr ausgereift. Es handelt sich um eine native Streaming-Lösung, die guter Performance vorzuweisen hat. Allerdings fehlen einige komplexere Features wie Aggregations, Sessionmanagement und Statemanagement.  
### Spark Streaming
Spark Streaming ist ein Sonderfall von Spark, dass ja via Batch-Verarbeitung funktioniert. Spark Streaming ist keine native Streaming-Lösung, da auf Micro-Batching gesetzt wird. Dadurch ist es allerdings Sehr robust. Die Einrichtung kann sich als kompliziert erweisen, da Spark Streaming extrem viele Parameter besitzt, die eingestellt werden können und müssen.
### Flink
Flink ist eine native Streaming-Lösung, die das größte Feature-Set besitzt. Sämtliche fortgeschrittenen Features, wie Aggregations, Watermarks oder Event time processing werden unterstützt. Die Einrichtung gestaltet sich deutlich einfacher als beispielsweise bei Spark Streaming. Batch Processing ist auch möglich, aber nicht die Grundlage für das Streaming.

## Vergleich der Agenten-Frameworks
Es folgt ein Vergleich der verschiedenen vorgestellten Frameworks, mit denen Stream-Processing-Agenten erstellt werden können:

| | Akka Streams | Apache Storm | Spark Streaming | Apache Flink |
| --- | --- | --- | --- | --- |
| nativ vs batch | nativ | nativ | micro-batch | nativ |
| Latenz | gering | gering | hoch | gering |
| Komplexe Verarbeitungen (Aggregations etc.) | nein | ja | teilweise | ja |
| Statemanagement | ja | ja | nein | ja |

Wie zu sehen ist, unterscheiden sich die Frameworks stark voneinander. Daher ist es wichtig, das Framework zu wählen, dass die eigenen Anforderungen am Besten unterstützt. Weiterhin unterscheiden sich die Frameworks teilweise radikal in der Art, wie Stream Processing implementiert wird: In Akka beispielsweise ist die komplette Softwarearchitektur grundlegend anders.

<b id="f1">1:</b> https://kafka.apache.org/intro. [↩](#a1)

<b id="f2">2:</b> http://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-complete-v1.0-os.pdf. [↩](#a2)
