SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalHistoryResult](
	[MedicalHistoryResultId] [uniqueidentifier] NOT NULL,
	[MedicalHistoryId] [uniqueidentifier] NOT NULL,
	[DateCompleted] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ChestXRay] [int] NOT NULL,
	[ChestXRayDetails] [nvarchar](max) NOT NULL,
	[ColumnXRay] [int] NOT NULL,
	[ColumnXRayDetails] [nvarchar](max) NOT NULL,
	[Laboratory] [int] NOT NULL,
	[LaboratoryDetails] [nvarchar](max) NOT NULL,
	[Electrocardiogram] [int] NOT NULL,
	[ElectrocardiogramDetails] [nvarchar](max) NOT NULL,
	[Audiometry] [int] NOT NULL,
	[AudiometryDetails] [nvarchar](max) NOT NULL,
	[Spirometry] [int] NOT NULL,
	[SpirometryDetails] [nvarchar](max) NOT NULL,
	[PsychologicalExam] [int] NOT NULL,
	[PsychologicalExamDetails] [nvarchar](max) NOT NULL,
	[Electroencephalogram] [int] NOT NULL,
	[ElectroencephalogramDetails] [nvarchar](max) NOT NULL,
	[Ergometry] [int] NOT NULL,
	[ErgometryDetails] [nvarchar](max) NOT NULL,
	[Ophthalmology] [int] NOT NULL,
	[OphthalmologyDetails] [nvarchar](max) NOT NULL,
	[NeurologicalConsultation] [int] NOT NULL,
	[NeurologicalDetails] [nvarchar](max) NOT NULL,
	[CardiologyConsultation] [int] NOT NULL,
	[CardiologyDetails] [nvarchar](max) NOT NULL,
	[NeumonologyConsultation] [int] NOT NULL,
	[NeumonologyDetails] [nvarchar](max) NOT NULL,
	[MagneticResonance] [int] NOT NULL,
	[MagneticResonanceDetails] [nvarchar](max) NOT NULL,
	[Ultrasound] [int] NOT NULL,
	[UltrasoundDetails] [nvarchar](max) NOT NULL,	
	[VestibularExam] [int] NOT NULL,
	[VestibularExamDetails] [nvarchar](max) NOT NULL,
	[Dental] [int] NOT NULL,
	[DentalDetails] [nvarchar](max) NOT NULL,
	[ORL] [int] NOT NULL,
	[ORLDetails] [nvarchar](max) NOT NULL,
	[Others] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MedicalHistoryResult] PRIMARY KEY CLUSTERED 
(
	[MedicalHistoryResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[MedicalHistoryResult]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryResult_MedicalHistory] FOREIGN KEY([MedicalHistoryId])
REFERENCES [dbo].[MedicalHistory] ([MedicalHistoryId])
GO
ALTER TABLE [dbo].[MedicalHistoryResult] CHECK CONSTRAINT [FK_MedicalHistoryResult_MedicalHistory]
GO
ALTER TABLE [dbo].[MedicalHistoryResult]  WITH CHECK ADD  CONSTRAINT [FK_MedicalHistoryResult_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[MedicalHistoryResult] CHECK CONSTRAINT [FK_MedicalHistoryResult_User]
GO
