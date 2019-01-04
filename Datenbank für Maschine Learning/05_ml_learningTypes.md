## ML Einteilung der ML-Lerntypen

### Typeinteilung

    Überwachtes Lernen
    Unüberwachtes Lernen
    Teilüberwachtes Lernen
    Bestärkendes Lernen

Der [Towards Data Science][601] Artikel "Types of Machine Learning Algorithms You Should Know" 
zeigt eine zusammenfassende Übersicht der verschiedenen Machine Learning Typen.

<!-- [![ML Types](statics/MLTypes2017.png)][601] -->

#### Überwachtes Lernen (Supervised Learning)

Das überwachte Lernen (Supervised Learning) 
hat strikte Vorgaben in Form von markierten Trainingsdaten (Label)
mit positiven und/oder negativen Beispielen aus denen Modelle erstellt werden.
Als Anwendungsgebiete stehen etwa die Klassifizierung (Classification) 
und die Regression zur Verfügung.
Dabei ist die Regression eine kontinuierliche Wertermittlung gemessen an Schwellwerten 
und die Klassifizierung eine Einteilung bzw. Abgrenzung in Kategorien.
Das Supervised Learning bieten sich an, wenn eine Erwartung an die Ergebnisse vorhanden ist und 
sehr genaue Vorhersagen für zukünftige Modellanwendungen abzusehen sind.

#### Unüberwachtes Lernen (Unsupervised Learning)

Das unüberwachte Lernen (Unsupervised Learning) kommt ohne
Traingsdaten aus und versucht durch seine Algorithmen 
vorborgene Segmente, Metadaten oder Strukturen zu erkennen.
Als Anwendungsgebiete steht etwa das bilden von Segmenten (Clustering) 
und die Assoziationsanalyse (Assocation) zur Verfügung.
Dabei ist die Segmentierung ein Erkennen von Ähnlichkeiten
und die Assoziation eine Abbildung und Reduktion auf gmeinsame 
Abhängigkeiten, Parameter oder Eigenschaften.

#### Teilüberwachtes Lernen (Semi-Supervised Learning)

Das teilüberwachte Semi-Supervised Learning 
ist eine Mischung des Supervised Learning und Unsupervised Learning.
Die Traingsdaten bestehen teils aus markierten (Label) und überwiegend aus nicht markierten Daten.
Sprich das System erhält einen geringen Anteil an Vorgaben, 
um dann durch die unmarkierten Daten weiter zu lernen.
Dies bietet sich an, wenn ein sehr große Menge an unmarkierten Daten vorhanden ist.
Die Qualität kann deutlich verbessert werden, 
wenn zyklisch eine Erweiterung der markierten Daten vorgenommen wird.

#### Bestärkendes Lernen (Reinforcement Learning)

Das Reinforcement Learning (Verstärkung des Lernens) 
wird in Form von "Belohnungen" oder "Bestrafungen" als Verstärkung im Lernprozess ausgeübt. 
Dabei gibt es positive und negative Faktoren, sowohl für die Belohnung als auch für die Bestrafungstaktik.
Der Algorithmus lernt durch diese Reaktionen auf seine Ergebnisse, welche
Vorgehensweisen funktionieren und welche nicht zum Erfolg führen oder nicht geeignet sind.
Dabei führt der Algorithmus via Versuch und Irrtum (Trail and Error) alle möglichen Schritte 
passend zu seinem gegebenen Regelwerk und seinen gelernten Verstärkungen aus.
Das Reinforcement Learning besteht aus den Hauptkomponenten:

* lernender Agent
    * zustandsbehaftet
* interaktive Umgebung
    * Agenten aggieren mit Agenten
* mögliche Aktionen
    * Regelwerk
* "Gedächtnis"
    * zielführende Aktionen

Der Startpunkt für einen Agenten und dessen Aktionen ist meist das Kleinste vom Ganzen gegeben. 
Als Ziel steht die Ermittlung der besten Strategien zur Aufgabenerfüllung im Ganzen oder im größtmöglichem Teil des Ganzen.

### Häufige Darstellungen von Clustering vs. Klassifikation:

Der Bericht vom März 2018 ["MASCHINELLES LERNEN – KOMPETENZEN, ANWENDUNGEN UND FORSCHUNGSBEDARF"][603] zeigt auf:

_"Beim Clustering werden Gruppen von ähnlichen Daten gefunden. Dabei steht noch gar 
nicht fest, welche Merkmale genau diese Ähnlichkeiten und Unterschiede ausmachen. In 
einer Menge von Emails können sich zum Beispiel zwei Cluster herausbilden, die ein Ex-
perte anschließend als »Spam« und »Wichtig« erkennt."_

_"Bei einer Klassifikation steht dagegen schon im Vorfeld fest, in welche Gruppen ein Ob-
jekt eingeordnet werden kann. Hier geht es darum, die Merkmale herauszufinden, die für 
die Zuordnung am signifikantesten sind. Im Fall der Emails unterscheiden sich Spam und 
wichtige Emails zum Beispiel in den Absendern und den verwendeten Wörtern."_


[601]:https://towardsdatascience.com/types-of-machine-learning-algorithms-you-should-know-953a08248861
[602]:https://www.sas.com/de_de/insights/analytics/machine-learning.html
[603]:https://www.bigdata.fraunhofer.de/content/dam/bigdata/de/documents/Publikationen/BMBF_Fraunhofer_ML-Ergebnisbericht_Gesamt.pdf