# Code Generator
## Overview
Code Generator is a Windows Forms application designed to streamline the process of generating data access and business layer code for databases. This tool provides an interface for users to select a database, view its tables and columns, and generate the necessary boilerplate code for data access and business logic layers.

## Features
* **Database Selection:** Easily select and switch between different databases.
* **Table Information Display:** View detailed information about tables and their columns.
* **Column Selection:** Select specific columns for which to generate code.
* **Code Generation:** Automatically generate data access and business layer code based on the selected tables and columns.
* **Clipboard Copy:** Copy the generated code directly to the clipboard for easy pasting into your projects.
## How It Works
* **Database Loading:** On load, the application fetches all available databases and populates the database dropdown list.
* **Table Loading:** When a database is selected, the application fetches all tables from the selected database and populates the table dropdown list.
* **Column Loading:** When a table is selected, the application fetches all columns from the selected table and populates a checklist box for column selection.
* **Code Generation:** Upon clicking the "Generate Code" button, the application generates the data access and business layer code based on the selected columns and displays it in HTML views.
* **Copy to Clipboard:** Users can copy the generated code to the clipboard with a single click for both data access and business layers.
## Classes and Methods
* **Form1:** The main form of the application.
* **_FillNameDataBase():** Populates the database dropdown list.
* **_RefreshTableInfo():** Refreshes and displays the table information.
* **_FillNameTableFromDatabase():** Populates the table dropdown list based on the selected database.
* **_GetColumnName():** Populates the checklist box with columns from the selected table.
* **Form1_Load():** Initializes the form and populates databases and tables on load.
* **cmbDatabase_SelectedIndexChanged_1():** Event handler for database selection change.
* **_ConvertSelectedColumnToDataTable():** Converts selected columns to a DataTable.
* **FillAllTxtDataAccess():** Generates and displays the data access code.
* **FillAllTxtBusinessLayer():** Generates and displays the business layer code.
* **btnGenerateCode_Click():** Event handler for generating code.
* **btnCopyDataAcc_Click():** Copies data access code to clipboard.
* **cmbTable_SelectedIndexChanged_1():** Event handler for table selection change.
* **btnCopyBusinessLayer_Click():** Copies business layer code to clipboard.
## Dependencies
* **System.Data:** For data handling and database operations.
* **System.Windows.Forms:** For the graphical user interface.
## Usage
* Run the application.
* Select a database from the dropdown list.
* Select a table from the dropdown list.
* Select the columns you want to include in the generated code.
* Click "Generate Code" to generate the data access and business layer code.
* Use the "Copy" buttons to copy the generated code to your clipboard.
## Contribution
Feel free to fork this repository and submit pull requests for any improvements or new features. Contributions are welcome!
- Contact us at hamzalafsioui@gmail.com
