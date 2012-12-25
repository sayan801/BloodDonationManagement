-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: bdmsdb
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `bdmsdb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `bdmsdb` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bdmsdb`;

--
-- Table structure for table `blood_banks`
--

DROP TABLE IF EXISTS `blood_banks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `blood_banks` (
  `login_id` varchar(45) NOT NULL,
  `login_name` varchar(30) DEFAULT NULL,
  `login_type` varchar(10) DEFAULT NULL,
  `login_password` varchar(20) DEFAULT NULL,
  `login_address` varchar(100) DEFAULT NULL,
  `login_dob` date DEFAULT NULL,
  PRIMARY KEY (`login_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `blood_banks`
--

LOCK TABLES `blood_banks` WRITE;
/*!40000 ALTER TABLE `blood_banks` DISABLE KEYS */;
/*!40000 ALTER TABLE `blood_banks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donor`
--

DROP TABLE IF EXISTS `donor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `donor` (
  `donor_id` varchar(45) NOT NULL,
  `donor_name` varchar(30) NOT NULL,
  `donor_blood_group` varchar(6) DEFAULT NULL,
  `donor_dob` date DEFAULT NULL,
  `donor_address` varchar(100) DEFAULT NULL,
  `donor_contact` int(100) DEFAULT NULL,
  `donor_last_blood_donate` date DEFAULT NULL,
  PRIMARY KEY (`donor_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donor`
--

LOCK TABLES `donor` WRITE;
/*!40000 ALTER TABLE `donor` DISABLE KEYS */;
INSERT INTO `donor` VALUES ('41030.5556459606','Susmita Saha','A+','1990-06-28','Habra',22989099,'2012-03-16'),('41030.5583384375','Shovan Talukder','Bombay','1989-08-31','Shyambazar',22353333,'2012-05-04'),('41035.4621086806','Atanu Dey','Bombay','1987-05-26','Noihati',29878789,'2012-05-18'),('41039.4216824653','Kajal Roy','B+','1980-02-09','Digha',22890789,'2012-02-02'),('41041.8815406597','Kallal Das','B-','1982-05-25','Dumdum',26898765,'2012-05-26'),('41043.3361153704','Ashit Paul','AB-','1989-02-02','Barasat',26989098,'2012-02-02'),('41044.3999980787','Joydev Golder','B-','1982-05-05','Behala',29239049,'2012-05-05'),('41103.5600033218','Puja Mandal','A+','1992-06-26','Howrah',22790999,'2012-06-28'),('41110.3550950579','chinmoy','A+','2012-07-16','bmg',45679123,'2012-07-03'),('41110.3552251968','chinmoy','A+','2012-07-16','bmg',123456789,'2012-07-03'),('41110.3575189352','shantu','A+','2012-06-29','456 bangalore',101,'2012-07-09');
/*!40000 ALTER TABLE `donor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `event_id` varchar(45) NOT NULL,
  `event_title` varchar(45) NOT NULL,
  `event_doe` date DEFAULT NULL,
  `event_venue` varchar(100) DEFAULT NULL,
  `event_goal` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`event_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES ('41035.5057219907','Blood Donation Camp awareness','2012-05-11','Kolkata','Social Awareness Programmes Camps'),('41040.0161179745','Health Check Up','2012-05-27','Barasat','Free Health Check Up for poor');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `expense`
--

DROP TABLE IF EXISTS `expense`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `expense` (
  `expense_id` varchar(45) NOT NULL,
  `expense_purpose` varchar(45) DEFAULT NULL,
  `expense_doe` datetime DEFAULT NULL,
  `expensed_by` varchar(45) DEFAULT NULL,
  `expensed_amount` double DEFAULT NULL,
  PRIMARY KEY (`expense_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `expense`
--

LOCK TABLES `expense` WRITE;
/*!40000 ALTER TABLE `expense` DISABLE KEYS */;
INSERT INTO `expense` VALUES ('41043.5001148264','Food','2012-05-12 00:00:00','Amit',1555),('41043.7487917708','Gift','2012-03-02 00:00:00','amit',1000),('41109.5450884954','Poster','2012-04-08 00:00:00','Sokal paul',700);
/*!40000 ALTER TABLE `expense` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fund`
--

DROP TABLE IF EXISTS `fund`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fund` (
  `fund_Id` varchar(100) NOT NULL,
  `fund_wellwisher_name` varchar(45) DEFAULT NULL,
  `fund_contact` varchar(45) DEFAULT NULL,
  `fund_dod` datetime DEFAULT NULL,
  `fund_received_by` varchar(45) DEFAULT NULL,
  `fund_amount` double DEFAULT NULL,
  PRIMARY KEY (`fund_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fund`
--

LOCK TABLES `fund` WRITE;
/*!40000 ALTER TABLE `fund` DISABLE KEYS */;
INSERT INTO `fund` VALUES ('41035.5896526736','Taposh Karmakar','9890989888','2012-05-09 00:00:00','Gobinda Bapari',900000),('41035.5896838773','Sanjib Roy','7888789989','2012-05-09 00:00:00','Sayan Dasgupta',900000),('41041.902740162','Kakali Mitra','8909890989','2012-05-26 00:00:00','Sayan Dasgupta',5000),('41041.9027596644','Litan Mondal','9890989789','2012-05-26 00:00:00','Sayan Dasgupta',6000),('41043.4522787731','Dr. Suresh Baul','9576899908','2012-01-01 00:00:00','Sayan Dasgupta',1000);
/*!40000 ALTER TABLE `fund` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hdbb`
--

DROP TABLE IF EXISTS `hdbb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hdbb` (
  `hdbb_id` varchar(45) NOT NULL,
  `hdbb_type` varchar(15) DEFAULT NULL,
  `hdbb_name` varchar(45) DEFAULT NULL,
  `hdbb_address` varchar(100) DEFAULT NULL,
  `hdbb_contact` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`hdbb_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hdbb`
--

LOCK TABLES `hdbb` WRITE;
/*!40000 ALTER TABLE `hdbb` DISABLE KEYS */;
INSERT INTO `hdbb` VALUES ('41043','Blood Bank','Ulta Danga Blood Bank','Bidhan Nagar','03322878787'),('41044','Hospital','NRS','Sealdah','03324567876'),('41046.9161453472','Doctor','Dr. Juthika Nag','Birati','9898877678'),('41046.916519456','Blood Bank','Barasat Blood bank','Barasat','03322878987'),('41047','Hospital','SSKM','Kolkata','03326787656'),('41047.4450620255','Doctor','Dr. Suman Saha','Barasat','9098888757');
/*!40000 ALTER TABLE `hdbb` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `member` (
  `member_id` varchar(45) NOT NULL,
  `member_name` varchar(45) DEFAULT NULL,
  `member_doj` date DEFAULT NULL,
  `member_address` varchar(100) DEFAULT NULL,
  `member_contect` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`member_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` VALUES ('41042.5873998727','Sayan Dasgupta','2012-05-11','Barasat','9888878787'),('41042.5879379977','Joy Sadhukhan','2012-05-19','Barasat','7898767899'),('41043.3377675926','Amit Karmakar','2012-05-03','Barasat','7897875262'),('41106.8603612731','Gobinda Bapari','2012-07-15','Barasat','9287627678');
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `patient` (
  `patient_id` varchar(45) NOT NULL,
  `patient_name` varchar(30) NOT NULL,
  `patient_blood_group` varchar(6) DEFAULT NULL,
  `patient_age` int(3) DEFAULT NULL,
  `patient_contact` varchar(12) DEFAULT NULL,
  `patient_address` varchar(100) DEFAULT NULL,
  `patient_admited_address` varchar(100) DEFAULT NULL,
  `patient_expected_date` date DEFAULT NULL,
  `assigned_donor` varchar(45) DEFAULT 'TBA',
  `assigned_donor_contact` varchar(45) DEFAULT 'TBA',
  PRIMARY KEY (`patient_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES ('41039.4978149306','Anirban Dutta','B- ',23,'9898789870','Barackpore','Barasat Hospital','2012-08-18','Atanu Dey','29878789'),('41039.8092890857','Krishna Halder','O+',34,'8987898909','New Town','Kalpatoru Hospital','2012-08-11','Kallal Das','26898765'),('41039.9834535185','Partha Nath','B-',55,'7898467464','Kali Ghat','R. G. Kar Hospital','2012-09-12','Ashit Paul','26989098'),('41041.8817986458','Soumen Nandy','B+',33,'9890948448','Koikhali','S. S. K. M.','2012-08-02','Puja Mandal','22790999'),('41043.3369835185','Sanjit Mukherjee','AB+',23,'8883938899','Madhyamgram','Neel Ratan Hospital','2012-08-02','TBA','TBA');
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `todo`
--

DROP TABLE IF EXISTS `todo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `todo` (
  `todo_id` varchar(45) NOT NULL,
  `todo_date` datetime NOT NULL,
  `todo_details` longtext NOT NULL,
  PRIMARY KEY (`todo_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `todo`
--

LOCK TABLES `todo` WRITE;
/*!40000 ALTER TABLE `todo` DISABLE KEYS */;
INSERT INTO `todo` VALUES ('41109.547465','2012-07-19 13:08:20','Inform Member  about the upcomming meeting');
/*!40000 ALTER TABLE `todo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `well_wisher`
--

DROP TABLE IF EXISTS `well_wisher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `well_wisher` (
  `well_wisher_id` varchar(45) NOT NULL,
  `well_wisher_name` varchar(30) NOT NULL,
  `well_wisher_address` varchar(100) DEFAULT NULL,
  `well_wisher_doj` date DEFAULT NULL,
  `well_wisher_contact` varchar(12) DEFAULT NULL,
  `well_wisher_remarks` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`well_wisher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `well_wisher`
--

LOCK TABLES `well_wisher` WRITE;
/*!40000 ALTER TABLE `well_wisher` DISABLE KEYS */;
INSERT INTO `well_wisher` VALUES ('41035.5799617014','Taposh Karmakar','Serampore','2012-05-10','8898987676','School Master'),('41035.7971773611','Sanjib Roy','Halisohor','2012-05-03','8987656765','M. P.'),('41035.799034375','Dr. Rafi Hoshen','Howrah','2009-02-02','9878765654','HOD of Physics in JU'),('41035.8024025','Palash Nag','Dumdum','2010-02-02','9992298787','MLA'),('41035.807467338','Kakali Mitra','Malda','2012-05-18','9078787644','Social Worker'),('41041.9725704167','Sougota Dey','Siliguri','2012-05-11','9890002277','Poet'),('41041.9966558333','Avik Saha','Dhakuriya','2012-05-06','8980272677','Writer'),('41042.0032547106','Litan Mondal','Birati','2012-06-02','9800776682','Poet'),('41042.6255937616','Dr. Suresh Baul','Sodpur','2012-05-19','9097778287','Writer'),('41043.3389371991','Delip Satra','Madhyamgram','2012-05-06','9835656777','HM,');
/*!40000 ALTER TABLE `well_wisher` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-07-20  9:02:02
