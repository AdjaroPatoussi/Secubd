CREATE OR ALTER TRIGGER tg_miseAjourModule
ON  MODULE
AFTER INSERT,Delete 
AS
BEGIN
	DECLARE @module varchar(10)
	DECLARE @niveau varchar(10)


	IF EXISTS ( SELECT * FROM Deleted )
        BEGIN
			SELECT @niveau = codeNiv
			FROM deleted
		end
	else
		begin
			SELECT @niveau = codeNiv
			FROM inserted
		end


	select @module = COUNT(codeMod)
	from Module
	where @niveau= codeNiv

	update Niveau
     set nbreModule=@module
   where codeNiv= @niveau

END

go

CREATE OR ALTER TRIGGER tgVerificationEtudiantAge
ON Inscrire
INSTEAD OF insert,update
AS
BEGIN	
		DECLARE @CodeNiv VARCHAR(10)
		select  @CodeNiv = a.codeNiv  from inserted a

		DECLARE @lib VARCHAR(10)

		select @lib= n.libelleNiv from Niveau n where n.codeNiv = @CodeNiv

		if(@lib = 'L1AS' or @lib = 'L1GL')
		begin
			DECLARE @CodeEtu VARCHAR(10)
			select  @CodeEtu = a.codeEtud  from inserted a

			DECLARE @date datetime
			select @date = dateNaissance from Etudiant e where e.numeroEtud =@CodeEtu
			--IF (  datepart(( CONVERT (date, GETDATE())) - DATEPART(@date) ) >= 17 and (CONVERT (date, GETDATE()) - @date ) <= 23)
			IF (  (GETDATE() - @date)  >= 17 and ( GETDATE()- @date ) <= 23)
				BEGIN
		

					  INSERT  INTO Inscrire(codeClass ,codeEtud ,codeNiv,libelleAnn_Ac)
										SELECT  D.codeClass,
												D.codeEtud,
												D.codeNiv,
												D.libelleAnn_Ac
										FROM    Inserted D


					end
			end
        else
            begin
                 INSERT  INTO Inscrire(codeClass ,codeEtud ,codeNiv,libelleAnn_Ac)
										SELECT  D.codeClass,
												D.codeEtud,
												D.codeNiv,
												D.libelleAnn_Ac
										FROM    Inserted D

            end
END

GO



CREATE OR ALTER TRIGGER tg_MiseAjourNote
ON  Inscrire
AFTER INSERT 
AS
BEGIN
	DECLARE @numEtu  varchar(max)
	declare @niveau	 varchar(max)
	declare @mod	 varchar(max)
	SELECT @numEtu = codeEtud,@niveau = codeNiv
	FROM inserted

  DECLARE Curseur CURSOR FOR SELECT distinct codeMod   FROM  Module m  where m.codeNiv= @niveau
  OPEN Curseur
  FETCH Curseur INTO @mod
  WHILE(@@FETCH_STATUS=0)
		BEGIN
        	
				insert into  NOTER (numeroEtud,codeMod,codeEval, note,valide ,dateEval)values
				(@numEtu,@mod,'Dev1',0,0,GETDATE()),
				(@numEtu,@mod,'TP',0,0,GETDATE()),
				(@numEtu,@mod,'Part',0,0,GETDATE()),
				(@numEtu,@mod,'Rat',0,0,GETDATE());
            
                FETCH  Curseur INTO @mod
            End
	        CLOSE Curseur
	        DEALLOCATE Curseur
        

END

go

insert into Evaluation values	('Dev1', 'Premier devoir', '25'),
								('TP', 'Travaux pratique', '15'),
								('Part', 'Partiel', '60'),
								('Rat', 'Rattrapage', '60');
go
insert into Annee_Academique values ('2020'),
									('2021'),
									('2017'),
									('2019'),
									('2018');
go
insert into Parcours values ('GLSI', 'Programmation'),
							('ASR', 'R�seaux');


							go


insert into Niveau values ('L1GL','L1prog',2,'GLSI'),
						  ('L2GL','L2prog',2,'GLSI'),
						  ('L3GL','L3prog',2,'GLSI'),
						  ('L1AS','L1r�seaux',2,'ASR'),
						  ('L2AS','L2r�seaux',2,'ASR'),
						  ('L3AS','L3r�seaux',2,'ASR');

						  go
INSERT INTO [dbo].[Classe]
           ([codeClass],[codeNiv],[libelleClass],[capacite])
     VALUES
           ('L1AGL','L1GL','licence1',50),
		   ('L1BGL','L1GL','licence1',50),
		   ('L2AGL','L2GL','licence1',50),
		   ('L2BGL','L2GL','licence1',50),
		   ('L3AGL','L3GL','licence1',50),
		   ('L3BGL','L3GL','licence1',50),
		   ('L1AAS','L1AS','licence1',50),
		   ('L1BAS','L1AS','licence1',50),
		   ('L2AAS','L2AS','licence1',50),
		   ('L2BAS','L2AS','licence1',50),
		   ('L3AAS','L3AS','licence1',50),
		   ('L3BAS','L3AS','licence1',50);
GO


insert into Module values ('algo12','initiation aux algos',4,1,'L1GL'),
						  ('electro12','�lectronique num�rique',3,0,'L1GL'),
						  ('java','initiation � la programmation java',4,0,'L2GL'),
						  ('poo',' poo avanc�e',3,0,'L2GL');
						  go
insert into Etudiant values('1','wilson','amewo','M',02-01-2000,'GLSI'),
						   ('2','AGBEGBO','ESPOIR','M',17-06-2001,'GLSI'),
						   ('3','AKOTI','STEAVEN','M',03-05-2002,'GLSI'),
						   ('4','AWILON','ESSO','F',15-11-2000,'GLSI'),
						   ('5','PEPEYI','GODWIN','M',18-05-2000,'GLSI');
                        go

INSERT INTO [dbo].[Inscrire]
           ([codeClass]
           ,[codeEtud]
           ,[codeNiv]
           ,[libelleAnn_Ac])
     VALUES
           ('L2AGL',1,'L2GL','2021')
		   go


create or ALTER   TRIGGER CopieUsers
ON AspNetUsers
FOR INSERT
AS
BEGIN
	DECLARE @id nvarchar(128), @mail nvarchar(256), @nom nvarchar(256),
	@prenom nvarchar(256),
	@grade int, 
	@anne datetime

	SELECT @id = Id, @mail = Email, @grade = grade, @prenom = prenomEns, @nom = nomEns,@anne = anneePriseFonction
	FROM inserted

	INSERT INTO Enseignant
	values(@id, @nom,@prenom,@grade,@anne,@mail)

	declare @rid nvarchar(128)

	select @rid=Id
	from AspNetRoles
	where Name = 'Enseignant'

	INSERT INTO AspNetUserRoles
	values (@id, @rid)
END

