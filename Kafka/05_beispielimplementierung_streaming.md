# Einfaches Beispiel zum Streaming mit Apache Kafka

Das folgende Beispiel soll verdeutlichen, wie sich Kafka in eigene Anwendungen integrieren bzw. nutzen lässt. In diesem Fall handelt es sich um eine sehr vereinfachte Streaming-Applikation, die in Python geschrieben wird. Ausgehend von einem frisch installierten Ubuntu Server 18.10 mit 20 GB Speicherplatz sind einige Schritte notwendig und Scripte zu schreiben.

## Vorbereitung des Systems

Ubuntu Server 18.10 wird mit Python 3 ausgeliefert. Für die Verwendung von Apache Kafka ist darüber hinaus Java, im Speziellen ein JDK, erforderlich. Im Zuge des kleinen Projekts kommen in Python ``opencv`` und ``Flask`` zum Einsatz.

```bash
sudo apt update
sudo apt upgrade -y

sudo apt install openjdk-8-jdk

sudo apt install python3-pip
pip3 install kafka-python opencv-python Flask
```

## Download, Konfiguration und Start ...

### ... von ZooKeeper

```bash
cd /opt/

# Herunterladen und Entpacken von ZooKeeper
sudo wget https://www-eu.apache.org/dist/zookeeper/stable/zookeeper-3.4.12.tar.gz
sudo tar -zxf zookeeper-3.4.12.tar.gz

# Verzeichnis für die Speicherung von Snapshots anlegen
sudo mkdir /opt/zookeeper-3.4.12/data

# Konfiguration vornehmen
sudo vim /opt/zookeeper-3.4.12/conf/zoo.cfg

# ZooKeeper starten
sudo /opt/zookeeper-3.4.12/bin/zkServer.sh start
```

Unter ``/opt/zookeeper-3.4.12/conf/`` befindet sich eine ``zoo_sample.cfg``, welche als Basis für eine eigene Konfiguration ebenfalls kopiert werden kann. Für dieses Beispiel umfasst die ``zoo.cfg`` folgende Einstellungen:

```ini
# The number of milliseconds of each tick
tickTime=2000
# The number of ticks that the initial
# synchronization phase can take
initLimit=5
# The number of ticks that can pass between
# sending a request and getting an acknowledgement
syncLimit=2
# the directory where the snapshot is stored.
dataDir=/opt/zookeeper-3.4.12/data
# the port at which the clients will connect
clientPort=2181
```

### ... von Kafka

```bash
# Herunterladen und Entpacken von Kafka
sudo wget https://www-eu.apache.org/dist/kafka/2.1.0/kafka_2.12-2.1.0.tgz
sudo tar -zxf kafka_2.12-2.1.0.tgz

# Kafka starten
sudo /opt/kafka_2.12-2.1.0/bin/kafka-server-start.sh  /opt/kafka_2.12-2.1.0/config/server.properties
```

## Produzenten und Konsumenten scripten

Ziel ist es, eine kleine Video-Datei, welche sich im Filesystem befindet, mithilfe von Apache Kafka zu streamen. Für den Produzenten, als auch für den Konsumenten müssen entsprechende Python-Scripte geschrieben werden, welche beispielsweise zusammen mit dem Video unter ``/opt/kafkastream`` abgelegt werden.

```bash
/opt/kafkastream/
├── konsument.py
├── produzent.py
└── video.mp4
```

Ein passendes, kleines Video kann unter anderem von [techslides.com](http://techslides.com/demos/sample-videos/small.mp4) heruntergeladen werden.

### produzent.py

```python
import cv2, time

from kafka import SimpleProducer, KafkaClient


def video_producer(video_file):
    kafka = KafkaClient('localhost:9092')
    producer = SimpleProducer(kafka)
    topic = 'dbtech'
    captured = cv2.VideoCapture(video_file)

    while (captured.isOpened()):
        read_correctly, frame = captured.read()
        if read_correctly:
            return_value, image = cv2.imencode('.png', frame)
            producer.send_messages(topic, image.tobytes())
            time.sleep(0.25)
        else:
            break
    captured.release()


if __name__ == '__main__':
    video_producer('video.mp4')
```

### konsument.py

```python
from flask import Flask, Response
from kafka import KafkaConsumer


app = Flask(__name__)
topic = 'dbtech'
consumer = KafkaConsumer(topic, bootstrap_servers=['0.0.0.0:9092'], group_id='view')


@app.route('/')
def index():
    return Response(stream_content(), mimetype='multipart/x-mixed-replace; boundary=frame')

def stream_content():
    for message in consumer:
        yield (b'--frame\r\n' b'Content-Type: image/png\r\n\r\n' + message.value + b'\r\n\r\n')


if __name__ == '__main__':
    app.run(host='0.0.0.0', debug=True)
```

## Streaming testen / ausführen

```bash
# ZooKeeper und Kafka starten
sudo /opt/zookeeper-3.4.12/bin/zkServer.sh start
sudo /opt/kafka_2.12-2.1.0/bin/kafka-server-start.sh /opt/kafka_2.12-2.1.0/config/server.properties

# Scripte ausführen
cd /opt/kafkastream/
python3 produzent.py
python3 konsument.py
```

Anschließend kann der FQDN bzw. die IP-Adresse des Systems, auf welchem Produzent, Kafka und Konsument in diesem Beispiel betrieben werden, im Browser eines anderen Rechners aufgerufen werden, sofern die beiden Systeme vernetzt sind und die Firewall ggf. für den Zugriff konfiguriert ist. Im konkreten Fall ist dies die URL ``http://fqdn:5000``.

---

| [<< Organisation und Übertragung von Daten](04_daten_organisation_uebertragung.md) | Einfaches Beispiel zum Streaming mit Apache Kafka | [Beispielanwendung von Apache Kafka in der Bioinformatik >>](06_beispielanwendung_bioinformatik.md) |
|------------------------------------------------------------------------------------|---------------------------------------------------|-----------------------------------------------------------------------------------------------------|
