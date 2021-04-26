CREATE TABLE HotelManagementREAL.dbo.client ( 
	id_client            int NOT NULL    ,
	cl_name              varchar(100) NOT NULL    ,
	cl_gmail             varchar(100) NOT NULL    ,
	cli_idclityp         int NOT NULL    ,
	CONSTRAINT Pk_client_id_client PRIMARY KEY  ( id_client ) 
 );

CREATE TABLE HotelManagementREAL.dbo.menu ( 
	id_menu              int NOT NULL   IDENTITY ,
	menu_parentid        int NOT NULL    ,
	menu_url             varchar(100) NOT NULL    ,
	menu_name            varchar(100) NOT NULL    ,
	menu_orderindex      int NOT NULL    ,
	menu_activeflag      bit NOT NULL    ,
	menu_createdate      date NOT NULL CONSTRAINT [defo_menu_menu_createdate] DEFAULT getdate()   ,
	menu_updatedate      date NOT NULL CONSTRAINT [defo_menu_menu_updatedate] DEFAULT getdate()   ,
	CONSTRAINT Pk_menu_id_menu PRIMARY KEY  ( id_menu ) 
 );

CREATE TABLE HotelManagementREAL.dbo.role ( 
	id_role              int NOT NULL   IDENTITY ,
	role_name            varchar(100) NOT NULL    ,
	role_description     varchar(200)  CONSTRAINT [defo_role_role_description] DEFAULT 'none'   ,
	CONSTRAINT Pk_role_id_role PRIMARY KEY  ( id_role ) 
 );

CREATE TABLE HotelManagementREAL.dbo.room_type ( 
	id_roomtype          int NOT NULL   IDENTITY ,
	roty_name            varchar(100) NOT NULL    ,
	roty_description     varchar(250)  CONSTRAINT [defo_room_type_roty_description] DEFAULT 'none'   ,
	roty_currentprice    decimal(10,2) NOT NULL    ,
	roty_capacity        int NOT NULL    ,
	CONSTRAINT Pk_room_type_id_roomtype PRIMARY KEY  ( id_roomtype ) 
 );

CREATE TABLE HotelManagementREAL.dbo.[status] ( 
	id_status            int NOT NULL   IDENTITY ,
	sta_name             varchar(100) NOT NULL    ,
	sta_description      varchar(200)  CONSTRAINT [defo_status_sta_description] DEFAULT 'none'   ,
	CONSTRAINT Pk_Tbl_id_status PRIMARY KEY  ( id_status ) 
 );

CREATE TABLE HotelManagementREAL.dbo.[user] ( 
	id_user              int NOT NULL   IDENTITY ,
	user_name            varchar(100) NOT NULL    ,
	user_photo           int NOT NULL    ,
	user_gmail           varchar(100) NOT NULL    ,
	user_phone           varchar(10) NOT NULL    ,
	user_gender          bit NOT NULL    ,
	user_activeflag      bit NOT NULL    ,
	user_code            varchar(8) NOT NULL CONSTRAINT [defo_user_user_code] DEFAULT 0   ,
	CONSTRAINT Pk_Tbl_id_user PRIMARY KEY  ( id_user ) 
 );

CREATE TABLE HotelManagementREAL.dbo.user_role ( 
	id_userol            int NOT NULL   IDENTITY ,
	userol_iduser        int NOT NULL    ,
	userol_idrole        int NOT NULL    ,
	userol_activeflag    bit NOT NULL CONSTRAINT [defo_user_role_userol_activeflag] DEFAULT 1   ,
	CONSTRAINT Pk_user_role_id_userol PRIMARY KEY  ( id_userol ) 
 );

CREATE TABLE HotelManagementREAL.dbo.ImgStorage ( 
	id_imgsto            int NOT NULL   IDENTITY ,
	imgsto_url           varchar(200) NOT NULL    ,
	imgsto_description   varchar(200)     ,
	imgsto_idrootyp      int     ,
	imgsto_iduser        int     ,
	CONSTRAINT Pk_ImgStorage_id_imgsto PRIMARY KEY  ( id_imgsto ) 
 );

CREATE TABLE HotelManagementREAL.dbo.Invoice ( 
	id_invoice           int NOT NULL   IDENTITY ,
	inv_totalbooking     decimal(10,2) NOT NULL    ,
	inv_createdate       date NOT NULL CONSTRAINT [defo_Invoice_inv_createdate] DEFAULT getdate()   ,
	inv_updatedate       date NOT NULL CONSTRAINT [defo_Invoice_inv_updatedate] DEFAULT getdate()   ,
	inv_idclient         int NOT NULL    ,
	inv_iduser           int NOT NULL    ,
	CONSTRAINT Pk_Invoice_id_invoice PRIMARY KEY  ( id_invoice ) 
 );

CREATE TABLE HotelManagementREAL.dbo.auth ( 
	id_auth              int NOT NULL   IDENTITY ,
	auth_idrole          int NOT NULL    ,
	auth_idmenu          int NOT NULL    ,
	auth_permission      bit NOT NULL    ,
	auth_activeflag      bit NOT NULL    ,
	auth_createdate      date NOT NULL CONSTRAINT [defo_auth_auth_createdate] DEFAULT getdate()   ,
	auth_updatedate      date NOT NULL CONSTRAINT [defo_auth_auth_updatedate] DEFAULT getdate()   ,
	CONSTRAINT Pk_auth_id_auth PRIMARY KEY  ( id_auth ) 
 );

CREATE TABLE HotelManagementREAL.dbo.booking ( 
	id_book              int NOT NULL   IDENTITY ,
	book_bookdate        date NOT NULL CONSTRAINT [defo_booking_book_bookdate] DEFAULT getdate()   ,
	book_checkindate     date NOT NULL    ,
	book_idclient        int NOT NULL    ,
	book_note            varchar(600)     ,
	book_status          varchar(10) NOT NULL    ,
	book_deposit         int NOT NULL    ,
	book_totalprice      int NOT NULL    ,
	book_paymentdate     date NOT NULL    ,
	book_iduser          int NOT NULL    ,
	CONSTRAINT Pk_appointment_id_appoint PRIMARY KEY  ( id_book ) 
 );

CREATE TABLE HotelManagementREAL.dbo.room ( 
	id_room              int NOT NULL   IDENTITY ,
	room_name            varchar(100) NOT NULL    ,
	room_description     varchar(250)     ,
	room_idroomtype      int NOT NULL    ,
	CONSTRAINT Pk_room_id_room PRIMARY KEY  ( id_room ) 
 );

CREATE TABLE HotelManagementREAL.dbo.status_time ( 
	id_statim            int NOT NULL   IDENTITY ,
	statim_fromdate      date NOT NULL CONSTRAINT [defo_status_time_statim_fromdate] DEFAULT getdate()   ,
	statim_todate        date NOT NULL CONSTRAINT [defo_status_time_statim_todate] DEFAULT getdate()   ,
	statim_idroom        int NOT NULL    ,
	statim_idstatus      int NOT NULL    ,
	CONSTRAINT Pk_status_time_id_statim PRIMARY KEY  ( id_statim ) 
 );

CREATE TABLE HotelManagementREAL.dbo.booking_detail ( 
	id_boodet            int NOT NULL   IDENTITY ,
	boodet_duration      int NOT NULL    ,
	boodet_price         int NOT NULL    ,
	boodet_idbook        int NOT NULL    ,
	boodet_idroom        int NOT NULL    ,
	CONSTRAINT Pk_appointment_detail_id_appdet PRIMARY KEY  ( id_boodet ) 
 );

ALTER TABLE HotelManagementREAL.dbo.ImgStorage ADD CONSTRAINT Fk_ImgStorage_room_type FOREIGN KEY ( imgsto_idrootyp ) REFERENCES HotelManagementREAL.dbo.room_type( id_roomtype ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.ImgStorage ADD CONSTRAINT Fk_ImgStorage_user FOREIGN KEY ( imgsto_iduser ) REFERENCES HotelManagementREAL.dbo.[user]( id_user ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.Invoice ADD CONSTRAINT Fk_Invoice_client FOREIGN KEY ( inv_idclient ) REFERENCES HotelManagementREAL.dbo.client( id_client ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.Invoice ADD CONSTRAINT Fk_Invoice_user FOREIGN KEY ( inv_iduser ) REFERENCES HotelManagementREAL.dbo.[user]( id_user ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.auth ADD CONSTRAINT Fk_auth_menu FOREIGN KEY ( auth_idmenu ) REFERENCES HotelManagementREAL.dbo.menu( id_menu ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.auth ADD CONSTRAINT Fk_auth_role FOREIGN KEY ( auth_idrole ) REFERENCES HotelManagementREAL.dbo.role( id_role ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.booking ADD CONSTRAINT Fk_booking_client FOREIGN KEY ( book_idclient ) REFERENCES HotelManagementREAL.dbo.client( id_client ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.booking ADD CONSTRAINT Fk_booking_user FOREIGN KEY ( book_iduser ) REFERENCES HotelManagementREAL.dbo.[user]( id_user ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.booking_detail ADD CONSTRAINT Fk_booking_detail_booking FOREIGN KEY ( boodet_idbook ) REFERENCES HotelManagementREAL.dbo.booking( id_book ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.booking_detail ADD CONSTRAINT Fk_booking_detail_room FOREIGN KEY ( boodet_idroom ) REFERENCES HotelManagementREAL.dbo.room( id_room ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.room ADD CONSTRAINT Fk_room_room_type FOREIGN KEY ( room_idroomtype ) REFERENCES HotelManagementREAL.dbo.room_type( id_roomtype ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.status_time ADD CONSTRAINT Fk_status_time_room FOREIGN KEY ( statim_idroom ) REFERENCES HotelManagementREAL.dbo.room( id_room ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.status_time ADD CONSTRAINT Fk_status_time_status FOREIGN KEY ( statim_idstatus ) REFERENCES HotelManagementREAL.dbo.[status]( id_status ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.user_role ADD CONSTRAINT Fk_user_role_role FOREIGN KEY ( userol_idrole ) REFERENCES HotelManagementREAL.dbo.role( id_role ) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE HotelManagementREAL.dbo.user_role ADD CONSTRAINT Fk_user_role_user FOREIGN KEY ( userol_iduser ) REFERENCES HotelManagementREAL.dbo.[user]( id_user ) ON DELETE CASCADE ON UPDATE CASCADE;

