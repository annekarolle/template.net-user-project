using StoreFIAP.Enums;

namespace StoreFIAP.DTO
{
    public class SaveUserDTO
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public PermitionsTypes Permitions { get; internal set; }
    }
}
