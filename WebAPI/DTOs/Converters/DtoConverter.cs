using AutoMapper;
using Data_Access_Layer.Models;

namespace WebAPI.DTOs.Converters;

public static class DtoConverter<FromType, ToType>
{
    private static readonly MapperConfiguration _config = new(cfg =>
    {
        cfg.CreateMap<FromType, ToType>();
    });
    private readonly static Mapper _mapper = new(_config);


    //      OUTPUT                     <FROM>      <TO>               <SOURCE>
    //var bookingList = DtoConverter<BookingDto, Booking>.FromList(bookingDtoList);
    //var bookingDto = DtoConverter<Booking, BookingDto>.FromType(booking);
    //var booking = DtoConverter<BookingDto, Booking>.FromType(bookingDto);
    public static ToType From(FromType sourceObject)
    {
        return _mapper.Map<FromType, ToType>(sourceObject);
    }

    public static IEnumerable<ToType> FromList(IEnumerable<FromType> sourceList)
    {
        if (sourceList is null)
        {
            throw new ArgumentNullException(nameof(sourceList));
        }

        return sourceList.ToList().Select(From);
    }
}

