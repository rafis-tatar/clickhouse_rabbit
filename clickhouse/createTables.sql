CREATE TABLE IF NOT EXISTS audit_log (
  EventType String,
  EventName String,
  ApplicationName String,
  ModuleName String,
  InstanceName String,
  AccountName String,
  Guid UUID,
  EventTime DateTime,
  Value String
) ENGINE = RabbitMQ
SETTINGS
  rabbitmq_host_port = 'rabbit:5672',
  rabbitmq_skip_broken_messages = 1,
  rabbitmq_routing_key_list = 'audit_log',
  rabbitmq_exchange_name = 'exchange',
  rabbitmq_format = 'JSONEachRow';

CREATE TABLE IF NOT EXISTS audit_log_data_source (
    EventType String,
    EventName String,
    ApplicationName String,
    ModuleName String,
    InstanceName String,
    AccountName String,    
    Guid UUID,
    EventTime DateTime,
    Value String
) ENGINE MergeTree()
  ORDER BY EventTime;

CREATE MATERIALIZED VIEW audit_log_view TO audit_log_data_source
  AS SELECT * FROM audit_log;