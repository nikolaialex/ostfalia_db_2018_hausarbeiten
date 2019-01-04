## ML Einteilung der ML-Lerntypen

### Typeinteilung

Der [Towards Data Science][601] Artikel "Types of Machine Learning Algorithms You Should Know" 
zeigt eine zusammenfassende Übersicht der verschiedenen Machine Learning Typen.

![ML Types](statics/MLTypes2017.png)

#### Supervised Learning

Das geregelte bzw. kontrollierte Lernen (Supervised Learning) 
hat strikte Vorgaben in Form von Trainingsdaten 
mit positiven und/oder negativen Beispielen aus denen ein Modell erstellt wird.
Als Anwendungsgebiete stehen die Klassifizierung (Classification) 
und die Regression zur Verfügung.
Dabei ist die Regression eine kontinuierliche Wertermittlung gemessen an Schwellwerten 
und die Klassifizierung eine Einteilung bzw. Abgrenzung in Kategorien.

#### Unsupervised Learning

Das ungeregelte bzw. unkontrollierte Lernen (Unsupervised Learning) kommt ohne
Traingsdaten aus und versucht durch seine Algorithmen 
vorborgene Metadaten oder Strukturen zu erkennen.
Als Anwendungsgebiete steht das bilden von Segmenten (Clustering) und die Assoziationsanalyse (Assocation) zur Verfügung.
Dabei ist die Segmentierung ein Erkennen von Ähnlichkeiten
und die Assoziation eine Abbildung und Reduktion auf gmeinsame Abhängigkeiten oder Eigenschaften.

#### Semi-Supervised Learning

Semi-Supervised Learning ist eine Mischung des Supervised Learning und Unsupervised Learning.
Die Traingsdaten bestehen teils aus markierten und überwiegend aus nicht markierten Daten.
Sprich das System erhält einen geringen Anteil an Vorgaben, 
um dann durch die unmarkierten Daten unkontrolliert weiter zu lernen.

#### Reinforcement Learning

Das Reinforcement Learning (Verstärkung des Lernens) 
wird in Form von "Belohnungen" oder "Bestrafungen" 
als Verstärkung im Lernprozess ausgeübt. 
Dabei gibt es positive und negative Faktoren, sowohl für die Belohnung als auch für die Bestrafungstaktik.
Der Algorithmus lernt durch diese Reaktionen auf seine Ergebnisse, welche
Vorgehensweisen funktionieren und welche nicht zum Erfolg führen oder nicht geeignet sind.
Dabei führt der Algorithmus via "Trail and Error" alle möglichen Schritte 
passend zu seinem erstellten Regelwerk und seinen gelernten Verstärkungen aus.

[601]:https://towardsdatascience.com/types-of-machine-learning-algorithms-you-should-know-953a08248861