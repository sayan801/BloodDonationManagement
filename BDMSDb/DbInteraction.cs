using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDMSData;

namespace BDMSDb
{
    public static class DbInteraction
    {
        static string passwordCurrent = "technicise";
        static string dbmsCurrent = "bdmsdb";

        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;                               

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }

        #region Donor

        public static int DoRegisterNewDonor(DonorInfo donorDetails)
        {
            return DoRegisterNewDonorInDb(donorDetails);
        }

        private static int DoRegisterNewDonorInDb(DonorInfo donorDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO donor(donor_id,donor_name,donor_blood_group,donor_dob,donor_address,donor_contact,donor_last_blood_donate) "
                                                   + "VALUES(@donor_id,@donor_name,@donor_blood_group,@donor_dob,@donor_address,@donor_contact,@donor_last_blood_donate)";

                msqlCommand.Parameters.AddWithValue("@donor_id", donorDetails.id);
                msqlCommand.Parameters.AddWithValue("@donor_name", donorDetails.name);
                msqlCommand.Parameters.AddWithValue("@donor_blood_group", donorDetails.bloodGroup);
                msqlCommand.Parameters.AddWithValue("@donor_dob", donorDetails.dob);
                msqlCommand.Parameters.AddWithValue("@donor_address", donorDetails.address);
                msqlCommand.Parameters.AddWithValue("@donor_contact", donorDetails.phone);
                msqlCommand.Parameters.AddWithValue("@donor_last_blood_donate", donorDetails.lastDonateDate);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<DonorInfo> GetAllDonorList()
        {
            return QueryAllDonorList();
        }

        private static List<DonorInfo> QueryAllDonorList()
        {
            List<DonorInfo> DonorList = new List<DonorInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From donor;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    DonorInfo Donor = new DonorInfo();

                    Donor.id = msqlReader.GetString("donor_id");
                    Donor.name = msqlReader.GetString("donor_name");
                    Donor.bloodGroup = msqlReader.GetString("donor_blood_group");
                    Donor.dob = msqlReader.GetDateTime("donor_dob");
                    Donor.address = msqlReader.GetString("donor_address");
                    Donor.phone = msqlReader.GetString("donor_contact");
                    Donor.lastDonateDate = msqlReader.GetDateTime("donor_last_blood_donate");

                    DonorList.Add(Donor);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return DonorList;

        }


        public static void DeleteDonor(string donorToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM donor WHERE donor_id= @donorIdToDelete";
                msqlCommand.Parameters.AddWithValue("@donorIdToDelete", donorToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }



        public static void EditDonor(DonorInfo donorToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE donor SET donor_name=@donor_name,donor_blood_group=@donor_blood_group,donor_dob=@donor_dob,donor_address=@donor_address,donor_contact=@donor_contact,donor_last_blood_donate=@donor_last_blood_donate WHERE donor_id= @donorIdToDelete";
                msqlCommand.Parameters.AddWithValue("@donor_name", donorToEdit.name);
                msqlCommand.Parameters.AddWithValue("@donor_blood_group", donorToEdit.bloodGroup);
                msqlCommand.Parameters.AddWithValue("@donor_dob", donorToEdit.dob);
                msqlCommand.Parameters.AddWithValue("@donor_address", donorToEdit.address);
                msqlCommand.Parameters.AddWithValue("@donor_contact", donorToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@donor_last_blood_donate", donorToEdit.lastDonateDate);
                msqlCommand.Parameters.AddWithValue("@donorIdToDelete", donorToEdit.id); 
                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Member


        public static int DoRegisterNewMember(MemberInfo memberDetails)
        {
            return DoRegisterNewMemberInDb(memberDetails);
        }

        private static int DoRegisterNewMemberInDb(MemberInfo memberDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO member(member_id,member_name,member_doj,member_address,member_contect) "
                                                   + "VALUES(@member_id,@member_name,@member_doj,@member_address,@member_contect)";

                msqlCommand.Parameters.AddWithValue("@member_id", memberDetails.id);
                msqlCommand.Parameters.AddWithValue("@member_name", memberDetails.name);
                msqlCommand.Parameters.AddWithValue("@member_doj", memberDetails.doj);
                msqlCommand.Parameters.AddWithValue("@member_address", memberDetails.address);
                msqlCommand.Parameters.AddWithValue("@member_contect", memberDetails.phone);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<MemberInfo> GetAllMemberList()
        {
            return QueryAllMemberList();
        }

        private static List<MemberInfo> QueryAllMemberList()
        {
            List<MemberInfo> MemberList = new List<MemberInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From member;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    MemberInfo Member = new MemberInfo();

                    Member.id = msqlReader.GetString("member_id");
                    Member.name = msqlReader.GetString("member_name");
                    Member.doj = msqlReader.GetDateTime("member_doj");
                    Member.address = msqlReader.GetString("member_address");
                    Member.phone = msqlReader.GetString("member_contect");

                    MemberList.Add(Member);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return MemberList;

        }

        public static void DeleteMember(string memberToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM member WHERE member_id= @memberIdToDelete";
                msqlCommand.Parameters.AddWithValue("@memberIdToDelete", memberToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditMember(MemberInfo memberToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE member SET member_name=@member_name,member_doj=@member_doj,member_address=@member_address,member_contect=@member_contect WHERE member_id=@id";
                
                msqlCommand.Parameters.AddWithValue("@member_name", memberToEdit.name);
                msqlCommand.Parameters.AddWithValue("@member_doj", memberToEdit.doj);
                msqlCommand.Parameters.AddWithValue("@member_address", memberToEdit.address);
                msqlCommand.Parameters.AddWithValue("@member_contect", memberToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@id", memberToEdit.id);

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Patient

        public static int DoRegisterPatient(PatientInfo patientDetails)
        {
            return DoRegisterNewPatientInDb(patientDetails);
        }

        private static int DoRegisterNewPatientInDb(PatientInfo patientDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO patient(patient_id,patient_name,patient_blood_group,patient_age,patient_address,patient_contact,patient_admited_address,patient_expected_date) "
                                                   + "VALUES(@patient_id,@patient_name,@patient_blood_group,@patient_age,@patient_address,@patient_contact,@patient_admitted_address,@patient_expected_date)";

                msqlCommand.Parameters.AddWithValue("@patient_id", patientDetails.id);
                msqlCommand.Parameters.AddWithValue("@patient_name", patientDetails.name);
                msqlCommand.Parameters.AddWithValue("@patient_blood_group", patientDetails.bloodGroup);
                msqlCommand.Parameters.AddWithValue("@patient_age", patientDetails.age);
                msqlCommand.Parameters.AddWithValue("@patient_address", patientDetails.address);
                msqlCommand.Parameters.AddWithValue("@patient_contact", patientDetails.phone);
                msqlCommand.Parameters.AddWithValue("@patient_admitted_address", patientDetails.admittedAddress);
                msqlCommand.Parameters.AddWithValue("@patient_expected_date", patientDetails.expectedDate);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception ex)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }
        public static List<PatientInfo> GetAllPatientList()
        {
            return QueryAllPatientList();
        }

        private static List<PatientInfo> QueryAllPatientList()
        {
            List<PatientInfo> PatientList = new List<PatientInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From patient;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    PatientInfo Patient = new PatientInfo();

                    Patient.id = msqlReader.GetString("patient_id");
                    Patient.name = msqlReader.GetString("patient_name");
                    Patient.bloodGroup = msqlReader.GetString("patient_blood_group");
                    Patient.age = msqlReader.GetInt32("patient_age");
                    Patient.address = msqlReader.GetString("patient_address");
                    Patient.phone = msqlReader.GetString("patient_contact");
                    Patient.admittedAddress = msqlReader.GetString("patient_admited_address");
                    Patient.expectedDate = msqlReader.GetDateTime("patient_expected_date");
                    //Patient.admittedAddress = msqlReader.GetString("assigned_donor");
                    //Patient.expectedDate = msqlReader.GetDateTime("assigned_donor_contact");

                    PatientList.Add(Patient);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return PatientList;

        }


        public static void DeletePatient(string patientToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM patient WHERE patient_id= @patientIdToDelete";
                msqlCommand.Parameters.AddWithValue("@patientIdToDelete", patientToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditPatient(PatientInfo patientToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE patient SET patient_name=@patient_name,patient_blood_group=@patient_blood_group,patient_age=@patient_age,patient_contact=@patient_contact,patient_address=@patient_address,patient_admited_address=@patient_admited_address,patient_expected_date=@patient_expected_date WHERE patient_id=@patient_id";
                msqlCommand.Parameters.AddWithValue("@patient_name", patientToEdit.name);
                msqlCommand.Parameters.AddWithValue("@patient_blood_group", patientToEdit.bloodGroup);
                msqlCommand.Parameters.AddWithValue("@patient_age", patientToEdit.age);
                msqlCommand.Parameters.AddWithValue("@patient_contact", patientToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@patient_address", patientToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@patient_admited_address", patientToEdit.admittedAddress);
                msqlCommand.Parameters.AddWithValue("@patient_expected_date", patientToEdit.expectedDate);
                msqlCommand.Parameters.AddWithValue("@patient_id", patientToEdit.id);

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region WellWisher

        public static int DoRegisterWellWisher(WellWisherInfo wellWisherDetails)
        {
            return DoRegisterWellWisherInDb(wellWisherDetails);
        }

        private static int DoRegisterWellWisherInDb(WellWisherInfo wellWisherDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO well_wisher(well_wisher_id,well_wisher_name,well_wisher_address,well_wisher_doj,well_wisher_contact,well_wisher_remarks) "
                                                   + "VALUES(@well_wisher_id,@well_wisher_name,@well_wisher_address,@well_wisher_doj,@well_wisher_contact,@well_wisher_remarks)";

                msqlCommand.Parameters.AddWithValue("@well_wisher_id", wellWisherDetails.id);
                msqlCommand.Parameters.AddWithValue("@well_wisher_name", wellWisherDetails.name);
                msqlCommand.Parameters.AddWithValue("@well_wisher_address", wellWisherDetails.address);
                msqlCommand.Parameters.AddWithValue("@well_wisher_doj", wellWisherDetails.doj);
                msqlCommand.Parameters.AddWithValue("@well_wisher_contact", wellWisherDetails.phone);
                msqlCommand.Parameters.AddWithValue("@well_wisher_remarks", wellWisherDetails.remarks);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception ex)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }
        public static List<WellWisherInfo> GetAllWellWisherList()
        {
            return QueryAllWellWisherList();
        }

        private static List<WellWisherInfo> QueryAllWellWisherList()
        {
            List<WellWisherInfo> WellWisherList = new List<WellWisherInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From well_wisher;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    WellWisherInfo WellWisher = new WellWisherInfo();

                    WellWisher.id = msqlReader.GetString("well_wisher_id");
                    WellWisher.name = msqlReader.GetString("well_wisher_name");
                    WellWisher.address = msqlReader.GetString("well_wisher_address");
                    WellWisher.doj = msqlReader.GetDateTime("well_wisher_doj");
                    WellWisher.phone = msqlReader.GetString("well_wisher_contact");
                    WellWisher.remarks = msqlReader.GetString("well_wisher_remarks");

                    WellWisherList.Add(WellWisher);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return WellWisherList;

        }


        public static void DeleteWellWisher(string wellWisherToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM well_wisher WHERE well_wisher_id= @wellWisherIdToDelete";
                msqlCommand.Parameters.AddWithValue("@wellWisherIdToDelete", wellWisherToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditWellWisher(WellWisherInfo wellWisherToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE well_wisher SET well_wisher_name=@well_wisher_name,well_wisher_address=@well_wisher_address,well_wisher_doj=@well_wisher_doj,well_wisher_contact=@well_wisher_contact,well_wisher_remarks=@well_wisher_remarks WHERE well_wisher_id=@well_wisher_id";
                
                msqlCommand.Parameters.AddWithValue("@well_wisher_name", wellWisherToEdit.name);
                msqlCommand.Parameters.AddWithValue("@well_wisher_address", wellWisherToEdit.address);
                msqlCommand.Parameters.AddWithValue("@well_wisher_doj", wellWisherToEdit.doj);
                msqlCommand.Parameters.AddWithValue("@well_wisher_contact", wellWisherToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@well_wisher_remarks", wellWisherToEdit.remarks);
                msqlCommand.Parameters.AddWithValue("@well_wisher_id", wellWisherToEdit.id);

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Event

        public static int DoRegisterNewEvent(EventInfo EventDetails)
        {
            return DoRegisterNewEventInDb(EventDetails);
        }

        private static int DoRegisterNewEventInDb(EventInfo eventDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO Event(event_id,event_title,event_doe,event_venue,event_goal) "
                                                   + "VALUES(@event_id,@event_title,@event_doe,@event_venue,@event_goal)";

                msqlCommand.Parameters.AddWithValue("@event_id", eventDetails.id);
                msqlCommand.Parameters.AddWithValue("@event_title", eventDetails.eventTitle);
                msqlCommand.Parameters.AddWithValue("@event_doe", eventDetails.eventDoe);
                msqlCommand.Parameters.AddWithValue("@event_venue", eventDetails.eventVenue);
                msqlCommand.Parameters.AddWithValue("@event_goal", eventDetails.eventGoal);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<EventInfo> GetAllEventList()
        {
            return QueryAllEventList();
        }

        private static List<EventInfo> QueryAllEventList()
        {
            List<EventInfo> EventList = new List<EventInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From event;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    EventInfo Event = new EventInfo();

                    Event.id = msqlReader.GetString("event_id");
                    Event.eventTitle = msqlReader.GetString("event_title");
                    Event.eventDoe = msqlReader.GetDateTime("event_doe");
                    Event.eventVenue = msqlReader.GetString("event_venue");
                    Event.eventGoal = msqlReader.GetString("event_goal");

                    EventList.Add(Event);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return EventList;

        }


        public static void DeleteEvent(string eventToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM event WHERE event_id= @eventIdToDelete";
                msqlCommand.Parameters.AddWithValue("@eventIdToDelete", eventToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditEvent(EventInfo eventToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE event SET event_id=@event_id,event_title=@event_title,event_doe=@event_doe,event_venue=@event_venue,event_goal=@event_goal WHERE event_id= @eventIdToDelete";
                msqlCommand.Parameters.AddWithValue("@event_id", eventToEdit.id);
                msqlCommand.Parameters.AddWithValue("@event_title", eventToEdit.eventTitle);
                msqlCommand.Parameters.AddWithValue("@event_doe", eventToEdit.eventDoe);
                msqlCommand.Parameters.AddWithValue("@event_venue", eventToEdit.eventVenue);
                msqlCommand.Parameters.AddWithValue("@event_goal", eventToEdit.eventGoal);
                msqlCommand.Parameters.AddWithValue("@eventIdToDelete", eventToEdit.id);

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Todo

        public static int DoRegisterNewTodo(TodoInfo todoDetails)
        {
            return DoRegisterNewTodoInDb(todoDetails);
        }

        private static int DoRegisterNewTodoInDb(TodoInfo todoDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO todo(todo_id,todo_date,todo_details) "
                                                   + "VALUES(@todo_id,@todo_date,@todo_details)";

                msqlCommand.Parameters.AddWithValue("@todo_id", todoDetails.id);
                msqlCommand.Parameters.AddWithValue("@todo_date", todoDetails.date);
                msqlCommand.Parameters.AddWithValue("@todo_details", todoDetails.details);


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<TodoInfo> GetAllTodoList()
        {
            return QueryAllTodoList();
        }

        private static List<TodoInfo> QueryAllTodoList()
        {
            List<TodoInfo> TodoList = new List<TodoInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 


            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From todo;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    TodoInfo todo = new TodoInfo();

                    todo.id = msqlReader.GetString("todo_id");
                    todo.date = msqlReader.GetDateTime("todo_date");
                    todo.details = msqlReader.GetString("todo_details");

                    TodoList.Add(todo);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return TodoList;

        }


        public static void DeleteTodo(string todoToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM todo WHERE todo_id= @todoIdToDelete";
                msqlCommand.Parameters.AddWithValue("@todoIdToDelete", todoToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        //public static void EditTodo(TodoInfo todoToEdit)
        //{
        //    MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

        //    msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

        //    try
        //    {   //define the command reference
        //        MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
        //        msqlCommand.Connection = msqlConnection;

        //        msqlConnection.Open();
        //        msqlCommand.CommandText = "UPDATE todo SET todo_id=@todo_id,todo_date=@todo_date,todo_details=@todo_details WHERE todo_id= @todoIdToDelete";
        //        msqlCommand.Parameters.AddWithValue("@todo_id", todoToEdit.id);
        //        msqlCommand.Parameters.AddWithValue("@todo_date", todoToEdit.date);
        //        msqlCommand.Parameters.AddWithValue("@todo_details", todoToEdit.details);

        //        msqlCommand.ExecuteNonQuery();


        //    }
        //    catch (Exception er)
        //    {
        //    }
        //    finally
        //    {
        //        //always close the connection
        //        msqlConnection.Close();
        //    }
        //}

        #endregion

        #region Hdbb

        public static int DoRegisterNewHdbb(HdbbInfo hdbbDetails)
        {
            return DoRegisterNewHdbbInDb(hdbbDetails);
        }

        private static int DoRegisterNewHdbbInDb(HdbbInfo hdbbDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO hdbb(hdbb_id,hdbb_type,hdbb_name,hdbb_address,hdbb_contact) "
                                                   + "VALUES(@hdbb_id,@hdbb_type,@hdbb_name,@hdbb_address,@hdbb_contact)";

                msqlCommand.Parameters.AddWithValue("@hdbb_id", hdbbDetails.id);
                msqlCommand.Parameters.AddWithValue("@hdbb_type", hdbbDetails.type);
                msqlCommand.Parameters.AddWithValue("@hdbb_name", hdbbDetails.name);
                msqlCommand.Parameters.AddWithValue("@hdbb_address", hdbbDetails.address);
                msqlCommand.Parameters.AddWithValue("@hdbb_contact", hdbbDetails.phone);


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<HdbbInfo> GetAllHdbbList()
        {
            return QueryAllHdbbList();
        }

        private static List<HdbbInfo> QueryAllHdbbList()
        {
            List<HdbbInfo> HdbbList = new List<HdbbInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From hdbb;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    HdbbInfo Hdbb = new HdbbInfo();

                    Hdbb.id = msqlReader.GetString("hdbb_id");
                    Hdbb.type = msqlReader.GetString("hdbb_type");
                    Hdbb.name = msqlReader.GetString("hdbb_name");
                    Hdbb.address = msqlReader.GetString("hdbb_address");
                    Hdbb.phone = msqlReader.GetString("hdbb_contact");

                    HdbbList.Add(Hdbb);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return HdbbList;

        }

        public static void DeleteHdbb(string hdbbToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM hdbb WHERE hdbb_id= @hdbbIdToDelete";
                msqlCommand.Parameters.AddWithValue("@hdbbIdToDelete", hdbbToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditHdbb(HdbbInfo hdbbToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE hdbb SET hdbb_type=@hdbb_type,hdbb_name=@hdbb_name,hdbb_address=@hdbb_address,hdbb_contact=@hdbb_contact WHERE hdbb_id=@hdbb_id";
                
                msqlCommand.Parameters.AddWithValue("@hdbb_type", hdbbToEdit.type);
                msqlCommand.Parameters.AddWithValue("@hdbb_name", hdbbToEdit.name);
                msqlCommand.Parameters.AddWithValue("@hdbb_address", hdbbToEdit.address);
                msqlCommand.Parameters.AddWithValue("@hdbb_contact", hdbbToEdit.phone);
                msqlCommand.Parameters.AddWithValue("@hdbb_id", hdbbToEdit.id);

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Fund

        public static int DoRegisterNewFund(FundInfo fundDetails)
        {
            return DoRegisterNewFundInDb(fundDetails);
        }

        private static int DoRegisterNewFundInDb(FundInfo fundDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO fund(fund_Id,fund_wellwisher_name,fund_contact,fund_dod,fund_received_by,fund_amount) "
                                                   + "VALUES(@fund_Id,@fund_wellwisher_name,@fund_contact,@fund_dod,@fund_received_by,@fund_amount)";

                msqlCommand.Parameters.AddWithValue("@fund_Id", fundDetails.id);
                msqlCommand.Parameters.AddWithValue("@fund_wellwisher_name", fundDetails.wellwisher_name);
                msqlCommand.Parameters.AddWithValue("@fund_contact", fundDetails.contact);
                msqlCommand.Parameters.AddWithValue("@fund_dod", fundDetails.dod);
                msqlCommand.Parameters.AddWithValue("@fund_received_by", fundDetails.received_by);
                msqlCommand.Parameters.AddWithValue("@fund_amount", fundDetails.amount);


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<FundInfo> GetAllFundList()
        {
            return QueryAllFundList();
        }

        private static List<FundInfo> QueryAllFundList()
        {
            List<FundInfo> FundList = new List<FundInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From fund;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    FundInfo Fund = new FundInfo();

                    Fund.id = msqlReader.GetString("fund_Id");
                    Fund.wellwisher_name = msqlReader.GetString("fund_wellwisher_name");
                    Fund.contact = msqlReader.GetString("fund_contact");
                    Fund.dod = msqlReader.GetDateTime("fund_dod");
                    Fund.received_by = msqlReader.GetString("fund_received_by");
                    Fund.amount = msqlReader.GetDouble("fund_amount");

                    FundList.Add(Fund);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return FundList;

        }

        public static void DeleteFund(string fundToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM fund WHERE fund_id= @fundIdToDelete";
                msqlCommand.Parameters.AddWithValue("@fundIdToDelete", fundToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditFund(FundInfo fundToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE fund SET fund_wellwisher_name=@fund_wellwisher_name,fund_contact=@fund_contact,fund_dod=@fund_dod,fund_received_by=@fund_received_by,fund_amount=@fund_amount WHERE fund_id=@fund_id";

                msqlCommand.Parameters.AddWithValue("@fund_wellwisher_name", fundToEdit.wellwisher_name);
                msqlCommand.Parameters.AddWithValue("@fund_contact", fundToEdit.contact);
                msqlCommand.Parameters.AddWithValue("@fund_dod", fundToEdit.dod);
                msqlCommand.Parameters.AddWithValue("@fund_received_by", fundToEdit.received_by);
                msqlCommand.Parameters.AddWithValue("@fund_amount", fundToEdit.amount);
                msqlCommand.Parameters.AddWithValue("@fund_id", fundToEdit.id);
                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #region Expense

        public static int DoRegisterNewExpense(ExpenseInfo expenseDetails)
        {
            return DoRegisterNewExpenseInDb(expenseDetails);
        }

        private static int DoRegisterNewExpenseInDb(ExpenseInfo expenseDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO expense(expense_id,expense_purpose,expense_doe,expensed_by,expensed_amount) "
                                                   + "VALUES(@expense_id,@expense_purpose,@expense_doe,@expensed_by,@expensed_amount)";

                msqlCommand.Parameters.AddWithValue("@expense_id", expenseDetails.id);
                msqlCommand.Parameters.AddWithValue("@expense_purpose", expenseDetails.purpose);
                msqlCommand.Parameters.AddWithValue("@expense_doe", expenseDetails.doe);
                msqlCommand.Parameters.AddWithValue("@expensed_by", expenseDetails.expensed_by);
                msqlCommand.Parameters.AddWithValue("@expensed_amount", expenseDetails.amount);


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<ExpenseInfo> GetAllExpenseList()
        {
            return QueryAllExpenseList();
        }

        private static List<ExpenseInfo> QueryAllExpenseList()
        {
            List<ExpenseInfo> ExpenseList = new List<ExpenseInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 
            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From expense;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ExpenseInfo Expense = new ExpenseInfo();

                    Expense.id = msqlReader.GetString("expense_id");
                    Expense.purpose = msqlReader.GetString("expense_purpose");
                    Expense.doe = msqlReader.GetDateTime("expense_doe");
                    Expense.expensed_by = msqlReader.GetString("expensed_by");
                    Expense.amount = msqlReader.GetDouble("expensed_amount");


                    ExpenseList.Add(Expense);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ExpenseList;

        }



        public static void DeleteExpense(string expenseToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;
                
                msqlCommand.CommandText = "DELETE FROM expense WHERE expense_id= @expenseIdToDelete";
                msqlCommand.Parameters.AddWithValue("@expenseIdToDelete", expenseToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

        }

        public static void EditExpense(ExpenseInfo expenseToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection(); 

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE expense SET expense_purpose=@expense_purpose,expense_doe=@expense_doe,expensed_by=@expensed_by,expensed_amount=@expensed_amount WHERE expense_id=@expense_id";
               
                msqlCommand.Parameters.AddWithValue("@expense_purpose", expenseToEdit.purpose);
                msqlCommand.Parameters.AddWithValue("@expense_doe", expenseToEdit.doe);
                msqlCommand.Parameters.AddWithValue("@expensed_by", expenseToEdit.expensed_by);
                msqlCommand.Parameters.AddWithValue("@expensed_amount", expenseToEdit.amount);
                msqlCommand.Parameters.AddWithValue("@expense_id", expenseToEdit.id); 

                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }
        #endregion


        public static List<PatientInfo> GetAllPatientListWithAssignedDonor()
        {
            List<PatientInfo> PatientList = new List<PatientInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From patient;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    PatientInfo Patient = new PatientInfo();

                    Patient.id = msqlReader.GetString("patient_id");
                    Patient.name = msqlReader.GetString("patient_name");
                    Patient.bloodGroup = msqlReader.GetString("patient_blood_group");
                    Patient.age = msqlReader.GetInt32("patient_age");
                    Patient.address = msqlReader.GetString("patient_address");
                    Patient.phone = msqlReader.GetString("patient_contact");
                    Patient.admittedAddress = msqlReader.GetString("patient_admited_address");
                    Patient.expectedDate = msqlReader.GetDateTime("patient_expected_date");
                    Patient.assignedDonor = msqlReader.GetString("assigned_donor");
                    Patient.donorContact = msqlReader.GetString("assigned_donor_contact");

                    PatientList.Add(Patient);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return PatientList;
        }

        public static DonorInfo getDonorInfo(string donorId)
        {
            DonorInfo donor = new DonorInfo();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From donor WHERE donor_id=@id;";
                msqlCommand.Parameters.AddWithValue("@id", donorId);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                msqlReader.Read();

               // donor.id = msqlReader.GetString("id");
                donor.phone = msqlReader.GetString("donor_contact");
               
            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return donor;
        }

        public static void assignDonor(PatientInfo patientData)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE patient SET assigned_donor=@assigned_donor, assigned_donor_contact = @assigned_donor_contact WHERE patient_id=@patient_id";
                msqlCommand.Parameters.AddWithValue("@patient_id", patientData.id);
                msqlCommand.Parameters.AddWithValue("@assigned_donor", patientData.assignedDonor);
                msqlCommand.Parameters.AddWithValue("@assigned_donor_contact", patientData.donorContact);
                msqlCommand.ExecuteNonQuery();


            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            } 
        }
    }
}


