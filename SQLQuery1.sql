USE AssetManagementDb;

CREATE TABLE Login(
l_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
Username VARCHAR(20),
Password VARCHAR(20),
UserType VARCHAR(20));

CREATE TABLE UserRegistration(
u_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(20),
LastName VARCHAR(20),
Age INT,
Gender Varchar(10),
Address Varchar(20),
PhoneNumber NUMERIC,
l_id NUMERIC CONSTRAINT fk_login FOREIGN KEY
REFERENCES Login (l_id));

CREATE TABLE AssetType(
at_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
at_name VARCHAR(20));

CREATE TABLE AssetDefinition(
ad_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
ad_name VARCHAR(20),
ad_type_id NUMERIC CONSTRAINT fk_assettype1 FOREIGN KEY
REFERENCES AssetType (at_id));

CREATE TABLE Vendor(
vd_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
vd_name VARCHAR(100),
vd_type VARCHAR(40),
vd_atype_id NUMERIC CONSTRAINT fk_assettype2 FOREIGN KEY
REFERENCES AssetType (at_id),
vd_from DATE,
vd_to DATE,
vd_address VARCHAR(200));

CREATE TABLE PurchaseOrder(
pd_id NUMERIC IDENTITY(1,1) PRIMARY KEY,
pd_order_no NUMERIC,
pd_ad_id NUMERIC CONSTRAINT fk_assetdef1 FOREIGN KEY
REFERENCES AssetDefinition (ad_id),
pd_type_id NUMERIC,
pd_qty Numeric,
pd_vendor_id NUMERIC CONSTRAINT fk_vendor1 FOREIGN KEY
REFERENCES Vendor (vd_id),
pd_date DATE,
pd_ddate DATE,
pd_status VARCHAR(10));

CREATE TABLE AssetMaster(
am_id INT IDENTITY(1,1) PRIMARY KEY,
am_atype_id NUMERIC CONSTRAINT fk_assettype3 FOREIGN KEY
REFERENCES Vendor (vd_id),
am_make_id NUMERIC CONSTRAINT fk_vendor2 FOREIGN KEY
REFERENCES AssetDefinition (ad_id),
am_ad_id NUMERIC CONSTRAINT fk_assetdef2 FOREIGN KEY
REFERENCES AssetDefinition (ad_id),
am_model VARCHAR(40),
am_snumber VARCHAR(20),
am_myyear VARCHAR(10),
am_pdate DATE,
am_waranty VARCHAR(20),
am_form DATE,
am_to DATE);

ALTER TABLE  UserRegistration
  ADD CONSTRAINT fk_login1 
  FOREIGN KEY (l_id) 
  REFERENCES Login(l_id) 
  ON DELETE CASCADE;

  SELECT * FROM Login;
  SELECT * FROM UserRegistration;

INSERT INTO Login VALUES
('chandler','chandler@123','Admin'),
('monica','monica@123','Purchase Manager'),
('ross','ross@123','Admin'),
('rachel','rachel@123','Purchase Manager');

INSERT INTO UserRegistration VALUES
('Chandler','Bing',25,'Male','California',9898989898,1);
