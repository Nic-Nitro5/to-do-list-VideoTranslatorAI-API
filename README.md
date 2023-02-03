#Todo list API with .NET, C# and Postgres

#SETUP
* Install Nuget packages for the application
	1. EntityFramework -> dotnet add package Microsoft.EntityFrameworkCore --version 7.0.2
	2. EntityFramework Tools -> dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.2
	3. EntityFramework Postgres -> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0.1

* Database Setup (Postgres)
	1. After adding the Entities and DbContext run -> Add-Migration "Initial Migration"
	2. Run the migration script -> update-database

#Run LOCALLY
* Supply the database details in the appsettings.json in the "ConnectionStrings" property

#User Flow
1. CRUD on Users
2. Login User
3. CRUD on Todo items

#DEPLOYMENT (GCM)
* Setup a VM (Virtual Machine) on Google Cloud:
	1. Setup a firewall rule on the VPC Network tab
		-> Supply a name
		-> Set logs accorfing to prefference 
		-> Direction of traffic set to ingress
		-> Allow action on match
		-> Supply a unique target tag
		-> Source set to 0.0.0.0/0 (This will allow traffic from any IP, This can be altered should there be a particular IP required only)
		-> Specify a port (eg. 5432)
		-> Create rule
	2. Create the VM
		-> Supply a name
		-> Select a region
		-> Choose a machine type for Series E2
		-> Modify boot disk according to requirements (This document has been created using a Debian OS)
		-> Advanced options: Add the networking tag created before of firewall rule
		-> Create VM
	3. Setup Docker on the VM
		-> SSH into the server
		-> Update server: sudo apt-get update, sudo apt-install
		-> Follow Docker Docs on the full installtion process see: https://docs.docker.com/engine/install/debian/
	4. Setup Postgres Image
		-> Run: sudo docker pull postgres
		-> Now run the container: sudo docker run --name {name} -e POSTGRES_PASSWORD=yourSecretPassword -v postgres:/var/lib/postgresql/data -p 5432:5432 -d postgres
			*Ensure your port matches the specified port on the firewall rule setup in step 1
		-> The server name is found on the VM instances under external IP
* Connect the API to the newly setup postgres database