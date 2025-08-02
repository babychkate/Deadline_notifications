FROM rabbitmq:3.12-management

# Встановлюємо curl, щоб завантажити плагін
RUN apt-get update && apt-get install -y curl

# Завантажуємо плагін потрібної версії (має відповідати версії RabbitMQ)
RUN curl -L -o /plugins/rabbitmq_delayed_message_exchange-3.12.0.ez \
    https://github.com/rabbitmq/rabbitmq-delayed-message-exchange/releases/download/v3.12.0/rabbitmq_delayed_message_exchange-3.12.0.ez

# Активуємо плагін
RUN rabbitmq-plugins enable --offline rabbitmq_delayed_message_exchange

EXPOSE 5672 15672
