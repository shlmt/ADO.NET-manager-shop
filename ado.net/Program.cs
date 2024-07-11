using ado.net;

string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=webApi_214729121;Integrated Security=True;Encrypt=False";

DataAccess da = new DataAccess();

da.insertData(connectionString);
da.readData(connectionString);