namespace GarageThree.Web.Mappings
{
    public class GarageProfile : Profile
    {
        public GarageProfile()
        {
            CreateMap<Garage, GarageViewModel>();
            CreateMap<Garage, MemberCreateOrEditViewModel>().ReverseMap();
        }
    }
}
