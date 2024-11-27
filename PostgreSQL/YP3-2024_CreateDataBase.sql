CREATE TABLE "Organization" (
 "OrganizationID" SERIAL PRIMARY KEY
	, "Title" VARCHAR(50) NOT NULL
);

CREATE TABLE "Divisions" (
 "DivisionsID" SERIAL PRIMARY KEY
	, "OrganizationID" INT NOT NULL
		REFERENCES "Organization"("OrganizationID")
 	, "Title" VARCHAR(100) NOT NULL
);

CREATE TABLE "Post" (
 "PostID" SERIAL PRIMARY KEY
	, "Title" VARCHAR(100) NOT NULL
);

CREATE TABLE "Cabinet" (
 "CabinetID" SERIAL PRIMARY KEY
	, "Title" VARCHAR(20) NOT NULL
);

CREATE TABLE "User" (
 "UserID" SERIAL PRIMARY KEY
	, "OrganizationID" INT NOT NULL
		REFERENCES "Organization"("OrganizationID")
	, "DivisionsID" INT NULL
		REFERENCES "Divisions"("DivisionsID")
	, "MinDivisionsID" INT NULL
		REFERENCES "Divisions"("DivisionsID")
	, "PostID" INT NOT NULL
		REFERENCES "Post"("PostID")
	, "Surname" VARCHAR(50) NOT NULL
	, "Name" VARCHAR(50) NOT NULL
	, "Middlename" VARCHAR(50) NOT NULL
	, "Date" DATE NOT NULL
	, "Phone" FLOAT NOT NULL
	, "CabinetID" INT NOT NULL
		REFERENCES "Cabinet"("CabinetID")
	, "Email" VARCHAR(100) NOT NULL
)