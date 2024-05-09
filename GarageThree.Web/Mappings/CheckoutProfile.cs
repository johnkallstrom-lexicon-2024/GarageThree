using GarageThree.Web.ViewModels.Checkout;

namespace GarageThree.Web.Mappings
{
    public class CheckoutProfile : Profile
    {
        public CheckoutProfile()
        {
            CreateMap<Checkout, CheckoutViewModel>();
            CreateMap<CheckoutCreateViewModel, Checkout>();
        }
    }
}
