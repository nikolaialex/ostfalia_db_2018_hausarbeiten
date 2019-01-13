# 3. Azure Cosmos DB

Azure Cosmos DB ist eine von Microsoft entwickelte Multi-Model Datenbank mit nativer NoSQL Unterstützung. Im Entwicklungsfokus stand die globale Verteilung und horizontale Skalierbarkeit, sowie eine Hochverfügbarkeit von 99,999 Prozent.[1]

## 3.1 Funktionsweise

Im logischen Aufbau der Datenbank steht an erster Stelle der Datenbank-Account, der an eine Azure-Subcription gebunden ist. Was eine Azure Subcription ist kann in der Einleitung dieser Arbeit nachgelesen werden. Innerhalb des Datenbank-Accounts können mehrere Datenbanken erstellt werden. Die Datenbank managt die Benutzer, Berechtigungen und Container.[3]

Eine Datenbank ist API-Spezifisch. Es kann aus verschiedenen vordefinierten APIs gewählt werden. Die Wahl der API hat Auswirkungen auf das in der Datenbank projiziert Datenmodell der Container und Items.[2] [3]

In Abhängigkeit der gewählten API werden die Items als Row, Document, Item oder Node/Edge abgelegt. Dabei liegt immer das später in dieser Arbeit beschriebene ARS Datenmodell zugrunde.

Ein Container enthält die schema-agnostischen Items, das bedeutet, das ein genaues Schema zuvor nicht definiert werden muss. Sowie den Items liegt auch dem Container ein API-spezifisches Datenmodell zugrunde. Je nach API kann das eine Collection, Table oder ein Graph sein.[4]

### 3.1.1 Atom Record Sequence (ARS)

Alle Datenmodelle werden intern als ein durch Microsoft eingeführtes Atom Record Sequence (ARS) basierendes Datenmodell in der Datenbank als Schlüssel-Wert-Paare gespeichert.

Atome beschereiben primitive Datentypen wie Strings, Zahlen oder boolsche Werte aus denen sich die Records zusammensetzen. Sequences sind Array die aus Atomen Records und Sequencen selbst bestehen. Ein Item basiert zwar auf einem ASR-Modell, wird aber wie auch der Container, durch das von der gewählten API spezifizerte Modell abgelegt. [2][3]

### 3.1.2 Indexierung

Azure Cosmos DB indiziert alle Daten, ohne das dafür ein genaues Schema erstellt werden muss. Dabei stellt Azure Cosmos DB jedes Item  [5]

### 3.1.3 Datenzugriff

Übersetzung der Anfrage in ASR

### 3.1.4 API-Schnittstellen

Gremlin-API etc.

### 3.1.5 Skalierung und Replikation

Horizontale Skalierung auf Containerebene.
Global by Design.

---

[1]: Microsoft Azure Cosmos DB. Abgerufen 12.01.2019 von https://azure.microsoft.com/de-de/services/cosmos-db/

[2]: Lobel, Lenni : Demystifying the Multi-Model Capabilities in Azure Cosmos DB. Abgerufen 12.01.2019 von,https://www.pass.org/Community/PASSBlog/tabid/1476/entryid/881/Demystifying-the-Multi-Model-Capabilities-in-Azure-Cosmos-DB.aspx

[3]: Shukla, Dharma : A technical overview of Azure Cosmos DB. Abgerufen 12.01.2019, von https://azure.microsoft.com/de-de/blog/a-technical-overview-of-azure-cosmos-db/

[4]: Microsoft : Working with Azure Cosmos databases, containers and items. Abgerufen 12.01.2019, von https://docs.microsoft.com/en-us/azure/cosmos-db/databases-containers-items

[5]: Microsoft : Indexing in Azure Cosmos DB. Abgerufen 08.01.2019  https://docs.microsoft.com/en-us/azure/cosmos-db/index-overview