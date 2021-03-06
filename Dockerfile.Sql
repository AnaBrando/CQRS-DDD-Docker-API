FROM microsoft/mssql-server-linux:2017-latest
ENV ACCEPT_EULA y
ENV SA_PASSWORD myPass123
ENV MSSQL_IP_ADDRESS=0.0.0.0
COPY ./init.sql .
COPY ./entrypoint.sh .
EXPOSE 1433
CMD /bin/bash ./entrypoint.sh