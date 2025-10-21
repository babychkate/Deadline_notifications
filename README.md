# Event Notification Service

A practice project demonstrating how to use **RabbitMQ** for event-driven notifications.  
This service includes an API to create events and a listener that processes notifications asynchronously via a delayed message exchange.

---

## Technologies

- **C# (.NET 8.0)**  
- **ASP.NET Core Web API**  
- **RabbitMQ**  
- **RabbitMQ Delayed Message Exchange Plugin**  

---

## Project Structure

- **EventService** – API project with `EventController` for creating events.  
- **NotificationService** – background service listening to RabbitMQ and processing notifications.  
- **Dockerfile** – for running RabbitMQ with the delayed message plugin.

---

## Functionality

- **Create events** via HTTP POST to `/Event`.  
- **Publish events** to RabbitMQ with a delayed message exchange.  
- **Listen for notifications** and handle messages asynchronously.  
- **Console output** to show received messages (can be replaced with actual notification logic).

---
