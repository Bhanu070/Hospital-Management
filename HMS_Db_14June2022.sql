USE [master]
GO
/****** Object:  Database [Hospital_Management]    Script Date: 6/14/2022 10:40:51 AM ******/
CREATE DATABASE [Hospital_Management] ON  PRIMARY 
( NAME = N'Hospital_Management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Hospital_Management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hospital_Management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Hospital_Management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hospital_Management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hospital_Management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hospital_Management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hospital_Management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hospital_Management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hospital_Management] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hospital_Management] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hospital_Management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hospital_Management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hospital_Management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hospital_Management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hospital_Management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hospital_Management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hospital_Management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hospital_Management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hospital_Management] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Hospital_Management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hospital_Management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hospital_Management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hospital_Management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hospital_Management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hospital_Management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hospital_Management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hospital_Management] SET RECOVERY FULL 
GO
ALTER DATABASE [Hospital_Management] SET  MULTI_USER 
GO
ALTER DATABASE [Hospital_Management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hospital_Management] SET DB_CHAINING OFF 
GO
USE [Hospital_Management]
GO
/****** Object:  Table [dbo].[Doctor_Master]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor_Master](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[Doc_Id] [uniqueidentifier] NULL,
	[Doc_Name] [nvarchar](500) NULL,
	[QualificationID] [uniqueidentifier] NULL,
	[Qualification] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctor_Master_Log]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor_Master_Log](
	[Code] [int] NULL,
	[Doc_Id] [uniqueidentifier] NULL,
	[Doc_Name] [nvarchar](500) NULL,
	[QualificationID] [uniqueidentifier] NULL,
	[Qualification] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPD_Admission_Slip]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPD_Admission_Slip](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[AdmissionId] [uniqueidentifier] NOT NULL,
	[Patient_id] [uniqueidentifier] NULL,
	[Registration_Type] [nvarchar](500) NULL,
	[OPD_RegistrationId] [uniqueidentifier] NULL,
	[IPD_No] [nvarchar](50) NULL,
	[Consultant_Name] [nvarchar](500) NULL,
	[ReferredBy] [nvarchar](500) NULL,
	[WardName] [nvarchar](500) NULL,
	[RoomName] [nvarchar](500) NULL,
	[BedNo] [int] NULL,
	[AC_Normal] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL,
	[Ipd_Reg_Date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdmissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPD_Admission_Slip_log]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPD_Admission_Slip_log](
	[Code] [int] NOT NULL,
	[AdmissionId] [uniqueidentifier] NOT NULL,
	[Patient_id] [uniqueidentifier] NULL,
	[Registration_Type] [nvarchar](500) NULL,
	[OPD_RegistrationId] [uniqueidentifier] NULL,
	[IPD_No] [nvarchar](50) NULL,
	[Consultant_Name] [nvarchar](500) NULL,
	[ReferredBy] [nvarchar](500) NULL,
	[WardName] [nvarchar](500) NULL,
	[RoomName] [nvarchar](500) NULL,
	[BedNo] [int] NULL,
	[AC_Normal] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL,
	[Ipd_Reg_Date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IPD_Main_Details]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPD_Main_Details](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[MainId] [uniqueidentifier] NOT NULL,
	[AdmissionId] [uniqueidentifier] NULL,
	[Patient_Id] [uniqueidentifier] NULL,
	[Doc_Id] [uniqueidentifier] NULL,
	[Payment_Mode] [nvarchar](50) NULL,
	[Admission_Date] [datetime] NULL,
	[Discharge_Date] [datetime] NULL,
	[Bill_No] [nvarchar](1000) NULL,
	[Service_type] [nvarchar](500) NULL,
	[Total_amount] [decimal](18, 2) NULL,
	[Total_deduction] [decimal](18, 2) NULL,
	[Advance] [decimal](18, 2) NULL,
	[Gross_total_amount] [decimal](18, 2) NULL,
	[Additonal_discount] [decimal](18, 2) NULL,
	[TCS] [decimal](18, 2) NULL,
	[Net_total_amount] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NULL,
	[UserPic] [nvarchar](150) NULL,
	[UserLanguage] [nvarchar](150) NULL,
	[Role] [nvarchar](150) NULL,
	[DOB] [nvarchar](150) NULL,
	[Country] [nvarchar](150) NULL,
	[State] [nvarchar](150) NULL,
	[City] [nvarchar](150) NULL,
	[LastLogin] [nvarchar](150) NULL,
	[IPAddress] [nvarchar](150) NULL,
	[Extra1] [nvarchar](150) NULL,
	[Extra2] [nvarchar](150) NULL,
	[Extra3] [nvarchar](150) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pathology_OPD_Main_Details]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pathology_OPD_Main_Details](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[MainId] [uniqueidentifier] NOT NULL,
	[Patient_Id] [uniqueidentifier] NULL,
	[Doc_Id] [uniqueidentifier] NULL,
	[Payment_Mode] [nvarchar](50) NULL,
	[Reciept_Date] [datetime] NULL,
	[OP_No] [nvarchar](1000) NULL,
	[Service_type] [nvarchar](500) NULL,
	[Total_amount] [decimal](18, 2) NULL,
	[Total_deduction] [decimal](18, 2) NULL,
	[Gross_total_amount] [decimal](18, 2) NULL,
	[Additonal_discount] [decimal](18, 2) NULL,
	[Net_total_amount] [decimal](18, 2) NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient_Master]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient_Master](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[Patient_Id] [uniqueidentifier] NOT NULL,
	[Patient_Name] [nvarchar](500) NULL,
	[Patient_UID] [nvarchar](500) NULL,
	[Age] [int] NULL,
	[Sex] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Patient_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient_Master_log]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient_Master_log](
	[Code] [int] NOT NULL,
	[Patient_Id] [uniqueidentifier] NOT NULL,
	[Patient_Name] [nvarchar](500) NULL,
	[Patient_UID] [nvarchar](500) NULL,
	[Age] [int] NULL,
	[Sex] [nvarchar](100) NULL,
	[MobileNo] [nvarchar](20) NULL,
	[Address] [nvarchar](250) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [varchar](250) NULL,
	[AddRecord] [varchar](250) NULL,
	[UpdateRecord] [varchar](250) NULL,
	[DeleteRecord] [varchar](250) NULL,
	[ExtraColumn] [varchar](250) NULL,
	[Status] [varchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Permission.] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_type_Master]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_type_Master](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [uniqueidentifier] NOT NULL,
	[ServiceName] [nvarchar](500) NULL,
	[ServiceType] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_type_Master_log]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_type_Master_log](
	[Code] [int] NULL,
	[ServiceId] [uniqueidentifier] NULL,
	[ServiceName] [nvarchar](500) NULL,
	[ServiceType] [nvarchar](500) NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_type_SubDetails]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_type_SubDetails](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [uniqueidentifier] NULL,
	[MainId] [uniqueidentifier] NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Unit] [int] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_type_SubDetails_temp]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_type_SubDetails_temp](
	[Code] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [uniqueidentifier] NULL,
	[MainId] [uniqueidentifier] NULL,
	[Price] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 2) NULL,
	[Unit] [int] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime] NULL,
	[Status] [nvarchar](500) NULL,
	[extra] [nvarchar](500) NULL,
	[extra1] [nvarchar](500) NULL,
	[extra2] [nvarchar](500) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doctor_Master] ON 
GO
INSERT [dbo].[Doctor_Master] ([Code], [Doc_Id], [Doc_Name], [QualificationID], [Qualification], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (1, N'1c59b1f0-5a5f-4a0f-93b3-23f61b100fc6', N'Ankush', N'c1144928-9da2-4a5a-8b62-51dfb38a9e53', N'MBBS', N'HR', CAST(N'2022-05-24T13:26:47.640' AS DateTime), N'HR', NULL, N'Active')
GO
INSERT [dbo].[Doctor_Master] ([Code], [Doc_Id], [Doc_Name], [QualificationID], [Qualification], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (2, N'f82d7266-fce4-434e-baeb-376e1ac485ff', N'Mohit', N'62963aab-3949-440f-a682-7f509ef6a5ab', N'MBBSa', N'Admin', CAST(N'2022-05-24T13:43:22.880' AS DateTime), N'Admin', CAST(N'2022-05-24T13:43:31.827' AS DateTime), N'Active')
GO
INSERT [dbo].[Doctor_Master] ([Code], [Doc_Id], [Doc_Name], [QualificationID], [Qualification], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (3, N'58143ee4-9e8c-47dc-b7bb-be3194f7ae5c', N'AMit', N'3372c07b-4835-4816-9677-ce74960903eb', N'MBBS', N'Admin', CAST(N'2022-05-26T18:07:50.970' AS DateTime), N'Admin', NULL, N'Active')
GO
SET IDENTITY_INSERT [dbo].[Doctor_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Login] ON 
GO
INSERT [dbo].[Login] ([Id], [Code], [UserName], [Password], [Email], [MobileNo], [Address], [UserPic], [UserLanguage], [Role], [DOB], [Country], [State], [City], [LastLogin], [IPAddress], [Extra1], [Extra2], [Extra3], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'7d88890e-1a29-431a-bdcc-4ce2dd969f35', 191, N'Operator2', N'MTIz', N'Operator2', N'7906691751', N'AA', N'../UserImage/DSC_0249.JPG', N'AA', N'Operator', N'Mr', N'57286ade-dc44-47fe-9d8f-d6ef437cb530', N'156AA3CD-8A23-45D0-B4AD-B026E7A7B65A', N'248002', N'd370785f-d84e-4d62-9d04-0095c1b2431b', N'5f056a2e-e249-49a9-bc1e-3ee25ed764a4', N'Approve', N'14-09-2021', N'A', N'Updated', CAST(N'2021-12-24T11:34:10.973' AS DateTime), N'Admin', CAST(N'2021-09-14T13:57:19.960' AS DateTime))
GO
INSERT [dbo].[Login] ([Id], [Code], [UserName], [Password], [Email], [MobileNo], [Address], [UserPic], [UserLanguage], [Role], [DOB], [Country], [State], [City], [LastLogin], [IPAddress], [Extra1], [Extra2], [Extra3], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'582b2161-1634-4d3a-be94-545cd559e0d0', 189, N'Operator1', N'MTIz', N'Operator1', N'9917319282', N'AA', N'../UserImage/DSC_0249.JPG', N'AA', N'Operator', N'Mr', N'57286ade-dc44-47fe-9d8f-d6ef437cb530', N'156AA3CD-8A23-45D0-B4AD-B026E7A7B65A', N'248002', N'd370785f-d84e-4d62-9d04-0095c1b2431b', N'5f056a2e-e249-49a9-bc1e-3ee25ed764a4', N'Approve', N'14-09-2021', N'A', N'Updated', CAST(N'2021-12-24T11:34:10.973' AS DateTime), N'Admin', CAST(N'2021-09-14T13:57:19.960' AS DateTime))
GO
INSERT [dbo].[Login] ([Id], [Code], [UserName], [Password], [Email], [MobileNo], [Address], [UserPic], [UserLanguage], [Role], [DOB], [Country], [State], [City], [LastLogin], [IPAddress], [Extra1], [Extra2], [Extra3], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 100, N'Admin', N'MTIz', N'admin@gmail.com', N'9410143186', N'AA', N'../UserImage/DSC_0249.JPG', N'AA', N'Admin', N'Mr', N'57286ade-dc44-47fe-9d8f-d6ef437cb530', N'156AA3CD-8A23-45D0-B4AD-B026E7A7B65A', N'248002', N'd370785f-d84e-4d62-9d04-0095c1b2431b', N'5f056a2e-e249-49a9-bc1e-3ee25ed764a4', N'Approve', N'14-09-2021', N'A', N'Updated', CAST(N'2021-12-24T11:34:10.973' AS DateTime), N'Admin', CAST(N'2021-09-14T13:57:19.960' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Login] OFF
GO
SET IDENTITY_INSERT [dbo].[Pathology_OPD_Main_Details] ON 
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (10, N'0dc65eb3-938b-414e-9e85-02d5b0758a54', N'93db7607-30ac-4fbe-be3c-836ac8e111ad', N'f82d7266-fce4-434e-baeb-376e1ac485ff', N'Cash', CAST(N'2022-05-26T18:11:04.813' AS DateTime), N'2022050000010', N'OPD', CAST(1000.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(960.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(860.00 AS Decimal(18, 2)), N'Pending amojunt', N'Admin', CAST(N'2022-05-26T18:10:23.337' AS DateTime), N'Admin', CAST(N'2022-05-26T18:11:04.843' AS DateTime), N'Complete', N'extra', N'extra1', N'extra2')
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (13, N'77fc90eb-be37-45ab-bb45-1087eee6b5a4', N'93db7607-30ac-4fbe-be3c-836ac8e111ad', N'1c59b1f0-5a5f-4a0f-93b3-23f61b100fc6', N'Debit Card', CAST(N'2022-06-13T17:57:17.503' AS DateTime), N'202206000013', N'OPD', CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(390.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(380.00 AS Decimal(18, 2)), N'45', N'Admin', CAST(N'2022-06-13T17:57:17.507' AS DateTime), N'Admin', CAST(N'2022-06-13T17:57:17.517' AS DateTime), N'Pending', N'100', N'extra1', N'extra2')
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (12, N'a1bbbf99-ca57-4148-b86b-7f20c1b00e4a', N'ee68ceb4-3bff-4d23-875f-690024200699', N'1c59b1f0-5a5f-4a0f-93b3-23f61b100fc6', N'Cash', CAST(N'2022-05-30T18:04:49.467' AS DateTime), N'202205000012', N'OPD', CAST(600.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(580.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(575.00 AS Decimal(18, 2)), N'6746', N'Admin', CAST(N'2022-05-30T18:04:49.470' AS DateTime), N'Admin', CAST(N'2022-05-30T18:04:49.483' AS DateTime), N'Pending', N'extra', N'extra1', N'extra2')
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (11, N'88243d26-0c7f-48be-8323-b1fb5c76879b', N'ee68ceb4-3bff-4d23-875f-690024200699', N'f82d7266-fce4-434e-baeb-376e1ac485ff', N'Cash', CAST(N'2022-06-13T18:18:30.430' AS DateTime), N'202205000011', N'OPD', NULL, NULL, NULL, CAST(56.00 AS Decimal(18, 2)), NULL, N'jhkghjk', N'Admin', CAST(N'2022-05-30T18:01:51.593' AS DateTime), N'Admin', CAST(N'2022-06-13T18:18:30.450' AS DateTime), N'Pending', N'200', N'extra1', N'extra2')
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (9, N'4d2f16c4-10d9-4da6-9a8c-bae028282b89', N'93db7607-30ac-4fbe-be3c-836ac8e111ad', N'f82d7266-fce4-434e-baeb-376e1ac485ff', N'Cash', CAST(N'2022-05-26T15:35:40.240' AS DateTime), N'202205000009', N'Pathology', CAST(1200.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(1160.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(1110.00 AS Decimal(18, 2)), N'dfgsfgs fghdfghdg', N'Admin', CAST(N'2022-05-26T15:33:28.230' AS DateTime), N'Admin', CAST(N'2022-05-26T15:35:40.260' AS DateTime), N'Complete', N'extra', N'extra1', N'extra2')
GO
INSERT [dbo].[Pathology_OPD_Main_Details] ([Code], [MainId], [Patient_Id], [Doc_Id], [Payment_Mode], [Reciept_Date], [OP_No], [Service_type], [Total_amount], [Total_deduction], [Gross_total_amount], [Additonal_discount], [Net_total_amount], [Remarks], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (8, N'52c9fd9a-57a8-413c-8079-e4a2671fe7dd', N'93db7607-30ac-4fbe-be3c-836ac8e111ad', N'1c59b1f0-5a5f-4a0f-93b3-23f61b100fc6', N'Debit Card', CAST(N'2022-05-26T15:46:59.683' AS DateTime), N'202205000001', N'OPD', CAST(1500.00 AS Decimal(18, 2)), CAST(60.00 AS Decimal(18, 2)), CAST(1440.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(1390.00 AS Decimal(18, 2)), N'352 gfdhdf', N'Admin', CAST(N'2022-05-26T15:30:04.120' AS DateTime), N'Admin', CAST(N'2022-05-26T15:46:59.713' AS DateTime), N'Pending', N'extra', N'extra1', N'extra2')
GO
SET IDENTITY_INSERT [dbo].[Pathology_OPD_Main_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient_Master] ON 
GO
INSERT [dbo].[Patient_Master] ([Code], [Patient_Id], [Patient_Name], [Patient_UID], [Age], [Sex], [MobileNo], [Address], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (2, N'dd4c543b-7ee1-4c61-b1be-26e126198a6d', N'Ankur', NULL, 45, N'Male', N'9865888798', N'Moradabad', N'Admin', CAST(N'2022-05-26T18:08:18.253' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Patient_Master] ([Code], [Patient_Id], [Patient_Name], [Patient_UID], [Age], [Sex], [MobileNo], [Address], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (4, N'ee68ceb4-3bff-4d23-875f-690024200699', N'ghfghdfgh', N'20220500004', 54, N'Male', N'4334634653', N'gfhdfgh', N'Admin', CAST(N'2022-05-26T18:37:21.597' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Patient_Master] ([Code], [Patient_Id], [Patient_Name], [Patient_UID], [Age], [Sex], [MobileNo], [Address], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (1, N'93db7607-30ac-4fbe-be3c-836ac8e111ad', N'Rohit', N'202205000001', 45, N'Male', N'7987987894', N'MBD', N'Admin', CAST(N'2022-05-24T14:06:51.600' AS DateTime), N'Admin', CAST(N'2022-05-24T14:53:32.060' AS DateTime), N'Active')
GO
INSERT [dbo].[Patient_Master] ([Code], [Patient_Id], [Patient_Name], [Patient_UID], [Age], [Sex], [MobileNo], [Address], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (3, N'd64324bb-3a62-4ba5-bfeb-a73549882c1d', N'ghfghdfgh', NULL, 54, N'Male', N'4334634653', N'gfhdfgh', N'Admin', CAST(N'2022-05-26T18:35:29.500' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Patient_Master] ([Code], [Patient_Id], [Patient_Name], [Patient_UID], [Age], [Sex], [MobileNo], [Address], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (5, N'878f841d-6dbc-405a-90f5-d6a2b27d59ab', N'deva', N'20220500005', 54, N'Male', N'4564346533', N'dfhgd', N'Admin', CAST(N'2022-05-26T18:37:41.263' AS DateTime), N'Admin', NULL, N'Active')
GO
SET IDENTITY_INSERT [dbo].[Patient_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'a377c2b6-2625-473a-9d0e-07a09dc858db', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4971, N'Employee Designation', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.040' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.040' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'689108be-a645-4c1b-823a-09453ebbe290', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4972, N'Receipts', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.120' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.120' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'2f0db50b-5f67-4caf-8d1a-09f8f91eb9f5', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5862, N'Court Case', N'off', N'on', N'on', N'off', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'887fd066-e9f3-4785-9e3d-0dd82cd53ae7', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4973, N'Designation Board', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.033' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.033' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'ed5e7797-9ee6-49ab-8189-170cfab9059f', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4974, N'UID', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.017' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.017' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'0d8e4fa3-7227-447a-afa8-209c4eedcf08', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4975, N'State Recived Fund Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.113' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.113' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'd10c9844-2331-4c41-b571-2266cf1715f2', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4976, N'Allowance', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.073' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.073' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'3b4916ad-d27c-4ba5-bca0-32ae49903c85', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4977, N'BloodGroup', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.053' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.053' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'8a280b82-e3dc-457c-bbc6-3668a902b3b2', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4978, N'Budget', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.080' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.080' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'56213a57-aab9-4f2a-b8fa-455af91f6510', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4979, N'Board Exp Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.090' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.090' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'15fb64af-7154-41c6-ae43-45691396c3c5', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4980, N'Master', N'', N'', N'', N'off', N'', N'Admin', CAST(N'2021-10-07T13:33:54.000' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.000' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'969041ce-2b3d-4699-8b9e-49b7525115b1', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4981, N'Waqf Registration Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.067' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.067' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'5919122d-5974-46fe-8701-4ed66ae5ddb9', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4982, N'Center Scheme Recived Fund Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.107' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.107' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'6083c166-2c68-4ddf-ab11-505a1aba68e5', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4983, N'MenuMaster', N'off', N'off', N'off', N'off', N'', N'Admin', CAST(N'2021-10-07T13:33:54.003' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.003' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'e8a4a2c9-903c-4688-902d-56c953035efc', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5625, N'WaqfComplaint', N'off', N'off', N'off', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.050' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.050' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'93ce5fc2-979d-4025-b0b9-6206ee1c36bb', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4984, N'Center Scheme', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.083' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.083' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'99f252f0-3bba-4d61-8146-64347a34fb08', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4985, N'Reports', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.023' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.023' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'989c6f28-8621-4ccc-8baf-69c4a20f580f', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4986, N'Contributation Receipt', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.130' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.130' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'c0377adf-8ad9-4acc-bcc8-6ad655cec6ef', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5626, N'WaqfEncrochment', N'off', N'off', N'off', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.053' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.053' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'ba50d877-49fd-45b5-b17b-789937c67253', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4987, N'State Demand', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.080' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.080' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'8cdfd6e7-8305-48db-9e20-7a27c5084f04', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4988, N'State Fund Allotment Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.113' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.113' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'1b1e9742-e7f0-488c-bda5-7e06ef2e51f0', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4989, N'Cadre', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.040' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.040' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'0447de28-f54b-4523-bace-7ef7cd095b07', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4990, N'Grade', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.027' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.027' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'7cdeb308-0abe-47ab-a880-830e89358ae2', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4991, N'Receipt Application Status Accountant', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.107' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.107' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'ab96c02a-b102-4cbb-9570-84d05a1be9d8', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4992, N'Board Income Sub Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.103' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.103' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'9d165edc-d32d-4c10-935d-8ed33e45f3c9', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4993, N'Receipt Application Status CEO', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.060' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.060' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'abc0643f-b7b8-4d67-966a-91ff0c20d5ec', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4994, N'Emp Allowence', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.047' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.047' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'd3eec5e3-5649-4fe8-9960-92e97f00e9d0', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4995, N'District', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:53.997' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:53.997' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'3bfc0668-23c0-42f9-a39a-970d1b58c118', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4996, N'Emp Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.047' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.047' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'84a6d1ef-ce4b-4f6b-8070-9bec9ddcbba4', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4997, N'Area Type', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.020' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.020' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'390e1b52-65f0-436d-8bbf-9c6aa896d1d8', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4998, N'State', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.007' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.007' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'8cb43b65-b750-4fcc-a5a6-9dd600f1d508', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 4999, N'HR', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.087' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.087' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'7c673769-a5a7-4265-92fa-a381c2858e50', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5861, N'Laywer Master', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'630e7f12-bbf2-45be-aa28-a5a894e29c44', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5000, N'Copy Receipt', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.133' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.133' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'aff25703-b47a-4cc2-8842-a6696b101e21', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5001, N'Board Income Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.100' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.100' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'5512cfc9-9c4d-4eb5-bf33-a6a25cc04bad', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5002, N'State Grant', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.100' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.100' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'e66a35b5-0658-47c7-b16e-a6f2ec587810', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5003, N'Inspection Receipt', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.130' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.130' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'0bde8fa2-0c54-4e4e-b90e-a77e71d87c13', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5004, N'Deduction', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.073' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.073' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'31d50322-9e17-4898-b753-abcf8888096f', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5005, N'Board Fund Provision Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.120' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.120' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'6d8f4e76-5ba0-4c1b-a58c-acf862c968f1', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5006, N'MenuCategory', N'off', N'off', N'off', N'off', N'', N'Admin', CAST(N'2021-10-07T13:33:54.003' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.003' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'74a399ff-2238-4bb1-971b-b055ddcc81b7', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5007, N'Matrial Status', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.013' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.013' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'de3fbb33-e583-4fb3-9e5b-b1d8a34b5ce7', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5008, N'Waqf Registration', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.063' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.063' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'6a781e5f-671b-4aa0-bf5a-b9e42bdecbcd', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5009, N'Center Scheme Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.090' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.090' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'6aebb479-b9b6-42e6-b120-be7f593ff041', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5010, N'Payroll', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.070' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.070' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'762a17b0-fe4e-46e5-a4c8-c018673e3b17', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5011, N'RTI Application', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.060' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.060' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'13675aaa-03f2-4688-aa69-c2c0aa42f0f9', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5012, N'Center Scheme Fund Allotment Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.110' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.110' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'10d2d5ee-6d29-4fe7-8239-c4b23bf1a827', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5858, N'Court Case Master', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'dcc51c9b-520a-40e3-9c7c-c5f76bf4d035', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5013, N'Sub District', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.010' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.010' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'2c0331f2-dc3b-48a1-97f9-c7218be2fa9b', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5014, N'Salary Type', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.043' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.043' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'c78fa151-228f-4fde-9ccc-c7e4a9291f20', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5935, N'Court Cases', N'off', N'on', N'on', N'off', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'6a96a183-1796-43bb-83fd-c9464a2d6bbf', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5859, N'Court Type', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'd50bb98d-ce70-4919-91e2-d1a864b7c341', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5015, N'Caste', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.020' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.020' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'fee2c925-e9c0-4760-ac5a-d29e6c2a5f01', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5121, N'MC_Income_Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.067' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.067' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'9f5ab890-9fc3-4b53-8272-d4840ee4d6b7', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5016, N'Source Master', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.097' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.097' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'21d98a00-031e-4132-91bf-db810093613a', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5017, N'Add User', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.030' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.030' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'fbb1ec89-087a-4328-a17f-dd7a281256f4', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5018, N'Registration Receipt', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.123' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.123' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'28f9e85a-f55a-4436-beed-de5c3f937622', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5019, N'User Management', N'', N'', N'', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.027' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.027' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'8b02ab8e-e2e5-49f8-bde3-e05b2f1dc253', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5020, N'Qualification', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.037' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.037' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'55a3b60f-7aa8-4d15-90c2-e548b28f40b1', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5021, N'RTI Application PIO', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.057' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.057' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'f81f5788-a2a1-49d5-a072-e69150407d6d', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5022, N'Board Exp Sub Head', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.093' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.093' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'0b1aef47-92ee-4ff5-a6ac-e6e1f67a15df', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5023, N'Branch Name', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.127' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.127' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'cc0be03a-3f92-4cec-9b95-eebd68b8b165', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5024, N'Emp Allowence and Deduction', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.077' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.077' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'b436a09a-fc66-4d93-97f5-f7458ae5a700', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5025, N'Religion', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.000' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.000' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'fc6d24b8-c7ed-4903-93f6-f83130fa6abe', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5026, N'Bank Name', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.013' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.013' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'338c6469-89cf-4bb6-95e9-fcec8ad52637', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5027, N'Office Master', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.033' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.033' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'29aee3ed-cc67-4425-9321-fd3608f2500f', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5028, N'Gender', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.010' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.010' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'0612fc3a-a097-4b13-8fc1-fd3f14b3818c', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5029, N'Receipt Application Status', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.137' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.137' AS DateTime))
GO
INSERT [dbo].[Permission] ([Id], [UserId], [Code], [MenuName], [AddRecord], [UpdateRecord], [DeleteRecord], [ExtraColumn], [Status], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn]) VALUES (N'8c08535a-f6ee-46f4-9609-fdafc72df41c', N'04d5d515-4f6f-41aa-9b63-ecf1118164aa', 5030, N'Board Fund Allotment Details', N'on', N'on', N'on', N'on', N'', N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime), N'Admin', CAST(N'2021-10-07T13:33:54.117' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[Service_type_Master] ON 
GO
INSERT [dbo].[Service_type_Master] ([Code], [ServiceId], [ServiceName], [ServiceType], [Price], [Discount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (1, N'ab287b01-9373-4675-9ace-2dab1af46c04', N'XRay', N'OPD', CAST(500.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-24T14:08:45.943' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Service_type_Master] ([Code], [ServiceId], [ServiceName], [ServiceType], [Price], [Discount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (2, N'7bdb2680-dbba-4019-b87b-475018299422', N'ECG', N'OPD', CAST(200.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-24T16:03:44.457' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Service_type_Master] ([Code], [ServiceId], [ServiceName], [ServiceType], [Price], [Discount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (4, N'0fc4c511-b4e9-45c2-8699-b58a7ca2b47d', N'OPd service 1', N'OPD', CAST(400.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-26T18:09:04.190' AS DateTime), N'Admin', NULL, N'Active')
GO
INSERT [dbo].[Service_type_Master] ([Code], [ServiceId], [ServiceName], [ServiceType], [Price], [Discount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status]) VALUES (3, N'573b650d-e693-48df-a58d-ef97c228046d', N'Pathalogy Test1', N'Pathology', CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-26T15:11:11.137' AS DateTime), N'Admin', NULL, N'Active')
GO
SET IDENTITY_INSERT [dbo].[Service_type_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Service_type_SubDetails] ON 
GO
INSERT [dbo].[Service_type_SubDetails] ([Code], [ServiceId], [MainId], [Price], [Discount], [Unit], [PaidAmount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (17, N'ab287b01-9373-4675-9ace-2dab1af46c04', N'52c9fd9a-57a8-413c-8079-e4a2671fe7dd', CAST(500.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 3, CAST(400.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-26T15:46:59.700' AS DateTime), N'Admin', CAST(N'2022-05-26T15:46:59.700' AS DateTime), N'status', N'', N'', N'')
GO
INSERT [dbo].[Service_type_SubDetails] ([Code], [ServiceId], [MainId], [Price], [Discount], [Unit], [PaidAmount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (20, N'573b650d-e693-48df-a58d-ef97c228046d', N'a1bbbf99-ca57-4148-b86b-7f20c1b00e4a', CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 2, CAST(100.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-30T18:04:49.483' AS DateTime), N'Admin', CAST(N'2022-05-30T18:04:49.483' AS DateTime), N'status', N'', N'', N'')
GO
INSERT [dbo].[Service_type_SubDetails] ([Code], [ServiceId], [MainId], [Price], [Discount], [Unit], [PaidAmount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (21, N'573b650d-e693-48df-a58d-ef97c228046d', N'77fc90eb-be37-45ab-bb45-1087eee6b5a4', CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 1, CAST(250.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-06-13T17:57:17.517' AS DateTime), N'Admin', CAST(N'2022-06-13T17:57:17.517' AS DateTime), N'status', N'', N'', N'')
GO
INSERT [dbo].[Service_type_SubDetails] ([Code], [ServiceId], [MainId], [Price], [Discount], [Unit], [PaidAmount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (19, N'ab287b01-9373-4675-9ace-2dab1af46c04', N'0dc65eb3-938b-414e-9e85-02d5b0758a54', CAST(500.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 2, CAST(1000.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-26T18:11:04.837' AS DateTime), N'Admin', CAST(N'2022-05-26T18:11:04.837' AS DateTime), N'status', N'', N'', N'')
GO
INSERT [dbo].[Service_type_SubDetails] ([Code], [ServiceId], [MainId], [Price], [Discount], [Unit], [PaidAmount], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [Status], [extra], [extra1], [extra2]) VALUES (16, N'573b650d-e693-48df-a58d-ef97c228046d', N'4d2f16c4-10d9-4da6-9a8c-bae028282b89', CAST(300.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), 4, CAST(500.00 AS Decimal(18, 2)), N'Admin', CAST(N'2022-05-26T15:35:40.250' AS DateTime), N'Admin', CAST(N'2022-05-26T15:35:40.250' AS DateTime), N'status', N'', N'', N'')
GO
SET IDENTITY_INSERT [dbo].[Service_type_SubDetails] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Login__A9D105342E40852E]    Script Date: 6/14/2022 10:40:51 AM ******/
ALTER TABLE [dbo].[Login] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Doctor_Master_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[Doctor_Master_Delete]
@Doc_Id uniqueidentifier

as
begin
 insert into Doctor_Master_Log  select * from Doctor_Master  where Doc_Id=@Doc_Id
 Delete from Doctor_Master where Doc_Id=@Doc_Id
end
GO
/****** Object:  StoredProcedure [dbo].[Doctor_Master_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





create proc [dbo].[Doctor_Master_GetAll]
as
begin
select Code ,Doc_Id , Doc_Name,QualificationID,
Qualification,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,
Status from Doctor_Master
end
GO
/****** Object:  StoredProcedure [dbo].[Doctor_Master_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Doctor_Master_GetById]
@Doc_Id uniqueidentifier
as
begin
select Code ,Doc_Id , Doc_Name,QualificationID,
Qualification,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,
Status from Doctor_Master where Doc_Id=@Doc_Id
end

GO
/****** Object:  StoredProcedure [dbo].[Doctor_Master_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Doctor_Master_Insert]
@Doc_Id uniqueidentifier,@Doc_Name nvarchar(500),@Qualification nvarchar(500),@CreatedBy nvarchar(500),@UpdatedBy nvarchar(500)

as
begin
Insert into Doctor_Master values (@Doc_Id,@Doc_Name,newid(),@Qualification,@CreatedBy,getdate(),@UpdatedBy,null,'Active')

end
GO
/****** Object:  StoredProcedure [dbo].[Doctor_Master_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[Doctor_Master_Update]
@Doc_Id uniqueidentifier,@Doc_Name nvarchar(500),@Qualification nvarchar(500),@CreatedBy nvarchar(500),@UpdatedBy nvarchar(500)

as
begin
update Doctor_Master set Doc_Name =@Doc_Name  ,Qualification=@Qualification,UpdatedBy=@UpdatedBy ,UpdatedOn=getdate() where Doc_Id=@Doc_Id

end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Admission_Slip_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IPD_Admission_Slip_Delete]
@Id uniqueidentifier
as
begin

insert into IPD_Admission_Slip_log
select * from IPD_Admission_Slip where AdmissionId=@id

delete from  IPD_Admission_Slip where AdmissionId=@id

end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Admission_Slip_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE proc [dbo].[IPD_Admission_Slip_GetAll]
as
begin

SELECT I.[Code]
      ,I.[AdmissionId]
      ,I.[Patient_id]
      ,I.[Registration_Type]
      ,I.[OPD_RegistrationId]
      ,I.[IPD_No]
      ,I.[Consultant_Name]
      ,I.[ReferredBy]
      ,I.[WardName]
      ,I.[RoomName]
      ,I.[BedNo]
      ,I.[AC_Normal]
      ,I.[CreatedBy]
      ,I.[CreatedOn]
      ,I.[UpdatedBy]
      ,I.[UpdatedOn]
      ,I.[Status]
      ,I.[extra]
      ,I.[extra1]
      ,I.[extra2],I.Ipd_Reg_Date,P.Patient_Name,P.Patient_UID,O.OP_No
  FROM [dbo].[IPD_Admission_Slip] I
  inner join Patient_Master P on I.Patient_id=P.Patient_Id
  inner join Pathology_OPD_Main_Details O on I.OPD_RegistrationId=o.MainId

end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Admission_Slip_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IPD_Admission_Slip_GetById]
@Id uniqueidentifier
as
begin

select * from IPD_Admission_Slip where AdmissionId=@id

end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Admission_Slip_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[IPD_Admission_Slip_Insert]
	@AdmissionId uniqueidentifier ,@Patient_id uniqueidentifier,@Registration_Type nvarchar(500),@OPD_RegistrationId uniqueidentifier,
@Consultant_Name nvarchar(500)= null,@ReferredBy nvarchar(500)= null,@WardName nvarchar(500),@RoomName nvarchar(500),@BedNo int, @AC_Normal nvarchar(500),@CreatedBy [nvarchar](500) NULL,
	 @CreatedOn   datetime  NULL,
	 @UpdatedBy   nvarchar (500) NULL,
	 @UpdatedOn   datetime  NULL,
	 @Status   nvarchar (500) NULL,
	 @extra   nvarchar (500) NULL,
	 @extra1   nvarchar (500) NULL,
	 @extra2   nvarchar (500) NULL,@Ipd_Reg_Date datetime

	 as
	  begin

	  
declare @MaxCode int,@OPD nvarchar (50)
if exists(select * from IPD_Admission_Slip )
begin
select @MaxCode=max(Code) from IPD_Admission_Slip
if (@MaxCode <10)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00000' +  convert(nvarchar, @MaxCode)
end
else if (@MaxCode <100)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0000' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <1000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <10000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <100000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <1000000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2)  + convert(nvarchar, @MaxCode)
end
end
else
begin
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000001'

end


INSERT INTO [dbo].[IPD_Admission_Slip]
           ([AdmissionId]
           ,[Patient_id]
           ,[Registration_Type]
           ,[OPD_RegistrationId]
           ,[IPD_No]
           ,[Consultant_Name]
           ,[ReferredBy]
           ,[WardName]
           ,[RoomName]
           ,[BedNo]
           ,[AC_Normal]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdatedBy]
           ,[UpdatedOn]
           ,[Status]
           ,[extra]
           ,[extra1]
           ,[extra2],Ipd_Reg_Date)
     VALUES
           (@AdmissionId
           ,@Patient_id
           , @Registration_Type
           , @OPD_RegistrationId
           , @OPD
           , @Consultant_Name
           , @ReferredBy
           , @WardName 
           , @RoomName 
           , @BedNo 
           , @AC_Normal 
           , @CreatedBy
           , getdate()
           , null 
           , null
           , 'Completed'
           , @extra
           , @extra1
           , @extra2,@Ipd_Reg_Date )
 
INSERT INTO [dbo].[IPD_Main_Details]
           ([MainId]
           ,[AdmissionId]
           ,[Patient_Id]
           ,[Doc_Id]
           ,[Payment_Mode]
           ,[Admission_Date]
           ,[Discharge_Date]
           ,[Bill_No]
           ,[Service_type]
           ,[Total_amount]
           ,[Total_deduction]
           ,[Advance]
           ,[Gross_total_amount]
           ,[Additonal_discount]
           ,[TCS]
           ,[Net_total_amount]
           ,[Remarks]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdatedBy]
           ,[UpdatedOn]
           ,[Status]
           ,[extra]
           ,[extra1]
           ,[extra2])
     VALUES
           ( newid()
           ,@AdmissionId
           ,@Patient_id
           ,'00000000-0000-0000-0000-000000000000'
           ,null
           ,null
           ,null
           ,null
           ,@WardName
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null
           ,@CreatedBy
           ,getdate()
           ,null
           ,null
           ,null
           ,null
           ,null
           ,null)

		  
	  end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Admission_Slip_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


	CREATE proc [dbo].[IPD_Admission_Slip_Update]
	@AdmissionId uniqueidentifier ,@Patient_id uniqueidentifier,@Registration_Type nvarchar(500),@OPD_RegistrationId uniqueidentifier,
@Consultant_Name nvarchar(500)= null,@ReferredBy nvarchar(500)= null,@WardName nvarchar(500),@RoomName nvarchar(500),@BedNo int, @AC_Normal nvarchar(500),@CreatedBy [nvarchar](500) NULL,
	 @CreatedOn   datetime  NULL,
	 @UpdatedBy   nvarchar (500) NULL,
	 @UpdatedOn   datetime  NULL,
	 @Status   nvarchar (500) NULL,
	 @extra   nvarchar (500) NULL,
	 @extra1   nvarchar (500) NULL,
	 @extra2   nvarchar (500) NULL,@Ipd_Reg_Date datetime

	 as
	  begin

	 
	 Update IPD_Admission_Slip set Patient_id=@Patient_id,Registration_Type=@Registration_Type,OPD_RegistrationId=@OPD_RegistrationId,
	@Consultant_Name=Consultant_Name ,ReferredBy=@ReferredBy,WardName=@WardName,RoomName =@RoomName ,BedNo=@BedNo , AC_Normal=@AC_Normal,
	UpdatedOn=GETDATE(),UpdatedBy=@UpdatedBy,Ipd_Reg_Date=@Ipd_Reg_Date where AdmissionId=@AdmissionId
	  end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Main_Details_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	  create proc [dbo].[IPD_Main_Details_GetAll]
	  as
	  begin

	  SELECT I.*,P.Patient_Name,P.Patient_UID,D.Doc_Name,IAS.IPD_No
  FROM IPD_Main_Details I left join Patient_Master P on I.Patient_Id=p.Patient_Id  left join Doctor_Master D on I.Doc_Id=D.Doc_Id
  inner join IPD_Admission_Slip IAS on I.AdmissionId=IAS.AdmissionId

	  end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Main_Details_GetByID]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	  create proc [dbo].[IPD_Main_Details_GetByID]
	  @ID uniqueidentifier
	  as
	  begin

	  SELECT I.*,P.Patient_Name,P.Patient_UID,D.Doc_Name,IAS.IPD_No
  FROM IPD_Main_Details I left join Patient_Master P on I.Patient_Id=p.Patient_Id  left join Doctor_Master D on I.Doc_Id=D.Doc_Id
  inner join IPD_Admission_Slip IAS on I.AdmissionId=IAS.AdmissionId where MainId=@ID

	  end
GO
/****** Object:  StoredProcedure [dbo].[IPD_Main_Details_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[IPD_Main_Details_Update]
@MainId uniqueidentifier,@Patient_Id uniqueidentifier,@Doc_Id uniqueidentifier,@Payment_Mode nvarchar(50),@Admission_Date datetime
,@Additonal_discount decimal(18,2),@Discharge_Date Datetime,@Advance decimal(18,2),@TCS decimal(18,2),
@Remarks nvarchar(max)
,@UpdatedBy nvarchar(500)
,@extra nvarchar(500)=null,@extra1 nvarchar(500)=null,@extra2 nvarchar(500)=null
,@Status nvarchar(500)

as
begin

update IPD_Main_Details set Patient_Id=@Patient_Id,Doc_Id=@Doc_Id,
Payment_Mode=@Payment_Mode,Admission_Date=@Admission_Date,Discharge_Date = @Discharge_Date 
,Additonal_discount=@Additonal_discount, TCS=@TCS,
Remarks=@Remarks,UpdatedBy=@UpdatedBy,Status=@Status
,extra=@extra,extra1=@extra1,extra2=@extra2
where MainId=@MainId

end

GO
/****** Object:  StoredProcedure [dbo].[OPD_Receipt]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[OPD_Receipt] -- '0DC65EB3-938B-414E-9E85-02D5B0758A54'
@MainId uniqueidentifier
as
begin
declare @patientUId nvarchar(500),@patientMobile nvarchar(500),@PaidAmount nvarchar(500)
select @patientMobile=MobileNo,@patientUId=Patient_UID from Patient_Master where Patient_Id=(select Patient_Id  from Pathology_OPD_Main_Details where MainId=@MainId  )

select @PaidAmount=isnull(sum(PaidAmount),0) from Service_type_SubDetails where MainId =@MainId
select  main.[Code]
      ,main.[MainId]
      ,main.[Patient_Id]
      ,main.[Doc_Id]
      ,main.[Payment_Mode]
      ,main.[Reciept_Date]
      ,main.[OP_No]
      ,main.[Service_type]
      ,main.[Total_amount]
      ,main.[Total_deduction]
      ,main.[Gross_total_amount]
      ,main.[Additonal_discount]
      ,main.[Net_total_amount]
      ,main.[Remarks]
      ,main.[CreatedBy]
      ,main.[CreatedOn]
      ,main.[UpdatedBy]
      ,main.[UpdatedOn]
      ,main.[Status]
      ,[extra]
      ,@patientUId [extra1]
      ,@PaidAmount [extra2],
pm.Patient_Name,Patient_UID,Age,Sex,MobileNo,Address,pm.UpdatedBy,
dm.Doc_Name,dm.Qualification
from Pathology_OPD_Main_Details main inner join Patient_Master pm on main.Patient_Id=pm.Patient_Id
inner join Doctor_Master dm on main.Doc_Id=dm.Doc_Id
where MainId=@MainId   
 

select smsd.[Code]
      ,smsd.[ServiceId]
      ,[MainId]
      ,smsd.[Price]
      ,smsd.[Discount]
      ,[Unit]
      ,[PaidAmount]
      ,smsd.[CreatedBy]
      ,smsd.[CreatedOn]
      ,smsd.[UpdatedBy]
      ,smsd.[UpdatedOn]
      ,smsd.[Status]
      ,(smsd.Price * Unit )-(smsd.Discount * Unit) as extra
      ,[extra1]
      ,[extra2]
	  ,sm.ServiceType,sm.ServiceName 
from Service_type_SubDetails smsd inner join  Service_type_Master sm on smsd.ServiceId=sm.ServiceId
where MainId=@MainId

end
GO
/****** Object:  StoredProcedure [dbo].[Pathology_OPD_Main_Details_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Pathology_OPD_Main_Details_GetAll]

as
begin
SELECT PO.[Code]
      ,PO.[MainId]
      ,PO.[Patient_Id]
      ,PO.[Doc_Id]
      ,PO.[Payment_Mode]
      ,PO.[Reciept_Date]
      ,PO.[OP_No]
      ,PO.[Service_type]
      ,PO.[Total_amount]
      ,PO.[Total_deduction]
      ,PO.[Gross_total_amount]
      ,PO.[Additonal_discount]
      ,PO.[Net_total_amount]
      ,PO.[Remarks]
      ,PO.[CreatedBy]
      ,PO.[CreatedOn]
      ,PO.[UpdatedBy]
      ,PO.[UpdatedOn]
      ,PO.[Status]
      ,PO.[extra]
      ,PO.[extra1]
      ,PO.[extra2],P.Patient_Name,P.Patient_UID,D.Doc_Name
  FROM [dbo].[Pathology_OPD_Main_Details] PO inner join Patient_Master P on PO.Patient_Id=p.Patient_Id  inner join Doctor_Master D on Po.Doc_Id=D.Doc_Id

  end
GO
/****** Object:  StoredProcedure [dbo].[Pathology_OPD_Main_Details_GetAll_Pending]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Pathology_OPD_Main_Details_GetAll_Pending]
@status nvarchar (100)
as
begin
SELECT PO.[Code]
      ,PO.[MainId]
      ,PO.[Patient_Id]
      ,PO.[Doc_Id]
      ,PO.[Payment_Mode]
      ,PO.[Reciept_Date]
      ,PO.[OP_No]
      ,PO.[Service_type]
      ,PO.[Total_amount]
      ,PO.[Total_deduction]
      ,PO.[Gross_total_amount]
      ,PO.[Additonal_discount]
      ,PO.[Net_total_amount]
      ,PO.[Remarks]
      ,PO.[CreatedBy]
      ,PO.[CreatedOn]
      ,PO.[UpdatedBy]
      ,PO.[UpdatedOn]
      ,PO.[Status]
      ,PO.[extra]
      ,PO.[extra1]
      ,PO.[extra2],P.Patient_Name,P.Patient_UID,D.Doc_Name
  FROM [dbo].[Pathology_OPD_Main_Details] PO inner join Patient_Master P on PO.Patient_Id=p.Patient_Id  inner join Doctor_Master D on Po.Doc_Id=D.Doc_Id
  where PO.Status='Pending'
end
GO
/****** Object:  StoredProcedure [dbo].[Pathology_OPD_Main_Details_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select  * from Pathology_OPD_Main_Details

CREATE proc [dbo].[Pathology_OPD_Main_Details_GetById]
@Id uniqueidentifier
as
begin

declare @PaidAmount decimal(18,2)
select @PaidAmount= isnull(sum(PaidAmount ),0.00) from Service_type_SubDetails  where MainId =@Id 
select *,@PaidAmount as PaidAmount from Pathology_OPD_Main_Details where MainId=@id

end
GO
/****** Object:  StoredProcedure [dbo].[Pathology_OPD_Main_Details_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Pathology_OPD_Main_Details_Insert]
@MainId uniqueidentifier,@Patient_Id uniqueidentifier,@Doc_Id uniqueidentifier,@Payment_Mode nvarchar(50),@Reciept_Date datetime,@Service_type nvarchar(500),
@Total_amount decimal(18,2),@Total_deduction decimal(18,2),@Gross_total_amount  decimal(18,2),@Additonal_discount decimal(18,2),@Net_total_amount decimal(18,2),
@Remarks nvarchar(max),@CreatedBy nvarchar(500),@UpdatedBy nvarchar(500),@extra nvarchar(500)=null,@extra1 nvarchar(500)=null,@extra2 nvarchar(500)=null,@Status nvarchar(500) --extra opd charges
as
begin


declare @MaxCode int,@OPD nvarchar (50)
if exists(select * from Pathology_OPD_Main_Details )
begin
select @MaxCode=max(Code) from Pathology_OPD_Main_Details
if (@MaxCode <10)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00000' +  convert(nvarchar, @MaxCode)
end
else if (@MaxCode <100)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0000' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <1000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <10000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <100000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0' + convert(nvarchar, @MaxCode)
end
else if (@MaxCode <1000000)
begin
set @MaxCode= @MaxCode +1
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2)  + convert(nvarchar, @MaxCode)
end
end
else
begin
Set @OPD= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000001'

end



insert into Pathology_OPD_Main_Details values(@MainId ,@Patient_Id ,@Doc_Id ,@Payment_Mode
,@Reciept_Date, @OPD,@Service_type ,
@Total_amount ,@Total_deduction ,@Gross_total_amount  ,@Additonal_discount ,@Net_total_amount ,
@Remarks ,@CreatedBy,getdate() ,@UpdatedBy,getdate(),@Status ,@extra ,@extra1 ,@extra2 )

end
GO
/****** Object:  StoredProcedure [dbo].[Pathology_OPD_Main_Details_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Pathology_OPD_Main_Details_Update]
@MainId uniqueidentifier,@Patient_Id uniqueidentifier,@Doc_Id uniqueidentifier,@Payment_Mode nvarchar(50),@Reciept_Date datetime,
@Total_amount decimal(18,2),@Total_deduction decimal(18,2),@Gross_total_amount  decimal(18,2),@Additonal_discount decimal(18,2),@Net_total_amount decimal(18,2),
@Remarks nvarchar(max)
,@UpdatedBy nvarchar(500)
,@extra nvarchar(500)=null,@extra1 nvarchar(500)=null,@extra2 nvarchar(500)=null
,@Status nvarchar(500)

as
begin

update Pathology_OPD_Main_Details set Patient_Id=@Patient_Id,Doc_Id=@Doc_Id,
Payment_Mode=@Payment_Mode,Reciept_Date=@Reciept_Date
,Additonal_discount=@Additonal_discount,
Remarks=@Remarks,UpdatedBy=@UpdatedBy,Status=@Status
,extra=@extra,extra1=@extra1,extra2=@extra2
where MainId=@MainId

end
GO
/****** Object:  StoredProcedure [dbo].[Patient_Master_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Patient_Master_Delete]
@Patient_Id uniqueidentifier

as
begin

insert into Patient_Master_Log select * from Patient_Master where Patient_Id=@Patient_Id
delete from Patient_Master where Patient_Id=@Patient_Id
end
GO
/****** Object:  StoredProcedure [dbo].[Patient_Master_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Patient_Master_GetAll]

as
begin
select Code ,Patient_Id   , Patient_Name + ' - ' + Patient_UID as Patient_Name ,Patient_UID ,Age ,Sex ,MobileNo ,Address ,
CreatedBy ,CreatedOn ,UpdatedBy ,UpdatedOn ,
Status  from Patient_Master


end
GO
/****** Object:  StoredProcedure [dbo].[Patient_Master_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[Patient_Master_GetById]
@Patient_Id uniqueidentifier
as
begin
select Code ,Patient_Id   , Patient_Name ,Patient_UID ,Age ,Sex ,MobileNo ,Address ,
CreatedBy ,CreatedOn ,UpdatedBy ,UpdatedOn ,
Status  from Patient_Master  where Patient_Id=@Patient_Id


end
GO
/****** Object:  StoredProcedure [dbo].[Patient_Master_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[Patient_Master_Insert]
@Patient_Id uniqueidentifier, @Patient_Name nvarchar(500),@Patient_UID nvarchar(500)=null,@Age int,@Sex nvarchar(100),@MobileNo nvarchar(20),@Address nvarchar(250),
@CreatedBy nvarchar(500),@UpdatedBy nvarchar(500)

as
begin
declare @MaxCode bigint
if exists(select * from Patient_Master )
begin
select @MaxCode=max(code) from Patient_Master
if (@MaxCode <10)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00000' + @MaxCode
end
else if (@MaxCode <100)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0000' + @MaxCode
end
else if (@MaxCode <1000)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000' + @MaxCode
end
else if (@MaxCode <10000)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'00' + @MaxCode
end
else if (@MaxCode <100000)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'0' + @MaxCode
end
else if (@MaxCode <1000000)
begin
set @MaxCode= @MaxCode +1
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2)  + @MaxCode
end
end
else
begin
Set @Patient_UID= convert(nvarchar,year(getdate()))  + SUBSTRING(CONVERT(nvarchar(6),getdate(), 112),5,2) +'000001'

end

Insert into Patient_Master values(@Patient_Id,@Patient_Name,@Patient_UID,@Age,@Sex,@MobileNo,@Address,@CreatedBy,getdate(),@UpdatedBy,null,'Active')

end
GO
/****** Object:  StoredProcedure [dbo].[Patient_Master_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Patient_Master_Update]
@Patient_Id uniqueidentifier, @Patient_Name nvarchar(500),@Patient_UID nvarchar(500)=null,@Age int,@Sex nvarchar(100),@MobileNo nvarchar(20),@Address nvarchar(250),
@CreatedBy nvarchar(500),@UpdatedBy nvarchar(500)

as
begin

Update Patient_Master set Patient_Name= @Patient_Name,age=@age,sex=@sex,MobileNo =@MobileNo,Address =@Address,UpdatedBy=@UpdatedBy ,UpdatedOn =GETDATE()
where Patient_Id=@Patient_Id
end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[Service_type_Master_Delete]
 @ServiceId uniqueidentifier
as
begin

insert into Service_type_Master_log select * from Service_type_Master_log where ServiceId =@ServiceId
delete from Service_type_Master where ServiceId =@ServiceId
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[Service_type_Master_GetAll]
 @ServiceId uniqueidentifier
as
begin

select * from Service_type_Master
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetAll_All]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
     
   
create proc [dbo].[Service_type_Master_GetAll_All]
 
as
begin

select * from Service_type_Master
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetAll_Service]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
     
   
CREATE proc [dbo].[Service_type_Master_GetAll_Service]
 @ServiceType nvarchar(200)
as
begin

if @ServiceType='OPD'
begin
select *,0 as Unit,0.00 as PaidAmount from Service_type_Master where  servicetype in ('Pathology','Radiology','Miscellaneous') 
end
else
begin
select *,0 as Unit,0.00 as PaidAmount from Service_type_Master where servicetype=@ServiceType
end
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetAll_Service_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
     
   
CREATE proc [dbo].[Service_type_Master_GetAll_Service_GetById]
 @ServiceType nvarchar(200),@Id uniqueidentifier
as
begin

if @ServiceType='OPD'
begin
select s.code,s.ServiceId,sm.ServiceName ,@ServiceType as ServiceType,sm.Price,sm.Discount,
sm.CreatedBy,sm.CreatedOn,sm.UpdatedBy,sm.UpdatedOn,sm.Status,s.unit,s.PaidAmount from Service_type_SubDetails s inner join Service_type_Master sm on s.ServiceId=sm.ServiceId  where s.MainId= @Id 
union
select *,0 as Unit,0.00 as PaidAmount from Service_type_Master where servicetype in ('Pathology','Radiology','Miscellaneous') and ServiceId not in (select ServiceId from Service_type_SubDetails where MainId =@Id )
end
else 
begin
select s.code,s.ServiceId,sm.ServiceName ,@ServiceType as ServiceType,sm.Price,sm.Discount,
sm.CreatedBy,sm.CreatedOn,sm.UpdatedBy,sm.UpdatedOn,sm.Status,s.unit,s.PaidAmount from Service_type_SubDetails s inner join Service_type_Master sm on s.ServiceId=sm.ServiceId  where s.MainId= @Id 
union
select *,0 as Unit,0.00 as PaidAmount from Service_type_Master where servicetype=@ServiceType and ServiceId not in (select ServiceId from Service_type_SubDetails where MainId =@Id )
end
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


   CREATE proc [dbo].[Service_type_Master_GetById]
 @ServiceId uniqueidentifier
as
begin

select * from Service_type_Master where ServiceId=@ServiceId
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_GetByService]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

       CREATE proc [dbo].[Service_type_Master_GetByService]
 @ServiceType nvarchar(500)
as
begin

select * from Service_type_Master where ServiceType=@ServiceType
   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
CREATE proc [dbo].[Service_type_Master_Insert]
 @ServiceId uniqueidentifier ,@ServiceName nvarchar(500),@ServiceType nvarchar(500),
@Price decimal(18,2),@Discount decimal(18,2),@CreatedBy nvarchar(500),@CreatedOn datetime,@UpdatedBy nvarchar(500),@UpdatedOn datetime,
@Status nvarchar(500)
as
begin

insert into Service_type_Master values( @ServiceId  ,@ServiceName ,@ServiceType ,
@Price ,@Discount ,@CreatedBy ,getdate() ,@UpdatedBy ,null ,
'Active')
end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_Master_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[Service_type_Master_Update]
@ServiceId uniqueidentifier ,@ServiceName nvarchar(500),@ServiceType nvarchar(500),
@Price decimal(18,2),@Discount decimal(18,2),@CreatedBy nvarchar(500),@CreatedOn datetime,@UpdatedBy nvarchar(500),@UpdatedOn datetime,
@Status nvarchar(500)
as
begin

update Service_type_Master set    ServiceName=@ServiceName ,ServiceType=@ServiceType,
Price=@Price ,Discount=@Discount ,UpdatedBy=@UpdatedBy ,UpdatedOn=getdate()
   where ServiceId=@ServiceId

   end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_Final_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Service_type_SubDetails_Final_Update]
@MainId uniqueidentifier
as

begin

delete Service_type_SubDetails where MainId=@MainId

insert into Service_type_SubDetails 
SELECT [ServiceId]
      ,[MainId]
      ,[Price]
      ,[Discount]
      ,[Unit]
      ,[PaidAmount]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[Status]
      ,[extra]
      ,[extra1]
      ,[extra2]
  FROM [dbo].[Service_type_SubDetails_temp]
where MainId=@MainId

delete Service_type_SubDetails_temp where MainId=@MainId


Declare @Total_amount decimal(18,2),@Total_deduction decimal(18,2),@Gross_total_amount decimal(18,2),@Additional_discount decimal(18,2),@Net_total_amount decimal(18,2),@UpdatedBy nvarchar(250),@OpdCharges decimal(18,2)
select @Total_amount=sum(Price * unit),@Total_deduction =sum(Discount * unit) from Service_type_SubDetails where MainId=@MainId 
select @Additional_discount=Additonal_discount,@UpdatedBy=UpdatedBy  from Pathology_OPD_Main_Details where MainId=@MainId 
set @Gross_total_amount=@Total_amount-@Total_deduction
set @Net_total_amount=@Gross_total_amount-@Additional_discount 

update Pathology_OPD_Main_Details set Total_amount=@Total_amount,Total_deduction=@Total_deduction ,Gross_total_amount=@Gross_total_amount,Net_total_amount=@Net_total_amount ,UpdatedBy=@UpdatedBy ,
UpdatedOn =getdate()  where MainId =@MainId 
end





GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_Final_Update_IPD]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Service_type_SubDetails_Final_Update_IPD]
@MainId uniqueidentifier
as

begin

delete Service_type_SubDetails where MainId=@MainId

insert into Service_type_SubDetails 
SELECT [ServiceId]
      ,[MainId]
      ,[Price]
      ,[Discount]
      ,[Unit]
      ,[PaidAmount]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[Status]
      ,[extra]
      ,[extra1]
      ,[extra2]
  FROM [dbo].[Service_type_SubDetails_temp]
where MainId=@MainId

delete Service_type_SubDetails_temp where MainId=@MainId


Declare @Total_amount decimal(18,2),@Total_deduction decimal(18,2),@Gross_total_amount decimal(18,2),@Additional_discount decimal(18,2),@Net_total_amount decimal(18,2),@UpdatedBy nvarchar(250),
@TCS decimal(18,2),@Advance decimal(18,2)
select @Total_amount=sum(Price * unit),@Total_deduction =sum(Discount * unit) from Service_type_SubDetails where MainId=@MainId 
select @Additional_discount=Additonal_discount,@UpdatedBy=UpdatedBy,@TCS=TCS,@Advance=Advance   from IPD_Main_Details where MainId=@MainId 
set @Gross_total_amount=@Total_amount-@Total_deduction - @TCS -@Advance
set @Net_total_amount=@Gross_total_amount-@Additional_discount  

update IPD_Main_Details set Total_amount=@Total_amount,Total_deduction=@Total_deduction ,Gross_total_amount=@Gross_total_amount,Net_total_amount=@Net_total_amount ,UpdatedBy=@UpdatedBy ,
UpdatedOn =getdate()  where MainId =@MainId 
end




GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Service_type_SubDetails_GetAll]
as
begin
SELECT [Code]
      ,[ServiceId]
      ,[MainId]
      ,[Price]
      ,[Discount]
      ,[Unit]
      ,[PaidAmount]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[Status]
      ,[extra]
      ,[extra1]
      ,[extra2]
  FROM [dbo].[Service_type_SubDetails]

end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_GetById_Service]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Service_type_SubDetails_GetById_Service]
@ServiceId uniqueidentifier
as
begin
SELECT [Code]
      ,[ServiceId]
      ,[MainId]
      ,[Price]
      ,[Discount]
      ,[Unit]
      ,[PaidAmount]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
      ,[Status]
      ,[extra]
      ,[extra1]
      ,[extra2]
  FROM [dbo].[Service_type_SubDetails]
  where ServiceId=@ServiceId
end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Service_type_SubDetails_Insert]
     @ServiceId uniqueidentifier   
	,@MainId uniqueidentifier   
	,@Price decimal (18, 2)  
	,@Discount decimal (18, 2)  
	,@Unit int   
	,@PaidAmount decimal (18, 2)  
	,@CreatedBy nvarchar (500)  
	,@CreatedOn datetime   
	,@UpdatedBy nvarchar (500)  
	,@UpdatedOn datetime   
	,@Status nvarchar (500)  
	 
as
begin

insert into Service_type_SubDetails values(@ServiceId,@MainId,@Price,@Discount,@Unit,@PaidAmount,@CreatedBy,@CreatedOn,@UpdatedBy,@CreatedOn,@Status,'','','' )
Declare @Total_amount decimal(18,2),@Total_deduction decimal(18,2),@Gross_total_amount decimal(18,2),@Additional_discount decimal(18,2),@Net_total_amount decimal(18,2),@OpdCharges decimal(18,2)
select @Total_amount=sum(Price * unit),@Total_deduction =sum(Discount * unit) from Service_type_SubDetails where MainId=@MainId 
select @Additional_discount=Additonal_discount  from Pathology_OPD_Main_Details where MainId=@MainId 
set @Gross_total_amount=@Total_amount-@Total_deduction  
set @Net_total_amount=@Gross_total_amount-@Additional_discount 

update Pathology_OPD_Main_Details set Total_amount=@Total_amount,Total_deduction=@Total_deduction ,Gross_total_amount=@Gross_total_amount,Net_total_amount=@Net_total_amount ,UpdatedBy=@UpdatedBy ,
UpdatedOn =@UpdatedOn  where MainId =@MainId 

end
GO
/****** Object:  StoredProcedure [dbo].[Service_type_SubDetails_temp_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[Service_type_SubDetails_temp_Insert]
     @ServiceId uniqueidentifier   
	,@MainId uniqueidentifier   
	,@Price decimal (18, 2)  
	,@Discount decimal (18, 2)  
	,@Unit int   
	,@PaidAmount decimal (18, 2)  
	,@CreatedBy nvarchar (500)  
	,@CreatedOn datetime   
	,@UpdatedBy nvarchar (500)  
	,@UpdatedOn datetime   
	,@Status nvarchar (500)  
	 
as
begin

insert into Service_type_SubDetails_temp values(@ServiceId,@MainId,@Price,@Discount,@Unit,@PaidAmount,@CreatedBy,@CreatedOn,@UpdatedBy,@CreatedOn,@Status,'','','' )

end
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[Usp_Login_Delete]
(
@Id uniqueidentifier
)
as
Delete
  FROM   [Login]
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[Usp_Login_GetAll]    
as    
SELECT [Id]    
      ,[Code]    
      ,[UserName]    
      ,[Password]    
      ,[Email]    
      ,[MobileNo]    
      ,[Address]    
      ,[UserPic]    
      ,[UserLanguage]    
      ,[Role]    
      ,[DOB]    
      ,[Country]    
      ,[State]    
      ,[City]    
      ,[LastLogin]    
      ,[IPAddress]    
      ,[Extra1]    
      ,[Extra2]    
      ,[Extra3]    
      ,[CreatedBy]    
      ,[CreatedOn]    
      ,[UpdatedBy]    
      ,[UpdatedOn]  
	   -- ,(select G.ClassName from [Grade_Class] G where G.Id=L.Country) as CourseName  
		  --,(select C.BoardName from [Board] C where C.Id= L.State ) as Stream  
  FROM   [Login] L order by code desc
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc  [dbo].[Usp_Login_GetById] -- 'F88C02E1-62D0-4212-83F7-172EC4C946DF'-- 'tarzon@gmail.com','MTIzNA=='   
(    
@Id uniqueidentifier    
)    
as    
SELECT [Id]    
      ,[Code]    
      ,[UserName]    
      ,[Password]    
      ,[Email]    
      ,[MobileNo]    
      ,[Address]    
      ,[UserPic]    
      ,[UserLanguage]    
      ,[Role]    
      ,[DOB]    
      ,[Country]    
      ,[State]    
      ,[City]    
      ,[LastLogin]    
      ,[IPAddress]    --[dbo].[fn_get_dashboard_pending_completed_appliction](@user nvarchar(100),@mode int,@type nvarchar(100),@User_id uniqueidentifier) 
      ,[Extra1]    
      ,[Extra2]    
      ,[Extra3]    
      ,[CreatedBy]    
      ,[CreatedOn]    
      ,[UpdatedBy]    
      ,[UpdatedOn] 
  
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Waqf Registration',Id) TotalRegWaqf,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Waqf Registration',Id) TotalPendingWaqf  ,
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Apply for Management',Id) TotalRegManagement,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Apply for Management',Id) TotalPendingManagement  ,

 -- [dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Encroachment Removal',Id) TotalEncroachment,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Encroachment Removal',Id) TotalPendingEncroachment  ,
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'File First Appeal',Id) TotalFirstRti,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'File First Appeal',Id) TotalPendingFirstRti  ,
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Apply for RTI',Id) TotalRTI,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Apply for RTI',Id) TotalPendingRTI  ,
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Recovery of Property',Id) TotalRecoveryProperty,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Recovery of Property',Id) TotalPendingRecoveryProperty ,

 -- [dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Complaint Against Waqf Management',Id) TotalComplaintWaqfManagement,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Complaint Against Waqf Management',Id) TotalPendingComplaintWaqfManagement  ,
 
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Apply for Certified Copy of Record',Id) TotalCertifiedCopy,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Apply for Certified Copy of Record',Id) TotalPendingCertifiedCopy  ,
   
 --  [dbo].[fn_get_dashboard_pending_completed_appliction](Role,1,'Apply for Inspection of Record',Id) TotalInspectionRecord,  
 --[dbo].[fn_get_dashboard_pending_completed_appliction](Role,2,'Apply for Inspection of Record',Id) TotalPendingInspectionRecord 
  FROM   [Login]    
where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_GetByName]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc   [dbo].[Usp_Login_GetByName]
(
@UserName varchar(MAX)
)
as
SELECT [Id]
      ,[Code]
      ,[UserName]
      ,[Password]
      ,[Email]
      ,[MobileNo]
      ,[Address]
      ,[UserPic]
      ,[UserLanguage]
      ,[Role]
      ,[DOB]
      ,[Country]
      ,[State]
      ,[City]
      ,[LastLogin]
      ,[IPAddress]
      ,[Extra1]
      ,[Extra2]
      ,[Extra3]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
  FROM   [Login]
   where UserName=@UserName
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc  [dbo].[Usp_Login_Insert]
(@Id  uniqueidentifier ,
           @UserName  nvarchar(150) ,
           @Password  nvarchar(150) ,
           @Email  nvarchar(150) ,
           @MobileNo  nvarchar(50) ,
           @Address  nvarchar(150) ,
           @UserPic  nvarchar(150) ,
           @UserLanguage  nvarchar(150) ,
           @Role  nvarchar(150) ,
           @DOB  nvarchar(150) ,
           @Country  nvarchar(150) ,
           @State  nvarchar(150) ,
           @City  nvarchar(150) ,
           @LastLogin  nvarchar(150) ,
           @IPAddress  nvarchar(150) ,
           @Extra1  nvarchar(150) ,
           @Extra2  nvarchar(150) ,
           @Extra3  nvarchar(150) ,
           @CreatedBy  varchar(50) ,
           @CreatedOn  datetime ,
           @UpdatedBy  varchar(50) ,
           @UpdatedOn  datetime )
           as
INSERT INTO   [Login]
           ([Id]
           ,[UserName]
           ,[Password]
           ,[Email]
           ,[MobileNo]
           ,[Address]
           ,[UserPic]
           ,[UserLanguage]
           ,[Role]
           ,[DOB]
           ,[Country]
           ,[State]
           ,[City]
           ,[LastLogin]
           ,[IPAddress]
           ,[Extra1]
           ,[Extra2]
           ,[Extra3]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdatedBy]
           ,[UpdatedOn])
     VALUES
        (@Id    ,
           @UserName    ,
           @Password    ,
           @Email    ,
           @MobileNo   ,
           @Address    ,
           @UserPic    ,
           @UserLanguage    ,
           @Role    ,
           @DOB    ,
           @Country    ,
           @State    ,
           @City    ,
           @LastLogin    ,
           @IPAddress    ,
           @Extra1    ,
           @Extra2    ,
           @Extra3    ,
           @CreatedBy    ,
           @CreatedOn    ,
           @UpdatedBy    ,
           @UpdatedOn    )
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_Login]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Usp_Login_Login]    --'admin@gmail.com','MTIz'   
(          
@UserName varchar(MAX),          
@Password varchar(250)          
)          
as          
SELECT L.[Id]          
      ,L.[Code]          
      ,L.[UserName]          
      ,L.[Password]          
      ,L.[Email]          
      ,L.[MobileNo]          
      ,L.[Address]          
      ,L.[UserPic]          
      ,L.[UserLanguage]          
      ,L.[Role]          
      ,L.[DOB]          
      ,L.[Country]          
      ,L.[State]          
      ,L.[City]          
      ,L.[LastLogin]          
      ,L.[IPAddress]          
      ,L.[Extra1]          
      ,L.[Extra2]          
      ,L.[Extra3]          
      ,L.[CreatedBy]          
      ,L.[CreatedOn]          
      ,L.[UpdatedBy]          
      ,L.[UpdatedOn]   
	   --    ,(SELECT count(*)  FROM Waqf_User_Registration where Sadqa='Approved Waqf') as TotalRegWaqf  
    --,(SELECT count(*)  FROM Waqf_User_Registration where Sadqa='Pending at Clerk') as TotalPendingWaqf         
  FROM [Login]   L       
   where ( L.MobileNo=@UserName or L.Email=@UserName) and L.Password=@Password --and Extra1='Approve'
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc  [dbo].[Usp_Login_Update]
(@Id  uniqueidentifier ,
           @UserName  nvarchar(150) ,
           @Password  nvarchar(150) ,
           @Email  nvarchar(150) ,
           @MobileNo  nvarchar(50) ,
           @Address  nvarchar(150) ,
           @UserPic  nvarchar(150) ,
           @UserLanguage  nvarchar(150) ,
           @Role  nvarchar(150) ,
           @DOB  nvarchar(150) ,
           @Country  nvarchar(150) ,
           @State  nvarchar(150) ,
           @City  nvarchar(150) ,
           @LastLogin  nvarchar(150) ,
           @IPAddress  nvarchar(150) ,
           @Extra1  nvarchar(150) ,
           @Extra2  nvarchar(150) ,
           @Extra3  nvarchar(150) ,
           --@CreatedBy  varchar(50) ,
           --@CreatedOn  datetime ,
           @UpdatedBy  varchar(50) ,
           @UpdatedOn  datetime )
           as
UPDATE   [Login]
   SET [Id] = @Id 
      ,[UserName] = @UserName 
      ,[Password] = @Password 
      ,[Email] = @Email 
      ,[MobileNo] = @MobileNo
      ,[Address] = @Address 
      ,[UserPic] = @UserPic 
      ,[UserLanguage] = @UserLanguage 
      ,[Role] = @Role 
      ,[DOB] = @DOB 
      ,[Country] = @Country 
      ,[State] = @State 
      ,[City] = @City 
      ,[LastLogin] = @LastLogin 
      ,[IPAddress] = @IPAddress 
      ,[Extra1] = @Extra1 
      ,[Extra2] = @Extra2 
      ,[Extra3] = @Extra3 
      --,[CreatedBy] = @CreatedBy 
      --,[CreatedOn] = @CreatedOn 
      ,[UpdatedBy] = @UpdatedBy 
      ,[UpdatedOn] = @UpdatedOn 
 WHERE Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_Delete]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_Delete]
(
@Id uniqueidentifier
)
as
Delete 
 FROM   [Permission]
  where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_GetAll]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_GetAll]
as
SELECT [Id]
      ,[UserId]
      ,[Code]
      ,[MenuName]
      ,[AddRecord]
      ,[UpdateRecord]
      ,[DeleteRecord]
      ,[ExtraColumn]
      ,[Status]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
  FROM   [Permission]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_GetById]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_GetById]
(
@Id uniqueidentifier
)
as
SELECT [Id]
      ,[UserId]
      ,[Code]
      ,[MenuName]
      ,[AddRecord]
      ,[UpdateRecord]
      ,[DeleteRecord]
      ,[ExtraColumn]
      ,[Status]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
  FROM   [Permission]
  where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_GetByUserId]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_GetByUserId]
(
@UserId uniqueidentifier
)
as
SELECT [Id]
      ,[UserId]
      ,[Code]
      ,[MenuName]
      ,[AddRecord]
      ,[UpdateRecord]
      ,[DeleteRecord]
      ,[ExtraColumn]
      ,[Status]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[UpdatedBy]
      ,[UpdatedOn]
  FROM [Permission]
where UserId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_Insert]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_Insert]
 (@Id  uniqueidentifier ,
           @UserId  uniqueidentifier ,
           @MenuName  varchar(250) ,
           @AddRecord  varchar(250) ,
           @UpdateRecord  varchar(250) ,
           @DeleteRecord  varchar(250) ,
           @ExtraColumn  varchar(250) ,
           @Status  varchar(250) ,
           @CreatedBy  varchar(50) ,
           @CreatedOn  datetime ,
           @UpdatedBy  varchar(50) ,
           @UpdatedOn  datetime )
           as
INSERT INTO   [Permission]
           ([Id]
           ,[UserId]
           ,[MenuName]
           ,[AddRecord]
           ,[UpdateRecord]
           ,[DeleteRecord]
           ,[ExtraColumn]
           ,[Status]
           ,[CreatedBy]
           ,[CreatedOn]
           ,[UpdatedBy]
           ,[UpdatedOn])
     VALUES
           (@Id    ,
           @UserId    ,
           @MenuName    ,
           @AddRecord    ,
           @UpdateRecord    ,
           @DeleteRecord    ,
           @ExtraColumn    ,
           @Status    ,
           @CreatedBy    ,
           @CreatedOn    ,
           @UpdatedBy    ,
           @UpdatedOn    )
GO
/****** Object:  StoredProcedure [dbo].[Usp_Permission_Update]    Script Date: 6/14/2022 10:40:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc  [dbo].[Usp_Permission_Update]
 (@Id  uniqueidentifier ,
           @UserId  uniqueidentifier ,
           @MenuName  varchar(250) ,
           @AddRecord  varchar(250) ,
           @UpdateRecord  varchar(250) ,
           @DeleteRecord  varchar(250) ,
           @ExtraColumn  varchar(250) ,
           @Status  varchar(250) ,
           @CreatedBy  varchar(50) ,
           @CreatedOn  datetime ,
           @UpdatedBy  varchar(50) ,
           @UpdatedOn  datetime )
           as
UPDATE   [Permission]
   SET [Id] = @Id 
      ,[UserId] = @UserId 
      ,[MenuName] = @MenuName 
      ,[AddRecord] = @AddRecord 
      ,[UpdateRecord] = @UpdateRecord 
      ,[DeleteRecord] = @DeleteRecord 
      ,[ExtraColumn] = @ExtraColumn 
      ,[Status] = @Status 
      ,[CreatedBy] = @CreatedBy 
      ,[CreatedOn] = @CreatedOn 
      ,[UpdatedBy] = @UpdatedBy 
      ,[UpdatedOn] = @UpdatedOn 
 WHERE Id=@Id
GO
USE [master]
GO
ALTER DATABASE [Hospital_Management] SET  READ_WRITE 
GO
