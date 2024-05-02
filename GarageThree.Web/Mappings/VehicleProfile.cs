namespace GarageThree.Web.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<Vehicle, VehicleCreateOrEditViewModel>().ReverseMap();
        }
    }
}
