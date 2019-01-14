# Geschichte
Der Begriff _Consistent Hashing_ wurde zum ersten Mal in einem akademischen Paper von David Karger, MIT Professor im Jahr 1997 benutzt. Dabei wurde das Prinzip beschrieben, wenn viele Anfragen an unterschiedliche Webserver gestellt werden und die Anzahl der Server nicht fest, sondern variable ist. Ein ähnliches Verfahren wurde bereits in 1986 von _Teradata_ benutzt, jedoch wurde es nicht explizit als _Consistent Hashing_ genannt. Die Co-Autoren von dem Paper von 1997, haben im Jahr 1998 _Akamai Technologies_ gegründet, welches auch _Consistent Hashing_ für das *Content Delivery Network* (kurz CDN) benutzt. 

Heute wird das Verfahren in vielen Systemen eingesetzt, zB.: Akamai CDN, Amazon’s Speicher System Dynamo, Couchbase, Openstack, Discord und viele Andere.

Der Bedarf nach einem Verfahren wie _Consistent Hashing_ wurde immer wichtiger, als immer mehr Daten an unterschiedlichen Orten gespeichert wurden, und es immer schwerer wurde die Daten dynamisch zu synchronisieren, falls neue Server hinzugefügt bzw. entfernt wurden, da jedes mal der gesamte Cache synchronisiert werden musste. Durch _Consistent Hashing_ kann die Last in jeder Situation dynamisch verteilt werden, und dadurch die Skalierbarkeit des gesamten Systems verbessert werden kann.  

____
[Zurück](README.md) | [Weiter](DasVerfahren.md)  