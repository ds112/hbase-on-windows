--This sample script has been included along with the Syncfusion Big Data Studio to make getting started easier.
-- creating external table
CREATE EXTERNAL TABLE IF NOT EXISTS Customers(CUSTOMERID string,COMPANYNAME string,CONTACTNAME string,CONTACTTIT string,ADDRESS string,CITY string,REGION string,POSTALCODE string,COUNTRY string,PHONE string,FAX string)
ROW FORMAT DELIMITED FIELDS TERMINATED BY ',' LOCATION '/Data/Customers' ;

--dropping table
drop table Customers;