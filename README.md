# WebbAppMSSql
## DATABASE CONNECTION
We create a new EDM item.
We choose EF and connect to our base and server.
Then we select to entity version and add all the stored tables
procedure we created above.
## EDITING IMPORT FUNCTIOS OF STORED PROCEDURES
We press edit in the function import of each store and then we select the table with which
we want it to connect. Below we see an example with SearchQuery1 , the opio the
connect with TableQuery1. Correspondingly for the following stored procedures.
## ADDITION OF CONTROLLER AND VIEW
For each of the tables in our base we will do the following next steps.
-We create a scaffolded item in the controller area.
-We choose the following MVC controller.
-We add the table we want with the base where it is and the options to
automatically build the View with page layout.
So we have the corresponding controller and View:
## CREATION OF STORED PROCEDURES CLASSES
In the model area we create a new class in which we will put each stored
procedure which you will call later from the corresponding controller of the table.
Below we will see, for example, how the SearchQuery1 class is inside and similarly it is
and the others
TQ1CLASS
The class returns GetQUERY1() which contains the SearchQuery1 procedure with the
results of his table, i.e. the data we want.
## EDITCONTROLLERTABLEQUERYANDVIEW
TABLEQUERY1
We create an object of class TQ1CLASS with which we call the Stored Procedure
SearchQuery1.Then we put it in a variable query1 which we process with
use where and take to select dates and top results. With the
parameters d,e are the starting and ending date and the number that determines how many
records will be returned, which take values through the view and are determined by the
user.
 
TABLEQUERY2
In query2 in which we have GetQuery2() we process it like TableQuery2,
but we have two parameters with n1,n2 with which the user defines through the View
ContactName, and two variables d, e with which the user specifies the desired range
date.
TABLEQUERY3
In query3 where we have GetQuery3() we process it like TableQuery3,
but we have two parameters with search1,search2 with which the user specifies through
View CompanyName , and two variables d,e with which the user specifies the desired
date range.
TABLEQUERY4
We do the appropriate processing in the TableQuery4 controller to interact with the
View and return the correct entries of the table. For this purpose we use them
variables search1 ,search2 for processing the name , tfor selecting ttops
columns, date to select a specific date.
TABLEQUERY5
We do the appropriate processing on controllerTableQuery5 to interact with it
View and return the correct entries of the table. For this purpose we use them
variables search1 ,search2 for editing the name and ye for the selection
specific date.
## The basic HOME Index of the page
--> Where all the titles and buttons of our application appear
