namespace GarageThree.Web.Mappings
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberViewModel>();
            CreateMap<Member, MemberIndexViewModel>();
            CreateMap<Member, MemberCreateOrEditViewModel>().ReverseMap();
        }
    }
}
