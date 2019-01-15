
# Überblick

Stream Processing bezeichnet eine Technologie, durch die sich ein kontinuierlicher Datenstrom während der Laufzeit analysieren und verarbeiten lässt. Im Folgenden soll darauf eingegangen werden, warum Stream Processing wichtig ist und was genau der Begriff bedeutet

## Warum ist Stream Processing wichtig?

In einer Zeit mit schier endlosen Datenmengen wird es immer wichtiger auf bestimmte Auslöser direkt zu reagieren und dem Ereignis entsprechende Maßnahmen durchzuführen. Dadurch reicht es nicht mehr die einkommenden Daten erst abzuspeichern und im Nachhinein zu analysieren, wie es beispielsweise beim Batch Processing üblich ist. Denn der Informationsgehalt vieler Daten hängt direkt mit der Zeit des Auftretens zusammen wodurch der Wert der Daten häufig drastisch abnimmt umso später auf diese reagiert wird und sie bearbeitet werden können. So ist beispielsweise die Information das ein System kurz vor der Überhitzung steht kaum noch von Nutzen, wenn auf diese erst zehn Minuten nach Eintreffen reagiert werden kann. Weiterhin ist Stream Processing in den meisten Fällen eine Lösung, die die Hardware deutlich weniger belastet. Während beim Batch Processing, also der Aufteilung von daten in einzelne Batches (also Stapel), die Stapel großer Datenmengen schnellstmöglich abgearbeitet werden, wird beim Stream Processing diese Arbeit auf einen längeren kontinuierlichen Zeitraum aufgeteilt, was die zur Verarbeitung benötigte Leistung stark verringert. Auch der Speicherbedarf lässt sich durch Stream Processing stark verringern, da durch herausfiltern unwichtiger Ereignisse zur Laufzeit, nur solche die auch von Belang sind, gespeichert werden müssen. Auf die genauen Vor- und Nachteile und die Anwendungsfelder dieser Verarbeitungsmethode wird im Kapitel Beispiele noch genauer eingegangen.

## Begriffserklärung

Der Oberbegriff Stream Processing umfasst zwei Engines durch die das Abarbeiten von Streams ermöglicht wird. Event Stream Processing (ESP) und Complex Event Processing (CEP). Die Methoden dieser konvergieren sehr stark zueinander wie in Abbildung 1 zu sehen ist und werden häufig, wie auch in dieser Arbeit, synonym verwendet.<sup id="a1">[1](#f1)</sup>

| ![Abbildung 1: Stream Processing](https://qph.fs.quoracdn.net/main-qimg-9ec93fab35668d719b158d0da4e12128.webp) |
|--|
| Abbildung 1: Stream Processing  |
| Quelle: https://qph.fs.quoracdn.net/main-qimg-9ec93fab35668d719b158d0da4e12128.webp |


Es soll nun zuerst auf den Begriff Event eingegangen werden, dessen Verständnis unabdinglich ist, um die genannten Engines zu verstehen. Anschließend wird ein Überblick über den genauen Ablauf des Stream Processing mit Fokus auf Complex Event Processing, gegeben. Im weiteren Verlauf wird dieses der Einfachheit halber als CEP bezeichnet. Es wird jedoch drauf hingewiesen sollte die beschriebene Methode vom CEP abweichen. 

## Event

Jeder einzelne Datensatz, der mit bestimmten auftretenden Geschehnissen im Anwendungsumfeld in Verbindung gebracht werden kann, lässt sich als ein Ereignis bezeichnen. Ein solches Ereignis erhält alle nötigen Informationen zum Auftreten von eben diesem. Ein Ereignis allein reicht aber meist nicht aus um die entsprechende Situation oder den Status des Anwendungsfelds zu beurteilen. Dazu wird meist eine Kette von Ereignissen benötigt. Diese müssen alle nötigen Metadaten zum Auftreten des Ereignisses enthalten, so wie den Zeitpunkt, zu dem es passiert ist, was genau passiert ist, von welchen Schnittstellen das Ereignis abgefangen wurde und eine ID, die dem Ereignis eindeutig zugeordnet werden kann. Weiterhin können Events auch in einer Hierarchie zueinanderstehen. So können aus mehreren einfachen Ereignissen komplexere Ereignisse hervorkommen. Eine linear geordnete Abfolge solcher Ereignisse welche kontinuierlich eintreffen, werden als Event Stream (Ereignisstrom) bezeichnet.

<b id="f1">1:</b> http://www.complexevents.com/2006/08/01/what%E2%80%99s-the-difference-between-esp-and-cep/. [↩](#a1)
