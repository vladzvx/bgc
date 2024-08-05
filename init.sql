create table games(
  id bigserial PRIMARY KEY,
  name_ru text,
  name_eng text,
  issue_date date,
  age_min int,
  age_max int,
  players_min int,
  players_max int,
  game_time_min interval,
  game_time_max interval,
  edition int
);

create table countries(
    id bigserial PRIMARY KEY,
    name text
);

create table genres(
    id bigserial PRIMARY KEY,
    name text
);

create table themes(
    id bigserial PRIMARY KEY,
    name text
);

create table authors(
   id bigserial PRIMARY KEY,
    first_name text,
    last_name text,
    id_country bigint REFERENCES  countries (id)
);

create table owners(
  id bigserial PRIMARY KEY,
  first_name text,
    last_name text
);

create table rating_types(
 id bigserial PRIMARY KEY,
 name text,
scale text
);

create table game_collection(
 id_owner bigint REFERENCES owners (id),
id_game bigint REFERENCES games (id),
PRIMARY KEY(id_owner, id_game)
);

create table game_authors(
 id_author bigint REFERENCES authors (id),
id_game bigint REFERENCES games (id),
PRIMARY KEY(id_author, id_game)
);

create table game_genres(
  id_game bigint REFERENCES games (id),
id_genre bigint REFERENCES genres (id),
PRIMARY KEY(id_genre, id_game)
);

create table game_themes(
  id_game bigint REFERENCES games (id),
  id_theme bigint REFERENCES themes (id),
  PRIMARY KEY(id_theme, id_game)
);

create table game_ratings(
   id_game bigint REFERENCES games (id),
   id_rating_type bigint REFERENCES rating_types (id),
   rating numeric,
   PRIMARY KEY(id_rating_type, id_game)
);

ALTER TABLE games
ADD CHECK (name_ru is not null or name_eng is not null);

ALTER TABLE games
ADD CHECK (age_min >= 0 and age_min <= 99);

ALTER TABLE games
ADD CHECK (age_max >= 0 and age_max <= 99);

ALTER TABLE games
ADD CHECK (players_min > 0 and players_min < 99);

ALTER TABLE games
ADD CHECK (players_max > 0 and players_max < 99);

ALTER TABLE games
ADD CHECK (game_time_min > 0 and game_time_min < 1440);

ALTER TABLE games
ADD CHECK (game_time_max > 0 and game_time_max < 1440);