using ApplicationCore;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly ICabRepository _cabRepository;
        public BookingService(IBookingRepository bookingRepository, ILocationRepository locationRepository, ICabRepository cabRepository)
        {
            _bookingRepository = bookingRepository;
            _locationRepository = locationRepository;
            _cabRepository = cabRepository;
        }

        public async Task<BookingsDetailsResponseModel> Add(BookingsRequestModel requestModel)
        {
            var random = new Random();
            var randomNumber = random.Next(15, 19);
            var bookingEntity = new Bookings
            {
                BookingDate = requestModel.BookingDate,
                BookingTime = requestModel.BookingTime,
                Email = requestModel.Email,
                PickupDate = requestModel.PickupDate,
                PickupTime = requestModel.PickupTime,
                Status = requestModel.Status,
                ContactNo = requestModel.ContactNo,
                CabTypesId = randomNumber
            };

            var addedBooking = await _bookingRepository.Add(bookingEntity);

            var locationEntity = new Location
            {
                PickupAddress = requestModel.locationRequest.PickupAddress,
                DropoffAddress = requestModel.locationRequest.DropoffAddress,
                BookingsId = addedBooking.Id,
                Landmark = requestModel.locationRequest.Landmark,
                PlacesId = requestModel.locationRequest.placeIdRequestModel.Id            
            };

            var addLocation = await _locationRepository.Add(locationEntity);

            

            if (addedBooking != null && addedBooking != null)
            {
                var CabName = await _cabRepository.GetById((int)addedBooking.CabTypesId);
                var responseModel = new BookingsDetailsResponseModel
                {
                    BookingDate = addedBooking.BookingDate,
                    Status = addedBooking.Status,
                    BookingTime = addedBooking.BookingTime,
                    ContactNo = addedBooking.ContactNo,
                    Email = addedBooking.Email,
                    PickupDate = addedBooking.PickupDate,
                    PickupTime = addedBooking.PickupTime,
                    locationRequest = new LocationResponseModel {
                        PickupAddress = addLocation.PickupAddress,
                        DropoffAddress = addLocation.DropoffAddress,
                        Landmark = addLocation.Landmark,
                        placeIdRequestModel = new PlaceIdRequestModel
                        {
                            Id = addLocation.PlacesId
                        } 
                    },
                    cabResponseModel = new CabResponseModel
                    {
                        Id = (int)addedBooking.CabTypesId,
                        CabTypeName = CabName.CabTypeName
                    }
                };

                return responseModel;
            }
                

            return null;
        }

        public async Task Delete(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            await _bookingRepository.Delete(booking);
        }

        public async Task<List<BookingsResponseModel>> GetAll()
        {
            var bookingList = new List<BookingsResponseModel>();
            var allBookings = await _bookingRepository.GetAll();
 
            bookingList = allBookings.Select(b => new BookingsResponseModel
            {
                BookingDate = b.BookingDate,
                BookingTime = b.BookingTime,
                PickupDate = b.PickupDate,
                ContactNo = b.ContactNo,
                Email = b.Email,
                Id = b.Id,
                PickupTime = b.PickupTime,
                Status = b.Status,
                CabTypesId = b.CabTypesId                 
            }).ToList();


            return (bookingList);
        }

        public async Task<BookingsResponseModel> GetById(int id)
        {
            var booking = await _bookingRepository.GetById(id);

            var bookingResponse = new BookingsResponseModel
            {
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                Email = booking.Email,
                ContactNo = booking.ContactNo,
                PickupDate = booking.PickupDate,
                PickupTime = booking.PickupTime,
                Status = booking.Status,
                CabTypesId = booking.CabTypesId             
            };

            return bookingResponse;
        }

        public async Task<BookingsDetailsResponseModel> Update(UpdateBookingsRequestModel requestModel)
        {
            Console.Write(requestModel.BookingDate);
            var updateBooking = new Bookings
            {
                Id = requestModel.Id,
                BookingDate = requestModel.BookingDate.Value,
                BookingTime = requestModel.BookingTime,
                PickupDate = requestModel.PickupDate,
                PickupTime = requestModel.PickupTime,
                Email = requestModel.Email,
                ContactNo = requestModel.ContactNo,
                Status = requestModel.Status,
                CabTypesId = requestModel.CabTypesId
            };

            var updateLocation = new Location
            {
                Id = requestModel.locationRequest.Id,
                PickupAddress = requestModel.locationRequest.PickupAddress,
                DropoffAddress = requestModel.locationRequest.DropoffAddress,
                Landmark = requestModel.locationRequest.Landmark,
                PlacesId = requestModel.locationRequest.placeIdRequestModel.Id,
                BookingsId = requestModel.Id
            };

            var updatedBooking = await _bookingRepository.Update(updateBooking);
            var updatedLocation = await _locationRepository.Update(updateLocation);

            if (updatedBooking != null && updatedLocation != null)
            {
                var bookingResponse = new BookingsDetailsResponseModel
            {
                Id = updatedBooking.Id,
                BookingDate = updatedBooking.BookingDate,
                BookingTime = updatedBooking.BookingTime,
                PickupDate = updatedBooking.PickupDate,
                PickupTime = updatedBooking.PickupTime,
                Email = updatedBooking.Email,
                ContactNo = updatedBooking.ContactNo,
                Status = updatedBooking.Status,
                CabTypesId = updatedBooking.CabTypesId,
                locationRequest = new LocationResponseModel
                {
                    PickupAddress = updatedLocation.PickupAddress,
                    DropoffAddress = updatedLocation.DropoffAddress,
                    Landmark = updatedLocation.Landmark,
                    BookingsId = updatedBooking.Id,
                    Id = updatedLocation.Id,
                    PlacesId = updatedLocation.PlacesId                    
                }
            };

            
                return bookingResponse;
            }

            return null;
        }
    }
}
