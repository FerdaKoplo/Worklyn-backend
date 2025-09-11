namespace Worklyn_backend.Domain.ValueObjects.Profile

{
    public class EmergencyContactVO
    {
        public string Name { get; }
        public PhoneNumberVO Phone { get; }
        public string Relation { get; }
        private EmergencyContactVO() { } 

        public EmergencyContactVO(string name, PhoneNumberVO phone, string relation)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Relation = relation ?? throw new ArgumentNullException(nameof(relation));
        }
    }
}
