namespace GarageThree.Web.Mappings
{
    public class VehicleTypeProfile : Profile
    {
        public VehicleTypeProfile()
        {
            CreateMap<VehicleType, VehicleTypeViewModel>();
        }
    }
}
