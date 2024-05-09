using GarageThree.Web.ViewModels.Checkout;

namespace GarageThree.Web.Mappings
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<Checkout, CheckoutViewModel>()
                .ForMember(dest => dest.ParkingPeriod, opt => opt.MapFrom(src => (src.CheckoutAt - src.ParkedAt)))
                .ReverseMap();

            CreateMap<CheckoutCreateViewModel, Checkout>();
        }
    }
}
