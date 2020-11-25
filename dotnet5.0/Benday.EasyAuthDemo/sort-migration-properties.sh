#!/bin/bash

dotnet ./misc/efcorepropertysorter/efcoreutil.dll sortmigrationproperties /directory:./src/Benday.EasyAuthDemo.Api/Migrations /migrationname:InitialSetup /updatefile
