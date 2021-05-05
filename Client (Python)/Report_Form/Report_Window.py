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
from Workspace.Workspace import Ui_Workspace
from Report_Form.Report_form import Ui_Report_form


class Report_Window(QtWidgets.QMainWindow):
    def __init__(self, parent=None):
        super().__init__(parent)
        self.ui = Ui_Report_form()
        self.ui.setupUi(self)