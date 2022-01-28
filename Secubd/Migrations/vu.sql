IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[valEnseignant]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[valEnseignant]
as
  select e.numeroEtud,(e.nomEtud+'' ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,(es.nomEns+'' ''+es.prenomEns)  as nomEnseignant,n.codeEval,es.codeEns,ev.libelleEval,es.logEns
  from Etudiant e,Annee_Academique a,NOTER n, DISPENSER d ,Module m,Enseignant es,Evaluation ev
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  and d.codeMod = m.codeMod and es.codeEns=d.codeEns and a.libelleAnn_Ac =''2022'' and a.libelleAnn_Ac=d.libelleAnn_Ac and ev.codeEval= n.codeEval and n.valide= 0
'

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ConsEnseignantAn]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ConsEnseignantAn]
as
  select e.numeroEtud,(e.nomEtud+'' ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,(es.nomEns+'' ''+es.prenomEns)  as nomEnseignant,n.codeEval,es.codeEns,ev.libelleEval,es.logEns
  from Etudiant e,Annee_Academique a,NOTER n, DISPENSER d ,Module m,Enseignant es,Evaluation ev
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  and d.codeMod = m.codeMod and es.codeEns=d.codeEns and a.libelleAnn_Ac =''2022'' and a.libelleAnn_Ac=d.libelleAnn_Ac and ev.codeEval= n.codeEval and n.valide= 1
'



IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ConsEnseignant]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ConsEnseignant]
as
  select e.numeroEtud,(e.nomEtud+'' ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,n.codeEval
  from Etudiant e,Annee_Academique a,NOTER n, DISPENSER d ,Module m
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  and d.codeMod = m.codeMod  and a.libelleAnn_Ac !=''2022'' and a.libelleAnn_Ac=d.libelleAnn_Ac

'
 

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ConsDGCh]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ConsDGCh]
as
  select e.numeroEtud,(e.nomEtud+''  ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,n.codeEval
  from Etudiant e,NOTER n ,Module m
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  
'


IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[valCh]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[valCh]
as
  select e.numeroEtud,(e.nomEtud+''  ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,n.codeEval
  from Etudiant e,NOTER n ,Module m,DISPENSER d ,Annee_Academique a
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  and m.codeMod=d.codeMod and d.libelleAnn_Ac=a.libelleAnn_Ac  and a.libelleAnn_Ac=''2022'' and n.valide=0
 
'

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[valDg]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[valDg]
as
  select e.numeroEtud,(e.nomEtud+''  ''+e.prenomEtud)  as nomETudiant,e.codePar,m.nomMod,n.dateEval,n.note,n.codeMod,n.codeEval
  from Etudiant e,NOTER n ,Module m,DISPENSER d ,Annee_Academique a
  where e.numeroEtud= n.numeroEtud and n.codeMod= m.codeMod  and m.codeMod=d.codeMod and d.libelleAnn_Ac=a.libelleAnn_Ac  and a.libelleAnn_Ac=''2022'' 
 
'

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[notemodeval]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[notemodeval]
as
	select distinct	p.numeroEtud, p.codeMod , p.est_requis , (d.mo+t.mo+p.mo)  as moyN ,(d.mo+t.mo+R.mo) as moyR,p.codeNiv
	from 
	(select distinct n.numeroEtud, n.codeMod , m.est_requis ,(n.note * e.pourcentage)/100 as mo,m.codeNiv
	from  NOTER n , Module m , Evaluation e
	where n.codeEval= e.codeEval and n.codeMod= m.codeMod and e.codeEval= ''Dev1''
	) d,
	(select distinct n.numeroEtud, n.codeMod , m.est_requis ,(n.note * e.pourcentage)/100 as mo,m.codeNiv
	from  NOTER n , Module m , Evaluation e
	where n.codeEval= e.codeEval and n.codeMod= m.codeMod and e.codeEval= ''Rat''
	) R,
	(select distinct n.numeroEtud, n.codeMod , m.est_requis ,(n.note * e.pourcentage)/100 as mo,m.codeNiv
	from  NOTER n , Module m , Evaluation e
	where n.codeEval= e.codeEval and n.codeMod= m.codeMod and e.codeEval= ''TP''
	) t,
	(select distinct n.numeroEtud, n.codeMod , m.est_requis ,(n.note * e.pourcentage)/100 as mo,m.codeNiv
	from  NOTER n , Module m , Evaluation e
	where n.codeEval= e.codeEval and n.codeMod= m.codeMod and e.codeEval= ''Part''
	) p
	where d.numeroEtud=t.numeroEtud and d.numeroEtud= p.numeroEtud and p.numeroEtud=t.numeroEtud and R.numeroEtud= p.numeroEtud and R.numeroEtud=d.numeroEtud and R.numeroEtud= t.numeroEtud
	and	  d.codeMod=t.codeMod       and d.codeMod= p.codeMod       and p.codeMod=t.codeMod       and R.codeMod=p.codeMod		and R.codeMod=d.codeMod		  and R.codeMod=t.codeMod  
'
