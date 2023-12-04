This API has three endpoints. 
GET /api/v1/stock?tickerSymbol=""
GET /api/v1/stocks?tickerSymbolsFilter=
PUT /api/v1/trade

This would enable the client to 1. retrieve a specific share, retrieve a range of shares or receive all shares for any given ticker symbol.

Further, the ability to create or update the database from a trade notification request. This keeps the GET endpoints up to date.

A standard ASP.NET Web Controller-based API has been chosen for the initial implementation. I am familiar, and as of late, prefer minimal APIs however, for simplicity this approach was taken.

Architecture & Enhancements

The API would hosted in an Azure Web App initially. This has the capacity to scale using autoscaling. An alternative and powerful approach would be an Azure Function as this would require less manual scaling and we could defer to function apps horizontal scaling up to many instances.

CosmosDB was chosen as the database, utilising its Serverless plan would be cheaper and more cost effective as opposed to the standard plan. As trading occurs at specific times, the high-volume short-bursts of trade notifications would be handled nicely via this plan. 

CosmosDB is, scalable, has high availability and geo-replication if we needed to turn this on.

We could also have a redis cache of some sort if the API was queried from many different regions.

We would need to host secrets / means of auth inside Azure Key Vault and validate each request.

If the roadmap was to create a distributed architecture with many other microservices, it would be prudent to containerise this API, wrap it behind API Management for security and routing and Application Gateway for load balancing.

I would opt for Kubernetes, but Azure Containers Apps could suffice to. Azure Kubernetes Service would give us incredible flexibility on the image used, nodes, pods, further scalability, observability and maintainability via containerisation. 

Admittedly, we would have to have robust pipelines surrounding this to ensure that the our Azure Container Registry is kept up to date from success merges into develop and also to publish the images to Kubernetes. This would also include, patching and further maintainance, but would enable us to leverage security scans etc.

Further, we'd set-up the appropriate infrastructure as code in Bicep or Terraform. This would help work towards our one click deployment and ensure system reliability and stability. Being able to spin up environments for developers, QA or external teams is extremely powerful.

In addition, we'd want to set-up Virtual Networks, Subnets, Private Links (where applicable) and managed identities. This would help secure our infrastructure.

Lastly, we would want to leverage application insights to set-up metrics, alerts and dashboards to help monitor and action the usage of our API.

Apologies for the brain dump, hope to speak soon!
