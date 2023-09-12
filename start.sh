#!/bin/bash

docker-compose up -d

echo "Going to create a MSSQL connector"

while true; do

  result=$(curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8083/connectors/ -d  '{"name": "inventory-connector","config": {"connector.class": "io.debezium.connector.sqlserver.SqlServerConnector", "tasks.max": "1", "topic.prefix": "server1", "database.hostname": "sqlserver", "database.port": "1433", "database.user": "sa", "database.password": "yourStrong(!)Password", "database.names": "debezium-test", "table.include.list": "dbo.outbox-table", "schema.history.internal.kafka.bootstrap.servers": "kafka:9092", "schema.history.internal.kafka.topic": "schema-changes.inventory", "database.encrypt": "false"}}')
  message="already"

  if  echo "$result" | grep -q "$message"; then
   echo "Connector Created"
   break
  else
   echo "Retrying"
   sleep 5 
  fi
done

echo "Initialization Successful"
echo "Visit http://localhost:8080 in order to check Kafka topics"

exit 0
