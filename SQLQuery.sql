create database adpp;

create table osobe(
    id int,
    akcija int,
    pocVreme varchar(10),
    krajVreme varchar(10),
);

delete from osobe;

-- Default vrednosti
INSERT INTO osobe
values (1111, 12, '22:01', '23:45');
INSERT INTO osobe
values (1111, 4, '7:00', '10:00');
INSERT INTO osobe
values (1111, 2, '10:00', '12:00');
INSERT INTO osobe
values (1111, 3, '12:01', '14:00');
INSERT INTO osobe
values (1111, 1, '14:01', '17:00');
INSERT INTO osobe
values (1111, 5, '17:01', '18:00');
INSERT INTO osobe
values (1111, 14, '18:01', '20:00');
INSERT INTO osobe
values (1111, 6, '20:01', '21:30');
INSERT INTO osobe
values (1111, 11, '21:31', '22:00');