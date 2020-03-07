using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.Entities;
using CarRent.Api.Services;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        private MapperConfiguration _reservationConfig;
        private MapperConfiguration _reservationConfig2;
        private CarRentDbContext dbCtx;
        public ReservationRepository(CarRentDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
            _reservationConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReservationEntity, Reservation>()
                    .ForPath(dest => dest.Customer.IdCustomer, act => act.MapFrom(src => src.FidCustomer))
                    .ForPath(dest => dest.Car.IdCar, act => act.MapFrom(src => src.FidCar));
            });
            _reservationConfig2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationEntity>()
                    .ForPath(dest => dest.FidCustomer, act => act.MapFrom(src => src.Customer.IdCustomer))
                    .ForPath(dest => dest.FidCar, act => act.MapFrom(src => src.Car.IdCar));
            });
        }

        public long AddReservation(Reservation reservation)
        {
            IMapper mapper = _reservationConfig2.CreateMapper();
            ReservationEntity reservationEntity = new ReservationEntity();
            reservationEntity = mapper.Map<Reservation, ReservationEntity>(reservation);
            dbCtx.ReservationEntity.Add(reservationEntity);
            dbCtx.SaveChanges();
            return reservationEntity.IdReservation;
        }

        public int DeleteReservationById(long idReservation)
        {

            dbCtx.ReservationEntity.Remove(dbCtx.ReservationEntity.Single(r => r.IdReservation == idReservation));
            return dbCtx.SaveChanges();
        }


        public List<Reservation> ReadAllReservation()
        {
            List<ReservationEntity> reservationList = new List<ReservationEntity>();
            reservationList = dbCtx.ReservationEntity.ToList();

            IMapper mapper = _reservationConfig.CreateMapper();
            return mapper.Map<List<ReservationEntity>, List<Reservation>>(reservationList);

        }

        public Reservation ReadReservationById(long idReservation)
        {
            ReservationEntity reservationEntity = new ReservationEntity();
            reservationEntity = dbCtx.ReservationEntity.Where(r => r.IdReservation == idReservation).FirstOrDefault();

            IMapper mapper = _reservationConfig.CreateMapper();
            return mapper.Map<ReservationEntity, Reservation>(reservationEntity);
        }

        public long UpdateReservation(Reservation reservation)
        {
            IMapper mapper = _reservationConfig2.CreateMapper();
            ReservationEntity reservationEntity = mapper.Map<Reservation, ReservationEntity>(reservation);

            dbCtx.ReservationEntity.Update(reservationEntity);
            dbCtx.SaveChanges();
            return reservationEntity.IdReservation;
        }

    }
}
