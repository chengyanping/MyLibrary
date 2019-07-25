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

--读者类型
create table T_ReaderType
(
	ReaderTypeId	int  identity(1,1) primary key,
	ReaderTypeName  char(16) not null unique,	--读者类型名称
	CanBorrowQty	int,		--能借的书数量，默认2本	
	CanBorrowDay	int,		--能借的天数
	CanContinueTimes	int,	--能续借几次
	PunishRate		float,		--罚款比列
	BookTypeId		int,	--书籍类型，暂时不用
	
)
--用户
create table T_User
(
	UserId	int primary key identity(1,1), --读者编号
	ReaderTypeId	int references T_ReaderType(ReaderTypeId),
	ReaderName	varchar(32),
	ReaderSex	char(2),
	ReaderPhone	char(32),
	ReaderEmail	char(32),
	ReaderStatus	int, --读者状态
	ReaderPwd		char(32), --读者密码
	ReaderPhoto		char(256) , --读者照片
	ReaderDate	datetime,  --注册日期
	LastLogin	datetime,	--上次登录时间
	IsAdmin		int --是否为管理员

)

--日志
create table T_UserLog
(
	UserLogId int identity(1,1) primary key,
	UserId	int references T_User(UserId), --读者编号
	UserName	varchar(32), --用户名称
	AddDate		DateTime, --日志添加时间
	Content		varchar(1024), --日志内容

)

--找回密码
create table T_GetPwd
(
	GetPwdId	int identity(1,1) primary key,
	UserId	int references T_User(UserId), --读者编号
	Guid		varchar(128), --唯一表示	
	AddDate		DateTime, --添加时间
	ExpireDate	DateTime, --过期时间
	State		int, --有效状态	
)




--图书类别
create table T_Category
(
	CategoryId	int identity(1,1) primary key,
	Name	char(32), --类型名称
	AddDate			datetime, --添加时间
	PinYin			char(32), --拼音
	State int	, --状态
	
)

--图书
create table T_Book
(
	BookId	int identity(1,1) primary key, --
	ISBN13	char(13), --索书号
	BookName varchar(128),	--书名
	BookPublisher	varchar(128), --出版社
	BookPrice	money,		--图书单价
	Pubdate	DateTime,	--出版日期
	CategoryId	int references T_Category(CategoryId),--图书分类
	Author		varchar(128), --作者
	AuthorIntro	varchar(1024), --作者简介
	BookNum		int,				--库存数量
	Summary	char(1024),			--简介
	BookCatalog		ntext,	--目录
	BookPrim	char(32),			--图书关键字
	BookRecord	datetime,		--图书登记日期
	BookCover	varchar(128),			--图书封面
	Pages		int ,		--页数
	
)


--评论
create table T_Comment
(
	CommentId int identity(1,1) primary key,
	UserId	int references T_User(UserId),
	BookId  int references T_Book(BookId),
	Content varchar(1024),
	AddDate datetime,
	Floor int,
	ReadCount int , --阅读次数
	LikeCount int , --点赞字数
	HateCount int , --反对次数



)

--借阅记录
create table T_BorrowedRecord
(
	BorrowedRecordId	int primary key,
	BookId	 int references T_Book(BookId),
	UserId	int references T_User(UserId), --读者编号
	BookName  varchar(128), --图书名
	OutDate		datetime , --借阅时间
	InDate		datetime,	--预期归还时间
	Status		int, --是否还书
	IsRenewCount	int , --续借几次

)

--我的收藏
create table  T_Favorite
(
	FavoriteId	int primary key,
	BookId	int references T_Book(BookId),
	UserId	int references T_User(UserId), --读者编号
	BookName  varchar(128), --图书名	

)






--还书记录
create table T_ReturnRecord
(
	
	BorrowedRecordId	int  primary key references  T_BorrowedRecord(BorrowedRecordId) ,
	BookId	 int references T_Book(BookId),
	UserId	int references T_User(UserId), --读者编号
	BookName  varchar(128), --图书名
	OutDate		datetime , --借阅时间
	InDate		datetime,	--预归还时间
	
)

--预定记录
create table T_Reserved
(
	ReservedId int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	UserId	int references T_User(UserId), --读者编号
	BookName  varchar(128), --图书名
	ReservedDate datetime,
	IsSatisfy	int, --是否能借
)	


--罚款信息
create table T_Fine
(
	FineId	int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	UserId	int references T_User(UserId), --读者编号
	BookName	varchar(128),	--图书名
	BorrowedRecordId	int  references T_BorrowedRecord(BorrowedRecordId) , 
	OutDate		datetime,		--借阅时间
	InDate		datetime,		--归还时间
	--OverDate	int,		--超期天数
	Fine		money,		--罚款金额
	FineCause	int,		--罚款原因
	CLState		int,		--处理状态
)

ALTER DATABASE MyLibraryDB
COLLATE Chinese_PRC_CI_AS

insert into T_Category(Name,AddDate,State,PinYin) values('科幻',getDate(),1,'kehuan');
insert into T_Category(Name,AddDate,State,PinYin) values('社科',getDate(),1,'sheke');
insert into T_Category(Name,AddDate,State,PinYin) values('自然',getDate(),1,'ziran');
insert into T_Category(Name,AddDate,State,PinYin) values('爱情',getDate(),1,'aiqing');

select * from T_Category

delete from T_Book;
insert into T_Book(ISBN13,BookName,Pages,BookRecord,BookNum,Pubdate,BookPrice,CategoryId,BookCover_Large,BookCover_Small,Author) values('skdf','西游记',0,getdate(),0,getdate(),11,1,'http://localhost:9812/Images/WeiXin/1_small.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg','老舍');

select * from T_Book



---注意
1、实体类加入virtual

修改实体类  T_book




