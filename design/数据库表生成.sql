
CREATE TABLE Address_code(
    Code      int    NOT NULL,
    A_Name    nvarchar(50)      NOT NULL,
    CONSTRAINT PK8 PRIMARY KEY NONCLUSTERED (Code)
)
go



IF OBJECT_ID('Address_code') IS NOT NULL
    PRINT '<<< CREATED TABLE Address_code >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Address_code >>>'
go

/* 
 * TABLE: Dealer_Level 
 */

CREATE TABLE Dealer_Level(
    Dealer_ID    int    NOT NULL,
    Level        int    NOT NULL,
    CONSTRAINT PK5 PRIMARY KEY NONCLUSTERED (Dealer_ID)
)
go



IF OBJECT_ID('Dealer_Level') IS NOT NULL
    PRINT '<<< CREATED TABLE Dealer_Level >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Dealer_Level >>>'
go

/* 
 * TABLE: DealerInfo 
 */

CREATE TABLE DealerInfo(
    Dealer_ID    int          NOT NULL,
    Name         nvarchar(20)      NOT NULL,
    Province     int    NULL,
    City         int    NULL,
    Tel          int    NULL,
    Address      nvarchar(50)      NULL,
    CONSTRAINT PK4 PRIMARY KEY NONCLUSTERED (Dealer_ID)
)
go



IF OBJECT_ID('DealerInfo') IS NOT NULL
    PRINT '<<< CREATED TABLE DealerInfo >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE DealerInfo >>>'
go

/* 
 * TABLE: Log 
 */

CREATE TABLE UseLog(
    Log_ID       int           identity(1,1)         NOT NULL,
    Method       nvarchar(10)           NOT NULL,
    Time         datetime               NOT NULL,
    Number       int    NULL,
    Dealer_ID    int                    NULL,
    P_Model      varchar(20)            NULL,
    CONSTRAINT PK10 PRIMARY KEY NONCLUSTERED (Log_ID)
)
go



IF OBJECT_ID('Log') IS NOT NULL
    PRINT '<<< CREATED TABLE Log >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Log >>>'
go

/* 
 * TABLE: PhoneInfo 
 */

CREATE TABLE PhoneInfo(
    P_Model      varchar(20)       NOT NULL,
    P_Address    int    NULL,
    P_Color      nvarchar(10)      NOT NULL,
    P_Deploy     nvarchar(20)      NOT NULL,
    P_Brand      nvarchar(20)      NOT NULL,
    CONSTRAINT PK6 PRIMARY KEY NONCLUSTERED (P_Model)
)
go



IF OBJECT_ID('PhoneInfo') IS NOT NULL
    PRINT '<<< CREATED TABLE PhoneInfo >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE PhoneInfo >>>'
go

/* 
 * TABLE: Stock_Manage 
 */

CREATE TABLE Stock_Manage(
    Dealer_ID    int                      NOT NULL,
    P_Model      varchar(20)              NOT NULL,
    Parent_ID    int           NOT NULL,
    Inventory    int    NOT NULL,
    CONSTRAINT PK7 PRIMARY KEY NONCLUSTERED (Dealer_ID, P_Model)
)
go



IF OBJECT_ID('Stock_Manage') IS NOT NULL
    PRINT '<<< CREATED TABLE Stock_Manage >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Stock_Manage >>>'
go

/* 
 * TABLE: [Users] 
 */

CREATE TABLE [Users](
    Dealer_ID      int        identity(1,1)    NOT NULL,
    Dealer_Name    varchar(20)    NOT NULL,
    Dealer_Psw     varchar(20)    NOT NULL,
	Parent_ID		int			Not Null,
    CONSTRAINT PK1 PRIMARY KEY NONCLUSTERED (Dealer_ID)
)
go



IF OBJECT_ID('Users') IS NOT NULL
    PRINT '<<< CREATED TABLE Users >>>'
ELSE
    PRINT '<<< FAILED CREATING TABLE Users >>>'
go

/* 
 * TABLE: Dealer_Level 
 */

ALTER TABLE Dealer_Level ADD CONSTRAINT [RefUsers6] 
    FOREIGN KEY (Dealer_ID)
    REFERENCES [Users](Dealer_ID)
go


/* 
 * TABLE: DealerInfo 
 */

ALTER TABLE DealerInfo ADD CONSTRAINT [RefUsers5] 
    FOREIGN KEY (Dealer_ID)
    REFERENCES [Users](Dealer_ID)
go


/* 
 * TABLE: Log 
 */

ALTER TABLE UseLog ADD CONSTRAINT [RefUsers11] 
    FOREIGN KEY (Dealer_ID)
    REFERENCES [Users](Dealer_ID)
go

ALTER TABLE UseLog ADD CONSTRAINT RefPhoneInfo12 
    FOREIGN KEY (P_Model)
    REFERENCES PhoneInfo(P_Model)
go


/* 
 * TABLE: Stock_Manage 
 */

ALTER TABLE Stock_Manage ADD CONSTRAINT [RefUsers8] 
    FOREIGN KEY (Dealer_ID)
    REFERENCES [Users](Dealer_ID)
go

ALTER TABLE Stock_Manage ADD CONSTRAINT RefPhoneInfo10 
    FOREIGN KEY (P_Model)
    REFERENCES PhoneInfo(P_Model)
go
