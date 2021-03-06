USE [MafieBlog]
GO
/****** Object:  Table [dbo].[blog_article]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[blog_article](
	[article_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NOT NULL,
	[text] [text] NOT NULL,
	[description] [varchar](1000) NOT NULL,
	[post_date] [date] NOT NULL,
	[image_name] [varchar](100) NULL,
	[category_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[comment_count] [int] NULL,
 CONSTRAINT [PK_blog_article] PRIMARY KEY CLUSTERED 
(
	[article_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[blog_category]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[blog_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[identificator] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NOT NULL,
 CONSTRAINT [PK_blog_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[blog_comment]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[blog_comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[comment_date] [date] NOT NULL,
	[comment] [varchar](500) NOT NULL,
	[article_id] [int] NOT NULL,
 CONSTRAINT [PK_blog_comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[blog_role]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[blog_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[identificator] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_blog_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[blog_user]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[blog_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_blog_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[blog_article] ON 

INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (1, N'Sicilská mafie', N'Je opravdu kruta', N'Tvrdý hoši', CAST(N'2015-02-03' AS Date), NULL, 3, 1, 0)
INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (2, N'Americká mafie', N'Základnou organizačnou jednotkou je rodina (angl. family),[pozn 1] ktorá operuje buď na istom území (najmä mesta alebo štátu) alebo určitých aktivitách (hazardné hry, ilegálne drogy, úžerníctvo a pod.).

Operácie rodiny sú vykonávané skupinami (ang. crew, tal. regime) pozostávajúcimi z vojakov a spolupracovníkov. Skupiny obvykle pôsobia samostatne, pod vedením kapitána (tal. caporegime, skrátene capo, ang. captain, skipper), ktorého členovia skupiny pravidelne informujú a ktorý odsúhlasuje ich operácie.[1] Spolupracovník (ang. associate, tal. Giovane D''Honore) participuje na týchto operáciách, ale nie je riadnym členom rodiny, zatiaľ čo vojak (ang. soldier, tal. soldato) je najnižšie postaveným riadnym (prísažným) členom a dohliada na aktivity svojich spolupracovníkov.[2] Ako piciotto sa označuje nižšie postavený vojak, ktorý slúži ako vymáhač a výraz sgarrista pomenúva pešiaka, ktorý vykonáva rozkazy kapitána.[3]

Vedenie rodiny tvorí boss (šéf, tal. don, capo crimini), ktorému asistuje consigliere (poradca), často advokát alebo finančný poradca rodiny, a underboss (podšéf, tal. capo bastone, sottocapo).[2]

V roku 1931 založil boss newyorskej rodiny Genovese Lucky Luciano tzv. Komisiu (ang. The Commission), ktorá mala slúžiť ako orgán na urovnávanie sporov medzi jednotlivými rodinami, rozdelenie území pôsobnosti rodín, rokovanie s ostatnými kriminálnymi organizáciami a pod.[4]', N'Objavila sa v meste New York počas 19. storočia po vlnách prisťahovalectva z Talianska a Sicílie. Má korene v sicílskej mafii, ale je to samostatná organizácia v Amerike po veľa rokov. Dnes taliansko-americká mafia spolupracuje v rôznych trestných činnostiach spolu so sicílskou mafiou a inými talianskymi skupinami organizovaného zločinu, ako Camorra a ’Ndrangheta. V meste New York dodnes existujú mafiánske rodiny, známe tiež pod pojmom Five Families (slovensky Päť rodín). Sú to rodiny Gambino, Lucchese, Genovese, Bonanno a Colombo.', CAST(N'2014-01-01' AS Date), NULL, 1, 1, 2)
INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (3, N'Jakuza', N'Klucjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj', N'Kluci z japonska', CAST(N'2012-02-03' AS Date), NULL, 4, 2, 0)
INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (5, N'Novy7', N'<p>wwww</p>', N'<p>www</p>', CAST(N'2015-05-10' AS Date), NULL, 4, 1, 0)
INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (6, N'wwwwwwwwww', N'<p>eeeeeeeeeeeeee</p>', N'<p>wwwwwwwwwwwwwwww</p>', CAST(N'2015-05-10' AS Date), NULL, 5, 2, 0)
INSERT [dbo].[blog_article] ([article_id], [title], [text], [description], [post_date], [image_name], [category_id], [user_id], [comment_count]) VALUES (8, N'Velke neštěstí v Berlíně', N'<p>Současn&aacute; Jakuza, resp. jej&iacute; členov&eacute;, se děl&iacute; do tř&iacute; hlavn&iacute;ch kategori&iacute;:</p>
<p>Překupn&iacute;ci a gambleři maj&iacute; sv&eacute; kořeny v, gangsteři zač&iacute;naj&iacute; ps&aacute;t svoji historii až po <a title="Druh&aacute; světov&aacute; v&aacute;lka" href="http://cs.wikipedia.org/wiki/Druh%C3%A1_sv%C4%9Btov%C3%A1_v%C3%A1lka">2. světov&eacute; v&aacute;lce</a>, s extr&eacute;mn&iacute;m n&aacute;růstem čern&eacute;ho trhu. Tradičně <em>tekija</em>, původně středověc&iacute; podvodn&iacute;ci, obstar&aacute;vali lup od prodavačů, <em>bakuto</em> zase loupili ve městech a přepad&aacute;vali na cest&aacute;ch. <em>Gurentai</em> se vyprofilovali podle vzorů <a title="Al Capone" href="http://cs.wikipedia.org/wiki/Al_Capone">Al Caponeho</a>. Po 2. světov&eacute; v&aacute;lce, kdy byla &uacute;ředn&iacute; moc pod palcem americk&yacute;ch okupantů, gurentai velmi prosperovali a posilovali svoje společensk&eacute; pozice. Podařilo se jim pov&yacute;&scaron;it japonsk&yacute; zločin na dal&scaron;&iacute; &uacute;roveň n&aacute;sil&iacute;. Svoje meče postupně vyměnili za paln&eacute; zbraně.</p>', N'<h1>ppppppppppppppppp</h1>', CAST(N'2015-05-10' AS Date), NULL, 3, 1, 2)
SET IDENTITY_INSERT [dbo].[blog_article] OFF
SET IDENTITY_INSERT [dbo].[blog_category] ON 

INSERT [dbo].[blog_category] ([category_id], [identificator], [name], [description]) VALUES (1, N'americka_mafie', N'Americká mafie', N'Mafie v americe rozkvétala ve 30. letech')
INSERT [dbo].[blog_category] ([category_id], [identificator], [name], [description]) VALUES (2, N'ceska_mafie', N'Česká mafie', N'Česká mafie')
INSERT [dbo].[blog_category] ([category_id], [identificator], [name], [description]) VALUES (3, N'italska_mafie', N'Italská mafie', N'Sekce italska mafie')
INSERT [dbo].[blog_category] ([category_id], [identificator], [name], [description]) VALUES (4, N'jakuza', N'Jakuza', N'Japonská mafie')
INSERT [dbo].[blog_category] ([category_id], [identificator], [name], [description]) VALUES (5, N'ruska_mafie', N'Ruská mafie', N'Sekce ruska mafie')
SET IDENTITY_INSERT [dbo].[blog_category] OFF
SET IDENTITY_INSERT [dbo].[blog_comment] ON 

INSERT [dbo].[blog_comment] ([comment_id], [name], [email], [comment_date], [comment], [article_id]) VALUES (1, N'Petra', N'petra@seznam.cz', CAST(N'2015-05-02' AS Date), N'jejda', 2)
INSERT [dbo].[blog_comment] ([comment_id], [name], [email], [comment_date], [comment], [article_id]) VALUES (2, N'Pavel', N'pavel@seznam.cz', CAST(N'2015-05-04' AS Date), N'hmmmmmm', 2)
INSERT [dbo].[blog_comment] ([comment_id], [name], [email], [comment_date], [comment], [article_id]) VALUES (10, N'sim', N'SED', CAST(N'2015-02-04' AS Date), N'RRR', 8)
INSERT [dbo].[blog_comment] ([comment_id], [name], [email], [comment_date], [comment], [article_id]) VALUES (12, N'www', N'ttt', CAST(N'2015-02-03' AS Date), N'rrr', 8)
SET IDENTITY_INSERT [dbo].[blog_comment] OFF
SET IDENTITY_INSERT [dbo].[blog_role] ON 

INSERT [dbo].[blog_role] ([role_id], [identificator], [description]) VALUES (1, N'admin', N'Admin')
INSERT [dbo].[blog_role] ([role_id], [identificator], [description]) VALUES (2, N'redaktor', N'Redaktor')
SET IDENTITY_INSERT [dbo].[blog_role] OFF
SET IDENTITY_INSERT [dbo].[blog_user] ON 

INSERT [dbo].[blog_user] ([user_id], [name], [surname], [email], [login], [password], [role_id], [active]) VALUES (1, N'Pepa', N'Velky', N'pepa@seznam.cz', N'pepa', N'pepa', 1, 1)
INSERT [dbo].[blog_user] ([user_id], [name], [surname], [email], [login], [password], [role_id], [active]) VALUES (2, N'Pave', N'Smutny', N'pavel@seznam.cz', N'pavel', N'pavel', 2, 1)
INSERT [dbo].[blog_user] ([user_id], [name], [surname], [email], [login], [password], [role_id], [active]) VALUES (5, N'Josef', N'Jirka', N'jirka@seznam.cz', N'joska', N'9bO8QUz6TI9VLqs1McROP3Bd4hePS4ocvwEj8Yhu+PI=', 2, 0)
INSERT [dbo].[blog_user] ([user_id], [name], [surname], [email], [login], [password], [role_id], [active]) VALUES (6, N'Josef', N'Jirka', N'jirka@seznam.cz', N'joska', N'9Pj0TmmnJhn/P5vcPuufaXrguqXCqSP0qrYp7WqJK3I=', 2, 1)
INSERT [dbo].[blog_user] ([user_id], [name], [surname], [email], [login], [password], [role_id], [active]) VALUES (7, N'Eva', N'Mala', N'eva@seznam.cz', N'eva', N'eva1', 1, 1)
SET IDENTITY_INSERT [dbo].[blog_user] OFF
ALTER TABLE [dbo].[blog_comment]  WITH CHECK ADD  CONSTRAINT [FK_blog_comment_blog_article] FOREIGN KEY([article_id])
REFERENCES [dbo].[blog_article] ([article_id])
GO
ALTER TABLE [dbo].[blog_comment] CHECK CONSTRAINT [FK_blog_comment_blog_article]
GO
ALTER TABLE [dbo].[blog_user]  WITH CHECK ADD  CONSTRAINT [FK_blog_user_blog_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[blog_role] ([role_id])
GO
ALTER TABLE [dbo].[blog_user] CHECK CONSTRAINT [FK_blog_user_blog_role]
GO
/****** Object:  Trigger [dbo].[pocetKomentaru]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery10.sql|7|0|C:\Users\Franta\AppData\Local\Temp\~vs3C35.sql
CREATE TRIGGER [dbo].[pocetKomentaru]
ON [dbo].[blog_comment]
AFTER INSERT
AS 
UPDATE blog_article
SET
comment_count = (SELECT COUNT(*) FROM blog_comment WHERE blog_article.article_id = blog_comment.article_id);

GO
/****** Object:  Trigger [dbo].[pocetKomentaruOdebrat]    Script Date: 18.5.2015 12:41:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[pocetKomentaruOdebrat]
ON [dbo].[blog_comment]
AFTER DELETE
AS 
UPDATE blog_article
SET
comment_count = (SELECT COUNT(*) FROM blog_comment WHERE blog_article.article_id = blog_comment.article_id);
GO
