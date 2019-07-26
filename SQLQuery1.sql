use master
go

if exists(select * from sysdatabases where name='MyLibraryDB')
begin
drop database MyLibraryDB
end
go



create database MyLibraryDB
COLLATE  Chinese_PRC_CI_AS
go


use MyLibraryDB
go

--��������
create table T_ReaderType
(
	ReaderTypeId	int  identity(1,1) primary key,
	ReaderTypeName  char(16) not null unique,	--������������
	CanBorrowQty	int,		--�ܽ����������Ĭ��2��	
	CanBorrowDay	int,		--�ܽ������
	CanContinueTimes	int,	--�����輸��
	PunishRate		float,		--�������
	BookTypeId		int,	--�鼮���ͣ���ʱ����
	
)
--�û�
create table T_User
(
	UserId	int primary key identity(1,1), --���߱��
	ReaderTypeId	int references T_ReaderType(ReaderTypeId),
	ReaderName	varchar(32),
	ReaderSex	char(2),
	ReaderPhone	char(32),
	ReaderEmail	char(32),
	ReaderStatus	int, --����״̬
	ReaderPwd		char(32), --��������
	ReaderPhoto		char(256) , --������Ƭ
	ReaderDate	datetime,  --ע������
	LastLogin	datetime,	--�ϴε�¼ʱ��
	IsAdmin		int --�Ƿ�Ϊ����Ա

)

--��־
create table T_UserLog
(
	UserLogId int identity(1,1) primary key,
	UserId	int references T_User(UserId), --���߱��
	UserName	varchar(32), --�û�����
	AddDate		DateTime, --��־���ʱ��
	Content		varchar(1024), --��־����

)

--�һ�����
create table T_GetPwd
(
	GetPwdId	int identity(1,1) primary key,
	UserId	int references T_User(UserId), --���߱��
	Guid		varchar(128), --Ψһ��ʾ	
	AddDate		DateTime, --���ʱ��
	ExpireDate	DateTime, --����ʱ��
	State		int, --��Ч״̬	
)




--ͼ�����
create table T_Category
(
	CategoryId	int identity(1,1) primary key,
	Name	char(32), --��������
	AddDate			datetime, --���ʱ��
	PinYin			char(32), --ƴ��
	State int	, --״̬
	
)

--ͼ��
create table T_Book
(
	BookId	int identity(1,1) primary key, --
	ISBN13	char(13), --�����
	BookName varchar(128),	--����
	BookPublisher	varchar(128), --������
	BookPrice	money,		--ͼ�鵥��
	Pubdate	DateTime,	--��������
	CategoryId	int references T_Category(CategoryId),--ͼ�����
	Author		varchar(128), --����
	AuthorIntro	varchar(1024), --���߼��
	BookNum		int,				--�������
	Summary	char(1024),			--���
	BookCatalog		ntext,	--Ŀ¼
	BookPrim	char(32),			--ͼ��ؼ���
	BookRecord	datetime,		--ͼ��Ǽ�����
	BookCover	varchar(128),			--ͼ�����
	Pages		int ,		--ҳ��
	
)


--����
create table T_Comment
(
	CommentId int identity(1,1) primary key,
	UserId	int references T_User(UserId),
	BookId  int references T_Book(BookId),
	Content varchar(1024),
	AddDate datetime,
	Floor int,
	ReadCount int , --�Ķ�����
	LikeCount int , --��������
	HateCount int , --���Դ���



)

--���ļ�¼
create table T_BorrowedRecord
(
	BorrowedRecordId	int primary key,
	BookId	 int references T_Book(BookId),
	UserId	int references T_User(UserId), --���߱��
	BookName  varchar(128), --ͼ����
	OutDate		datetime , --����ʱ��
	InDate		datetime,	--Ԥ�ڹ黹ʱ��
	Status		int, --�Ƿ���  0��ʾΪ�黹 1��ʾ�ѹ黹
	IsRenewCount	int , --���輸��

)

--�ҵ��ղ�
create table  T_Favorite
(
	FavoriteId	int primary key,
	BookId	int references T_Book(BookId),
	UserId	int references T_User(UserId), --���߱��
	BookName  varchar(128), --ͼ����	

)






--�����¼
create table T_ReturnRecord
(
	
	BorrowedRecordId	int  primary key references  T_BorrowedRecord(BorrowedRecordId) ,
	BookId	 int references T_Book(BookId),
	UserId	int references T_User(UserId), --���߱��
	BookName  varchar(128), --ͼ����
	OutDate		datetime , --����ʱ��
	InDate		datetime,	--Ԥ�黹ʱ��
	
)

--Ԥ����¼
create table T_Reserved
(
	ReservedId int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	UserId	int references T_User(UserId), --���߱��
	BookName  varchar(128), --ͼ����
	ReservedDate datetime,
	IsSatisfy	int, --�Ƿ��ܽ�
)	


--������Ϣ
create table T_Fine
(
	FineId	int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	UserId	int references T_User(UserId), --���߱��
	BookName	varchar(128),	--ͼ����
	BorrowedRecordId	int  references T_BorrowedRecord(BorrowedRecordId) , 
	OutDate		datetime,		--����ʱ��
	InDate		datetime,		--�黹ʱ��
	--OverDate	int,		--��������
	Fine		money,		--������
	FineCause	int,		--����ԭ��
	CLState		int,		--����״̬
)
--�Ƽ��鵥
create table T_RecommendedBook
(
	RecommendedBook int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	Description	varchar(1024), --�Ƽ�����
	AddDate		datetime,
		
)


ALTER DATABASE MyLibraryDB
COLLATE Chinese_PRC_CI_AS


--������
insert into T_Category(Name,AddDate,State,PinYin) values('�ƻ�',getDate(),1,'kehuan');
insert into T_Category(Name,AddDate,State,PinYin) values('���',getDate(),1,'sheke');
insert into T_Category(Name,AddDate,State,PinYin) values('��Ȼ',getDate(),1,'ziran');
insert into T_Category(Name,AddDate,State,PinYin) values('����',getDate(),1,'aiqing');
--����鼮��Ϣ
insert into T_Book values('12345678','ʱ���ʷ','�廪������',45,'2016/6/1',3,'����','Ӣ������ѧ��',12,null,null,null,'2019/6/30','/images/time.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg',356)

insert into T_Book values('112233445566','������','���շ������',50,'2017/6/1',2,'������������','��������׿����С˵�ҡ�ɢ�ļҺ;����ң�����������ѧ��ʦ�����ĵ���ѧ���Ĵ�������',3,'�������ˡ�����������˴���������ѧ����"����"�Ĺ���;�����˺�����ķ��룬�����������˵�ǻĵ��ġ���������ģ����˶Իĵ�����������Ϊ������˲����κ�ϣ������һ�����ﶼ�޶����ԡ�',null,null,'2019/7/1','/images/juwairen.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg',400)
insert into T_Book values('987654321','����','�廪������',35,'2018/6/1',2,'�໪','�������ҡ��й�����Э��ھŽ�ȫ��ίԱ��ίԱ',4,'�������ڴ�ʱ�������£�������ս�������巴����Ծ�����Ļ�������������츣��������ͼ�ͥ���Ͼ����ſ��ѣ���������������˶��Ⱥ�������ȥ����ʣ�����ϵ�����һͷ��ţ����Ϊ����',null,null,'2019/6/25','/images/life.png','http://localhost:9812/Images/WeiXin/1_small.jpg',400)


select top 12  * from T_Book where BookRecord>'2019/6/28'

select * from T_Category
select * from T_Book


--����û�����
insert into T_ReaderType values('��ͨ�û�',5,30,1,10.2,2)

--����û�
insert into T_User values(1,'lucy','Ů','18538003652','luo@126.com',1,'e10adc3949ba59abbe56e057f20f883e',GETDATE(),GETDATE(),null,1,1)

select * from T_User

select * from T_ReaderType


--���ļ�¼
insert into T_BorrowedRecord values(2,1,'ʱ���ʷ',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(2,1,'ʱ���ʷ',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(3,1,'������',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(6,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(6,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(9,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(9,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(13,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(13,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
											 
insert into T_BorrowedRecord values(16,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(16,1,'����',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)

select * from T_BorrowedRecord where BookId=2

insert into T_BookList values(1,'21�����ƻ�',getdate(),'21�����ʱ������21���Ķ�3����,��д�¶����',GETDATE());


---ע��
1��ʵ�������virtual

2  ���ComplexType�������GlobalConfig

3




 