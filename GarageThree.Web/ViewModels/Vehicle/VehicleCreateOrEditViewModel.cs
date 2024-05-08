namespace GarageThree.Web.ViewModels.Vehicle
{
    public class VehicleCreateOrEditViewModel
    {

        public MemberRepository MemberRepository { get; set; }
        
        public VehicleCreateOrEditViewModel(MemberRepository memberRepository) {
            MemberRepository = memberRepository;  
        }

        [Required]
        public string RegNumber { get; set; } = default!;

        [Required]
        public string Brand { get; set; }  = default!;

        [Required]
        public string Model { get; set; }  = default!;
        [Required]
        public DateTime RegisterdAt { get; set; } = DateTime.Now;
        [Required]
        public int MemberId { get; set; } 

        [Required]
        public Color Color { get; set; }
    }
}
