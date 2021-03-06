CREATE DATABASE IF NOT EXISTS audit;

CREATE TABLE IF NOT EXISTS event (
	Guid UUID,
	EventType String,
	EventKind String,
	EventName String,
	EventTime DateTime,	
	Tag string,	
	ApplicationName String,
	ModuleName String,
	AccountName String,
	InstanceName String
) ENGINE = RabbitMQ
SETTINGS
  rabbitmq_host_port = 'rabbit:5672',
  rabbitmq_skip_broken_messages = 1,
  rabbitmq_routing_key_list = 'audit_event',
  rabbitmq_exchange_name = 'audit_exchange',
  rabbitmq_format = 'JSONEachRow';

CREATE TABLE IF NOT EXISTS event_source (
    Guid UUID,
	EventType String,
	EventKind String,
	EventName String,
	EventTime DateTime,	
	Tag String,	
	ApplicationName String,
	ModuleName String,
	AccountName String,
	InstanceName String
) ENGINE MergeTree()
  ORDER BY EventTime;

CREATE MATERIALIZED VIEW event_view TO event_source 
  AS SELECT * FROM event;