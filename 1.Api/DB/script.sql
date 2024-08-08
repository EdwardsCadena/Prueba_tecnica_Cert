-- Database: Cert

-- DROP DATABASE IF EXISTS "Cert";

CREATE DATABASE "Cert"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Spanish_Latin America.1252'
    LC_CTYPE = 'Spanish_Latin America.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


-- Table: public.productos

-- DROP TABLE IF EXISTS public.productos;

CREATE TABLE IF NOT EXISTS public.productos
(
    id integer NOT NULL DEFAULT nextval('productos_id_seq'::regclass),
    nombre character varying(255) COLLATE pg_catalog."default" NOT NULL,
    precio numeric(10,2) NOT NULL,
    cantidad integer NOT NULL,
    row_version bytea,
    CONSTRAINT productos_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.productos
    OWNER to postgres;
-- Index: idx_row_version

-- DROP INDEX IF EXISTS public.idx_row_version;

CREATE UNIQUE INDEX IF NOT EXISTS idx_row_version
    ON public.productos USING btree
    (row_version ASC NULLS LAST)
    TABLESPACE pg_default;