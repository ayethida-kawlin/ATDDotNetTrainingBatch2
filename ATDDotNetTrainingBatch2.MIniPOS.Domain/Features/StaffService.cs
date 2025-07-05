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
        public int Register()
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Enter Staff Code: ");
            string code = Console.ReadLine()!;
            Console.Write("Enter Staff Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Email Address: ");
            string email = Console.ReadLine()!;
            Console.Write("Enter Password: ");
            string password = Console.ReadLine()!;
            Console.Write("Enter Position: ");
            string position = Console.ReadLine()!;
            Console.Write("Enter Mobile No: ");
            string mobile = Console.ReadLine()!;
            Console.WriteLine("---------------------------------");

            var staff = new TblStaffRegistration()
            {
                StaffCode = code,
                StaffName = name,
                EmailAddress = email,
                Password = password,
                Position = position,
                MobileNo = mobile,
                IsDelete = false
            };


            AppDbContext db = new AppDbContext();
            db.TblStaffRegistrations.Add(staff);
            var staffInput = db.SaveChanges();
            return staffInput;
        }

        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.TblProducts
                .Where(x => x.IsDelete == false).ToList();
            //return lst;
        }
    }
}
