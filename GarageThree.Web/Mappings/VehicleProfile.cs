namespace GarageThree.Web.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ForMember(vm => vm.VehicleType, opt => opt.MapFrom(entity => entity.VehicleType));
            CreateMap<Vehicle, VehicleCreateViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleEditViewModel>().ReverseMap();
        }
    }
}
