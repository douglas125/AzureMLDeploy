# AzureMLDeploy

A very simple way to deploy any machine learning model using Azure Functions
---

Source code for an Azure Function App that makes it very simple and easy to deploy any machine learning model (Keras, TensorFlow, PyTorch, XGBoost, LightGBM, scikit-learn, etc) and consume it using any client application via REST APIs.

---

**Have you ever wondered how to deploy a machine learning model as a REST API so that people can use it in apps, websites and general production settings?**

It turns out that this can be complicated: you might need to set up a server with containers, export models and do a lot of other tasks. Well, not anymore. This repository contains code for a simple Azure Function App template that can be used to receive requests from clients, send them to a machine learning server (MLServer) and store the results after they are computed.

The base code for Azure Functions can be found in azure_function_app folder. The simplest way to get started is to create a new function app and create the 4 endpoints needed (2 for client: send task and receive results, 2 for MLServer: retrieve task and send results). Copy and paste each function code and create the Integration with Azure Blob Storage.

# Sample application: Image Segmentation Using DeepLabv3+

As a sample application, we show how to serve the amazing DeepLabv3+ segmentation model (https://github.com/bonlime/keras-deeplab-v3-plus) using a C# client application and a python MLServer (running locally or using Google Colab):

![alt text](architecture.png "Client-Server-MLServer Architecture")

Using this architecture, it is possible to enable serving the segmentation model to a client side application (C# desktop in this case, but it could be anything - HTML, mobile app, desktop - anything that can POST to a REST endpoint). The MLServer keeps listening for new tasks - when one is found, it downloads the tasks, computes predictions and sends results back to the server.

Note that this setup is invisible to the client application -- it needs only to send query data to the REST API, save the task_id token and use the task_id to retrieve results.

(coming up soon)

# Creating the Azure Function App

## Create the Function App

## Create the endpoints

## Add Blob Storage integration

## Copy and paste the code

## Test the Function App

TO DO:

[ ] Describe how to deploy the code to the Azure Function App
