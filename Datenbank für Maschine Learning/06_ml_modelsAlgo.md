***

## ML Modelle und Algorithmen

### Modelle und Modelldaten

_"Ein Modell ist eine Abstraktion der Wirklichkeit."_

Beim Machine Learning erstellt oder befüllt der Algorithmus ein Modell, das Beispieldaten generalisiert. 
Das Modell kann anschließend auf neue unbekannte Daten angewendet werden.

**Klassische Modelle**

Im klassischen Modell können lediglich korrekte Abbilder der Vorgaben erkannt werden.
Sobald es Abweichungen zur Vorgabe gibt werden die Zugehörigkeiten zum gegeben Modell nicht mehr erkannt.

Bsp: SPAM E-Mail, es werden nur E-Mails erkannt, die genau passen zum Filter oder der Regel.

* Regeln / Filter
* Programme
* Funktionen

**Basis-ML-Modelltypen**

Im Basis-ML-Modell können bereits abweichende Abbilder der konkreten Vorgaben erkannt werden.
Sobald es zu starke Abweichungen zur Vorgabe gibt werden die Zugehörigkeiten zum gegeben Modell nicht mehr erkannt.

Bsp: SPAM E-Mail, es werden E-Mails erkannt, die hohe Ähnlichkeiten in Anwendung des Modells aufweisen.

* Binäres Klassifizierungsmodell
* Mehrklassen-Klassifizierungsmodell
* Regressionsmodell

**Modelldaten**

* Dateiformate (CSV,XML,Text)
* REST (API/Endpoint)
* Artifakte erzeugt aus Traingsdaten

**Modellformen und Datenstrukturen**

* Tabelle
* Baum
* Graphen

**Probleme**

* überangepasst (overfit)
* zu wenig angepasst (underfit)
* Diskriminierung

### Algorithmen

**Agorithmentypen**

* Logistische Regression
* Rekurrente Neuronale Netze (RNN)
* Faltungsnetze (CNN)
* Gradient Boosted Machines
* Stützvektormaschinen
* Ensemble-Methoden
* Bayessche Inferenzen
* Neuronale Netze
* Random Forests
* Entscheidungsbäume
* Sonstige


<!-- [![ML Algos](statics/ml-algos.png)][610] -->

### Lerntypen und Algorithmen

#### Supervised Learning Algorithmen
    Nearest Neighbor
    Naive Bayes
    Decision Trees
    Linear Regression
    Support Vector Machines (SVM)
    Neural Networks

#### Unsupervised Learning Algorithmen
    k-means clustering, Association Rules

#### Semi-Supervised Learning Algorithmen
    k-Nearest-Neighbor

#### Reinforcement Learning Algorithmen
    Q-Learning
    Temporal Difference (TD)
    Deep Adversarial Networks

------

[< Einteilung der ML-Lerntypen](05_ml_learningTypes.md)	|	[Abgrenzungen >](07_ml_dds.md)


[610]:https://www.quora.com/What-are-different-models-in-machine-learning
[612]:https://machinelearningmastery.com/a-tour-of-machine-learning-algorithms/
[613]:https://www.bigdata.fraunhofer.de/content/dam/bigdata/de/documents/Publikationen/BMBF_Fraunhofer_ML-Ergebnisbericht_Gesamt.pdf
