﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using PSMSData;

//namespace PSMSDatabase
//{
//    public static class DbInteraction
//    {
//        static string passwordCurrent = "1234";
//        static string dbmsCurrent = "psmsdatabase";

//        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

//            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

//            //open the connection
//            if (msqlConnection.State != System.Data.ConnectionState.Open)
//                msqlConnection.Open();

//            return msqlConnection;
//        }

//        #region NewConnection

//        public static int DoRegisterNewNewConnection(NewConnectionInfo newConnectionDetails)
//        {
//            return DoRegisterNewNewConnectionInDb(newConnectionDetails);
//        }

//        private static int DoRegisterNewNewConnectionInDb(NewConnectionInfo newConnectionDetails)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                //define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "INSERT INTO application_register(apps_no,payment_id,customerId,received_date) "
//                                                   + "VALUES(@apps_no,@payment_id,@customerId,@received_date)";

//                msqlCommand.Parameters.AddWithValue("@apps_no", newConnectionDetails.appsNo);
//                msqlCommand.Parameters.AddWithValue("@payment_id", newConnectionDetails.paymentId);
//                msqlCommand.Parameters.AddWithValue("@customerId", newConnectionDetails.customerId);
//                msqlCommand.Parameters.AddWithValue("@received_date", newConnectionDetails.receivedDate);
//                msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }

//        public static List<NewConnectionInfo> GetAllNewConnectionList()
//        {
//            return QueryAllNewConnectionList();
//        }

//        private static List<NewConnectionInfo> QueryAllNewConnectionList()
//        {
//            List<NewConnectionInfo> NewConnectionList = new List<NewConnectionInfo>();

//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From application_register;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    NewConnectionInfo NewConnection = new NewConnectionInfo();

//                    NewConnection.appsNo = msqlReader.GetString("apps_no");
//                    NewConnection.customerId = msqlReader.GetString("customerId");
//                    NewConnection.paymentId = msqlReader.GetString("payment_id");
//                    NewConnection.receivedDate = msqlReader.GetDateTime("received_date");
//                    NewConnectionList.Add(NewConnection);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return NewConnectionList;
//        }

//        public static void DeleteNewConnection(string newConnectionToDelete)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "DELETE FROM application_register WHERE apps_no=@newConnectionIdToDelete";
//                msqlCommand.Parameters.AddWithValue("@newConnectionIdToDelete", newConnectionToDelete);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//        }



//        public static void EditNewConnection(NewConnectionInfo newConnectionToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE application_register SET payment_id=@payment_id,received_date=@received_date WHERE apps_no=@apps_no";

//                msqlCommand.Parameters.AddWithValue("@payment_id", newConnectionToEdit.paymentId);
//                msqlCommand.Parameters.AddWithValue("@received_date", newConnectionToEdit.receivedDate);
//                msqlCommand.Parameters.AddWithValue("@apps_no", newConnectionToEdit.appsNo);
//                msqlCommand.ExecuteNonQuery();
//            }

//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//        }

//        public static string GetNewConnectionCustomerId(string appNo)
//        {
//            string cusId = null;

//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select customerId From application_register WHERE apps_no=@apps_no;";
//                msqlCommand.Parameters.AddWithValue("@apps_no", appNo);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                msqlReader.Read();

//                cusId = msqlReader.GetString("customerId");


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return cusId;
//        }


//        #endregion

//        #region Employee

//        public static int DoRegisterNewEmployee(EmployeeInfo employeeDetails)
//        {
//            return DoRegisterNewEmployeeInDb(employeeDetails);
//        }

//        private static int DoRegisterNewEmployeeInDb(EmployeeInfo employeeDetails)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();
//            try
//            {
//                define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "INSERT INTO employee(id,name,address,contact,post_type,doj,department) "
//                                                   + "VALUES(@id,@name,@address,@contact,@post_type,@doj,@department)";

//                msqlCommand.Parameters.AddWithValue("@id", employeeDetails.id);
//                msqlCommand.Parameters.AddWithValue("@name", employeeDetails.name);
//                msqlCommand.Parameters.AddWithValue("@address", employeeDetails.address);
//                msqlCommand.Parameters.AddWithValue("@contact", employeeDetails.contact);
//                msqlCommand.Parameters.AddWithValue("@post_type", employeeDetails.postType);
//                msqlCommand.Parameters.AddWithValue("@doj", employeeDetails.doj);
//                msqlCommand.Parameters.AddWithValue("@department", employeeDetails.department);

//                msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }

//        public static List<EmployeeInfo> GetAllEmployeeList()
//        {
//            return QueryAllEmployeeList();
//        }

//        private static List<EmployeeInfo> QueryAllEmployeeList()
//        {
//            List<EmployeeInfo> EmployeeList = new List<EmployeeInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From employee;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    EmployeeInfo Employee = new EmployeeInfo();

//                    Employee.id = msqlReader.GetString("id");
//                    Employee.name = msqlReader.GetString("name");
//                    Employee.address = msqlReader.GetString("address");
//                    Employee.contact = msqlReader.GetString("contact");
//                    Employee.postType = (PostType)Enum.Parse(typeof(PostType), msqlReader.GetString("post_type"), true);
//                    Employee.doj = msqlReader.GetDateTime("doj");
//                    Employee.department = msqlReader.GetString("department");

//                    EmployeeList.Add(Employee);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return EmployeeList;

//        }

//        public static void DeleteEmployee(string employeeToDelete)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "DELETE FROM employee WHERE id= @employeeIdToDelete";
//                msqlCommand.Parameters.AddWithValue("@employeeIdToDelete", employeeToDelete);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//        }

//        public static void EditEmployee(EmployeeInfo employeeToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE employee SET name=@name,address=@address,contact=@contact,post_type=@postType,doj=@doj WHERE id=@id";

//                msqlCommand.Parameters.AddWithValue("@name", employeeToEdit.name);
//                msqlCommand.Parameters.AddWithValue("@address", employeeToEdit.address);
//                msqlCommand.Parameters.AddWithValue("@contact", employeeToEdit.contact);
//                msqlCommand.Parameters.AddWithValue("@postType", employeeToEdit.postType);
//                msqlCommand.Parameters.AddWithValue("@doj", employeeToEdit.doj);
//                msqlCommand.Parameters.AddWithValue("@department", employeeToEdit.department);
//                msqlCommand.Parameters.AddWithValue("@id", employeeToEdit.id);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//        }

//        #endregion

//        #region Contractor

//        public static int DoRegisterNewContractor(ContractorInfo contractorDetails)
//        {
//            return DoRegisterNewContractorInDb(contractorDetails);
//        }

//        private static int DoRegisterNewContractorInDb(ContractorInfo contractorDetails)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                //define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "INSERT INTO contractor(id,name,address,contact,contract_details) "
//                                                   + "VALUES(@id,@name,@address,@contact,@contract_details)";

//                msqlCommand.Parameters.AddWithValue("@id", contractorDetails.id);
//                msqlCommand.Parameters.AddWithValue("@name", contractorDetails.name);
//                msqlCommand.Parameters.AddWithValue("@address", contractorDetails.address);
//                msqlCommand.Parameters.AddWithValue("@contact", contractorDetails.contact);
//                msqlCommand.Parameters.AddWithValue("@contract_details", contractorDetails.details);

//                msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }

//        public static List<ContractorInfo> GetAllContractorList()
//        {
//            return QueryAllContractorList();
//        }

//        private static List<ContractorInfo> QueryAllContractorList()
//        {
//            List<ContractorInfo> ContractorList = new List<ContractorInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;



//                msqlCommand.CommandText = "Select * From contractor;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    ContractorInfo Contractor = new ContractorInfo();

//                    Contractor.id = msqlReader.GetString("id");
//                    Contractor.name = msqlReader.GetString("name");
//                    Contractor.address = msqlReader.GetString("address");
//                    Contractor.contact = msqlReader.GetString("contact");
//                    Contractor.details = msqlReader.GetString("contract_details");

//                    ContractorList.Add(Contractor);
//                }
//            }

//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return ContractorList;

//        }

//        public static void DeleteContractor(string contractorToDelete)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "DELETE FROM contractor WHERE id= @contractorIdToDelete";
//                msqlCommand.Parameters.AddWithValue("@contractorIdToDelete", contractorToDelete);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//        }

//        public static void EditContractor(ContractorInfo contractorToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE contractor SET name=@name,address=@address,contact=@contact,contract_details=@details WHERE id=@id";

//                msqlCommand.Parameters.AddWithValue("@name", contractorToEdit.name);
//                msqlCommand.Parameters.AddWithValue("@address", contractorToEdit.address);
//                msqlCommand.Parameters.AddWithValue("@contact", contractorToEdit.contact);
//                msqlCommand.Parameters.AddWithValue("@details", contractorToEdit.details);
//                msqlCommand.Parameters.AddWithValue("@id", contractorToEdit.id);

//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//        }

//        #endregion

//        #region Payment

//        public static List<PaymentInfo> GetUnassignedPaymentList()
//        {
//            List<PaymentInfo> PaymentList = new List<PaymentInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From payment;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    PaymentInfo Payment = new PaymentInfo();

//                    Payment.id = msqlReader.GetString("id");
//                    Payment.customerId = msqlReader.GetString("customerId");
//                    Payment.amount = msqlReader.GetDouble("amount");
//                    Payment.dop = msqlReader.GetDateTime("dop");

//                    PaymentList.Add(Payment);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return PaymentList;

//        }

//        public static int DoRegisterNewPayment(PaymentInfo peaymentDetails)
//        {
//            return DoRegisterNewPaymentInDb(peaymentDetails);
//        }

//        private static int DoRegisterNewPaymentInDb(PaymentInfo peaymentDetails)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "INSERT INTO payment(id,customerId,amount,dop) "
//                                                   + "VALUES(@id,@customerId,@amount,@dop)";

//                msqlCommand.Parameters.AddWithValue("@id", peaymentDetails.id);
//                msqlCommand.Parameters.AddWithValue("@customerId", peaymentDetails.customerId);
//                msqlCommand.Parameters.AddWithValue("@amount", peaymentDetails.amount);
//                msqlCommand.Parameters.AddWithValue("@dop", peaymentDetails.dop);


//                msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }

//        public static List<PaymentInfo> GetAllPaymentList()
//        {
//            return QueryAllPaymentList();
//        }

//        private static List<PaymentInfo> QueryAllPaymentList()
//        {
//            List<PaymentInfo> PaymentList = new List<PaymentInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From payment;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    PaymentInfo Payment = new PaymentInfo();

//                    Payment.id = msqlReader.GetString("id");
//                    Payment.customerId = msqlReader.GetString("customerId");
//                    Payment.amount = msqlReader.GetDouble("amount");
//                    Payment.dop = msqlReader.GetDateTime("dop");

//                    PaymentList.Add(Payment);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return PaymentList;

//        }

//        public static void DeletePayment(string paymentToDelete)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "DELETE FROM payment WHERE id=@paymentIdToDelete";
//                msqlCommand.Parameters.AddWithValue("@paymentIdToDelete", paymentToDelete);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//        }

//        public static void EditPayment(PaymentInfo paymentToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE payment SET customerId=@customerId,amount=@amount,dop=@dop WHERE id=@id";

//                msqlCommand.Parameters.AddWithValue("@customerId", paymentToEdit.customerId);
//                msqlCommand.Parameters.AddWithValue("@amount", paymentToEdit.amount);
//                msqlCommand.Parameters.AddWithValue("@dop", paymentToEdit.dop);
//                msqlCommand.Parameters.AddWithValue("@id", paymentToEdit.id);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//        }

//        public static PaymentInfo GetPaymentInfo(string paymentId)
//        {
//            PaymentInfo payment = new PaymentInfo();

//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From payment WHERE id=@id;";
//                msqlCommand.Parameters.AddWithValue("@id", paymentId);
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                msqlReader.Read();

//                payment.id = msqlReader.GetString("id");
//                payment.customerId = msqlReader.GetString("customerId");
//                payment.amount = msqlReader.GetDouble("amount");
//                payment.dop = msqlReader.GetDateTime("dop");
//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return payment;

//        }

//        #endregion

//        #region Estimator

//        public static List<EmployeeInfo> GetAllEstimatorList()
//        {
//            List<EmployeeInfo> EmployeeList = new List<EmployeeInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From employee WHERE post_type=@post;";
//                msqlCommand.Parameters.AddWithValue("@post", "Estimator");
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    EmployeeInfo Employee = new EmployeeInfo();

//                    Employee.id = msqlReader.GetString("id");
//                    Employee.name = msqlReader.GetString("name");
//                    Employee.address = msqlReader.GetString("address");
//                    Employee.contact = msqlReader.GetString("contact");
//                    Employee.postType = (PostType)Enum.Parse(typeof(PostType), msqlReader.GetString("post_type"), true);
//                    Employee.doj = msqlReader.GetDateTime("doj");
//                    Employee.department = msqlReader.GetString("department");

//                    EmployeeList.Add(Employee);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return EmployeeList;
//        }

//        public static int DoRegisterNewEstimate(estimateInfo estimateToEdit)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                //define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "insert into estimate(appNo)" + "values(@appNo)";
//                msqlCommand.Parameters.AddWithValue("@appNo", estimateToEdit.appsNo);
//                msqlCommand.ExecuteNonQuery();

//                // msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }

//        public static void EditEstimate(estimateInfo estimateToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE estimate SET estimator=@estimator,wireLength=@wireLength,angleType=@angleType,angleWeight=@angleWeight,amountQuotation=@amountQuotation WHERE appNo=@appNo";

//                msqlCommand.Parameters.AddWithValue("@estimator", estimateToEdit.estimator);
//                msqlCommand.Parameters.AddWithValue("@wireLength", estimateToEdit.wireLength);
//                msqlCommand.Parameters.AddWithValue("@angleType", estimateToEdit.angleType);
//                msqlCommand.Parameters.AddWithValue("@angleWeight", estimateToEdit.angleWeight);
//                msqlCommand.Parameters.AddWithValue("@amountQuotation", estimateToEdit.quotationAmount);
//                msqlCommand.Parameters.AddWithValue("@appNo", estimateToEdit.appsNo);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//        }

//        public static List<estimateInfo> GetAllEstimateList()
//        {
//            List<estimateInfo> estimateList = new List<estimateInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();


//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From estimate;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    estimateInfo estimate = new estimateInfo();

//                    estimate.appsNo = msqlReader.GetString("appNo");
//                    estimate.wireLength = msqlReader.GetDouble("wireLength");
//                    estimate.angleType = (AngleType)Enum.Parse(typeof(AngleType), msqlReader.GetString("angleType"), true);
//                    estimate.angleWeight = msqlReader.GetDouble("angleWeight");
//                    estimate.quotationAmount = msqlReader.GetDouble("amountQuotation");
//                    estimate.estimator = msqlReader.GetString("estimator");
//                    estimateList.Add(estimate);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return estimateList;

//        }

//        #endregion

//        #region Customer

//        public static CustomerInfo GetCustomerInfo(string cusId)
//        {
//            CustomerInfo customer = new CustomerInfo();

//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From customer WHERE id=@id;";
//                msqlCommand.Parameters.AddWithValue("@id", cusId);
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                msqlReader.Read();

//                customer.name = msqlReader.GetString("name");
//                customer.address = msqlReader.GetString("address");
//                customer.contact = msqlReader.GetString("contact");
//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return customer;

//        }

//        public static int DoRegisterNewCustomer(CustomerInfo customerDetails)
//        {
//            return DoRegisterNewCustomerInDb(customerDetails);
//        }

//        private static int DoRegisterNewCustomerInDb(CustomerInfo customerDetails)
//        {
//            int returnVal = 0;
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

//                define the connection used by the command object
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "INSERT INTO customer(id,name,address,contact) "
//                                                   + "VALUES(@id,@name,@address,@contact)";

//                msqlCommand.Parameters.AddWithValue("@id", customerDetails.id);
//                msqlCommand.Parameters.AddWithValue("@name", customerDetails.name);
//                msqlCommand.Parameters.AddWithValue("@address", customerDetails.address);
//                msqlCommand.Parameters.AddWithValue("@contact", customerDetails.contact);
//                msqlCommand.ExecuteNonQuery();

//                returnVal = 1;
//            }
//            catch (Exception er)
//            {
//                returnVal = 0;
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//            return returnVal;
//        }


//        public static List<CustomerInfo> GetAllCustomerList()
//        {
//            return QueryAllCustomerList();
//        }

//        private static List<CustomerInfo> QueryAllCustomerList()
//        {
//            List<CustomerInfo> CustomerList = new List<CustomerInfo>();

//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From customer;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    CustomerInfo Customer = new CustomerInfo();

//                    Customer.id = msqlReader.GetString("id");
//                    Customer.name = msqlReader.GetString("name");
//                    Customer.address = msqlReader.GetString("address");
//                    Customer.contact = msqlReader.GetString("contact");
//                    CustomerList.Add(Customer);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//            return CustomerList;
//        }

//        public static void DeleteCustomer(string customerToDelete)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "DELETE FROM customer WHERE id=@customerIdToDelete";
//                msqlCommand.Parameters.AddWithValue("@customerIdToDelete", customerToDelete);

//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }

//        }

//        public static void EditCustomer(CustomerInfo employeeToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {
//                define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE customer SET name=@name,address=@address,contact=@contact WHERE id=@id";

//                msqlCommand.Parameters.AddWithValue("@name", employeeToEdit.name);
//                msqlCommand.Parameters.AddWithValue("@address", employeeToEdit.address);
//                msqlCommand.Parameters.AddWithValue("@contact", employeeToEdit.contact);
//                msqlCommand.Parameters.AddWithValue("@id", employeeToEdit.id);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                always close the connection
//                msqlConnection.Close();
//            }
//        }

//        #endregion



//        public static void assignEstimator(estimateInfo estimateToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE estimate SET estimator=@estimator WHERE appNo=@appNo";

//                msqlCommand.Parameters.AddWithValue("@estimator", estimateToEdit.estimator);
//                msqlCommand.Parameters.AddWithValue("@appNo", estimateToEdit.appsNo);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//        }



//        public static List<estimateInfo> GetAllEstimateListWithContractor()
//        {
//            List<estimateInfo> estimateList = new List<estimateInfo>();
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();


//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "Select * From estimate;";
//                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

//                while (msqlReader.Read())
//                {
//                    estimateInfo estimate = new estimateInfo();

//                    estimate.appsNo = msqlReader.GetString("appNo");
//                    estimate.wireLength = msqlReader.GetDouble("wireLength");
//                    estimate.angleType = (AngleType)Enum.Parse(typeof(AngleType), msqlReader.GetString("angleType"), true);
//                    estimate.angleWeight = msqlReader.GetDouble("angleWeight");
//                    estimate.quotationAmount = msqlReader.GetDouble("amountQuotation");
//                    estimate.estimator = msqlReader.GetString("estimator");
//                    estimate.contractor = msqlReader.GetString("contractor");
//                    estimateList.Add(estimate);
//                }

//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }

//            return estimateList;
//        }

//        public static void assignContractor(estimateInfo contractorToEdit)
//        {
//            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

//            try
//            {   //define the command reference
//                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
//                msqlCommand.Connection = msqlConnection;

//                msqlCommand.CommandText = "UPDATE estimate SET contractor=@contractor WHERE appNo=@appNo";

//                msqlCommand.Parameters.AddWithValue("@contractor", contractorToEdit.contractor);
//                msqlCommand.Parameters.AddWithValue("@appNo", contractorToEdit.appsNo);
//                msqlCommand.ExecuteNonQuery();


//            }
//            catch (Exception er)
//            {
//            }
//            finally
//            {
//                //always close the connection
//                msqlConnection.Close();
//            }
//        }
//    }

//}
