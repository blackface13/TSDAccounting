using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    public class ObjectGeneral
    {
        public int ObjectGeneralId { get; set; }
        public string ObjectGeneralCode { get; set; }
        public string ObjectGeneralName { get; set; }

        public ObjectGeneral()
        {

        }
        public ObjectGeneral(int id, string code, string name)
        {
            this.ObjectGeneralId = id;
            this.ObjectGeneralCode = code;
            this.ObjectGeneralName = name;
        }

        public List<ObjectGeneral> GetAccountingObjectCategories(bool isVendor = true, bool isEmployee = true, bool isAccountingObject = true, bool isCustomer = true)
        {
            var result = new List<ObjectGeneral>();
            if (isVendor)
                result.Add(new ObjectGeneral() { ObjectGeneralId = 0, ObjectGeneralCode = "00", ObjectGeneralName = "Nhà cung cấp" });
            if (isEmployee)
                result.Add(new ObjectGeneral() { ObjectGeneralId = 1, ObjectGeneralCode = "01", ObjectGeneralName = "Cán bộ" });
            if (isAccountingObject)
                result.Add(new ObjectGeneral() { ObjectGeneralId = 2, ObjectGeneralCode = "02", ObjectGeneralName = "Đối tượng khác" });
            if (isCustomer)
                result.Add(new ObjectGeneral() { ObjectGeneralId = 3, ObjectGeneralCode = "03", ObjectGeneralName = "Khách hàng" });
            return result;
        }
        public List<ObjectGeneral> GetCalculateRatios()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(){ ObjectGeneralId = 0, ObjectGeneralCode = "01", ObjectGeneralName = ""},
                new ObjectGeneral(){ ObjectGeneralId = 1, ObjectGeneralCode = "02", ObjectGeneralName = "X"},
            };
        }
        public List<ObjectGeneral> GetCostMethods()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(0, "", "Bình quân cuối kỳ"),
                new ObjectGeneral(1, "", "Đích danh"),
                new ObjectGeneral(2, "", "Nhập trước xuất trước"),
                new ObjectGeneral(3, "", "Nhập sau xuất trước"),
            };
        }
        public List<ObjectGeneral> GetMutualStates()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(0, "", "Mua chưa dùng"),
                new ObjectGeneral(1, "", "Đang dùng"),
                new ObjectGeneral(2, "", "Đang dùng - Dừng tính khấu hao"),
                new ObjectGeneral(3, "", "Đã thanh lý"),
                new ObjectGeneral(4, "", "Đã chuyển nhượng"),
                new ObjectGeneral(5, "", "Ghi giảm theo số lượng")
            };
        }
        public List<ObjectGeneral> GetPayItemTypes()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(){ ObjectGeneralId = 0, ObjectGeneralCode = "01", ObjectGeneralName = "Lương chính"},
                new ObjectGeneral(){ ObjectGeneralId = 1, ObjectGeneralCode = "02", ObjectGeneralName = "Phụ cấp"},
                //new ObjectGeneral(){ ObjectGeneralId = 2, ObjectGeneralCode = "03", ObjectGeneralName = "Cá nhân đóng"},
                //new ObjectGeneral(){ ObjectGeneralId = 3, ObjectGeneralCode = "04", ObjectGeneralName = "Cơ quan trả"},
                //new ObjectGeneral(){ ObjectGeneralId = 4, ObjectGeneralCode = "05", ObjectGeneralName = "Tăng khác"},
                //new ObjectGeneral(){ ObjectGeneralId = 5, ObjectGeneralCode = "06", ObjectGeneralName = "Giảm khác"},
                //new ObjectGeneral(){ ObjectGeneralId = 5, ObjectGeneralCode = "07", ObjectGeneralName = "Thuế thu nhập"},
            };
        }
        public List<ObjectGeneral> GetPayItemCodes()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral ( 0, "001", "Chỉ số sinh hoạt phí" ),
                new ObjectGeneral ( 1, "002", "Phụ cấp nữ" ),
                new ObjectGeneral ( 2, "003", "Phụ cấp chiến tranh" ),
                new ObjectGeneral ( 3, "004", "Phụ cấp kiêm nhiệm" )
            };
        }
        public List<ObjectGeneral> GetPlanTypes()
        {
            return new List<ObjectGeneral>()
            {
                //new ObjectGeneral(0, "", "Mẫu dự toán thu"),
                new ObjectGeneral(1, "", "Mẫu dự toán chi"),
            };
        }
        public List<ObjectGeneral> GetInventoryItemTypes()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(0, "", "Vật tư hàng hóa"),
                new ObjectGeneral(1, "", "Công cụ dụng cụ"),
            };
        }
        public List<ObjectGeneral> GetReportPeriods()
        {
            return new List<ObjectGeneral>()
            {
                new ObjectGeneral(0, "", "Năm nay"),
                new ObjectGeneral(1, "", "Tháng 1"),
                new ObjectGeneral(2, "", "Tháng 2"),
                new ObjectGeneral(3, "", "Tháng 3"),
                new ObjectGeneral(4, "", "Tháng 4"),
                new ObjectGeneral(5, "", "Tháng 5"),
                new ObjectGeneral(6, "", "Tháng 6"),
                new ObjectGeneral(7, "", "Tháng 7"),
                new ObjectGeneral(8, "", "Tháng 8"),
                new ObjectGeneral(9, "", "Tháng 9"),
                new ObjectGeneral(10, "", "Tháng 10"),
                new ObjectGeneral(11, "", "Tháng 11"),
                new ObjectGeneral(12, "", "Tháng 12"),
                new ObjectGeneral(13, "", "Quý 1"),
                new ObjectGeneral(14, "", "Quý 2"),
                new ObjectGeneral(15, "", "Quý 3"),
                new ObjectGeneral(16, "", "Quý 4"),
                new ObjectGeneral(17, "", "Tự chọn"),
            };
        }
    }
}
