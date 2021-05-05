import pandas as pd
import urllib

import pyodbc
from datetime import datetime

#import mssql
from sqlalchemy import create_engine

from PyQt5 import QtWidgets, uic
from PyQt5.QtWidgets import *
from PyQt5.QtGui import *

import sys
#импорт файлов программы
from SQL_Query.querys import sql_query
from Connect_Form.Connect_form import  Ui_Connect_form

from Workspace.Workspace import Ui_Workspace

#окно отчета
from Report_Form.Report_form import Ui_Report_form
from Report_Form.Report_Window import Report_Window



class Workspace_Window(QtWidgets.QMainWindow):
    def __init__(self, parent=None, *args):
        super().__init__(parent)
        #super(Workspace_Window, self).__init__()
        self.ui = Ui_Workspace()
        self.ui.setupUi(self)
        self.data_combobox()
        self.on_combobox_func(0) #вызов функции для заполнения талбицы при появлении формы
        self.ui.actionAbout.triggered.connect(lambda: self.click_actionAbout())
        self.ui.actionReport_1.triggered.connect(lambda: self.click_actionReport())
        self.ui.actionSave.triggered.connect(lambda: self.click_actionSave())

    # Список Таблиц в Combo_Box
    def data_combobox(self):
        ex = sql_query()
        df = ex.take_tabs_name()
        for name in list(df.TABLE_NAME):
            self.ui.Tables_comboBox.addItem(name)
        self.ui.Tables_comboBox.currentIndexChanged.connect(self.on_combobox_func)

    # Вывод выбранной таблицы в  tableWidget
    def on_combobox_func(self, index):
        self.ui.tableWidget.setRowCount(0)
        ex = sql_query()
        df = ex.take_data(self.ui.Tables_comboBox.currentText())
        headers = df.columns.values.tolist()
        self.ui.tableWidget.setColumnCount(len(headers))
        self.ui.tableWidget.setHorizontalHeaderLabels(headers)

        for i, row in df.iterrows():
            # Добавление строки
            self.ui.tableWidget.setRowCount( self.ui.tableWidget.rowCount() + 1)
            for j in range(self.ui.tableWidget.columnCount()):

                self.ui.tableWidget.setItem(i, j, QTableWidgetItem(str(row[j])))
        self.ui.tableWidget.resizeColumnsToContents()

    # Вывод текстового сообщещия
    def click_actionAbout(self):
        QMessageBox.about(self, "About", "Created by Bull6 28.04.2021")

    # Открытие окна отчетов
    def click_actionReport(self):
        #app = QtWidgets.QApplication([])
        self.hide()
        application2 = Report_Window()
        application2.show()
        #sys.exit(app.exit())

    #Чтение данных из таблицы на форме
    def dataframe_generation_from_table(self, table):
        number_of_rows = table.rowCount()
        number_of_columns = table.columnCount()
        header = []

        for i in range(table.columnCount()):
            header.append(table.horizontalHeaderItem(i).text())

        tmp_df = pd.DataFrame(
            columns=(),  # Fill columnets
            index=range(number_of_rows)  # Fill rows
        )


        for i in range( number_of_rows):
            for j in range(number_of_columns):
                tmp_df.loc[i, j] = table.item(i, j).text()
        tmp_df.columns = header
        return tmp_df

    #Сохранение данных в БД
    def click_actionSave(self):

        # df = self.dataframe_generation_from_table(self.ui.tableWidget)

        '''driver = 'DRIVER={SQL Server}'
        server = 'SERVER=' + '192.168.1.202'  # self.ui.IP_address_textbox.text()
        port = 'PORT=1433'
        db = 'DATABASE=' + 'ElectroTransport'  # self.ui.DB_name_textbox.text()
        user = 'UID=' + 'sa'  # ex.ui.Logintextbox()
        pw = 'PWD=' + '290798Denis'  # self.ui.Pass_textbox.text()
        conn_str = ';'.join([driver, server, port, db, user, pw])
        conn = pyodbc.connect(conn_str)
        cursor = conn.cursor()
        # Insert Dataframe into SQL Server:
        wildcards = ','.join(['?'] * len(df.columns))
        data = [tuple(x) for x in df.values]
        table_name = self.ui.Tables_comboBox.currentText()

        cursor.executemany("INSERT INTO %s VALUES(%s)" % (table_name, wildcards), data)
        conn.commit()'''
        qm = QMessageBox()
        qm.setIcon(QMessageBox.Question)
        ret = QMessageBox.question(self, 'Save data?', "Do you want to save table to DB",
                                   QMessageBox.Yes | QMessageBox.Cancel, QMessageBox.Cancel)

        if ret == QMessageBox.Yes:
            print('yes')
            ex = sql_query()
            engine = ex.take_conn()

            table_name = self.ui.Tables_comboBox.currentText()
            df = ex.take_data(table_name)
            engine.execute("TRUNCATE  TABLE %s" % (str(table_name)))
            with engine.begin() as connection:
                df.to_sql(table_name, con=connection, schema='dbo', if_exists='append')


        else:
            print("close")
