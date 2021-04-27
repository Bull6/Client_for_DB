import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

from PyQt5 import QtWidgets, uic
import sys

from Connect_Form.Connect_form import  Ui_Connect_form

from Workspace.Workspace import Ui_Workspace


driver = 'DRIVER={SQL Server}'
server = 'SERVER=' + '192.168.1.202'#self.ui.IP_address_textbox.text()
port = 'PORT=1433'
db = 'DATABASE=' + 'ElectroTransport'#self.ui.DB_name_textbox.text()
user = 'UID=' + 'sa'#self.ui.Login_texbox.text()
pw = 'PWD=' + '290798Denis'#self.ui.Pass_textbox.text()
conn_str = ';'.join([driver, server, port, db, user, pw])
params = urllib.parse.quote_plus(conn_str)
engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params)


qry = """select TABLE_NAME from INFORMATION_SCHEMA.TABLES """
df = pd.read_sql(qry, engine)
for name in list(df.TABLE_NAME):
    qry = "select * from %s" % (str(name))
    data = pd.read_sql(qry, engine)
    data.to_csv('C:\\Users\\DenT\\Desktop\\DB CSV\\'+ name+'.csv')
