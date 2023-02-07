CREATE TABLE url
(
    "Id"             bigserial primary key,
    "CreationDate" timestamp not null default current_timestamp,
    "Full"         text,
    "Short"          text
    -- "UserId"       bigint
) PARTITION BY RANGE ("Id");

-- Create 10 partitions by 5_000_000_000
DO
$$
    DECLARE
        partition_size bigint := 5000000000;
        partition_num  bigint := 0;
        i              bigint := 0;
        temp           bigint;
    BEGIN
        LOOP
            EXIT WHEN partition_num = 10;
            temp := i + partition_size;
            -- RAISE NOTICE 'CREATE TABLE url_% PARTITION OF url for values FROM (%) TO (%)', partition_num, i, temp;
            EXECUTE format('CREATE TABLE url_%s PARTITION OF url for values FROM (%s) TO (%s)', partition_num, i, temp);
            partition_num := partition_num + 1;
            i := temp;
        END LOOP;
    END;
$$;

CREATE SEQUENCE url_id MINVALUE 0 START 0;