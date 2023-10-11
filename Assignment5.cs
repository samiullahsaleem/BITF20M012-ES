using System;
using System.Data;
using System.Data.SqlClient;

class EmployeeRepository
{
    private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\PUCIT\\7- Seventh Semester\\Enterprise Application Development\\Assignments\\Assignment-5\\AssignmentFive.mdf\"";

    public void ReadAllEmployees()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees";
            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"FirstName: {reader["FirstName"]}");
                    Console.WriteLine($"LastName: {reader["LastName"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                    Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                    Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                    Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                    Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                    Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }

    public void InsertEmployee(string firstName, string lastName, string email, string primaryPhoneNumber, string createdBy, DateTime createdOn)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) " +
                           "VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
            command.Parameters.AddWithValue("@CreatedBy", createdBy);
            command.Parameters.AddWithValue("@CreatedOn", createdOn);

            command.ExecuteNonQuery();
        }
    }

    public void DeleteEmployee(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "DELETE FROM Employees WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", id);

            command.ExecuteNonQuery();
        }
    }

    public void SelectEmployeeById(long id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Employees WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}");
                    Console.WriteLine($"FirstName: {reader["FirstName"]}");
                    Console.WriteLine($"LastName: {reader["LastName"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine($"PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}");
                    Console.WriteLine($"SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}");
                    Console.WriteLine($"CreatedBy: {reader["CreatedBy"]}");
                    Console.WriteLine($"CreatedOn: {reader["CreatedOn"]}");
                    Console.WriteLine($"ModifiedBy: {reader["ModifiedBy"]}");
                    Console.WriteLine($"ModifiedOn: {reader["ModifiedOn"]}");
                }
            }
        }
    }

    public void UpdateEmployee(long id, string firstName, string lastName, string email, string modifiedBy, DateTime modifiedOn)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                           "ModifiedBy = @ModifiedBy, ModifiedOn = @ModifiedOn WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", id);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
            command.Parameters.AddWithValue("@ModifiedOn", modifiedOn);

            command.ExecuteNonQuery();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeRepository repository = new EmployeeRepository();

        while (true)
        {
            Console.WriteLine("Employee Database Menu");
            Console.WriteLine("1. List Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Delete Employee");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Select Employee by ID");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Employee Records:");
                    repository.ReadAllEmployees();
                    break;
                case 2:
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter Primary Phone Number: ");
                    string primaryPhoneNumber = Console.ReadLine();
                    Console.Write("Enter Created By: ");
                    string createdBy = Console.ReadLine();
                    DateTime createdOn = DateTime.Now;
                    repository.InsertEmployee(firstName, lastName, email, primaryPhoneNumber, createdBy, createdOn);
                    Console.WriteLine("Employee added successfully.");
                    break;
                case 3:
                    Console.Write("Enter Employee ID to delete: ");
                    long idToDelete = long.Parse(Console.ReadLine());
                    repository.DeleteEmployee(idToDelete);
                    Console.WriteLine("Employee deleted successfully.");
                    break;
                case 4:
                    Console.Write("Enter Employee ID to update: ");
                    long idToUpdate = long.Parse(Console.ReadLine());
                    Console.Write("Enter First Name: ");
                    string updatedFirstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string updatedLastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    string updatedEmail = Console.ReadLine();
                    Console.Write("Enter Modified By: ");
                    string modifiedBy = Console.ReadLine();
                    DateTime modifiedOn = DateTime.Now;
                    repository.UpdateEmployee(idToUpdate, updatedFirstName, updatedLastName, updatedEmail, modifiedBy, modifiedOn);
                    Console.WriteLine("Employee updated successfully.");
                    break;
                case 5:
                    Console.Write("Enter Employee ID to select: ");
                    long idToSelect = long.Parse(Console.ReadLine());
                    Console.WriteLine("Selected Employee Record:");
                    repository.SelectEmployeeById(idToSelect);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
