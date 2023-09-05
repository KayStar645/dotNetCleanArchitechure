﻿
namespace Core.Application.Transform
{
    public static class ValidatorTranform
    {
        public static string MaximumLength(string name, int max)
        {
            return $"Trường {name} phải nhỏ hơn hoặc bằng {max} kí tự!";
        }

        public static string MinimumLength(string name, int min)
        {
            return $"Trường {name} phải lớn hơn hoặc bằng {min} kí tự!";
        }

        public static string Length(string name, int number)
        {
            return $"Trường {name} phải đúng {number} kí tự!";
        }

        public static string Required(string name)
        {
            return $"Trường {name} là bắt buộc!";
        }

        public static string MustIn(string name)
        {
            return $"Trường {name} đã chọn không hợp lệ!";
        }

        public static string MustDate(string name, int year)
        {
            return $"Trường {name} tối thiểu phải đủ {year} tuổi!";
        }

        public static string Must(string name, string[] options)
        {
            return $"Trường {name} phải thuộc {string.Join(", ", options)}!";
        }

        public static string MustWhen(string name, string[] options, string nameOther, string value)
        {
            return $"Trường {name} có thể thuộc {string.Join(", ", options)} nếu {nameOther} là {value} ; ngược lại trường {name} phải null!";
        }

        public static string ValidValue(string name)
        {
            return $"Trường {name} không hợp lệ!";
        }

        public static string ExistsValue(string name, string value)
        {
            return $"{name} = {value} không tồn tại!";
        }

        public static string AnyIsLower(string name) 
        {
            return $"Trường {name} phải chứa ít nhất 1 chữ thường!";
        }

        public static string AnyIsUpper(string name)
        {
            return $"Trường {name} phải chứa ít nhất 1 chữ hoa!";
        }
        public static string AnyIsDigit(string name)
        {
            return $"Trường {name} phải chứa ít nhất 1 số!";
        }
        public static string AnyIsLetterOrDigit(string name) 
        {
            return $"Trường {name} phải chứa ít nhất 1 ký tự đặc biệt!";
        }

        public static string GreaterThanOrEqualTo(string name, int number)
        {
            return $"Trường {name} ít nhất lớn hơn hoặc bằng ${number}!";
        }


    }
}
