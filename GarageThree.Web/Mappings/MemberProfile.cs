namespace GarageThree.Web.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberViewModel>();
            CreateMap<Member, MemberCreateOrEditViewModel>().ReverseMap();
        }
    }
}
