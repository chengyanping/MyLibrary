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
	Status		int, --是否还书  0表示为归还 1表示已归还
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
--推荐书单
create table T_RecommendedBook
(
	RecommendedBook int identity(1,1) primary key,
	BookID	int references T_Book(BookId),
	Description	varchar(1024), --推荐理由
	AddDate		datetime,
		
)


ALTER DATABASE MyLibraryDB
COLLATE Chinese_PRC_CI_AS


--添加类别
insert into T_Category(Name,AddDate,State,PinYin) values('科幻',getDate(),1,'kehuan');
insert into T_Category(Name,AddDate,State,PinYin) values('社科',getDate(),1,'sheke');
insert into T_Category(Name,AddDate,State,PinYin) values('自然',getDate(),1,'ziran');
insert into T_Category(Name,AddDate,State,PinYin) values('爱情',getDate(),1,'aiqing');
--添加书籍信息
insert into T_Book values('12345678','时间简史','清华出版社',45,'2016/6/1',3,'霍金','英国物理学家',12,null,null,null,'2019/6/30','/images/time.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg',356)

insert into T_Book values('112233445566','局外人','江苏凤凰文艺',50,'2017/6/1',2,'阿尔贝·加缪','法国声名卓著的小说家、散文家和剧作家，存在主义文学大师，“荒诞哲学”的代表人物',3,'《局外人》形象地体现了存在主义哲学关于"荒谬"的观念;由于人和世界的分离，世界对于人来说是荒诞的、毫无意义的，而人对荒诞的世界无能为力，因此不抱任何希望，对一切事物都无动于衷。',null,null,'2019/7/1','/images/juwairen.jpg','http://localhost:9812/Images/WeiXin/1_small.jpg',400)
insert into T_Book values('987654321','活着','清华出版社',35,'2018/6/1',2,'余华','当代作家。中国作家协会第九届全国委员会委员',4,'讲诉了在大时代背景下，随着内战、三反五反，大跃进，文化大革命等社会变革，徐福贵的人生和家庭不断经受着苦难，到了最后所有亲人都先后离他而去，仅剩下年老的他和一头老牛相依为命。',null,null,'2019/6/25','/images/life.png','http://localhost:9812/Images/WeiXin/1_small.jpg',400)


select top 12  * from T_Book where BookRecord>'2019/6/28'

select * from T_Category
select * from T_Book


--添加用户类型
insert into T_ReaderType values('普通用户',5,30,1,10.2,2)

--添加用户
insert into T_User values(1,'lucy','女','18538003652','luo@126.com',1,'e10adc3949ba59abbe56e057f20f883e',GETDATE(),GETDATE(),null,1,1)

select * from T_User

select * from T_ReaderType


--借阅记录
insert into T_BorrowedRecord values(2,1,'时间简史',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(2,1,'时间简史',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(3,1,'局外人',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(4,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(6,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(6,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(9,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(9,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(13,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(13,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
											 
insert into T_BorrowedRecord values(16,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)
insert into T_BorrowedRecord values(16,1,'活着',GETDATE(),GETDATE(),GETDATE(),1,21,1,1)

select * from T_BorrowedRecord where BookId=2

insert into T_BookList values(1,'21天读书计划',getdate(),'21天读书时让你在21天阅读3本书,并写下读后管',GETDATE());


---注意
1、实体类加入virtual

2  添加ComplexType出错，添加GlobalConfig

3




 