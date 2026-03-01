#!/bin/sh
set -e
ulimit -s 8192
exec /opt/mssql/bin/sqlservr
