import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

from PyQt5 import QtWidgets, uic
from PyQt5.QtWidgets import *

import sys

#импорт файлов программы
from SQL_Query.querys import sql_query #файл запросов к БД

#окно подключения к БД
from Connect_Form.Connect_form import Ui_Connect_form
from Connect_Form.Connect_Window import Connect_Window

#окно работы с таблицами
from Workspace.Workspace import Ui_Workspace
from Workspace.Workspace_Window import Workspace_Window

#окно отчета
from Report_Form.Report_form import Ui_Report_form
from Report_Form.Report_Window import Report_Window

'''
    def take_conn(self):
        driver = 'DRIVER={SQL Server}'
        server = 'SERVER=' + '192.168.1.202'  # self.ui.IP_address_textbox.text()
        port = 'PORT=1433'
        db = 'DATABASE=' + 'ElectroTransport'  # self.ui.DB_name_textbox.text()
        user = 'UID=' + 'sa'#Ui_Connect_form.ui.Login_texbox.text()
        pw = 'PWD=' + '290798Denis'  # self.ui.Pass_textbox.text()
        conn_str = ';'.join([driver, server, port, db, user, pw])
        params = urllib.parse.quote_plus(conn_str)
        engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params)
        return engine


    def take_data(self, tab_name):
        qry = """select * from tab_name """
        df = pd.read_sql(qry, self.take_conn())
        return df

    def take_tab_name(self, engine):
        qry = """select TABLE_NAME from INFORMATION_SCHEMA.TABLES"""
        df = pd.read_sql(qry, engine)
        return df
'''

app = QtWidgets.QApplication([])
application = Connect_Window()
#application1 = Workspace_Window()
#application2 = Report_Window()
application.show()

sys.exit(app.exec())