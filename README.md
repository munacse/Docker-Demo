# Introduction

This is small application in ASP.Net core web api and its run inside a docker container in my local machine. I use Rabbitmq queue to publish
and receive message in consumer and publication server.

I have four project 
  DL.RabbitMQ.Domain,
  DL.RabbitMQ.Core,
  DL.Producer,
  DL.Consumer
  
DL.RabbitMQ.Domain & DL.RabbitMQ.Core : For RabbitMQ support

DL.Producer : Push message to the rabbitmq server, To push this message hit this api http://localhost:8000/api/publication

DL.Consumer : Get message from rabbitmq server and store data in postgressql database, To get all the data hit this http://localhost:8080/api/consumer

