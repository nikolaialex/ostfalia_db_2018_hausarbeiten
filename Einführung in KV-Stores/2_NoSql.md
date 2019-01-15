# 2. Was ist NoSQL?
***
[Einleitung](1_Einleitung.md) - **[Was ist NoSQL?](2_NoSql.md)** - [Key Value Stores im Detail](3_KV_Detail.md) - [Key Value Store Datenbanken](4_KV_Datenbanken.md) - [Funktionsweise von KV-Stores](5_KV_Abfragen.md)
***

Nach dem vorangegangen kurzen geschichtlichen Überblick, soll nun der Begriff "NoSQL" etwas weiter definiert werden. In den folgenden Abschnitten wird kurz geklärt, welche Eigenschaften ein Datenbanksystem haben muss, um überhaupt als NoSQL Datenbank anerkannt werden zu können und welchen Charakter die grundlegende Architektur haben muss.

### 2.1 Definition
Zu Beginn wird nun allgemein der Begriff "NoSQL" genauer erläutert. Früh wurde vorgeschlagen "NoSQL" mit "Not only SQL" zu beschreiben[1, S.2]. Das macht Sinn, denn NoSQL-Systeme heben sich zumeist deutlich von klassischen relationalen Datenbanken, welche mit SQL genutzt werden, ab. So kann, je nach eingesetztem Datenbanksystem, auch eine abweichebde Syntax vorgegeben werden.
Auch wenn es keine direkt zentralen Vorgaben gibt, nach welchem eine NoSQL-Sytem definiert wird, lassen sich jedoch folgende mögliche Facetten vorgeben. Von diesen sollten im Optimalfall alle oder zumindest einige erfüllt sein damit eine Datenbank als NoSQL konform gilt.
Wie bereits angedeutet, sollte das Datenmodel möglichst nicht relational sein und demnach einen alternatives Datenmodell verfolgen, welches für eine gute Performanz bei großen Datenmengen ausgelegt ist.
Ein weiteres Merkmal kann die Skalierbarkeit der Datenbank sein, welche auf horizontaler Ebene stattfindet (Scale-out Prinzip). Demnach sollte es möglich sein die Arbeitslast durch Erweiterung der Rechnerknoten auf diese weiter zu verteilen. Auch sollte es möglich sein bei niedriger Last bei Bedarf die Anzahl der Knoten wieder problemlos reduzieren zu können. Dieses Prinzip steht somit im Gegensatz zu dem Scale-up Prinzip bei dem die vorhandene Hardware immer weiter aufgerüstet werden muss, um die erhöhte Arbeitslast zu bewältigen.
Optimalerweise sollte zudem eine NoSQL Datenbank Open Source sein, was allerdings kein zwingendes Kriterium ist. Anders sieht es dagegen mit den Anforderungen an das Schema der Datenbank aus. Hier sollte eine sehr lockere Handhabung oder auch eine komplette Schemafreiheit verfolgt werden. Somit können agilere Anwendungen erschaffen werden, bei denen Änderungen an den Datenstrukturen zu keinem nennenswerten Arbeitsausfall führen und die Anwendung selber mehr Verantwortung tragen. Somit wäre es möglich bei Änderungen den Datenstand zu versionieren und mit Hilfe von Hintergrundprozessen mögliche Konvertierungen durchzuführen, um somit die Zeit in der die Anwendung nicht im vollen Umfang genutzt werden kann zu minimieren.
Ein weiterer Punkt ist die einfache Replikation von Daten auf Grundlage der verteilten Architektur. Tatsächlich gibt es NoSQL-Datenbanken, welche eine denkbar einfache Replikation ermöglichen.
Natürlich müssen NoSQL-Datenbanken eine einfache API bieten, welche sich gegen SQL behaupten kann und auf die unterschiedlichen Einsatzbereiche zugeschnitten ist. Als Beispiel können hier REST-Anfragen genannt werden, welche im Web-Umfeld interessante Möglichkeiten bieten.
Außerdem spielt das Konsitenzmodell von NoSQL-Datenbanken, je nach Einsatzzweck, eine unterschiedlich wichtige Rolle. Anwendungen mit nicht sehr hohen sichheitskritischen Merkmalen müssen als Beispiel nicht immer ACID-konform (atomicity, consistency, isolation, durability) sein, sondern können überdies BASE-Anforderungen (basic available, soft state, eventually consistent) erfüllen. Natürlich gibt es aber auch NoSQL-Datenbanken, welche ACID anbieten.[1, S.3 ff]

### 2.2 Kategorien von NoSQL-Systemen
In dieser Arbeit werden nur die NoSQL-Kernsysteme [1, S.6] betrachtet. Die Untergruppen dazu werden nachfolgend Ansatzweise vorgestellt.

#### 2.2.1 Key/Value Stores
Key/Value Stores sind so ausgelegt, dass in der Regel nur ein Schlüssel und die dazugehörigen Daten in Form von beispielsweise Strings gespeichert werden. Die Schlüsel selber können auch Namensräume bilden und somit auch auf auf mehrere Datenbanken verteilt werden. Üblicherweise findet keine Indexiierung der Daten statt und es besteht auch keine Beziehung zwischen den einzelnen Einträgen. Somit sind keine umfangreichen Abfragen möglich. Die abfragende Anwendung müsste demnach immer alle Daten abrufen und nach den gewünschten Kriterien durchsuchen. [1, S.7]

#### 2.2.2 Wide Column Stores/ Column Families
Eine bessere Strukturierung von Key/Value-Paaren ist mit sognannten Column-Family-Systemen möglich. Hierbei wird ein Schlüssel über eine beliebige Anzahl an Key-Value-Paaren gesetzt. Auch gibt es, je nach eingesetztem Datenbanksystem, die Möglichkeit über diese Struktur weitere Schlüssel zu speichern und somit mehr Struktur als Key Value Stores zu bieten. Auch kann diese Struktur an eine relationale Datenbank erinnern. [1, S.7]

#### 2.2.3 Document Stores
Anders als vermutet werden bei Document Stores keine Word-Dateien oder ähnliches abgelegt. Anhand einer ID wird auf strukturierte Datenformate wie JSON oder YAML verwiesen, welche selber erst die Daten halten. [1, S.8]

#### 2.2.1 Graphendatenbanken
Grundsätzlich werden bei Graphendatenbanken Graph- und Baumstrukturen mit verknüpften Elementen verwaltet. Hierbei lassen sich Beziehungen zwischen zwei Elementen sehr schnell aufzeigen lassen. Native Graphendatenbanken haben die größte Bedeutung. Bei dieser Art werden zu dn Einträgen entsprechende Eigenschaften abgelegt. Die dadurch entstehenden Relationen können deutlich schneller durchlaufen werden als bei relationalen Datenbanken. [1, S.8 ff]

***
[<< Einleitung](1_Einleitung.md) - [Key Value Stores im Detail >>](3_KV_Detail.md)

#### Quellenangaben
```
[01] - Edlich, Friedland, Hampe, Bauer; NoSQL - Einstieg in die Welt nicht relationaler WEB 2.0 Datenbanken, Jahr 2010
```
