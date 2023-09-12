# Outbox Pattern Implementation with .NET, Kafka, Debezium, and SQL Server

This repository presents a simple implementation of the Outbox Pattern using .NET, Kafka, Debezium, and SQL Server. If you've been working on implementing the Outbox Pattern with pure .NET background services and SQL Server, this repository offers an alternative approach. With this implementation, you don't need to worry about raising events on the producer side; instead, you can focus on putting events inside an outbox table in an atomic manner.

## Key Advantages

- **Producer Independence:** This implementation makes the producer independent of Kafka, removing concerns related to producer idempotency, retry patterns, and more.
- **Guaranteed Event Delivery:** Events will be eventually delivered, and delivery is 100% guaranteed.

## Getting Started

**Prerequisites:**

- Docker must be installed on your machine.

**Cloning the Project:**

Clone this repository to your local machine:

```bash
git clone https://github.com/amiru3f/debezium-empowered-outbox
```

##### Running the Project

1. Navigate to the root of the project.
2. Run the project using the provided `startup.sh`

``` bash
./startup.sh
```

1. Wait for the Kafka connector to be created using the `startup.sh` script.
2. Point your browser to http://localhost:5000/create-order to interact with the application.
3. Visit <http://localhost:8080/ui/clusters/kafka_cluster/topics> to access the Kafka topic (`server1.debezium-test.dbo.outbox-table`) containing events of created orders.

### Note for M1 Machine Users

If you are using an M1 machine, you may need to enable preview features under development using the following flag: "Use Rosetta for x86/amd64 emulation on Apple Silicon."
