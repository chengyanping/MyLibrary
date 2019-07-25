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
	Status		int, --�Ƿ���
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

ALTER DATABASE MyLibraryDB
COLLATE Chinese_PRC_CI_AS

insert into T_Category(Name,AddDate,State,PinYin) values('�ƻ�',getDate(),1,'kehuan');
insert into T_Category(Name,AddDate,State,PinYin) values('���',getDate(),1,'sheke');
insert into T_Category(Name,AddDate,State,PinYin) values('��Ȼ',getDate(),1,'ziran');
insert into T_Category(Name,AddDate,State,PinYin) values('����',getDate(),1,'aiqing');

select * from T_Category

delete from T_Book;
insert into T_Book(ISBN13,BookName,Pages,BookRecord,BookNum,Pubdate,BookPrice,CategoryId,BookCover_Large,BookCover_Small,Author) values('skdf','���μ�',0,getdate(),0,getdate(),11,1,'http://localhost:9812/Images/WeiXin/1_small.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg','����');

select * from T_Book



---ע��
1��ʵ�������virtual

�޸�ʵ����  T_book




