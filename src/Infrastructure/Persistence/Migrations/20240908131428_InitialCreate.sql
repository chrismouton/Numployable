CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory"
(
    "MigrationId"
    character
    varying
(
    150
) NOT NULL,
    "ProductVersion" character varying
(
    32
) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY
(
    "MigrationId"
)
    );

START TRANSACTION;

CREATE TABLE "Commute"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "Commute_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "NextActionType"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "NextActionType_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "ProcessStatus"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "ProcessStatus_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "RoleType"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "RoleType_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "Source"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "Source_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "Status"
(
    "Id"          int                    NOT NULL,
    "Description" character varying(100) NOT NULL,
    CONSTRAINT "Status_PRIMARY" PRIMARY KEY ("Id")
);

CREATE TABLE "JobApplication"
(
    "Id"               int GENERATED BY DEFAULT AS IDENTITY,
    "RoleName"         character varying(255) NOT NULL,
    "CompanyName"      character varying(255) NOT NULL,
    "RoleTypeId"       int                    NOT NULL,
    "StatusId"         int                    NOT NULL,
    "ProcessStatusId"  int                    NOT NULL,
    "SourceId"         int                    NOT NULL,
    "AdvertisedSalary" character varying(255),
    "Url"              character varying(1024),
    "Location"         character varying(255),
    "CommuteId"        int,
    "ApplicationDate"  date                   NOT NULL,
    "Note"             character varying(1024),
    CONSTRAINT "JobApplication_PRIMARY" PRIMARY KEY ("Id"),
    CONSTRAINT "JobApplication_Commute_FK" FOREIGN KEY ("CommuteId") REFERENCES "Commute" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "JobApplication_ProcessStatus_FK" FOREIGN KEY ("ProcessStatusId") REFERENCES "ProcessStatus" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "JobApplication_RoleType_FK" FOREIGN KEY ("RoleTypeId") REFERENCES "RoleType" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "JobApplication_Source_FK" FOREIGN KEY ("SourceId") REFERENCES "Source" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "JobApplication_Status_FK" FOREIGN KEY ("StatusId") REFERENCES "Status" ("Id") ON DELETE RESTRICT
);

CREATE TABLE "NextAction"
(
    "Id"               int GENERATED BY DEFAULT AS IDENTITY,
    "NextActionTypeId" int                    NOT NULL,
    "ActionNote"       character varying(255) NOT NULL,
    "ActionDate"       timestamp              NOT NULL,
    "JobApplicationId" int                    NOT NULL,
    CONSTRAINT "NextAction_PRIMARY" PRIMARY KEY ("Id"),
    CONSTRAINT "NextAction_JobApplication_FK" FOREIGN KEY ("JobApplicationId") REFERENCES "JobApplication" ("Id") ON DELETE RESTRICT,
    CONSTRAINT "NextAction_NextActionType_FK" FOREIGN KEY ("NextActionTypeId") REFERENCES "NextActionType" ("Id") ON DELETE RESTRICT
);

INSERT INTO "Commute" ("Id", "Description")
VALUES (1, 'On-site');
INSERT INTO "Commute" ("Id", "Description")
VALUES (2, 'Remote');
INSERT INTO "Commute" ("Id", "Description")
VALUES (3, 'Hybrid');

INSERT INTO "NextActionType" ("Id", "Description")
VALUES (1, 'Suggest time slots');
INSERT INTO "NextActionType" ("Id", "Description")
VALUES (2, 'Initial call');
INSERT INTO "NextActionType" ("Id", "Description")
VALUES (3, 'Interview');

INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (1, 'Applied');
INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (2, 'Interviewing');
INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (3, 'Waiting response');
INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (4, 'Offer received');
INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (5, 'Hired');
INSERT INTO "ProcessStatus" ("Id", "Description")
VALUES (6, 'Rejected');

INSERT INTO "RoleType" ("Id", "Description")
VALUES (1, 'Permanent');
INSERT INTO "RoleType" ("Id", "Description")
VALUES (2, 'Contract');
INSERT INTO "RoleType" ("Id", "Description")
VALUES (3, 'Part time');
INSERT INTO "RoleType" ("Id", "Description")
VALUES (4, 'Fixed-term contract');

INSERT INTO "Source" ("Id", "Description")
VALUES (1, 'Job board');
INSERT INTO "Source" ("Id", "Description")
VALUES (2, 'Networking');
INSERT INTO "Source" ("Id", "Description")
VALUES (3, 'Recruiter contact');
INSERT INTO "Source" ("Id", "Description")
VALUES (4, 'Recruiting site');

INSERT INTO "Status" ("Id", "Description")
VALUES (1, 'Active');
INSERT INTO "Status" ("Id", "Description")
VALUES (2, 'Expired');
INSERT INTO "Status" ("Id", "Description")
VALUES (3, 'Closed');

CREATE UNIQUE INDEX "Commute_UNIQUE" ON "Commute" ("Description");

CREATE INDEX "JobApplication_Commute_FK" ON "JobApplication" ("CommuteId");

CREATE INDEX "JobApplication_ProcessStatus_FK" ON "JobApplication" ("ProcessStatusId");

CREATE INDEX "JobApplication_RoleType_FK" ON "JobApplication" ("RoleTypeId");

CREATE INDEX "JobApplication_Source_FK" ON "JobApplication" ("SourceId");

CREATE INDEX "JobApplication_Status_FK" ON "JobApplication" ("StatusId");

CREATE INDEX "NextAction_JobApplication_FK" ON "NextAction" ("JobApplicationId");

CREATE INDEX "NextAction_NextActionType_FK" ON "NextAction" ("NextActionTypeId");

CREATE UNIQUE INDEX "NextActionType_UNIQUE" ON "NextActionType" ("Description");

CREATE UNIQUE INDEX "ApplicationProcessStatus_UNIQUE" ON "ProcessStatus" ("Description");

CREATE UNIQUE INDEX "RoleType_UNIQUE" ON "RoleType" ("Description");

CREATE UNIQUE INDEX "Source_UNIQUE" ON "Source" ("Description");

CREATE UNIQUE INDEX "ApplicationStatus_UNIQUE" ON "Status" ("Description");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240908131428_InitialCreate', '8.0.8');

COMMIT;