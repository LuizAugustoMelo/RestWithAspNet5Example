FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithAspNet5Example/db/migrations/ /home/database/
COPY ./RestWithAspNet5Example/db/dataset/ /home/database/
COPY ./RestWithAspNet5Example/CI/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh