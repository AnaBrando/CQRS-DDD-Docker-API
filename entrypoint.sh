#!/bin/bash
/opt/mssql-tools/bin/sqlcmd -S localhost -l 60 -U SA -P "myPass123" -i init.sql &
# Start SQL server
/opt/mssql/bin/sqlservr