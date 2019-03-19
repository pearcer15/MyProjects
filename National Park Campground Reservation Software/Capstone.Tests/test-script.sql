delete from reservation;
delete from site;
delete from campground;
delete from park;

insert into park (name, location, establish_date, area, visitors, description) values ('garage', 'ohio','1753-01-01',1,2,'a sometimes well lit occasional yoga studio.');
declare @park1 int = @@identity;
insert into park (name, location, establish_date, area, visitors, description) values ('car park','england','1776-02-03',50,5,'putting this here because we have to.' );
declare @park2 int = @@identity;

insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)  values (@park1,'taurus',2,4,25.00);
declare @campground1 int = @@identity;
insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)  values (@park1, 'stratus',4,6,30.00);
declare @campground2 int = @@identity;
insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)  values (@park2,'neon',8,12,15.00);
declare @campground3 int = @@identity;

insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) values (@campground1, 1,5,0,15,0);
declare @site1 int = @@identity;
insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) values (@campground1, 2,6,1,0,1);
declare @site2 int = @@identity;
insert into site (campground_id, site_number) values (@campground2, 1);
declare @site3 int = @@identity;
insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) values (@campground2, 2,1,1,12,1);
declare @site4 int = @@identity;
insert into site (campground_id, site_number) values (@campground3, 1);
declare @site5 int = @@identity;

insert into reservation (site_id, name, from_date, to_date) values (@site1, 'gary trello', '2019-02-01','2019-02-28');
insert into reservation (site_id, name, from_date, to_date) values (@site2, 'jason vorhees','2019-03-01','2019-03-29');
insert into reservation (site_id, name, from_date, to_date) values (@site3, 'river ryver','2019-02-15','2019-03-15');

select @park1 as park1, @park2 as park2, @campground1 as campground1, @campground2 as campground2, @site5 as siteID
