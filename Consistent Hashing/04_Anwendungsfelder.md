# Anwendungsfelder  

## Allgemein  

Hashfunktionen haben verschiedene Einsatzmöglichkeiten. Es gibt zB. kryptografische Hashfunktionen, die bestimmte Vorgaben erfüllen müssen. Dabei können diese für Passwort Sicherheit, Integritätsüberprüfung, Authentifizierung von Nachrichten und viele andere Optionen benutzt werden.

Es gibt auch auch andere Möglichkeiten, Hashfunktionen zu verwenden. Diese ist für uns wichtig, da es in den Datenbanken oft vorkommt, die _Hash-Tabelle_. 

## Hash-Tabelle  

Oft wird ein Array für eine Datenspeicherung verwendet. Dabei spielt die Suche in einem Array eine wichtige Rolle. Falls ein Array zB. aus 30 Elementen besteht, kann die Suche relativ schnell, selbst im schlimmsten Fall erfolgen. Den im schlimmsten Fall, wäre die Suche am 30 Element abgebrochen. Würde jedoch ein Array aus Millionen, oder noch mehr Elementen bestehen, würde die Suche immer länger dauern, was schlecht ist. 

Könnt man jedoch den Index direkt auffinden, wäre die Suchzeit konstant. Der Hashwert kann jedoch nicht als Indexwert benutzt werden, da in den meisten Fällen der Hashwert eine bestimmte, feste Länge aufweist. Dadurch kann der Speicherarray entweder zu groß oder zu klein sein. Zum Beispiel in der Abbildung 1, würde man den Array nach dem festen Hashwert der Länge drei benutzen, müsste ein Array für vier Elemente eine Länge von 1000 Elemente besitzen. Für nur vier Werte, wäre es eine Platz- bzw. Speicherverschwendung. Würde man jedoch mehr als 1000 Element einfügen wollen, wäre ein Array dieser Länge nicht mehr ausreichend. 

Darum wird der Hashwert nicht als Index benutzt, sondern wird zur Index Berechnung benutzt. Dabei wird der Hashwert berechnet und daraus der Rest von der Division von der Länge des Arrays berechnet. Wie bereits oben angesprochen, existieren _Kollisionen_, da die Eingaben oft sehr unterschiedlich sein können und die Division mit dem Rest zusätzlich Kollisionen erzeugen können. Deswegen werden die gesuchten Werte oft als Listen mit den zugehörigen Schlüssel (Key) innerhalb des Arrays gespeichert. Mit einer guten Hashfunktion, mit wenigen Kollisionen kann auf diese Weise eine Suche in einem Array beliebiger Länge sehr schnell und einfach erfolgen. Die Idee hinter dem Verfahren, kann wie folgt beschrieben werden:  
> Das Hashverfahren ist ein Algorithmus zum Suchen von Datenobjekten in großen Datenmengen. Es basiert auf der Idee, dass eine mathematische Funktion die Position eines Objektes in einer Tabelle berechnet. Dadurch erübrigt sich das Durchsuchen vieler Datenobjekte, bis das Zielobjekt gefunden wurde.<sup>1</sup>  

____
[Zurück](03_DasVerfahren.md) | [Weiter](05_ConsistentHashing.md)  

___  
```
1. https://de.wikipedia.org/wiki/Hashtabelle
```
