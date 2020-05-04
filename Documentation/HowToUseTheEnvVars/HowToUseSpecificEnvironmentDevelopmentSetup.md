# How to use specific environment development setup.

In this project we utilise environment variables to be able to add a connection string to a local SQL-database in this project without it being pushed to the remote git repository.

To set this up, simply change the connection string in the file "EnvVars.dev.json"

![EnvVarsLocation](EnvVarsLocation.PNG)

to match your preferred connection string. 

![ALookAtTheJsonFile](ALookAtTheJsonFile.PNG)



What you need to do is just create your own json file called "EnvVars.dev.json" and copy the connection string setup from the picture above:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=[your servername here] ;Database= [your Db name here];Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

In the .gitignore file, all files with the end signature ".dev.json" and ".dev.cs" will be ignored so you don't have to worry about any of your personal info in those files being pushed to the remote repository.