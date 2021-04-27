import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

from PyQt5 import QtWidgets, uic
import sys

from SQL_Query.querys import sql_query

from Connect_Form.Connect_form import  Ui_Connect_form

from Workspace.Workspace import Ui_Workspace


class Connect_Window(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()
        self.ui = Ui_Connect_form()
        self.ui.setupUi(self)
        #self.ui.Pass_textbox.setEchoMode(QtWidgets.QLineEdit.Password)
        #self.ui.IP_address_textbox.setInputMask('000.000.000.000')
        self.ui.Connect_button.clicked.connect(self.Connect_btnClicked)


    def Connect_btnClicked(self):

        '''
        conn = pyodbc.connect(conn_str)
        cursor = conn.cursor()
        print(cursor.execute('select * from Depo'))
        row = cursor.fetchone()
        rest_of_rows = cursor.fetchall()
        print (row)
        print (rest_of_rows)
        '''

        #self.take_data()
        #df = sql_query.take_conn(self)
        #print(df.head())
        application.hide()
        application1.show()



        # sys.exit()

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






class Workspace_Window(QtWidgets.QMainWindow):
    def __init__(self, parent=None):
        super().__init__(parent)
        #super(Workspace_Window, self).__init__()
        self.ui = Ui_Workspace()
        self.ui.setupUi(self)

        self.ui.Tables_comboBox.addItem("Программист")
        self.ui.Tables_comboBox.addItem("Дизайнер")


        # Список Таблиц в Combo_Box

        ex = Connect_Window()

        df = ex.take_tab_name( ex.take_conn())
        print (df.head())
        #for name in list(df.TABLE_NAME):
        #    print(name)




app = QtWidgets.QApplication([])
application = Connect_Window()
application1 = Workspace_Window()
application.show()


sys.exit(app.exec())