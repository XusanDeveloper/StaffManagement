using System.Collections.Generic;
using System.Linq;

namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() { Id = 1, FullName = "Xusan Ne'matov", Email = "huseyntechs@gmail.com", Department = Departments.CEO},
                new Staff() { Id = 2, FullName = "Xasan Ne'matov", Email = "xasannematov@gmail.com", Department = Departments.CTO},
                new Staff() { Id = 3, FullName = "Oybek Toshpolatov", Email = "oybek@gmail.com", Department = Departments.HR}
            };
        }


        public Staff Create(Staff staff)
        {
            staff.Id = _staffs.Max(s => s.Id) + 1;
            _staffs.Add(staff);
            return staff;
        }

        public Staff Delete(int id)
        {
             var staff = _staffs.FirstOrDefault(s => s.Id == id);
            if (staff != null)
            {
                _staffs.Remove(staff);
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }

        public Staff Update(Staff updatedStaff)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id == updatedStaff.Id);
            if (staff != null)
            {
                staff.FullName = updatedStaff.FullName;
                staff.Email = updatedStaff.Email;
                staff.Department = updatedStaff.Department;
            }
            return staff;
        }
    }
}
