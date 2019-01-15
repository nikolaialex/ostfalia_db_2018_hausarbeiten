# Arbeitsweise

Complex Event Processing ermöglicht es durch die Informationen, die durch sehr einfache in großen Mengen eintreffende Ereignisse gewonnen wird, komplexe, die ganze Situation umfassende Events zu erkennen und anhand dieser, entsprechende Maßnahmen oder Analysen durchzuführen. Dies geschieht durch das erkennen von Mustern und durch das verarbeiten anhand festgelegter Regeln. Nachfolgend werden diese beschrieben und anschließend eine Ereignisgesteuerte Softwarearchitektur vorgestellt wodurch das Konzept eines, auf die Event Processing fokussierten Systems veranschaulicht wird. Dabei wird sich hauptsächlich auf diese Quelle<sup id="a1">[1](#f1)</sup> verlassen. Zuletzt wird auf Event Processing Agents und auf Message Broker eingegangen um zwei Alternativen der Implementierung aufzuzeigen.

## Ereignismuster

Um sehr große Ereignisströme zu verarbeiten und Korrelationen zwischen den einzelnen Ereignissen zu entdecken, müssen diese auf das Auftreten spezifischer Muster untersucht werden. Dazu wird ein Ereignisstrom über einen längeren Zeitraum beobachtet und dieser nach bestimmten Operatoren beziehungsweise Gleichungen beurteilt. Dabei lässts ich zwischen der einfachen und der komplexen Mustererkennung unterscheiden.

Bei der einfachen werden dementsprechend simple boolesche Operatoren angewendet, wodurch sich sehr einfache Zusammenhänge erkennen lassen. So können zum Beispiel Muster wie (A ^ B ^ !C) erkannt werden. Dadurch würde sich überwachen lassen ob die Ereignisse A und B aufgetreten sind, während das Ereignis C nicht aufgetreten ist. Dadurch lassen sich beispielsweise das Auftreten gefährlicher Situationen überwachen und zeitnah eine Reaktion einleiten.

Bei der komplexen Mustererkennung werden dementsprechend komplexere Operatoren angewendet, denn viele Situationen sind zu vielschichtig um sie mit einfachen Mustern abzudecken. Häufig wird dabei besonderer Wert auf die zeitliche Abfolge oder den Zeitraum dieser gelegt.

Um den Überblick und das Arbeiten mit solchen erkannten Mustern einfacher zu gestalten und sogar eine Mustererkennung auf einer höheren Hierarchischen Ebene zu ermöglichen, werden diese Muster häufig Abstrahiert und zu einem übergeordneten Ereignis zusammenfasst. Dadurch lassen sich deutlich komplexere Events beschreiben. So lässt sich beispielsweise die Durchschnittstemperatur in einem Raum berechnen, in dem eine möglichst konstante Temperatur notwendig ist.

## Ereignisregeln

Jedes geschriebene Programm basiert auf gewissen Regeln, auf spezifizierten Bedingungen und auf einer entsprechenden Reaktion, wenn diese eintreffen. Deshalb erscheint es nur als natürlich auch im Bereich des CEP auf Regeln zurückzugreifen und durch sie den Umgang mit gefundenen Mustern festzulegen. Eine solche Ereignisregel besteht aus einem Bedingungsteil und einem Aktionsteil. Der Bedingungsteil legt fest, welche oder welches Muster eintreffen vorkommen muss damit die Bedingung erfüllt ist und weiter wie im Aktionsteil festgelegt vorgegangen wird. In diesem wird entsprechend festgelegt wie auf das Vorkommen bestimmter Muster reagiert werden soll. So können diese zu einem Abstrakteren Event zusammengefasst, bestimmte Maßnahmen durchgeführt oder spezifische Vorkehrungen getroffen werden. Dadurch lassen sich effektiv und schnell Daten ausfiltern, generieren oder aggregieren.
Solche Regeln lassen sich durch Event Processing Languages (EPL) festlegen.

## Ereignisgesteuerte Architektur

Die Architektur einer Software bezeichnet die generelle Organisation einer Software. Damit ist der übergeordnete Aufbau die möglichen Interaktionen und Komponenten gemeint. Wie der Name schon erahnen lässt geht es bei der Ereignisgesteuerten Architektur (oder Event-Driven Architecture) dementsprechend um eine Softwarearchitektur, die auf die Verarbeitung von großen kontinuierlichen Datenströmen in Echtzeit spezialisiert ist. Abbildung 2 zeigt den Grundsätzlichen Aufbau und die Komponenten einer solchen Architektur

| ![Ereignisgesteuerte Architektur](https://s15.directupload.net/images/190115/29xj33kk.png) |
|--|
| Abbildung 2: Ereignisgesteuerte Architektur |




Wie zu sehen ist, ist sie in drei Teile aufgeteilt.

Ereignisquellen: Dies beinhaltet jegliche Komponente, welche Ereignisse erkennt und diese innerhalb der Architektur weitergibt. Wie schon zu sehen ist, können das Sensoren, Nachrichtenfeeds aber auch interne Komponenten welche Ereignisse verarbeiten und somit ein neues Ereignis generieren können dazu zählen.

Ereignisverarbeitung: Hier werden die zuvor gesammelten Ereignisse durch Event Processing Agents verarbeitet. Auf diese wird im nachfolgenden Kapitel eingegangen

Ereignisbehandlung: Hierbei werden die verarbeiteten Ergebnisse weitergeleitet und der tatsächliche Nutzen für den Menschen wird umgesetzt. Das können direkte Benachrichtigungen an bestimmte Nutzer sein, ein Aufruf eines Web Services oder in Notfallsituationen das Auslösen eines bestimmten Alarms sein. Durch den untersten Pfeil lässt sich sehen das ein solches behandeltes Ereignis auch wieder zurück in die Architektur als neues Ereignis fließen kann

## Event Processing Agents

Der Event Processing Agent (EPA) ist die Hauptkomponente eines Ereignisgesteuerten Systems. Er baut sich wie in Abbildung 3 gezeigt auf.

| ![Event Processing Agents](https://s15.directupload.net/images/190115/39j36dts.png) |
|--|
| Abbildung 3: Event Processing Agents |  


Zuerst kommen beim Eingangsstrom alle abgefangenen Ereignisse an, diese werden dann entsprechend gefiltert. Dazu werden die Ereignisse mit dem Ereignismodell abgeglichen und nur die „passenden“ Ereignisse werden weitergegeben.

Diese validierten Ereignisse werden dann durch die Event Processing Engine weiterverarbeitet. Dabei werden die Ereignisse konstant nach den in den Ereignisregeln spezifizierten Mustern durchsucht und, sollte ein solches entdeckt werden, wird das Ereignisse oder die Ereignisse entsprechend der spezifizierten Aktion behandelt. Dabei können auch immer bereits in der Vergangenheit liegende Ereignisse eine Rolle spielen. Da bei einem unendlichen Datenstrom nicht alle Daten gespeichert werden können, werden nur die Ereignisse aus einem festgelegten Zeitintervall im Zwischenspeicher gehalten.

Weiterhin können die Ereignisregeln und das Ereignismodell auf die Datenbank zugreifen und diese aktualisieren oder durch diese aktualisiert werden.

Nun würde aber die Übersicht, die Wartbarkeit und die Leistung der Anwendung sehr stark leiden, wenn ein einzelner EPA die Verarbeitung jedes Ereignisses übernehmen müsste. Deshalb wird gängiger Weise mit einer Ansammlung solcher Agenten gearbeitet und diese zu einem Event Processing Network zusammengefasst. Dabei übernehmen die unterschiedlichen EPAs jeweils lediglich kleinere Aufgaben.

Ein EPN bildet somit die Grundlage für ein umfangreiches Stream Processing System. Welche Frameworks sich besonders für die Erstellung eignen wird im Thema Frameworks behandelt.

## Message Broker

Durch den Message Broker lässt sich ein kontinuierlicher Strom an Nachrichten in Echtzeit bearbeiten. Diese Nachrichten können nach bestimmten festgelegten Regeln weitergeleitet, gespeichert, gefiltert oder sogar umgewandelt werden. Dabei kann der Message Broker auch mit einer externen Quelle interagieren und die Nachricht entsprechend ändern oder auf etwaige Fehler reagieren. Nachrichten können hierbei alles sein, tatsächliche Nachrichten, Logfiles, Fehler, Befehle und so weiter.

Die Architektur eines solchen Message Brokers basiert meist auf einer von zwei Grundsätzlichen Architekturen: Der Speichenarchitektur oder dem Kommunikationsbus (Message Bus). Bei der ersten Architektur haben die beteiligten Systeme keine direkte Verbindung, sondern alle Verbindungen laufen über einen Zentralknoten in diesem Fall, den Message Broker. Bei der Message Bus Architektur läuft jegliche Kommunikation der Module über einen Bus, welcher die Nachrichten entsprechend transformiert, filtert oder weiterleitet. Der Bus ist wieder der Broker<sup id="a2">[2](#f2)</sup>.

Somit fungiert der Message Broker als eine, im Gegensatz zum EPN, eher simplere Herangehensweise, die dementsprechend aber auch leichter umzusetzen ist. Und wenn die gewünschten Funktionsanforderungen nicht zu hoch sind scheint dies die unkomplizierte Alternative zu einem kompletten EPN zu sein. Auch hier werden die Programme, die sich besonders zu Erstellung von eben diesem eignen im Kapitel Frameworks vorgestellt.

<b id="f1">1:</b> Metzdorf, Marcel, et al. "Complex event processing für intelligente mobile M2M-Kommunikation." _ITG-Fachbericht der_18 (2013): 58-63. [↩](#a1)

<b id="f2">2:</b> Samtani, G., and D. Sadhwani. "Integration Brokers and Web Services—Will Web Services Support Be Just Another Feature?." (2002). [↩](#a2)

