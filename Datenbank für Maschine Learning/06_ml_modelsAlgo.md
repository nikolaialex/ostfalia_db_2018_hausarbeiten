## ML Modelle und Algorithmen

### Modelle und Modelldaten

_"Ein Modell ist eine Abstraktion der Wirklichkeit."_

Beim Machine Learning erstellt oder befüllt der Algorithmus ein Modell, das Beispieldaten generalisiert. Das Modell kann anschließend auf neue unbekannte Daten angewendet werden.

#### Klassische Modelle

Im klassischen Modell können lediglich korrekte Abbilder der Vorgaben erkannt werden. Sobald Abweichungen zur Vorgabe existieren, werden die Zugehörigkeiten zum gegeben Modell nicht mehr erkannt.

**Beispiel**: SPAM E-Mail

Es werden nur E-Mails erkannt, die genau zum Filter oder der Regel passen.

- Regeln/Filter
- Programme
- Funktionen

#### Basis-ML-Modelltypen

Im Basis-ML-Modell können bereits abweichende Abbilder der konkreten Vorgaben erkannt werden. Sobald es zu deutlichen Abweichungen der Vorgabe kommt, werden die Zugehörigkeiten zum gegeben Modell nicht mehr erkannt.

**Beispiel**: SPAM E-Mail

Es werden E-Mails erkannt, die hohe Ähnlichkeiten in Anwendung des Modells aufweisen.

- Binäres Klassifizierungsmodell
- Mehrklassen-Klassifizierungsmodell
- Regressionsmodell

#### Modelldaten

Modelldaten werden in den folgenden Formen angeboten:

- Dateiformate (CSV, XML, Text, JSON)
- REST (API/Endpoint, JSON)
- Datenbanken (SQL, NoSQL, REST)

#### Modellformen und Datenstrukturen

Modelle werden in den folgenden grundlegenden Datenstrukturen abgelegt und verwaltet:

- Tabelle
- Baum
- Graph
- Mischformen

#### Probleme

Als Problemstellungen werden Folgende im Zusammenhang mit ML genannt:

- Überangepasst (overfit)
- Zu wenig angepasst (underfit)
- Diskriminierung

### Algorithmen

Der Algorithmus ist der Kern im Kontext ML, wenn es um die Gewinnung der Erkenntnisse und Informationen aus den Daten geht. Der Algorithmus ist der Teil im ML, in dem es vor allem um die Performance geht. Dabei stehen Performance, Zeit und Kosten in einer sogennanten "magischen Dreiecksbeziehung". [603] spiegelt hier einen Überblick zum aktuellen ML-Stand wider.

#### Agorithmentypen

Die folgenden Algorithmen werden laut [603] in der Häufigkeit ihrer Verwendung genannt:

- Logistische Regression
- Rekurrente Neuronale Netze (RNN)
- Faltungsnetze (CNN)
- Gradient Boosted Machines
- Stützvektormaschinen
- Ensemble-Methoden
- Bayessche Inferenzen
- Neuronale Netze
- Random Forests
- Entscheidungsbäume
- Sonstige

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

---

[601] Thamilalagan, Vishakha, 2017, Blog https://www.quora.com/What-are-different-models-in-machine-learning (letzer Abruf 2018-01-12 14:05)

[602] Brownlee, Jason, 2013, Blog https://machinelearningmastery.com/a-tour-of-machine-learning-algorithms/ (letzer Abruf 2018-01-12 14:07)

[603] Maschinelles Lernen - Kompetenzen, Anwendungen und Forschungsbedarf

---

[< Einteilung der ML-Lerntypen](05_ml_learningTypes.md) | [Abgrenzungen >](07_ml_dds.md)
