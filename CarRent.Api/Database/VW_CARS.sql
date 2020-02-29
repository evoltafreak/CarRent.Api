CREATE OR REPLACE VIEW VW_CARS AS
    SELECT 
        ca.idCar,
        ca.carName,
        ca.carNr,
        ct.carType,
        cm.carMake,
        cc.carClass,
        cc.fee
    FROM Car ca
        JOIN CarType ct
    ON ca.fidCarType = ct.idCarType
        JOIN CarMake cm
    ON ca.fidCarMake = cm.idCarMake
        JOIN CarClass cc
    ON ca.fidCarClass = cc.idCarClass;

