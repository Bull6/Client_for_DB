import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

from PyQt5 import QtWidgets, uic
import sys

from Connect_Form.Connect_form import  Ui_Connect_form


class mywindow(QtWidgets.QMainWindow):
    def __init__(self):
        super(mywindow, self).__init__()
        self.ui = Ui_Connect_form()
        self.ui.setupUi(self)
        #self.ui.Pass_textbox.setEchoMode(QtWidgets.QLineEdit.Password)
        #self.ui.IP_address_textbox.setInputMask('000.000.000.000')
        self.ui.Connect_button.clicked.connect(self.Connect_btnClicked)

    def Connect_btnClicked(self):
        driver = 'DRIVER={SQL Server}'
        server = 'SERVER=' + self.ui.IP_address_textbox.text()
        port = 'PORT=1433'
        db = 'DATABASE=' + self.ui.DB_name_textbox.text()
        user = 'UID=' + self.ui.Login_texbox.text()
        pw = 'PWD=' + self.ui.Pass_textbox.text()
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
        sys.exit()


app = QtWidgets.QApplication([])
application = mywindow()
application.show()
sys.exit(app.exec())