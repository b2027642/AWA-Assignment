CREATE TABLE [b2027642].[Applicant] (
    [ApplicantId]          INT           IDENTITY (1, 1) NOT NULL,
    [ApplicantName]       NVARCHAR (50)  NOT NULL,
    [ApplicantAddress]      NVARCHAR (50) NOT NULL,
    [Phone]  NVARCHAR (50) NOT NULL,
    [Email]  NVARCHAR (50)      NOT NULL,
    [UserId]     NVARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([ApplicantId] ASC)
);