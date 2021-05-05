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
from SQL_Query.querys import sql_query
from Connect_Form.Connect_form import  Ui_Connect_form
#from Connect_Form.Connect_form import  Connect_Window

#окно работы с таблицами
from Workspace.Workspace import Ui_Workspace
from Workspace.Workspace_Window import Workspace_Window

class Connect_Window(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()
        self.ui = Ui_Connect_form()
        self.ui.setupUi(self)
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
        #app = QtWidgets.QApplication([])
        self.hide()
        application1 = Workspace_Window()
        application1.show()
        #sys.exit(app.exit())
