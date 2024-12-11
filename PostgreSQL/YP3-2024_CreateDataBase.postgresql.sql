CREATE TABLE "Post" (
	"PostID" SERIAL PRIMARY KEY
	
	, "Title" VARCHAR(100) NOT NULL
);

CREATE TABLE "Cabinet" (
 	"CabinetID" SERIAL PRIMARY KEY
	 
	, "Title" VARCHAR(20) NOT NULL
);

CREATE TABLE "Organization" (
 	"OrganizationID" SERIAL PRIMARY KEY
	 
	, "Title" VARCHAR(50) NOT NULL
);

CREATE TABLE "Divisions" (
 	"DivisionsID" SERIAL PRIMARY KEY
 
	, "OrganizationID" INTEGER NOT NULL
		REFERENCES "Organization"("OrganizationID")
			ON DELETE CASCADE
			
 	, "Title" VARCHAR(100) NOT NULL
);

CREATE TABLE "StatusUser" (
	"StatusUserID" SERIAL PRIMARY KEY
	
	, "Title" VARCHAR(15) NOT NULL
);

CREATE TABLE "User" (
	"UserID" SERIAL PRIMARY KEY
 
	, "OrganizationID" INTEGER NOT NULL
		REFERENCES "Organization"("OrganizationID")
			ON DELETE CASCADE
			
	, "DivisionsID" INTEGER NULL
		REFERENCES "Divisions"("DivisionsID")
			ON DELETE CASCADE
			
	, "MinDivisionsID" INTEGER
		REFERENCES "Divisions"("DivisionsID")
			ON DELETE CASCADE
			
	, "PostID" INTEGER NOT NULL
		REFERENCES "Post"("PostID")
			ON DELETE CASCADE
			
	, "Surname" VARCHAR(50) NOT NULL
	
	, "Name" VARCHAR(50) NOT NULL
	
	, "Middlename" VARCHAR(50) NOT NULL
	
	, "Date" DATE NOT NULL
	
	, "Phone" VARCHAR(20) NOT NULL
	
	, "CabinetID" INTEGER NOT NULL
		REFERENCES "Cabinet"("CabinetID")
			ON DELETE CASCADE
			
	, "Email" VARCHAR(100) NOT NULL
	
	, "StatusUserID" INTEGER NOT NULL
		REFERENCES "StatusUser"("StatusUserID")
			ON DELETE CASCADE
			
	, "DateFinish" DATE NULL
);

CREATE TABLE "Resume" (
	"ResumeID" SERIAL PRIMARY KEY
	
	, "DateCreate" DATE NOT NULL
	
	, "Photo" BYTEA NOT NULL
	
	, "Description" TEXT NOT NULL
	
	, "UserID" INTEGER NOT NULL
		REFERENCES "User"("UserID")
			ON DELETE CASCADE
);

CREATE TABLE "StatusCalendar" (
	"StatusCalendarID" SERIAL PRIMARY KEY
	
	, "Title" VARCHAR(50) NOT NULL
);

CREATE TABLE "TypeCalendar" (
	"TypeCalendarID" SERIAL PRIMARY KEY
	
	, "Title" VARCHAR(100) NOT NULL
);

CREATE TABLE "Calendar" (
	"CalendarID" SERIAL PRIMARY KEY
	
	, "DateTime_Start" DATE NOT NULL
	
	, "DateTime_End" DATE NOT NULL
	
	, "StatusCalendarID" INTEGER
		REFERENCES "StatusCalendar"("StatusCalendarID")
			ON DELETE CASCADE
			
	, "TypeCalendarID" INTEGER
		REFERENCES "TypeCalendar"("TypeCalendarID")
			ON DELETE CASCADE
			
	, "UserID" INTEGER
		REFERENCES "User"("UserID")
			ON DELETE CASCADE
);

CREATE TABLE "Event" (
	"EventID" SERIAL PRIMARY KEY
	
	, "Description" TEXT
	
	, "TypeCalendarID" INTEGER
		REFERENCES "TypeCalendar"("TypeCalendarID")
			ON DELETE CASCADE
			
	, "UserID" INTEGER
		REFERENCES "User"("UserID")
			ON DELETE CASCADE
);