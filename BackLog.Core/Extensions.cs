using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace BackLog
{
    /// <summary>
    /// 枚举处理
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 获取名字
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetName(this Enum e)
        {
            return Enum.GetName(e.GetType(), e);
        }
        /// <summary>
        /// 获取枚举描述信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] memInfo = type.GetMember(e.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            //FieldInfo field = typeof(Enum).GetField(e.ToString());
            //if (field == null)
            //    return "";
            //object[] obj = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            //var resutl = "";
            //if (obj != null && obj.Length > 0)
            //{
            //    resutl = (obj[0] as DescriptionAttribute).Description;
            //}
            //return resutl;

            return e.ToString();
        }
        //public static List<ComboboxItemDto> GetNamesAndValues(this Type enumType)
        //{
        //    //List<ComboboxItemDto> list = new List<ComboboxItemDto>();
        //    ////获取枚举名称数组
        //    //var names = Enum.GetNames(enumType);
        //    ////获取枚举值数组
        //    //var values = Enum.GetValues(enumType);
        //    //for (var i = 0; i < names.Length; i++)
        //    //{
        //    //    list.Add(new ComboboxItemDto { Value = values.GetValue(i).ToString(), DisplayText = names[i] });
        //    //}
        //    //return list;

        //    List<ComboboxItemDto> list = new List<ComboboxItemDto>();
        //    if (!enumType.IsEnum)
        //    {
        //        return list;
        //    }
        //    string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组
        //    for (int i = 0; i < fieldstrs.Length; i++)
        //    {
        //        string description = string.Empty;
        //        var field = enumType.GetField(fieldstrs[i]);
        //        object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组
        //        if (arr != null && arr.Length > 0)
        //        {
        //            description = ((DescriptionAttribute)arr[0]).Description;   //属性描述
        //        }
        //        else
        //        {
        //            description = fieldstrs[i];  //描述不存在取字段名称
        //        }
        //        list.Add(new ComboboxItemDto
        //        {
        //            Value = ((int)Enum.Parse(enumType, fieldstrs[i])).ToString(),
        //            DisplayText = description,
        //            IsSelected = (i == 0 ? true : false)
        //        });
        //    }
        //    return list;
        //}
        public static List<NameValueDto<int>> GetNamesAndValues(this Type enumType)
        {
            //List<ComboboxItemDto> list = new List<ComboboxItemDto>();
            ////获取枚举名称数组
            //var names = Enum.GetNames(enumType);
            ////获取枚举值数组
            //var values = Enum.GetValues(enumType);
            //for (var i = 0; i < names.Length; i++)
            //{
            //    list.Add(new ComboboxItemDto { Value = values.GetValue(i).ToString(), DisplayText = names[i] });
            //}
            //return list;

            List<NameValueDto<int>> list = new List<NameValueDto<int>>();
            if (!enumType.IsEnum)
            {
                return list;
            }
            string[] fieldstrs = Enum.GetNames(enumType); //获取枚举字段数组
            for (int i = 0; i < fieldstrs.Length; i++)
            {
                string description = string.Empty;
                var field = enumType.GetField(fieldstrs[i]);
                object[] arr = field.GetCustomAttributes(typeof(DescriptionAttribute), true); //获取属性字段数组
                if (arr != null && arr.Length > 0)
                {
                    description = ((DescriptionAttribute)arr[0]).Description;   //属性描述
                }
                else
                {
                    description = fieldstrs[i];  //描述不存在取字段名称
                }
                list.Add(new NameValueDto<int>
                {
                    Value = (int)Enum.Parse(enumType, fieldstrs[i]),
                    Name = description,
                });
            }
            return list;
        }

        public static T AsEnum<T>(this int value) where T : struct
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            return default(T);
        }
        public static T AsEnum<T>(this string value) where T : struct
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            return default(T);
        }
        /// <summary>
        /// 根据Description获取枚举
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="description">枚举描述</param>
        /// <returns>枚举</returns>
        public static T AsEnumForDescription<T>(this string description)
        {
            Type _type = typeof(T);
            foreach (FieldInfo field in _type.GetFields())
            {
                DescriptionAttribute[] _curDesc = field.GetDescriptAttr();
                if (_curDesc != null && _curDesc.Length > 0)
                {
                    if (_curDesc[0].Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }

        /// <summary>
        /// 获取字段Description
        /// </summary>
        /// <param name="fieldInfo">FieldInfo</param>
        /// <returns>DescriptionAttribute[] </returns>
        public static DescriptionAttribute[] GetDescriptAttr(this FieldInfo fieldInfo)
        {
            if (fieldInfo != null)
            {
                return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }
            return null;
        }
    }
}
