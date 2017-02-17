@echo off

rem Setup xaftCentral server configuration

set mysql_hostname=172.16.100.36
set mysql_schema=snl_testing

rem Setup TaskScheduler folder configuration

set schedule_tasks_dir="D:\GitPctRepo\XAFT-AutomationScripts"
set file1="SNL_SMPS_SQLfile.sql"

rem Scheduling the tasks from MySQL database

mysql --defaults-extra-file=%file1% --host=%mysql_hostname% %mysql_schema% < %schedule_tasks_dir%\SNL_SMPS_SQLfile.sql
exit 0

