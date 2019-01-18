# Einführung

CRDTs sind ein Konzept aus dem Bereich Verteilter Systeme, dessen Anwendung dafür sorgt, dass Komponenten einer solchen Umgebung synchrone Kopien eines gemeinsamen Datenbestands pflegen können, wobei sonst häufig auftretende Problemlagen vermieden werden. Der Datenbestand ist dabei auf allen beteiligten Knoten repliziert, er kann gleichzeitig und unabhängig auf jedem davon aktualisiert werden, ohne eine zentrale Instanz zu benötigen.

Ohne besondere Vorkehrungen werden replizierte Datenbestände schnell inkonsistent und eine Korrektur ist im Allgemeinen nicht möglich.

CRDTs implementieren ein bestimmtes Verhalten, dass die genannten Eigenschaften aufweist und Inkonsistenzen aufgrund seiner algorithmischen Struktur verhindert.

Ziel der Entwicklung war es, ein Verfahren zu schaffen, dass sehr performant ist und skalierbar strong eventual consistency für replizierte Datenbestände herzustellen vermag.

[Kommunikation in Verteilten Systemen ->](Kom.md "Kommunikation in Verteilten Systemen")  
[Inhaltsverzeichnis](Inhaltsverzeichnis.md "Inhaltsverzeichnis")