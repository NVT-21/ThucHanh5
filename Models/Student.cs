using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        //
        [DisplayName("Tên")]    
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên 4-100 ký tự")]
        [Required(ErrorMessage = "Tên chưa nhập")]
        public string? Name { get; set; }
        //
        [Required(ErrorMessage = "Email chưa nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail\.com", 
        ErrorMessage = "Địa chỉ email phải có đuôi gmail.com")]
        public string? Email { get; set; }
        //
        [DisplayName("Mật khẩu")]
        [RegularExpression(@"^(?=.*[0-9].*[a-z].*[A-Z].*[*.!@$%^&(){}[:;<>,/.?~_+-=|\]]).{8,}$"
        , ErrorMessage = "Mật khẩu từ 8 ký tự trở lên, có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt")]
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu chưa nhập")]
        public string? Password { get; set; }
        //
        [DisplayName("Ngành học")]
        public Branch? Branch { get; set; }
        //
        [DisplayName("Giới tính")]
        [Required(ErrorMessage = "Giới tính chưa chọn")]
        public Gender? Gender { get; set; }
        //
        [DisplayName("Chính quy")]
        public bool IsRegular { get; set; }
        //
        [DisplayName("Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ chưa nhập")]
        public string? Address { get; set; }
        //
        [DisplayName("Ngày sinh")]
        [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ErrorMessage = "Ngày sinh trong khoảng 1/1/196 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh chưa nhập")]
        public DateTime? DateOfBorth { get; set; }
        //
        [DisplayName("Điểm")]
        [RegularExpression(@"\d+\.?\d*$", ErrorMessage = "Điểm phải là số thực")]
        [Range(0, 10, ErrorMessage = "Điểm phải là số và trong khoảng 1-10")]
        [Required(ErrorMessage = "Điểm chưa nhập")]
        public double Point { get; set; }

    }
    
}
