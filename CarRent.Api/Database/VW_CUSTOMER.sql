CREATE OR REPLACE VIEW VW_CUSTOMER AS
    SELECT
        cu.idCustomer,
        cu.firstname,
        cu.lastname,
        cu.address,
        cu.addressNr,
        pl.idPlace,
        pl.zipcode,
        pl.place
    FROM Customer cu
        JOIN Place pl
    ON pl.idPlace = cu.fidPlace;

