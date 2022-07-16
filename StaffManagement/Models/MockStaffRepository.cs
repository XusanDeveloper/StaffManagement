namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() { Id = 1, FullName = "Xusan Ne'matov", Email = "huseyntechs@gmail.com", Department = "CEO"},
                new Staff() { Id = 2, FullName = "Xasan Ne'matov", Email = "xasannematov@gmail.com", Department = "CTO"},
                new Staff() { Id = 3, FullName = "Oybek Toshpolatov", Email = "oybek@gmail.com", Department = "Production"}
            };
        }




        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }
    }
}
