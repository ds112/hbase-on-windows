#Steps to run HDFS Gradle samples through REST API
##################################################### SECURITY RELATED CHANGES ##########################################################################################
Pre-requisites to submit jobs in Secure Cluster through Big Data Command Shell form the BigData Dashboard.
 1. Configure your KRB5.ini located in C:\Windows\krb5.ini
		Add Realm and KDC of the Secure cluster which you want to access from your machine[C:\Windows\krb5.ini].
	Refer this link to create or configure krb5.ini file.

 2. Map the cacerts into your local JAVA cacerts 
	 Download your CAcert file from the Active name node of the Secure cluster in the location - %JAVA_HOME%\jre\lib\security\cacerts
	 Execute the command to import the keystore.	 
		keytool -importkeystore -srckeystore <Downloaded Source CAcert> -destkeystore %JAVA_HOME%\jre\lib\security\cacerts -srcstorepass changeit -deststorepass changeit -noprompt
		
 3. Configure KDC to support REST call.
	 Execute the following command to add KDC		
		ksetup /addkdc <DOMAINNAME.COM> <HostName of Active directory machine>
		
 4. Authentication:
		Login as the Super user by using the following command.		
		kinit username@DOMAIN.COM <password>

Note: If the Big data command shell is opened from the shortcut available in Big Data Studio, the above steps is not required, as it is automated.
###############################################################################################################################################################################		
Note:
Please ignore the above steps if you are using Normal Hadoop cluster without any authentication.	

*Gradle in command line
Open BigData command shell, type 

To build : 
	gradle -p %SYNCBDP_HOME%\Samples\Java\HDFS\RESTAPI build
	
To run : 

Simple Authentication:
	gradle -p %SYNCBDP_HOME%\Samples\Java\HDFS\RESTAPI runJar -Parguments="HostName OperationType"
	
KERBEROS Authentication:
	gradle -p %SYNCBDP_HOME%\Samples\Java\HDFS\RESTAPI runJar -Parguments="HostName OperationType kerberos"


* Gradle in Netbeans
Open the gradle project in Netbeans IDE.
To build : Right click on the project and click 'build'.
To run : Right click on the project click Custom Tasks-> Custom Tasks
             Under 'Tasks' type 'run'
             Under 'Arguments' type '-Parguments="HostName OperationType AuthenticationType"
             Click Execute to run the sample.
Ex: run -Parguments="192.16.10.12 upload [kerberos/simple]"

* Gradle in Eclipse
File-> Import-> Import Gradle project.
Choose the Gradle project and click 'Build Model'. Click Finish.
To build : Right click the project, click Run As-> Gradle Build.  
                Under Gradle Tasks type 'build' (or) 'jar', Apply and then click Run.
To run :  Right click the project, click Run As-> Gradle Build.
              Under Gradle Tasks type 'run'
              Under 'Arguments' tab, in Program arguments select 'Use' and type '-Parguments="HostName OperationType AuthenticationType"

* Gradle in IntelliJ
Open the gradle project in IntelliJ IDE.
Click View-> Tool Windows-> Gradle to open gradle projects. 
Click on the icon 'Execute Gradle Task'.
Under 'Gradle project' choose the Gradle project for execution.
Under 'Command line',
        To build sample : build  (or) jar (this generates an executable jar file under build/libs folder)
        To run : run -Parguments="HostName OperationType AuthenticationType"
Click OK to run the sample.

(Note: To get the list of HDFS samples available type run -Parguments="help"; To run the HDFS samples locally type run -Parguments="localhost upload simple")