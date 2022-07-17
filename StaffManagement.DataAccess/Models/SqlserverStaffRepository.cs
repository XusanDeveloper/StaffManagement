using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.DataAccess.Models
{
    public class SqlserverStaffRepository : IStaffRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlserverStaffRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Staff Create(Staff staff)
        {
            _dbContext.Staffs.Add(staff);
            _dbContext.SaveChanges();
            return staff;
        }

        public Staff Delete(int id)
        {
            var staff = _dbContext.Staffs.Find(id);
            if (staff != null)
            {
                _dbContext.Remove(staff);
                _dbContext.SaveChanges();
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return _dbContext.Staffs.Find(id);
        }

        public IEnumerable<Staff> GetAll()
        {
            return _dbContext.Staffs;
        }

        public Staff Update(Staff updateStaff)
        {
            var staff = _dbContext.Staffs.Attach(updateStaff);
            staff.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return updateStaff;

        }
    }
}
