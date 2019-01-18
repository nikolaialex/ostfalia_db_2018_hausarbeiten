# Einleitung
In Zeiten des Internet of Things werden täglich unvorstellbare Mengen an Daten erzeugt. Eine kürzliche Auswertung zeigt, wie viele Daten minütlich erzeugt werden<sup id="a1">[1](#f1)</sup>. Ein Beispiel dafür ist in Abbildung 1 zu sehen.

| ![Report of Data Generation](https://lh3.googleusercontent.com/xS1-tprreDq8gVtEDCmfAlfOqNr2s5LFTYYJeiA1MaFwg5jWYPpPJ8LwCwJoLWABtfCmIcILehSt)|
|---|
| *Abbildung 1: Ausschnitt aus dem Data Never Sleeps 6.0 Report* |
| *Quelle: https://www.domo.com/assets/downloads/18_domo_data-never-sleeps-6+verticals.pdf* |

Um diese gewaltigen Datenmengen effektiv zu verarbeiten werden immer leistungsfähigere Algorithmen und Hardwarekomponenten benötigt. Gleichzeitig erhöhen sich aber auch die Anforderungen an die Ergebnisse, die durch Auswertung dieser Daten hervorgehen.
Klassische Verarbeitungsprinzipien von Big Data, wie das Batch Processing, geraten zunehmends unter Druck. Batchlaufzeiten erhöhen sich, der Ressourcenverbrauch von CPU und Arbeitsspeicher steigt und teilweise lassen sich die bestehenden Lösung nicht einmal effektiv skalieren.

Seit einigen Jahren ist eine neue Technik beschrieben, die, wenn korrekt implementiert, viele der genannten Probleme löst. Es handelt sich um Stream Processing. Daten werden hierbei als kontinuierlicher Strom angesehen, dessen Einträge in dem Moment verarbeitet werden, in dem sie an der Applikation ankommen. Es gibt also kein Buffering und State Management ist daher auch sehr kompliziert. Werden allerdings einige Prinzipien eingehalten, handelt es sich bei Stream Processing um eine hochperformante und skalierbare Technik.

In dieser Arbeit sollen zunächst die theoretischen Grundlagen von Stream Processing erläutert werden. Daraufhin werden einige Frameworks und Technologien aufgezeigt, mithilfe derer Stream Processing implementiert werden kann. Dann werden einige Anwendungsbeispiele für Stream Processing beschrieben. Abschließend erfolgt ein Fazit über den aktuellen Zustand von Stream Processing.


<b id="f1">1:</b> https://www.domo.com/assets/downloads/18_domo_data-never-sleeps-6+verticals.pdf. [↩](#a1)
