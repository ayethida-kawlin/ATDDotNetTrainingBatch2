using ATDDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;


namespace ATDDotNetTrainingBatch2.WinFormsApp1
{
   
    public partial class FrmStaff : Form
    {
        private readonly AppDbContext _db;
        private int _editId;
        
        public FrmStaff()
        {
            InitializeComponent();
            _db = new AppDbContext();
            dgvData.AutoGenerateColumns = false;
        }


        private void btlSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_editId == 0)
                {
                    txtPassword.Text = Guid.NewGuid().ToString().Replace("-","").Substring(0,8);

                    _db.TblStaffs.Add(new TblStaff
                    {
                        EmailAddress = txtEmail.Text.Trim(),
                        IsDelete = false,
                        MobileNo = txtMobile.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Position = cboPosition.Text.Trim(),
                        StaffCode = txtCode.Text.Trim(),
                        StaffName = txtName.Text.Trim()

                    });
                    int result = _db.SaveChanges();
                    string messageStr = result > 0 ? "Saving Successful!" : "Saving Failed";
                    MessageBox.Show(messageStr, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Aye Thida", "ayethidar540@gmail.com"));
                    message.To.Add(new MailboxAddress("Testing Staff", txtEmail.Text.Trim()));
                    message.Subject = "Mini POS user creation";

                    message.Body = new TextPart("plain")
                    {
                        Text = $@"Your Staff Code is {txtCode.Text.Trim()} Your password is: {txtPassword.Text}"
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);

                        // Note: only needed if the SMTP server requires authentication
                        client.Authenticate("ayethidar540@gmail.com", "tkoq xveg wuzh tjrl");

                        client.Send(message);
                        client.Disconnect(true);
                    }

                    txtCode.Clear();
                    txtName.Clear();
                    txtPassword.Clear();
                    txtEmail.Clear();
                    txtMobile.Clear();
                    cboPosition.Text = "";

                    txtCode.Focus();
                    BindData();
                }
                else
                {
                    TblStaff? staffdata = _db.TblStaffs.FirstOrDefault(x => x.StaffId == _editId && x.IsDelete == false);
                    if (staffdata is null)
                    {
                        return;
                    }

                    staffdata.EmailAddress = txtEmail.Text.Trim();
                    staffdata.IsDelete = false;
                    staffdata.MobileNo = txtMobile.Text.Trim();
                    staffdata.Password = txtPassword.Text.Trim();
                    staffdata.Position = cboPosition.Text.Trim();
                    staffdata.StaffCode = txtCode.Text.Trim();
                    staffdata.StaffName = txtName.Text.Trim();
                    int result = _db.SaveChanges();
                    string message = result > 0 ? "Updating Successful!" : "Update Failed";
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCode.Clear();
                    txtName.Clear();
                    txtPassword.Clear();
                    txtEmail.Clear();
                    txtMobile.Clear();
                    cboPosition.Text = "";

                    txtCode.Focus();
                    _editId = 0;
                    btlSave.Text = "Save";
                    txtCode.Focus();
                    BindData();

                }


            }
            catch (Exception ex)
            {

            }

        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {

                dgvData.DataSource = _db.TblStaffs.ToList();
            }
            catch (Exception ex)
            {

                
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            //if(e.ColumnIndex == 0)
            if (e.ColumnIndex == dgvData.Columns["colEdit"].Index)
            {
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString())!;
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if(item is null)
                {
                    return;
                }

                txtCode.Text = item.StaffCode;
                txtName.Text = item.StaffName;
                txtEmail.Text = item.EmailAddress;
                txtMobile.Text = item.MobileNo;
                txtPassword.Text = item.Password;
                cboPosition.Text = item.Position;
                _editId = id;
                
            }
            else if (e.ColumnIndex == dgvData.Columns["colDelete"].Index)
            {
                var confirm = MessageBox.Show("Are you sure want to delete?", "",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(confirm == DialogResult.No) return;

                // Delete process
                int id = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value.ToString())!;
                var item = _db.TblStaffs.FirstOrDefault(x => x.StaffId == id);
                if (item is null)
                {
                    return;
                }
                _db.TblStaffs.Remove(item);
                int result = _db.SaveChanges();
                string message = result > 0 ? "Deleting Successful!" : "Deleting Failed";
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information );
                BindData();
            }
        }
    }
}
