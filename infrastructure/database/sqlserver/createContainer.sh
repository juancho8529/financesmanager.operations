#!/bin/bash
DATABASE_FOLDERPATH=$1 # /mnt/c/JDC/LEARN/FinancesManager/infrastructure/database/sqlserver
SA_PASSWORD=$2
docker run --name sqlserver -v $DATABASE_FOLDERPATH:/var/opt/mssql/data -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$SA_PASSWORD" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU15-ubuntu-20.04
