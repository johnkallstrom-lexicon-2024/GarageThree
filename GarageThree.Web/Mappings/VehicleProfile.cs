namespace GarageThree.Web.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(vm => vm.Type, opt => opt.MapFrom(entity => entity.VehicleType));

            CreateMap<Vehicle, VehicleCreateOrEditViewModel>().ReverseMap();
        }
    }
}
