import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

'''class Sql:
    def __init__(self, database, server="192.168.1.202,1433"):
        self.cnxn = pyodbc.connect("Driver={SQL Server Native Client 11.0};"
                                   "Server="+server+";"
                                   "Database="+database+";"
                                   "Trusted_Connection=yes;")
        self.query = "-- {}\n\n-- Made in Python".format(datetime.now()
                                                         .strftime("%d/%m/%Y"))
'''
#SQL= Sql('ElectroTransport')
#SQL.
driver = 'DRIVER={SQL Server}'
server = 'SERVER=192.168.1.202'
port = 'PORT=1433'
db = 'DATABASE=ElectroTransport'
user = 'UID=sa'
pw = 'PWD=290798Denis'
conn_str = ';'.join([driver, server, port, db, user, pw])
params = urllib.parse.quote_plus(conn_str)
engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params)
'''
conn = pyodbc.connect(conn_str)
cursor = conn.cursor()

print(cursor.execute('select * from Depo'))
row = cursor.fetchone()
rest_of_rows = cursor.fetchall()
print (row)
print (rest_of_rows)
'''
qry = """select * from Depo"""
df = pd.read_sql(qry, engine)
print(df.head())