import pandas as pd
import urllib

import pyodbc
from datetime import datetime
from sqlalchemy import create_engine

from Connect_Form.Connect_form import  Ui_Connect_form

class sql_query(object):

    def take_conn(self):

        driver = 'DRIVER={SQL Server}'
        server = 'SERVER=' + '192.168.1.202'  # self.ui.IP_address_textbox.text()
        port = 'PORT=1433'
        db = 'DATABASE=' + 'ElectroTransport'  # self.ui.DB_name_textbox.text()
        user = 'UID=' + Ui_Connect_form.ui.Login_texbox.text()
        pw = 'PWD=' + '290798Denis'  # self.ui.Pass_textbox.text()
        conn_str = ';'.join([driver, server, port, db, user, pw])
        params = urllib.parse.quote_plus(conn_str)
        engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params)

        #data = pd.read_csv('C:\\Users\\DenT\\Desktop\\DB CSV\\'+ 'Depo'+'.csv')
        #print (data.head())
        return engine

    def take_data(self, tab_name):
        qry = "select * from %s" % (str(tab_name))
        df = pd.read_sql(qry, self.take_conn())
        return df

    def take_tabs_name(self, engine):
        qry = """select TABLE_NAME from INFORMATION_SCHEMA.TABLES"""
        df = pd.read_sql(qry, engine)
        return df

    #def