using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.EF;
using CarRent.Api.Services;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        public MapperConfiguration reservationConfig;
        public MapperConfiguration reservationConfig2;
        public ReservationRepository()
        {
            reservationConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReservationEntity, Reservation>()
                    .ForPath(dest => dest.Customer.IdCustomer, act => act.MapFrom(src => src.FidCustomer))
                    .ForPath(dest => dest.Car.IdCar, act => act.MapFrom(src => src.FidCar));
            });
            reservationConfig2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Reservation, ReservationEntity>()
                    .ForPath(dest => dest.FidCustomer, act => act.MapFrom(src => src.Customer.IdCustomer))
                    .ForPath(dest => dest.FidCar, act => act.MapFrom(src => src.Car.IdCar));
            });
        }

        public long AddReservation(Reservation reservation)
        {
            IMapper mapper = reservationConfig2.CreateMapper();
            ReservationEntity reservationEntity = new ReservationEntity();
            using (var context = new CarRentDbContext())
            {
                reservationEntity = mapper.Map<Reservation, ReservationEntity>(reservation);
                context.ReservationEntity.Add(reservationEntity);
                context.SaveChanges();
            }
            return reservationEntity.IdReservation;
        }

        public int DeleteReservationById(long idReservation)
        {
            using (var context = new CarRentDbContext())
            {
                context.ReservationEntity.Remove(context.ReservationEntity.Single(r => r.IdReservation == idReservation));
                return context.SaveChanges();
            }
        }


        public List<Reservation> ReadAllReservation()
        {
            List<ReservationEntity> reservationList = new List<ReservationEntity>();
            using (var context = new CarRentDbContext())
            {
                reservationList = context.ReservationEntity.ToList();
            }
            
            IMapper mapper = reservationConfig.CreateMapper();
            return mapper.Map<List<ReservationEntity>, List<Reservation>>(reservationList);

        }

        public Reservation ReadReservationById(long idReservation)
        {
            ReservationEntity reservationEntity = new ReservationEntity();
            using (var context = new CarRentDbContext())
            {
                reservationEntity = context.ReservationEntity.Where(r => r.IdReservation == idReservation).FirstOrDefault();
            }
            IMapper mapper = reservationConfig.CreateMapper();
            return mapper.Map<ReservationEntity, Reservation>(reservationEntity);
        }

        public long UpdateReservation(Reservation reservation)
        {
            IMapper mapper = reservationConfig2.CreateMapper();
            ReservationEntity reservationEntity = mapper.Map<Reservation, ReservationEntity>(reservation);
            using (var context = new CarRentDbContext())
            {
                context.ReservationEntity.Update(reservationEntity);
                context.SaveChanges();
            }

            return reservationEntity.IdReservation;
        }

    }
}
