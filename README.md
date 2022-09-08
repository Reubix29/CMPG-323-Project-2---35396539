# CMPG-323-Project-2---35396539
A Repository for the API development project of the CMPG 323 module.

This project is a ASP.NET Web API hosted on Azure cloud.

There are three tables in the database. The user can query the contents using the following commands:
CATEGORY:
GET: api/Categories - returns all Categories
POST: api/Categories - adds a new category
GET: api/Categories/{id} - gets a specific category
PUT: api/Categories/{id} - updates a specific category
PATCH: api/Categories/{id} -partially updates a specific category
GET: api/Categories/devices/{id} - gets all devices in a category
GET: api/Categories/zones/{id} - returns the amount of zones in a category

DEVICE:

GET: api/Devices - returns all Devices
POST: api/Devices - adds a new device
GET: api/Devices/{id} - gets a specific device
PUT: api/Devices/{id} - updates a specific device
PATCH: api/Devices/{id} - partially updates a specific device


ZONE:

GET: api/Zones - returns all Categories
POST: api/Zones - adds a new zone
GET: api/Zones/{id} - gets a specific zone
PUT: api/Zones/{id} - updates a specific zone
PATCH: api/Zones/{id} -partially updates a specific zone
