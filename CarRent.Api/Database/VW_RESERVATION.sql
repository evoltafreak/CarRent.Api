CREATE OR REPLACE VIEW VW_RESERVATION AS
    SELECT
        re.idReservation,
        re.days,
        re.price,
        re.reservationNr,
        re.pickUpDate,
        re.isLease,
        cu.idCustomer,
        cu.firstname,
        cu.lastname,
        ca.idCar,
        ca.carName,
        ca.carNr
    FROM Reservation re
    JOIN Customer cu
        ON re.fidCustomer = cu.idCustomer
    JOIN Car ca
        ON re.fidCar = ca.idCar;

