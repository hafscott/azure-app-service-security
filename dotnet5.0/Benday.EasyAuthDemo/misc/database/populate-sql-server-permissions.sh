#!/bin/bash

sqlcmd -i ./create-database-logins.sql -d master -U sa -P Pa\$\$word
sqlcmd -i ./create-database-users.sql -d easyauthdemo -U sa -P Pa\$\$word
