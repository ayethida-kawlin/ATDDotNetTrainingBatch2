using ATDDotNetTrainingBatch2.MiniPOS.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.MiniPOS.Domain.Features
{
    public class StaffService
    {
        public int Register(string Code, string Name, string email, string Pwd, string Position, string mobile)
        {
            var staff = new TblStaffRegistration()
            {
                StaffCode = Code,
                StaffName = Name,
                EmailAddress = email,
                Password = Pwd,
                Position = Position,
                MobileNo = mobile,
                IsDelete = false
            };

            AppDbContext db = new AppDbContext();
            db.TblStaffRegistrations.Add(staff);
            var staffInput = db.SaveChanges();
            return staffInput;
        }
    }
}
