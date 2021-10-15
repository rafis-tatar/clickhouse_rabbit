CREATE TABLE IF NOT EXISTS cars (
  device_id String,
  datetime DateTime,
  latitude Float32,
  longitude Float32,
  altitude Float32,
  speed Float32,
  battery_voltage Nullable(Float32),
  cabin_temperature Float32,
  fuel_level Nullable(Float32)
) ENGINE = RabbitMQ
SETTINGS
  rabbitmq_host_port = 'rabbit:5672',
  rabbitmq_skip_broken_messages = 1,
  rabbitmq_routing_key_list = 'cars',
  rabbitmq_exchange_name = 'exchange',
  rabbitmq_format = 'JSONEachRow';

CREATE TABLE IF NOT EXISTS cars_data_source (
    device_id String,
    datetime DateTime,
    latitude Float32,
    longitude Float32,
    altitude Float32,
    speed Float32,
    battery_voltage Nullable(Float32),
    cabin_temperature Float32,
    fuel_level Nullable(Float32)
) ENGINE MergeTree()
  ORDER BY device_id;

CREATE MATERIALIZED VIEW cars_view TO cars_data_source
  AS SELECT * FROM cars;