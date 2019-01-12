# 3. Azure Cosmos DB

Azure Cosmos DB ist eine von Microsoft entwickelte Multi-Model Datenbank mit nativer NoSQL Unterstützung. Im Entwicklungsfokus stand die globale Verteilung und horizontale Skalierbarkeit, sowie eine Hochverfügbarkeit von 99,999 Prozent. [1]

## 3.1 Funktionsweise

Eine Datenbank besteht aus einem Container der API-Spezifisch ist. Dabei kann zwischen verschiedenen APIs gewählt werden, die dann Auswirkungen auf das in der Datenbank proiziert Datenmodell hat.

[x] Tabelle einfügen?

Alle Datenmodelle werden intern als ein durch Microsoft eingeführtes Atom Record Sequence (ARS) basierendes Datenmodell in der Datenbank als eine Art Schlüssel-Wert-Paare gespeichert.
Atome beschereiben primitive Datentypen wie Strings, Zahlen oder boolsche Werte aus denen sich die Records zusammensetzen. Sequences sind Array die aus Atomen Records und Sequencen selbst bestehen. Ein Item basiert zwar auf einem ASR-Modell, wird aber wie auch der Container, durch das von der gewählten API spezifizerte Modell abgelegt.

Die Arbeit von Dr. Leslie Lamport war stehts eine Quelle der Inspiration bei der Entwicklung. [2, 3]

---

[1]: Microsoft Azure Cosmos DB. Abgerufen 12.01.2018 von https://azure.microsoft.com/de-de/services/cosmos-db/

[2] Lobel, Lenni : Demystifying the Multi-Model Capabilities in Azure Cosmos DB. Abgerufen 12.01.2018 von,https://www.pass.org/Community/PASSBlog/tabid/1476/entryid/881/Demystifying-the-Multi-Model-Capabilities-in-Azure-Cosmos-DB.aspx

[3] Shukla, Dharma : A technical overview of Azure Cosmos DB. Abgerufen 12.01.2018, von https://azure.microsoft.com/de-de/blog/a-technical-overview-of-azure-cosmos-db/