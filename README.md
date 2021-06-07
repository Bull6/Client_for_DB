# Client_for_DB
Welcome to the Client_for_DB wiki!

The client application for the database. Connection to the database is possible both on the local and on the remote server. Tables are read from the metadata on the server.

There is an interface that includes the ability to view all existing tables with data. In addition, the form has a search button, the ability to sort data in ascending/descending order, a menubar that includes saving changes, a new connection and a report designer, as well as a program information button. The view of the application's start form is shown in Figure 1.
![connect](https://user-images.githubusercontent.com/8268783/120997427-9eeda000-c7a0-11eb-9687-6a6a15980236.png)

** Figure 1** - Appearance of the connection form

![workspace](https://user-images.githubusercontent.com/8268783/120997554-bdec3200-c7a0-11eb-8904-d1c984e00715.png)

** Figure 2** - Appearance of the main form

The following shows how the table obtained from the database is displayed.

![tab](https://user-images.githubusercontent.com/8268783/120997581-c47aa980-c7a0-11eb-89bc-e4289eff0093.png)

** Figure 3** - Appearance of the "Drivers" table output form»

The view of the report form is shown in Figure 4:

![report](https://user-images.githubusercontent.com/8268783/120997609-c9d7f400-c7a0-11eb-90f3-bcc35931e249.png)

** Figure 4** - Appearance of the report designer form

In the report designer, the user needs to select a table and the desired field of this table, and repeat it if necessary. At this stage, the constructor can work with a maximum of two tables. To create a report on the required data, the user needs to select the type of bundle in the drop-down menu (FROM row), as well as the corresponding fields for each of the tables (ON row). All other fields of the form are filled in automatically. If necessary, the user can edit them
